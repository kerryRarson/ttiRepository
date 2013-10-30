using System;
using System.Collections.Generic;
using System.Linq;
using TTI.DAL;

namespace TTI.Demo.Presenter
{
    public class DemoPresenter
    {
        protected readonly IDemoView _view;
        protected readonly DAL.Repository.IEntityRepository _entityRepository;
        /*
        * pass in the view on the construct & instansiate the db repository instance.
        */
        public DemoPresenter(IDemoView view)
        {
            _view = view;
            _entityRepository = new DAL.Repository.NHibernate.EntityRepository();
        }

        public void LoadStates()
        {
            _view.UpdateStatus("in the presenter::Loading States...");
            
            // get the list of states from the repository
            var states = _entityRepository.GetStateList();
            //pass the results back to the caller
            _view.BindStates(states);
            //_view.UpdateStatus(string.Format("presenter bound {0} states to the calling view.", states.Count));

        }
    }
}
