using System;
using System.Collections.Generic;
using System.Linq;
namespace Multicriteria
{
    public class Model
    {
        private static int modelID = 0;
        public int id;
        public string name;
        public int dominatedStatus = 0; // 0 - not domin, -1 - domin, n - eq with
        private static bool isDominated = false;
        private static bool IsDominated
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

        public static void CheckDominated()
        {
            if (!Model.IsDominated)
            {
                List<int> dominated = new List<int>();
                List<int> equal = new List<int>();
                List<int>[] output = new List<int>[2];
                output = MathLib.Domin.CalcDominated(Data.table);
                dominated = output[0];
                equal = output[1];
                dominated.Reverse();
                foreach (int eq in equal)
                {
                    int mainId = MathLib.Domin.EqualIndex(Data.table, eq - 1);
                    Data.models.First(m => m.id == mainId).name += "; " + Data.models[eq - 1].name;
                    Data.models[eq - 1].dominatedStatus = mainId;

                }
                foreach (int dom in dominated)
                {
                    Data.models[dom - 1].dominatedStatus = -1;
                }
                Model[] notDominated = Data.models.Where(m => m.dominatedStatus == 0).ToArray();
                Data.tablePareto = new double[notDominated.Count()][];
                int criteriaCount = Data.criteria.Count();
                int current = 0;
                foreach (Model m in notDominated)
                {
                    Data.tablePareto[current] = new double[criteriaCount];
                    for (int i = 0; i < criteriaCount; ++i)
                    {
                        Data.tablePareto[current][i] = Data.table[m.id - 1][i];
                    }
                    current++;
                }

            } Model.IsDominated = true;
        }   
    }

    public class Criterion
    {
        private static int criterionID = 0;
        
        public int id;
        public string name;
        public int value;
        public bool reverse;

        public Criterion()
        {
            id = ++criterionID;
            name = "Unknown "+criterionID.ToString();
            value = 0;
            reverse = false;
        }

        public Criterion(string nm, double vl, bool rev)
        {
            id = ++criterionID;
            name = nm;
            vl = (vl > 100) ? 100 : vl;
            vl = (vl < 1) ? 1 : vl;
            value = (int)Math.Round(vl);
            reverse = rev;
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

    public class Graph
    {
        public int val;
        public string name; 
    }

    public class Superiority
    {
        public static double[][] C;
        public static System.Tuple<string, double>[] scores;
    }

    public class Electre
    {
        //public static double Y;
        //public static double Q;
        //public static int[][] graph;
        public static double[][] C;
        public static double[][] D;
        public static System.Tuple<string, double>[] scores;
    }
}
