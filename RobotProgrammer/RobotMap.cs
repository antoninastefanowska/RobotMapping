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

        public void Update(Position robotPosition, Position sensorPosition)
        {
            for (int i = robotPosition.Y - 1; i > sensorPosition.Y; i--)
                if (Map[i, sensorPosition.X] > 0)
                    Map[i, sensorPosition.X]--;
            Map[sensorPosition.Y, sensorPosition.X] += 3;
        }

        public void Print()
        {
            for (int i = 0; i < Height; i++)
            {
                for (int j = 0; j < Width; j++)
                    Console.Write("{0} ", Map[i, j]);
                Console.WriteLine();
            }
        }
    }
}
