﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rftg
{
    interface Ownable
    {
        void AddTo(Player newOwner);
    }
}