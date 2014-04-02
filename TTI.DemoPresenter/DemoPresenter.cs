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
            _entityRepository = new DAL.Repository.nHibernate.EntityRepository();
        }

        public void LoadStates()
        {

            //test an error
            //throw new Exception("Something bad happened in the presenter.");

            _view.UpdateStatus("in the presenter::Loading States...");
            
            // get the list of states from the repository
            System.Threading.Thread.Sleep(10000);
            var states = _entityRepository.GetStateList();
            //pass the results back to the caller
            _view.BindStates(states);

        }

        public void LoadClubs()
        {
            var dpi = new DAL.Repository.nHibernate.CurBioRepository();
            var clubs = dpi.GetClubs();
            //_view.BindStates(clubs);
        }
    }
}
