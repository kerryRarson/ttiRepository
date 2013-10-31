using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TTI.DAL;
using TTI.Demo.Presenter;

namespace TTI.DAL.Tests
{
    [TestClass]
    public class DemoPresenterTests
    {
        private MockDemoView _view = new MockDemoView();
        [TestMethod]
        public void TestLoadStates()
        {
            //instansiate the presenter.
            var presenter = new DemoPresenter(_view);
            
            //tell the presenter to get the states
            presenter.LoadStates();
        }

        #region Mock View
        /*
        * This is a mock class representing either a windows form or a webform.
        */
        private class MockDemoView : IDemoView
        {
            public void UpdateStatus(string statusText)
            {
                Console.WriteLine(statusText);
            }

            public void BindStates(System.Collections.Generic.IList<Model.State> states)
            {
                Assert.IsNotNull(states);
                Console.WriteLine(string.Format("{0} states passed to the view's BindStates method", states.Count));
            }
        }
        #endregion
    }

}
