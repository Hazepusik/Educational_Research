
namespace Multicriteria
{
    public class Criterion
    {
        public string name;
        public double value;

        public Criterion()
        {
            name = "Unknown";
            value = 0;
        }

        public Criterion(string nm, double vl)
        {
            name = nm;
            value = vl;
        }

    }
}
