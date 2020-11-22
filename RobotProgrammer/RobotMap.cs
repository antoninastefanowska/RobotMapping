using NCalc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotProgrammer
{
    public class RobotMap
    {
        public int Height { get; }
        public int Width { get; }

        public int[,] Map { get; private set; }

        public RobotMap(int width, int height)
        {
            Height = height;
            Width = width;
            Map = new int[Height, Width];
        }

        public void Update(Position robotPosition, int sensorRadius, int sensorWidth)
        {
            int startX = robotPosition.X - sensorWidth / 2;
            int endX = robotPosition.X + sensorWidth / 2;
            int y = robotPosition.Y + sensorRadius;
            for (int i = startX; i < endX; i++)
            {

            }
        }
    }
}
