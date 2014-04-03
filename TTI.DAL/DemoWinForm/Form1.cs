using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
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
                UpdateStatus("An error occured! Thread did not complete.");
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
    }
}
