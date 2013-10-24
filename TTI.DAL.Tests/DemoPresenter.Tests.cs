using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TTI.DAL;
using TTI.Demo;

namespace TTI.DAL.Tests
{
    [TestClass]
    public class DemoPresenterTests
    {
        private MockDemoView _view = new MockDemoView();
        [TestMethod]
        public void TestLoadStates()
        {
            var presenter = new DemoPresenter(_view);
            presenter.LoadStates();
        }

        #region Mock View
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
