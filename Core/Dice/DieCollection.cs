using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rftg.Dice
{
    class DieCollection : IEnumerable<object>
    {
        private Collection<object> dice = new Collection<object>();

        public IEnumerator<object> GetEnumerator() => dice.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => dice.GetEnumerator();

        public void Add(object die)
        {
            dice.Add(die);
        }

        internal void Remove(object die)
        {
            dice.Remove(die);
        }
    }
}
