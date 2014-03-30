
namespace Multicriteria
{
    public class Model
    {
        public int id;
        public string name;
        public Model()
        {
            id = -1;
            name = "Unknown";
        }
        public Model(int new_id, string nm)
        {
            id = new_id;
            name = nm;
        }
    }

    public class Criterion :Model
    {

        public double value;
        

        public Criterion()
        {
            name = "Unknown";
            value = 0;
        }

        public Criterion(int new_id, string nm, double vl)
        {
            id = new_id;
            name = nm;
            value = vl;
        }

    }
}
