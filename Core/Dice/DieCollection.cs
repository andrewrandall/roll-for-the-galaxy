using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rftg.Dice
{
    public class DieCollection : IEnumerable<object>
    {
        private List<object> dice = new List<object>();

        public IEnumerator<object> GetEnumerator() => dice.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => dice.GetEnumerator();

        internal void Add(object die)
        {
            dice.Add(die);
        }

        internal void Remove(object die)
        {
            dice.Remove(die);
        }

        internal void AddRange(DieCollection developers)
        {
            dice.AddRange(developers);
        }

        internal void Clear()
        {
            dice.Clear();
        }
    }
}
