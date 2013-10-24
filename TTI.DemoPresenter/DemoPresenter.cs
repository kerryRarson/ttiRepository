using System;
using System.Collections.Generic;
using System.Linq;
using TTI.DAL;

namespace TTI.Demo
{
    public class DemoPresenter
    {
        protected readonly IDemoView _view;
        protected readonly DAL.Repository.IEntityRepository _entityRepository;
        public DemoPresenter(IDemoView view)
        {
            _view = view;
            _entityRepository = new DAL.Repository.NHibernate.EntityRepository();
        }

        public void LoadStates(){

            _view.UpdateStatus("in the presenter::Loading States...");

            var states = _entityRepository.GetStateList();
            _view.BindStates(states);
            _view.UpdateStatus(string.Format("presenter bound {0} states to the calling view.", states.Count));

        }
    }
}
