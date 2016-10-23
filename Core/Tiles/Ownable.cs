using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rftg.Tiles
{
    interface Ownable
    {
        int Cost { get; }
        void AddTo(Player newOwner);
    }
}
