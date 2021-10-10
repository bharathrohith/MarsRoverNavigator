using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRover
{
    public class Command
    {
        public int distance = 0;
        public Direction direction = Direction.NONE;

        public Command(int distance)
        {
            this.distance = distance;
        }

        public Command(string direction)
        {
            switch (direction)
            {
                case "Left": this.direction = Direction.LEFT; break;
                case "Right": this.direction = Direction.RIGHT; break;
                case "Forward": this.direction = Direction.UP; break;
                case "Backward": this.direction = Direction.DOWN; break;
                default: direction = null; break;
            }
        }
    }
}
