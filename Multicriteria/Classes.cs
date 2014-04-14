using System;
using System.Collections.Generic;
namespace Multicriteria
{
    public class Model
    {
        private static int modelID = 0;
        public int id;
        public string name;
        public int dominatedStatus = 0; // 0 - not domin, -1 - domin, n - eq with
        private static bool isDominated = false;
        public static bool IsDominated
        {
            get { return isDominated; }
            set { isDominated = value; }
        }
        public Model()
        {
            id = ++modelID;
            name = "Unknown " + modelID.ToString();
            dominatedStatus = 0;
        }
        public Model(string nm)
        {
            id = ++modelID;
            dominatedStatus = 0;
            name = nm;
        }
        public static void ResetModel()
        {
            modelID = 0;
            isDominated = false;
        }
    }

    public class Criterion
    {
        private static int criterionID = 0;
        
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
    public class Data
    {
        public static List<Model> models;
        public static List<Criterion> criteria;
        public static double[][] table;
        public static double[][] tablePareto;
    }

    public class Electre
    {
        public static double Y;
        public static double Q;
    }
}
