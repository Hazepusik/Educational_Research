﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MathLib;

namespace Multicriteria
{
    public partial class frmChoose : Form
    {
        public frmChoose()
        {
            InitializeComponent();
        }

        private void btnElectre_Click(object sender, EventArgs e)
        {
            List<int> dominated = new List<int>();
            List<int> equal = new List<int>();
            List<int>[] output = new List<int>[2];
            Model[] notDominated = Data.models.Where(m => m.dominatedStatus == 0).ToArray();
            if (!Model.IsDominated)
            {
                output = MathLib.Domin.CalcDominated(Data.table);
                dominated = output[0];
                equal = output[1];
                dominated.Reverse();
                foreach (int eq in equal)
                {
                    //TODO: make refs to equal 
                    Data.models[eq - 1].dominatedStatus = 1;
                }
                foreach (int dom in dominated)
                {
                    Data.models[dom - 1].dominatedStatus = -1;
                }
                output = MathLib.Domin.CalcDominated(Data.table);
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
                Model.IsDominated = true;
            }
            int[] P = new int[Data.criteria.Count];
            foreach (Criterion c in Data.criteria)
            {
                P[c.id - 1] = c.value;
            }

            var val = MathLib.Electre.CalcIndexes(Data.tablePareto, P);
            Electre.C = val.Select(t => t.Item1).First();
            Electre.D = val.Select(t => t.Item2).First();

            int modelsCount = Data.tablePareto.Count();
            Electre.graph = MathLib.Electre.GetGraphByIndexes(Electre.C, Electre.D, Electre.Y, Electre.Q);
            string[] modelNames = new string[notDominated.Count()];
            for (int i=0; i<notDominated.Count(); ++i)
            {
                modelNames[i] = notDominated[i].name;
            }
            MathLib.Electre.FinalScore(Electre.C, Electre.D, modelNames);
            /*Electre.graph = new Graph[modelsCount][modelsCount];
            for (int i = 0; i < modelsCount; ++i)
            {
                for (int j = 0; j < modelsCount; ++j)
                {
                    //Electre.graph[i][j] = new Graph();
                    //Electre.graph[i][j].name = Data.models.Where(m => m.dominatedStatus == 0).ToList()[i].name + " ---> " + Data.models.Where(m => m.dominatedStatus == 0).ToList()[j].name;
                    // it works. magic
                    if ((C[i][j] >= Electre.Y) && (D[i][j] <= Electre.Q) && (i != j))
                    {
                        Electre.graph[i][j] = 1;
                    }
                    else
                    {
                        Electre.graph[i][j] = 0;
                    }
                }
            }*/

            Excel.WriteElectre(Electre.C, Electre.D, Electre.graph, Data.models.Where(m => m.dominatedStatus == 0).ToList());
            frmGraph graphForm = new frmGraph();
            graphForm.ShowDialog();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<int> dominated = new List<int>();
            List<int> equal = new List<int>();
            List<int>[] output = new List<int>[2];
            //frmGraph valuesYQForm = new frmGraph();
            //valuesYQForm.ShowDialog();
            if (!Model.IsDominated)
            {
                output = MathLib.Domin.CalcDominated(Data.table);
                dominated = output[0];
                equal = output[1];
                dominated.Reverse();
                foreach (int eq in equal)
                {
                    //TODO: make refs to equal 
                    Data.models[eq - 1].dominatedStatus = 1;
                }
                foreach (int dom in dominated)
                {
                    Data.models[dom - 1].dominatedStatus = -1;
                }
                //output = MathLib.Domin.CalcDominated(Data.table);
                Data.tablePareto = new double[Data.models.Count(m => m.dominatedStatus == 0)][];
                int criteriaCount = Data.criteria.Count();
                int current = 0;
                foreach (Model m in Data.models.Where(m => m.dominatedStatus == 0))
                {
                    Data.tablePareto[current] = new double[criteriaCount];
                    for (int i = 0; i < criteriaCount; ++i)
                    {
                        Data.tablePareto[current][i] = Data.table[m.id - 1][i];
                    }
                    current++;
                }

            }
            int[] P = new int[Data.criteria.Count];
            foreach (Criterion c in Data.criteria)
            {
                P[c.id - 1] = c.value;
            }
            var val = MathLib.Electre.CalcIndexes(Data.tablePareto, P);
            double[][] C = val.Select(t => t.Item1).First();
            double[][] D = val.Select(t => t.Item2).First();
            //Excel.WriteElectre(C, D, Data.models.Where(m => m.dominatedStatus == 0).ToList());

            
        }
    }
}