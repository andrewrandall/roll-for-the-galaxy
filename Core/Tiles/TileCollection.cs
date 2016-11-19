using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rftg.Tiles
{
    public class TileCollection : IEnumerable<Ownable>
    {
        private List<Ownable> _tiles = new List<Ownable>();

        internal void Add(Ownable tile)
        {
            _tiles.Add(tile);
        }

        internal IEnumerable<TPowerType> GetPowers<TPowerType>() =>
            _tiles
                .Where(t => t is TPowerType)
                .Cast<TPowerType>();

        public IEnumerator<Ownable> GetEnumerator() => _tiles.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        internal Ownable Pop()
        {
            var tile = Peek();
            _tiles.RemoveAt(0);
            return tile;
            // todo test
        }

        internal Ownable Peek()
        {
            return _tiles[0];
            // todo test
        }
    }
}