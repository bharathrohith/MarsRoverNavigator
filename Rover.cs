using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRover
{
    public class Rover
    {
        int roverRange = 100;
        public Rover()
        { }

        private Location currentRoverLocation = new Location();

        public Location getRoverLocation()
        {
            return currentRoverLocation;
        }

        public Location move(Command[] commands)
        {
            if (commands.Length > 5)
            {
                throw new ExcessiveCommandsException(commands.Length);
            }

            foreach (Command c in commands)
            {
                // distance
                if (c.direction == Direction.NONE)
                {
                    currentRoverLocation = move(c.distance);
                }
                // direction change
                else if (c.distance == 0)
                {
                    currentRoverLocation = move(c.direction);
                }
            }
            return currentRoverLocation;
        }

        public Location move(Direction targetDir)
        {
            currentRoverLocation.compass = getCompassAfterDirectionChange(currentRoverLocation.compass, targetDir);
            return currentRoverLocation;
        }

        public Location move(int meters)
        {
            Point targetPoint = getTargetPoint(meters, currentRoverLocation);
            if (canMove(targetPoint))
            {
                currentRoverLocation.point = targetPoint;
            }
            else
            {
                throw new LocationOutOfBoundsException(targetPoint);
            }
            return currentRoverLocation;
        }

        private bool canMove(Point targetPoint)
        {
            if (targetPoint.IsInBounds(roverRange))
            {
                return true;
            }
            return false;
        }

        private Compass getCompassDirection(Direction currentDirection, Direction targetDirection)
        {
            return Compass.NORTH;
        }

        private Point getTargetPoint(int meters, Location roverLocation)
        {
            int boxNumber = roverLocation.point.boxNumber;
            switch (roverLocation.compass)
            {
                case Compass.NORTH: boxNumber -= (roverRange * meters); break;
                case Compass.SOUTH: boxNumber += (roverRange * meters); break;
                case Compass.EAST: boxNumber += (meters); break;
                case Compass.WEST: boxNumber -= (meters); break;
                default: boxNumber = 0; break;
            }

            return new Point(boxNumber);
        }

        private Compass getCompassAfterDirectionChange(Compass currentCompass, Direction directionToTurn)
        {
            //Directions in the order of LEFT, UP, RIGHT, DOWN
            Compass[,] correspondingDirections = new Compass[4, 4]
            {
            {Compass.WEST, Compass.NORTH, Compass.EAST, Compass.SOUTH}, //NORTH
            {Compass.EAST, Compass.SOUTH, Compass.WEST, Compass.NORTH}, //SOUTH
            {Compass.NORTH, Compass.EAST, Compass.SOUTH, Compass.WEST}, //EAST
            {Compass.SOUTH, Compass.WEST, Compass.NORTH, Compass.EAST}, //WEST
            };
            int index = 0;
            switch (directionToTurn)
            {
                case Direction.LEFT: index = 0; break;
                case Direction.UP: index = 1; break;
                case Direction.RIGHT: index = 2; break;
                case Direction.DOWN: index = 3; break;
            }

            switch (currentCompass)
            {
                case Compass.NORTH: return correspondingDirections[0, index];
                case Compass.SOUTH: return correspondingDirections[1, index];
                case Compass.EAST: return correspondingDirections[2, index];
                case Compass.WEST: return correspondingDirections[3, index];
            }
            return Compass.SOUTH;
        }
    }
}
