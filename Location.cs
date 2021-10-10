using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRover
{
    public class Location
    {
        public Point point = new Point();
        public Compass compass = Compass.SOUTH;

        public override string ToString()
        {
            return point.ToString() + " " + compass.ToString();
        }
    }
}
