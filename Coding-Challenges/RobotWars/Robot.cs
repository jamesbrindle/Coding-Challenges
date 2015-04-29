using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace RobotWars
{
    /// <summary>
    /// Robot object
    /// </summary>
    public class Robot
    {
        /// <summary>
        /// Can only construct a robot by setting inital position, the robot number and current facing direction
        /// </summary>
        /// <param name="robotNumber">An index plus 1 typically in a robot list and is auto assigned</param>
        /// <param name="x">Initial X coordinates on the arena</param>
        /// <param name="y">Initial Y coordinates on the arena</param>
        /// <param name="direction">1 of 4 compas facing points. N = north, E = east, S = south, W = west</param>
        public Robot(int robotNumber, int x, int y, char direction)
        {
            this.RobotNumber = robotNumber;
            this.Coordinates = new Point(x, y);
            this.Direction = direction;
            this.Destroyed = false;
        }

        /// <summary>
        /// Gets the robots current position and facing direction... Generated as a string to display to the user
        /// </summary>
        /// <returns>A string message of the current position and facing direction</returns>
        public string GetRobotCoordinatesAndHeading()
        {
            return (string.Format("New position of robot {0}: {1} {2} {3}", RobotNumber.ToString(), 
                Coordinates.X.ToString(), Coordinates.Y.ToString(), Direction));
        }

        #region Properties

        public Int32 RobotNumber { get; set; }
        public Point Coordinates { get; set; }
        public Char Direction { get; set; }
        public Boolean Destroyed { get; set; }

        #endregion
    }
}
