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
            int x = robot.CurrentPosition.X - 2;
            int y = robot.CurrentPosition.Y - 5;
            bool output;

            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    output = map.ObstacleMatrix[j + y, i + x] && SensorMask[j, i];
                    if (output)
                        return true;
                }
            }
            return false;
        }

        public List<Position> GetSensorPositions()
        {
            int x = robot.CurrentPosition.X - 2;
            int y = robot.CurrentPosition.Y - 5;
            List<Position> positions = new List<Position>();

            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                    positions.Add(new Position(x + i, y + j));
            }
            return positions;
        }
    }
}
