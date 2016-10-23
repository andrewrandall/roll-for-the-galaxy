using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rftg.Phases
{
    public interface Phase
    {
        event EventHandler<EventArgs> Ending;
    }
}