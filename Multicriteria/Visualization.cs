
namespace Multicriteria
{
    class Visualization
    {
        public static void ShowGraph(Model[] models, int[][] graphTable)
        {
            int[] core = MathLib.Electre.GetGraphCore(graphTable);
            Microsoft.Glee.GraphViewerGdi.GViewer viewer = new Microsoft.Glee.GraphViewerGdi.GViewer();
            Microsoft.Glee.Drawing.Graph graph = new Microsoft.Glee.Drawing.Graph("graph");
            for (int i = 0; i < models.Length; ++i)
            {
                graph.AddNode(models[i].name);
                for (int j = 0; j < models.Length; ++j)
                {
                    if (graphTable[i][j] == 1)
                        graph.AddEdge(models[i].name, models[j].name);
                } Microsoft.Glee.Drawing.Node n = graph.FindNode(models[i].name);
                //n.Attr.Shape = Microsoft.Glee.Drawing.Shape.DoubleCircle;
                if (core[i] == 1)
                {
                    n.Attr.Fillcolor = Microsoft.Glee.Drawing.Color.SeaGreen;
                }
                else
                {
                    n.Attr.Fillcolor = Microsoft.Glee.Drawing.Color.Brown;
                }
            }
            
            //bind the graph to the viewer
            viewer.Graph = graph;

            //associate the viewer with the form
            System.Windows.Forms.Form form = new System.Windows.Forms.Form();
            form.SuspendLayout();
            viewer.Dock = System.Windows.Forms.DockStyle.Fill;
            form.Controls.Add(viewer);
            form.ResumeLayout();

            //show the form
            form.ShowDialog();
        }
    }
}
