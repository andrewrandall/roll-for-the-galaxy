using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rftg.Tiles
{
    class TileCollection
    {
        private List<Ownable> _tiles = new List<Ownable>();

        public void Add(Ownable tile)
        {
            _tiles.Add(tile);
        }

        public IEnumerable<TPowerType> GetPowers<TPowerType>() =>
            _tiles
                .Where(t => t is TPowerType)
                .Cast<TPowerType>();
    }
}