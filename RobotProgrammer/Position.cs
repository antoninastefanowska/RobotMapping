
namespace RobotProgrammer
{
    public class Position
    {
        public enum NeighbourType
        {
            Top,
            Right,
            Bottom,
            Left,
            None
        };

        public int X { get; set; }
        public int Y { get; set; }

        public Position(int x, int y)
        {
            X = x;
            Y = y;
        }

        public NeighbourType GetNeighbourType(Position position, Compass compass)
        {
            if (position.Y == Y - 1 && position.X == X)
            {
                switch (compass.Orientation)
                {
                    case Compass.OrientationType.North:
                        return NeighbourType.Top;
                    case Compass.OrientationType.East:
                        return NeighbourType.Left;
                    case Compass.OrientationType.South:
                        return NeighbourType.Bottom;
                    case Compass.OrientationType.West:
                        return NeighbourType.Right;
                }
            }
            else if (position.Y == Y + 1 && position.X == X)
            {
                switch (compass.Orientation)
                {
                    case Compass.OrientationType.North:
                        return NeighbourType.Bottom;
                    case Compass.OrientationType.East:
                        return NeighbourType.Right;
                    case Compass.OrientationType.South:
                        return NeighbourType.Top;
                    case Compass.OrientationType.West:
                        return NeighbourType.Left;
                }
            }
            else if (position.Y == Y && position.X == X - 1)
            {
                switch (compass.Orientation)
                {
                    case Compass.OrientationType.North:
                        return NeighbourType.Left;
                    case Compass.OrientationType.East:
                        return NeighbourType.Bottom;
                    case Compass.OrientationType.South:
                        return NeighbourType.Right;
                    case Compass.OrientationType.West:
                        return NeighbourType.Top;
                }
            }
            else if (position.Y == Y && position.X == X + 1)
            {
                switch (compass.Orientation)
                {
                    case Compass.OrientationType.North:
                        return NeighbourType.Right;
                    case Compass.OrientationType.East:
                        return NeighbourType.Top;
                    case Compass.OrientationType.South:
                        return NeighbourType.Left;
                    case Compass.OrientationType.West:
                        return NeighbourType.Bottom;
                }
            }
            return NeighbourType.None;
        }

        public NeighbourType GetNeighbourType(Position position)
        {
            if (position.Y == Y - 1 && position.X == X)
                return NeighbourType.Top;
            else if (position.Y == Y + 1 && position.X == X)
                return NeighbourType.Bottom;
            else if (position.Y == Y && position.X == X - 1)
                return NeighbourType.Left;
            else if (position.Y == Y && position.X == X + 1)
                return NeighbourType.Right;
            else
                return NeighbourType.None;
        }

        public override string ToString()
        {
            return X.ToString() + ", " + Y.ToString();
        }
    }
}
