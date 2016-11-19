using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rftg.Tiles
{
    class MockDevelopment : Development
    {
        public Guid Id { get; } = Guid.NewGuid();

        public int Cost { get; set; }
    }
}
