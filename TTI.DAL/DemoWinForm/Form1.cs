using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using TTI.Demo.Presenter;

namespace DemoWinForm
{
    public partial class Form1 : Form , IDemoView
    {
        private DemoPresenter _presenter;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //create the presenter & pass it a reference to ourselves. ( this form inherits the IDemoView interface )
            try { _presenter = new DemoPresenter(this); }
            catch (Exception err)
            {
                System.Diagnostics.Debug.WriteLine(err.ToString());
                this.Text = "Could not instantiate presenter object.";
                this.cboStates.Enabled = false;
                this.btnLoadStates.Enabled = false;
                this.btnLoadStatesAsync.Enabled = false;
                //this.button1.Enabled = false;
            }
            
        }

        public void UpdateStatus(string statusText)
        {
            //Check to see if the call came from a different thread
            if (statusStrip1.InvokeRequired)
            {
                statusStrip1.BeginInvoke(
                    new Action(() =>{
                        lblStatus.Text = statusText;
                        })
                    );
            }
            else 
                lblStatus.Text = statusText;
        }

        public void BindStates(IList<TTI.DAL.Model.State> states)
        {
            UnlockUI();
            if (cboStates.InvokeRequired) {
                cboStates.BeginInvoke(new Action(() => {
                    cboStates.DataSource = states;
                }));
            }
            else { cboStates.DataSource = states; }
            
            UpdateStatus(string.Format("{0} states loaded.", states.Count));
        }

        private void btnLoadStates_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            LockUI();
            _presenter.LoadStates();
            Cursor = Cursors.Default;
        }
        private void LockUI()
        {
            btnLoadStates.Enabled = false;
            btnLoadStatesAsync.Enabled = false;
            cboStates.Enabled = false;
        }
        private void UnlockUI()
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new Action(() =>
                {
                    btnLoadStates.Enabled = true;
                    btnLoadStatesAsync.Enabled = true;
                    cboStates.Enabled = true;
                })
                );
            }
            else
            {
                btnLoadStates.Enabled = true;
                btnLoadStatesAsync.Enabled = true;
                cboStates.Enabled = true;
            }
        }

        private void btnLoadStatesAsync_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.AppStarting;
            UpdateStatus("Loading...");
            LockUI();
            LoadStatesAsync();
        }
        private async void LoadStatesAsync(){
            try
            {
                await Task.Run(() =>
                {
                    _presenter.LoadStates();
                    UnlockUI();
                });
                Cursor = Cursors.Default;
            }
            catch (Exception err)
            {
                Cursor = Cursors.Default;
                UnlockUI();
                UpdateStatus("An error occurred! Thread did not complete.");
                MessageBox.Show(err.ToString());
              
            }
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.AppStarting;
            UpdateStatus("running...");
            cboStates.Items.Clear();

            System.Diagnostics.Debug.WriteLine(string.Format("ThreadId [{0}]", System.Threading.Thread.CurrentThread.ManagedThreadId));
            var states = await Task<List<string>>.Run( () => { return longRunningFunction(); });
            
            cboStates.DataSource = states;
            UpdateStatus(string.Format("{0} loaded.", states.Count));
            Cursor = Cursors.Default;
        }
        private IList<string> longRunningFunction()
        {
            System.Diagnostics.Debug.WriteLine(string.Format("ThreadId [{0}]", System.Threading.Thread.CurrentThread.ManagedThreadId));
            System.Threading.Thread.Sleep(10000);
            var rtn = _presenter.LoadClubs();
            return rtn;
        }

        private IList<TTI.DAL.Model.CurBio> getPlayersFor(string org)
        {
            var players = _presenter.GetPlayersByClub(org);
            return players;
        }
        private async void cboStates_SelectedIndexChanged(object sender, EventArgs e)
        {
            //load the players for the selected org
            Cursor = Cursors.WaitCursor;
            string state = cboStates.SelectedValue.ToString();
            //just get some random clubs...
            string club = string.Empty;
            if (state.Equals("AK")) club = "COL";
            if (state.Equals("MT")) club = "CHC";
            UpdateStatus(string.Format("Getting players for {0}...", club));
            var players = await Task<List<TTI.DAL.Model.CurBio>>.Run(() => { return getPlayersFor(club); });

            //lstPlayers.ValueMember = "PlayerId";
            //lstPlayers.DisplayMember = "Name";
            //lstPlayers.DataSource = players;
            ////lstPlayers.Refresh();
            lstPlayers.Items.Clear();
            foreach (var player in players)
            {
                lstPlayers.Items.Add( player.Name + " " + player.JerseyNumber);
            }
            UpdateStatus(string.Format("{0} players.", players.Count));
            Cursor = Cursors.Default;
        }

        private async void btnDownload_Click(object sender, EventArgs e)
        {
            const string CONN_STRING = @"Data Source=(local);Initial Catalog=DataPro;Trusted_Connection=true;Connect Timeout=60";
            //IEnumerable<string> uris = new string[] { "http://mlb.com/lookup/named.cur_bio.bam", "http://mlb.com/lookup/named.cur_hitting.bam", "http://mlb.com/lookup/named.cur_hitting.bam?season=%272013%27", "http://mlb.com/lookup/named.cur_pitching.bam", "http://mlb.com/lookup/named.cur_fielding.bam" };
            List<MLBAMFeed> feeds = new List<MLBAMFeed>();
            feeds.Add(new MLBAMFeed() { Url = "http://mlb.com/lookup/named.cur_hitting.bam?season=%272013%27", FileName = "cur_hitting_2013.xml", DestinationTable="temp.curbat_v2" });
            feeds.Add(new MLBAMFeed() { Url = "http://mlb.com/lookup/named.cur_hitting.bam", FileName = "cur_hitting.xml", DestinationTable = "temp.curbat_v2" });

            System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();
            
            //build the collection of threaded tasks
            List<Task> tasks = new List<Task>();
            foreach (var xmlFeed in feeds)
            {
                tasks.Add(downloadFile(xmlFeed));
            }
            UpdateStatus(string.Format("downloading {0} files.", feeds.Count()));
            Cursor = Cursors.AppStarting;
            sw.Start();

            //kick them all off & wait until they've all completed.
            await Task.WhenAll(tasks.ToArray());

            sw.Stop();
            Cursor = Cursors.Default;
            UpdateStatus(string.Format("Completed in {0} seconds.", sw.Elapsed));
            this.Refresh();

            Cursor = Cursors.WaitCursor;
            //initialize the db tables
            using (System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection(CONN_STRING))
            {
                conn.Open();
                using (System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand("truncate table temp.curBio_v2;", conn))
                {
                    cmd.ExecuteNonQuery();
                }
                conn.Close();
            }

            //write them all to disk
            //clean up any previous .xml files
            DirectoryInfo di = new DirectoryInfo(Directory.GetCurrentDirectory());
            FileInfo[] files = di.GetFiles("*.xml")
                     .Where(p => p.Extension == ".xml").ToArray();
            foreach (FileInfo file in files)
            {
                file.Attributes = FileAttributes.Normal;
                File.Delete(file.FullName);
            }
                
                
            // save the Task results to disk as .xml files
            foreach (Task<MLBAMFeed> result in tasks)
            {
                MLBAMFeed xmlResult = result.Result;
                System.Xml.XmlDocument xmlDoc = new System.Xml.XmlDocument();
                xmlDoc.LoadXml(xmlResult.XML);
                string fileName = xmlResult.FileName; //string.Format("{0}.xml", xmlDoc.DocumentElement.Name);
                //append to the .xml if it exists
                using (StreamWriter writer = new StreamWriter(fileName, true))
                {
                    writer.Write(xmlResult.XML);
                }

                //Load it into a dataset so we can bcp it
                var ds = new DataSet();
                ds.ReadXml(fileName);
                lstPlayers.Items.Add(string.Format("{0} tables in {1} dataset...", ds.Tables.Count, fileName));
                lstPlayers.Items.Add(string.Format("{0} rows.", ds.Tables[1].Rows.Count));

                if (fileName.ToLower().Equals("cur_bio.xml"))
                {
                    using (System.Data.SqlClient.SqlBulkCopy sbc = new System.Data.SqlClient.SqlBulkCopy(CONN_STRING))
                    {
                        sbc.DestinationTableName="temp.curBio_v2";
                        sbc.BatchSize = 1000;
                        sbc.BulkCopyTimeout = 300;
                        //map the xml attribute to the db column
                        foreach (System.Data.DataColumn col in ds.Tables[1].Columns)
                        {
                            //don't include the ado queryResults node
                            if (col.ColumnName.ToLower() != "queryresults_id")
                            {
                                System.Diagnostics.Debug.WriteLine(col.ColumnName);
                                sbc.ColumnMappings.Add(col.ColumnName, col.ColumnName);
                            }
                        }
                        
                        sw.Reset();
                        sw.Start();
                        //push it up to the server
                        sbc.WriteToServer(ds.Tables[1]);
                        sw.Stop();
                        lstPlayers.Items.Add(string.Format("{0} rows inserted in {1} seconds.", ds.Tables[1].Rows.Count, sw.Elapsed));
                    }   
                }
            }
            Cursor = Cursors.Default;
        }
        /// <summary>
        /// uses WebClient to return a Task object that will be used to download the passed in url
        /// </summary>
        /// <param name="url">The URL of the file to download</param>
        /// <returns>a Task object that returns a string</returns>
        static async Task<MLBAMFeed> downloadFile(MLBAMFeed xmlFeed)
        {
            var rtn = xmlFeed;
            string xml = await new WebClient().DownloadStringTaskAsync(new Uri(xmlFeed.Url));
            rtn.XML = xml;
            return rtn;
        }
    }
}
