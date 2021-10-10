using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRover
{
    public class ExcessiveCommandsException : Exception
    {
        public ExcessiveCommandsException() { }

        public ExcessiveCommandsException(int noOfCommands)
            : base(String.Format("Rover can perform utmost 5 commands at a time. Given number of commands - {0}", noOfCommands))
        {

        }
    }
}
