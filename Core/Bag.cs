using Rftg.Tiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Rftg
{
    public class Bag: IEnumerable<Ownable>
    {
        Random rng;
        List<Ownable> tiles;

        public Bag(IEnumerable<Ownable> tiles)
        {
            rng = new Random();
            this.tiles = tiles.ToList();
        }

        public IEnumerable<Ownable> DrawRandom(int num)
        {
            for (int i = 0; i < num; i++)
            {
                var tile = tiles[rng.Next(tiles.Count)];
                tiles.Remove(tile);
                yield return tile;
            }
        }

        public IEnumerator<Ownable> GetEnumerator()
        {
            return tiles.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return tiles.GetEnumerator();
        }
    }
}
