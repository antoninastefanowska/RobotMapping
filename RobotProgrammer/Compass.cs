
namespace RobotProgrammer
{
    public class Compass
    {
        public enum OrientationType
        {
            North,
            East,
            West,
            South
        }

        public OrientationType Orientation { get; set; }

        public Compass()
        {
            Orientation = OrientationType.North;
        }

        public Compass(OrientationType orientationType)
        {
            Orientation = orientationType;
        }

        public void TurnRight()
        {
            switch (Orientation)
            {
                case OrientationType.North:
                    Orientation = OrientationType.East;
                    break;
                case OrientationType.West:
                    Orientation = OrientationType.North;
                    break;
                case OrientationType.South:
                    Orientation = OrientationType.West;
                    break;
                case OrientationType.East:
                    Orientation = OrientationType.South;
                    break;
            }
        }

        public void TurnLeft()
        {
            switch (Orientation)
            {
                case OrientationType.North:
                    Orientation = OrientationType.West;
                    break;
                case OrientationType.West:
                    Orientation = OrientationType.South;
                    break;
                case OrientationType.South:
                    Orientation = OrientationType.East;
                    break;
                case OrientationType.East:
                    Orientation = OrientationType.North;
                    break;
            }
        }

        public override string ToString()
        {
            switch (Orientation)
            {
                case OrientationType.North:
                    return "North";
                case OrientationType.West:
                    return "West";
                case OrientationType.East:
                    return "East";
                case OrientationType.South:
                    return "South";
            }
            return null;
        }
    }
}
