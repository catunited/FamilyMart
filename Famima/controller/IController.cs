using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Famima.controller
{
    public interface IController
    {
        void Check(List<item> items);
        void LoadView();
    }
}
