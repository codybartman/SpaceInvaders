using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders
{
    class RowColOffset
    {
        int colOffset;
        int rowOffset;
        public RowColOffset(int colIn, int rowIn)
        {
            colOffset = colIn;
            rowOffset = rowIn;
        }
        public int GetRow()
        {
            return rowOffset;
        }
        public int GetCol()
        {
            return colOffset;
        }
    }
}
