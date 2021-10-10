using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRover
{
    class Program
    {
        public static void Main(string[] args)
        {
            Rover rover = new Rover();
            Command c1 = new Command(50);
            Command c2 = new Command("Left");
            Command c3 = new Command(23);
            Command c4 = new Command("Left");
            Command c5 = new Command(4);
            //Command c6 = new Command(4);
            try
            {
                Command[] commands = new Command[] { c1, c2, c3, c4, c5 };
                Console.WriteLine(rover.move(commands));
            }
            catch (LocationOutOfBoundsException locEx)
            {
                Console.WriteLine(locEx.Message);
            }
            catch (ExcessiveCommandsException exCmdEx)
            {
                Console.WriteLine(exCmdEx.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                Console.ReadKey();
            }
        }
    }
    public enum Direction
    {
        UP,
        DOWN,
        LEFT,
        RIGHT,
        NONE
    }

    public enum Compass
    {
        NORTH,
        SOUTH,
        EAST,
        WEST
    }
}
