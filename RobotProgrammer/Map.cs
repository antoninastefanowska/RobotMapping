using System.Collections.Generic;
using System.Linq;

namespace RobotProgrammer
{
    public class Map
    {
        public int Height { get; }
        public int Width { get; }
        public List<Position> PositionList { get; private set; }
        public List<Position> ObstacleList { get; private set; }
        public Compass StartCompass { get; private set; }

        public bool[,] ObstacleMatrix { get; private set; }

        public Map(int height, int width)
        {
            Height = height;
            Width = width;
            PositionList = new List<Position>();
            ObstacleList = new List<Position>();
            ObstacleMatrix = new bool[Height, Width];
        }

        public bool AddPosition(int x, int y)
        {
            Position position = new Position(x, y);
            return AddPosition(position);
        }

        public bool AddPosition(Position position)
        {
            if (PositionList.Count == 0 || PositionList.Last().GetNeighbourType(position) != Position.NeighbourType.None)
            {
                PositionList.Add(position);
                return true;
            }
            return false;
        }

        public bool AddObstacle(int x, int y)
        {
            Position position = new Position(x, y);
            return AddObstacle(position);
        }

        public bool AddObstacle(Position position)
        {
            ObstacleList.Add(position);
            ObstacleMatrix[position.Y, position.X] = true;
            return true;
        }

        public bool RemoveObstacle(int x, int y)
        {
            foreach (Position position in ObstacleList)
            {
                if (position.X == x && position.Y == y)
                {
                    ObstacleList.Remove(position);
                    return true;
                }
            }
            return false;
        }

        public void Clear()
        {
            PositionList.Clear();
        }

        public bool RemovePosition(int x, int y)
        {
            Position last = PositionList.Last();
            if (last.X == x && last.Y == y)
            {
                PositionList.Remove(last);
                return true;
            }
            return false;
        }

        public bool IsPath(int x, int y)
        {
            return PositionList.Exists(pos => pos.X == x && pos.Y == y);
        }

        public bool IsObstacle(int x, int y)
        {
            return ObstacleMatrix[y, x];
        }

        public Program GenerateProgram()
        {
            Program program = new Program();
            if (PositionList.Count <= 1)
                return program;

            Position current = PositionList[0], next = PositionList[1];
            Compass compass = new Compass();
            Position.NeighbourType neighbourType = current.GetNeighbourType(next);

            switch (neighbourType)
            {
                case Position.NeighbourType.Top:
                    compass.Orientation = Compass.OrientationType.North;
                    break;
                case Position.NeighbourType.Right:
                    compass.Orientation = Compass.OrientationType.East;
                    break;
                case Position.NeighbourType.Bottom:
                    compass.Orientation = Compass.OrientationType.South;
                    break;
                case Position.NeighbourType.Left:
                    compass.Orientation = Compass.OrientationType.West;
                    break;
            }

            StartCompass = new Compass(compass.Orientation);
            
            for (int i = 1; i < PositionList.Count; i++)
            {
                next = PositionList[i];
                neighbourType = current.GetNeighbourType(next, compass);

                switch (neighbourType)
                {
                    case Position.NeighbourType.Top:
                        program.AddInstruction(Instruction.Type.ReadSensor);
                        program.AddInstruction(Instruction.Type.Forward);
                        break;
                    case Position.NeighbourType.Right:
                        program.AddInstruction(Instruction.Type.TurnRight);
                        compass.TurnRight();
                        program.AddInstruction(Instruction.Type.Forward);
                        break;
                    case Position.NeighbourType.Left:
                        program.AddInstruction(Instruction.Type.TurnLeft);
                        compass.TurnLeft();
                        program.AddInstruction(Instruction.Type.Forward);
                        break;
                }
                current = next;
            }
            return program;
        }
    }
}
