using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TTI.Demo;

namespace DemoWebForm
{
    public partial class _Default : Page, IDemoView
    {
        private DemoPresenter _presenter;
        protected void Page_Load(object sender, EventArgs e)
        {
            _presenter = new DemoPresenter(this);
        }

        public void UpdateStatus(string statusText)
        {
            //this is really meant for a windows client, so just write the msg to the degub window
            System.Diagnostics.Debug.WriteLine(statusText);
        }

        //** NOTE: in the real world the TTI.DAL.Models would be in their own .dll This would keep any data access dependencies out of the UI **
        public void BindStates(IList<TTI.DAL.Model.State> states)
        {
            //this method is called from the presenter after the states are pulled from the DB.
            cboStates.DataTextField = "Name";
            cboStates.DataSource = states;
            cboStates.DataBind();
        }

        protected void btnLoad_Click(object sender, EventArgs e)
        {
            //tell the presenter to get the states
            _presenter.LoadStates();
        }
    }
}
