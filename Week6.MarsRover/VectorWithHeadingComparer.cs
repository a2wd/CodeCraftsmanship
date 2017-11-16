namespace Week6.MarsRover
{
    using System.Collections.Generic;

    public class VectorWithHeadingComparer : IComparer<VectorWithHeading>
    {
        public int Compare(VectorWithHeading x, VectorWithHeading y)
        {
            if (x == null)
            {
                return -1;
            }

            if (y == null)
            {
                return 1;
            }

            if (x.GetXPosition() < y.GetXPosition() ||
                x.GetYPosition() < y.GetYPosition() ||
                x.GetHeading() < y.GetHeading())
            {
                return -1;
            }

            if (x.GetXPosition() > y.GetXPosition() ||
                x.GetYPosition() > y.GetYPosition() ||
                x.GetHeading() > y.GetHeading())
            {
                return 1;
            }

            return 0;
        }
    }
}
