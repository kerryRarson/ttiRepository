using System;
using System.Collections.Generic;
using TTI.DAL;

namespace TTI.Demo.Presenter
{
    /*
    * This is the interface between the presenter and the view
    */
    public interface IDemoView
    {
        void UpdateStatus(string statusText);
        void BindStates(IList<TTI.DAL.Model.State> states);
    }
}
