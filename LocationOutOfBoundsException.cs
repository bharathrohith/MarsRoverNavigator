using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRover
{
    public class LocationOutOfBoundsException : Exception
    {
        public LocationOutOfBoundsException() { }

        public LocationOutOfBoundsException(Point point)
            : base(String.Format("Rover cannot move to the location: {0}", point))
        {

        }
    }
}
