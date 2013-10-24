using System;
using System.Collections.Generic;
using TTI.DAL;

namespace TTI.Demo
{
    public interface IDemoView
    {
        void UpdateStatus(string statusText);
        void BindStates(IList<TTI.DAL.Model.State> states);
    }
}
