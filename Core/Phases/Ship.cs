using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rftg.Phases
{
    class Ship : Phase
    {
        public event EventHandler<EventArgs> Ending;

        protected void OnEnding()
        {
            Ending?.Invoke(this, EventArgs.Empty);
        }
    }
}
