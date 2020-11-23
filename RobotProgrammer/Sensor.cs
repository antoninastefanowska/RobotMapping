using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotProgrammer
{
    public class Sensor
    {
        public bool[,] SensorMask { get; private set; }

        private Robot robot;
        private Map map;

        public Sensor(Robot robot, Map map)
        {
            this.robot = robot;
            this.map = map;
            SensorMask = new bool[,] {
                { true, true, true, true, true },
                { true, true, true, true, true },
                { false, true, true, true, false },
                { false, true, true, true, false },
                { false, false, true, false, false },
            };
        }

        public bool ObstacleDetected()
        {
            int originX = robot.CurrentPosition.X - 2;
            int originY = robot.CurrentPosition.Y - 5;
            bool output;

            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    int y = j + originY, x = i + originX;
                    y = y < 0 ? 0 : y;
                    y = y > map.Height - 1 ? map.Height - 1 : y;
                    x = x < 0 ? 0 : x;
                    x = x > map.Width - 1 ? map.Width - 1 : x;
                    output = map.ObstacleMatrix[y, x] && SensorMask[j, i];
                    if (output)
                        return true;
                }
            }
            return false;
        }

        public List<Position> GetSensorPositions()
        {
            int originX = robot.CurrentPosition.X - 2;
            int originY = robot.CurrentPosition.Y - 5;
            List<Position> positions = new List<Position>();

            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    int y = originY + j, x = originX + i;
                    if (SensorMask[j, i] && y >= 0 && y < map.Height && x >= 0 && x < map.Width)
                        positions.Add(new Position(x, y));
                }
            }
            return positions;
        }

        public Position GetMainPosition()
        {
            int x = robot.CurrentPosition.X;
            int y = robot.CurrentPosition.Y - 4;
            return new Position(x, y);
        }
    }
}
