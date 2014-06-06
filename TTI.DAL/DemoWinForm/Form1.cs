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
            _presenter = new DemoPresenter(this);
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
            cboStates.DataSource = states;
            UnlockUI();
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
            btnLoadStates.Enabled = true;
            btnLoadStatesAsync.Enabled = true;
            cboStates.Enabled = true;
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
                    Cursor = Cursors.Default;
                    UnlockUI();
                });
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
            string club = cboStates.SelectedValue.ToString();
            UpdateStatus(string.Format("Getting players for {0}...", club));
            var players = await Task<List<TTI.DAL.Model.CurBio>>.Run(() => { return getPlayersFor(club); });

            //lstPlayers.ValueMember = "PlayerId";
            //lstPlayers.DisplayMember = "Name";
            //lstPlayers.DataSource = players;
            ////lstPlayers.Refresh();
            lstPlayers.Items.Clear();
            foreach (var player in players)
            {
                lstPlayers.Items.Add( player.Name + " " + player.Pos);
            }
            UpdateStatus(string.Format("{0} players.", players.Count));
            Cursor = Cursors.Default;
        }

        private async void btnDownload_Click(object sender, EventArgs e)
        {
            IEnumerable<string> uris = new string[] { "http://mlb.com/lookup/named.cur_bio.bam", "http://mlb.com/lookup/named.cur_hitting.bam", "http://mlb.com/lookup/named.cur_pitching.bam", "http://mlb.com/lookup/named.cur_hitting.bam", "http://mlb.com/lookup/named.cur_fielding.bam" };
            System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();
            //build the collection of threaded tasks
            List<Task> tasks = new List<Task>();
            foreach (var downloadUri in uris)
            {
                tasks.Add(downloadFile(downloadUri));
            }
            UpdateStatus(string.Format("downloading {0} files.", uris.Count()));
            Cursor = Cursors.AppStarting;
            sw.Start();
            //kick them all off & wait until they've all completed.
            //Task.WaitAll(tasks.ToArray());
            await Task.WhenAll(tasks.ToArray());
            //var xml = new WebClient().DownloadString(new Uri(uris.First()));
            sw.Stop();
            Cursor = Cursors.Default;
            UpdateStatus(string.Format("Completed in {0} seconds.", sw.Elapsed));
            //write them all to disk
            foreach (Task<string> result in tasks)
            {
                var xmlResult = result.Result;
                System.Xml.XmlDocument xmlDoc = new System.Xml.XmlDocument();
                xmlDoc.LoadXml(xmlResult);
                string fileName = string.Format("{0}.xml", xmlDoc.DocumentElement.Name);
                using (StreamWriter writer = new StreamWriter(fileName,false))
                {
                    writer.Write(xmlResult);
                    writer.Flush();
                    writer.Close();
                }
            }
        }
        static async Task<string> downloadFile(string url)
        {
            return await new WebClient().DownloadStringTaskAsync(new Uri(url));
        }
    }
}
