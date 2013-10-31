using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
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
            LockUI();
            _presenter.LoadStates();
        }
        private void LockUI()
        {
            btnLoadStates.Enabled = false;
            btnLoadStatesAsync.Enabled = false;
        }
        private void UnlockUI()
        {
            btnLoadStates.Enabled = true;
            btnLoadStatesAsync.Enabled = true;
        }

        private void btnLoadStatesAsync_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.AppStarting;
            LoadStatesAsync();
        }
        private void LoadStatesAsync(){
            #region create the thread to search on 
            var searchThread = new Thread( new ThreadStart( ()=>
                    {
                        try
                        {
                            Thread.Sleep(5000);
                            _presenter.LoadStates();
                            #region ulock the UI from this thread
                            this.BeginInvoke(
                                new Action(() =>
                                {
                                    Cursor = Cursors.Default;
                                    UnlockUI();
                                })
                                );
                            #endregion
                        }
                        catch (Exception err)
                        {
                            //pass the error to the UI thread
                             this.BeginInvoke(
                                        new Action(() =>
                                        {
                                            Cursor = Cursors.Default;
                                            UnlockUI();
                                            UpdateStatus("An error occured! " + err.ToString());
                                            MessageBox.Show("Thread did not complete!");
                                        }));
                        }
                    })
            );
            #endregion
            
            searchThread.Start();
        }
    }
}
