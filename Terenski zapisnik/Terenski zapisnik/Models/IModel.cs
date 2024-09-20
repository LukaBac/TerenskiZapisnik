using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Terenski_zapisnik.Models
{
    public interface IModel
    {
        bool Output(DionicaModel model);
    }
}
