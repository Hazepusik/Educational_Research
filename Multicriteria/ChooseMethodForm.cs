using System;
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
            Model.CheckDominated();
            Model[] notDominated = Data.models.Where(m => m.dominatedStatus == 0).ToArray();
            int[] P = new int[Data.criteria.Count];
            foreach (Criterion c in Data.criteria)
            {
                P[c.id - 1] = c.value;
            }

            var val = MathLib.Electre.CalcIndexes(Data.tablePareto, P);
            Electre.C = val.Select(t => t.Item1).First();
            Electre.D = val.Select(t => t.Item2).First();
            /*Electre.D[1][0] = 0.11;
            Electre.D[2][0] = 0.22;
            Electre.D[3][0] = 0.33;
            Electre.D[0][1] = 0.6;
            Electre.D[2][1] = 0.3;
            Electre.D[3][1] = 0.22;
            Electre.D[0][2] = 0.3;
            Electre.D[1][2] = 0.1;
            Electre.D[3][2] = 0.11;
            Electre.D[0][3] = 0.4;
            Electre.D[1][3] = 0.2;
            Electre.D[2][3] = 0.1;*/

            int modelsCount = Data.tablePareto.Count();
            //Electre.graph = MathLib.Electre.GetGraphByIndexes(Electre.C, Electre.D, Electre.Y, Electre.Q);
            string[] modelNames = new string[notDominated.Count()];
            for (int i=0; i<notDominated.Count(); ++i)
            {
                modelNames[i] = notDominated[i].name;
            }
            Electre.scores = MathLib.Electre.FinalScore(Electre.C, Electre.D, modelNames);

            Data.notDominated = notDominated.ToList();
            DataGridView tableCD = Electre.ShowCDMatrix();
            // TODO: write tableCD to excel
            Data.ShowResults(Electre.scores, 2);
            if (Electre.scores.Count() > 1)
            {
                frmGraph graphForm = new frmGraph(2);
                graphForm.ShowDialog();
            }

        }



        private void btnSuperiority_Click(object sender, EventArgs e)
        {
            Model.CheckDominated();
            Model[] notDominated = Data.models.Where(m => m.dominatedStatus == 0).ToArray();
            int[] P = new int[Data.criteria.Count];
            foreach (Criterion c in Data.criteria)
            {
                P[c.id - 1] = c.value;
            }

            Superiority.C = MathLib.Superiority.CalcIndexes(Data.tablePareto, P);


            int modelsCount = Data.tablePareto.Count();
            string[] modelNames = new string[notDominated.Count()];
            for (int i = 0; i < notDominated.Count(); ++i)
            {
                modelNames[i] = notDominated[i].name;
            }
            Superiority.scores = MathLib.Superiority.FinalScore(Superiority.C, modelNames);
            Data.notDominated = notDominated.ToList();
            DataGridView tableC = Superiority.ShowCMatrix();
            // TODO: write tableC to excel
            Data.ShowResults(Superiority.scores, 1);
            if (Superiority.scores.Count() > 1)
            {
                frmGraph graphForm = new frmGraph(1);
                graphForm.ShowDialog();
            }
        }

        private void btnAll_Click(object sender, EventArgs e)
        {
            Model.CheckDominated();
            Model[] notDominated = Data.models.Where(m => m.dominatedStatus == 0).ToArray();
            int[] P = new int[Data.criteria.Count];
            foreach (Criterion c in Data.criteria)
                P[c.id - 1] = c.value;
            int modelsCount = Data.tablePareto.Count();
            string[] modelNames = new string[notDominated.Count()];
            for (int i = 0; i < notDominated.Count(); ++i)
                modelNames[i] = notDominated[i].name;


            Superiority.C = MathLib.Superiority.CalcIndexes(Data.tablePareto, P);
            Superiority.scores = MathLib.Superiority.FinalScore(Superiority.C, modelNames);

            var val = MathLib.Electre.CalcIndexes(Data.tablePareto, P);
            Electre.C = val.Select(t => t.Item1).First();
            Electre.D = val.Select(t => t.Item2).First();

            Electre.scores = MathLib.Electre.FinalScore(Electre.C, Electre.D, modelNames);
            Array.Sort(Electre.scores);
            Array.Sort(Superiority.scores);
            Data.avgScores = new System.Tuple<string, double>[Electre.scores.Count()];
            for (int i = 0; i < Electre.scores.Count(); ++i)
            {
                double avg = ((Superiority.scores[i].Item2 * Superiority.importance) + (Electre.scores[i].Item2 * Electre.importance)) / (Electre.importance + Superiority.importance);
                Data.avgScores[i] = new System.Tuple<string, double>(Electre.scores[i].Item1, avg);
            }
            Data.avgScores = Data.avgScores.OrderBy(x => x.Item2).ToArray();
            Data.notDominated = notDominated.ToList();
            Data.ShowResults(Data.avgScores, 0);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Logger.Finish();
        }
    }
}
