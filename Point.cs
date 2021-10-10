using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRover
{
    public class Point
    {
        public int boxNumber = 1;

        public Point()
        {

        }

        public Point(int boxNumber)
        {
            this.boxNumber = boxNumber;
        }

        public override string ToString()
        {
            return boxNumber + "";
        }

        public bool IsInBounds(int range)
        {
            if (this.boxNumber > 0 && this.boxNumber <= (range * range))
            {
                return true;
            }
            return false;
        }

    }
}
