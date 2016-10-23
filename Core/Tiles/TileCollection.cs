using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rftg.Tiles
{
    public class TileCollection
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
    }
}