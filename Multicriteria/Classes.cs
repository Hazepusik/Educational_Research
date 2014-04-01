using System;
namespace Multicriteria
{
    public class Model
    {
        private static int modelID = 0;
        public int id;
        public string name;
        public Model()
        {
            id = ++modelID;
            name = "Unknown " + modelID.ToString();
        }
        public Model(string nm)
        {
            id = ++modelID;
            name = nm;
        }
        public static void ResetModel()
        {
            modelID = 0;
        }
    }

    public class Criterion
    {
        private static  int criterionID = 0;
        public int id;
        public string name;
        public int value;
        

        public Criterion()
        {
            id = ++criterionID;
            name = "Unknown "+criterionID.ToString();
            value = 0;
        }

        public Criterion(string nm, double vl)
        {
            id = ++criterionID;
            name = nm;
            vl = (vl > 100) ? 100 : vl;
            vl = (vl < 1) ? 1 : vl;
            value = (int)Math.Round(vl);
        }

        public static void ResetCriterion()
        {
            criterionID = 0;
        }

    }
}
