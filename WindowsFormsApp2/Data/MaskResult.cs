namespace WindowsFormsApp2
{
    public class MaskResult
    {
        public MaskResult(double east_SouthEast, double southEast_South, double south_SouthWest, double southWest_West)
        {
            East_SouthEast = east_SouthEast;
            SouthEast_South = southEast_South;
            South_SouthWest = south_SouthWest;
            SouthWest_West = southWest_West;
        }

        public double East_SouthEast { get; set; } = 0;
        public double SouthEast_South { get; set; } = 0;
        public double South_SouthWest { get; set; } = 0;
        public double SouthWest_West { get; set; } = 0;

    }
}