using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml;
using GraphSharp.Sample;
using QuickGraph;
using GraphSharp;
using GraphSharp.Controls;
using QuickGraph.Serialization;

namespace WinFormsGraphSharp
{
    /// <summary>
    /// Interaction logic for GraphSharpControl.xaml
    /// </summary>
    public partial class GraphSharpControl : UserControl
    {
        public GraphSharpControl()
        {
            InitializeComponent();

            var g = new CompoundGraph<object, IEdge<object>>();

            var vertices = new string[30];
            for (int i = 0; i < 30; i++)
            {
                vertices[i] = i.ToString();
                g.AddVertex(vertices[i]);
            }

            for (int i = 6; i < 15; i++)
            {
                g.AddChildVertex(vertices[i % 5], vertices[i]);
            }
            g.AddChildVertex(vertices[5], vertices[4]);
            g.AddChildVertex(vertices[5], vertices[2]);
            g.AddChildVertex(vertices[16], vertices[0]);
            g.AddChildVertex(vertices[16], vertices[1]);
            g.AddChildVertex(vertices[16], vertices[3]);
            g.AddChildVertex(vertices[16], vertices[20]);
            g.AddChildVertex(vertices[16], vertices[21]);
            g.AddChildVertex(vertices[16], vertices[22]);
            g.AddChildVertex(vertices[16], vertices[23]);
            g.AddChildVertex(vertices[16], vertices[24]);
            g.AddChildVertex(vertices[4], vertices[25]);
            g.AddChildVertex(vertices[4], vertices[26]);
            g.AddChildVertex(vertices[4], vertices[27]);

            g.AddEdge(new Edge<object>(vertices[0], vertices[1]));
            g.AddEdge(new Edge<object>(vertices[0], vertices[2]));
            g.AddEdge(new Edge<object>(vertices[2], vertices[4]));
            g.AddEdge(new Edge<object>(vertices[0], vertices[7]));
            g.AddEdge(new Edge<object>(vertices[8], vertices[7]));
            //g.AddEdge(new Edge<object>(vertices[13], vertices[12]));
            g.AddEdge(new Edge<object>(vertices[3], vertices[20]));
            g.AddEdge(new Edge<object>(vertices[20], vertices[21]));
            g.AddEdge(new Edge<object>(vertices[20], vertices[22]));
            g.AddEdge(new Edge<object>(vertices[22], vertices[23]));
            g.AddEdge(new Edge<object>(vertices[23], vertices[24]));
            g.AddEdge(new Edge<object>(vertices[0], vertices[28]));
            g.AddEdge(new Edge<object>(vertices[0], vertices[29]));
            g.AddEdge(new Edge<object>(vertices[25], vertices[27]));
            g.AddEdge(new Edge<object>(vertices[26], vertices[25]));
            g.AddEdge(new Edge<object>(vertices[14], vertices[27]));
            g.AddEdge(new Edge<object>(vertices[14], vertices[26]));
            g.AddEdge(new Edge<object>(vertices[14], vertices[25]));
            g.AddEdge(new Edge<object>(vertices[26], vertices[27]));


            layout.LayoutMode = LayoutMode.Automatic;
            layout.LayoutAlgorithmType = "CompoundFDP";
            layout.OverlapRemovalConstraint = AlgorithmConstraints.Automatic;
            layout.OverlapRemovalAlgorithmType = "FSA";
            layout.HighlightAlgorithmType = "Simple";
            layout.Graph = g;
        }
        public void OpenFile(string fileName)
        {
            //graph where the vertices and edges should be put in
            var graph = new CompoundGraph<object, IEdge<object>>();
        
            try
            {
                //open the file of the graph
                var reader = XmlReader.Create(fileName);

                //create the serializer
                var serializer = new GraphMLDeserializer<object, IEdge<object>, CompoundGraph<object, IEdge<object>>>();


                //deserialize the graph
                serializer.Deserialize(reader, graph,
                                       id => id, (source, target, id) => new Edge<object>(source, target)
                    );

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            layout.Graph = graph;
            layout.UpdateLayout();

        }

        private IBidirectionalGraph<object, IEdge<object>> ConvertGraph(PocGraph graph)
        {
            var g = new CompoundGraph<object, IEdge<object>>();

            foreach (var item in graph.Vertices)
            {
                g.AddVertex(item.ID);

            }

            foreach (var item in graph.Edges)
            {
                g.AddEdge(new Edge<object>(item.Source.ID, item.Target.ID));
            }


            return g;
        }

        private void Relayout_Click(object sender, RoutedEventArgs e)
        {
            layout.Relayout();
        }

    }
}
