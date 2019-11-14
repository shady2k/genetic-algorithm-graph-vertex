using Microsoft.Msagl.Core.Geometry;
using Microsoft.Msagl.Core.Geometry.Curves;
using Microsoft.Msagl.Drawing;
using System;
using System.Windows.Forms;
using Microsoft.Msagl;
using System.Collections.Generic;
using System.Linq;

namespace gavg
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            tbLog.Clear();
            Population population = new Population();

            foreach(DataGridViewRow dr in dgvAdjacency.Rows)
            {
                if (dr.IsNewRow) break;
                int a;
                int b;
                bool ab = Int32.TryParse(dr.Cells["A"].Value.ToString(), out a);
                bool bb = Int32.TryParse(dr.Cells["B"].Value.ToString(), out b);
                if (ab && bb)
                {
                    population.AddAdjacencyEdge(a, b);
                }
            }

            string[] textLines = tbChromosomes.Text.Split('\n');
            foreach (var line in textLines)
            {
                int[] ia = line.Split(',').Select(n => Convert.ToInt32(n)).ToArray();
                population.AddChromosome(new Chromosome(ia));
            }

            DrawChart(gViewer1, population);
            
            tbLog.Text += "========================\r\n";
            tbLog.Text += "Начальная поуляция\r\n";
            tbLog.Text += "========================\r\n";
            tbLog.Text += GenerateReport(population);

            for (int i = 0; i < 3; i++)
            {
                population.Mutation();
            }
            population.Complete();

            /*foreach(var item in population.chromosomes)
            {
                Console.WriteLine("---");
                foreach (var item2 in item.GetIntersectionList())
                {
                    Console.WriteLine(item2.intersection);
                }
            }*/

            DrawChart(gViewer2, population);

            tbLog.Text += "\r\n";
            tbLog.Text += "========================\r\n";
            tbLog.Text += "После мутации\r\n";
            tbLog.Text += "========================\r\n";
            tbLog.Text += GenerateReport(population);
            
        }
        public string GenerateReport(Population population)
        {
            string report = string.Empty;

            foreach (var chromosome in population.chromosomes)
            {
                report += String.Format("Хромосома {1}: {0}\r\n", String.Join(", ", chromosome.genes), "p" + chromosome.id.ToString());
            }


            string sqt = string.Empty;
            bool isFirstItem = true;
            foreach (var item in population.chromosomes)
            {
                if (!isFirstItem)
                {
                    sqt += " + ";
                }

                sqt += item.length;
                isFirstItem = false;
            }
            sqt += " = " + population.chromosomes.Sum(x => x.length).ToString();

            report += String.Format("Поколение: {0}\r\n", population.generation.ToString());
            report += String.Format("Суммарная длина: {0}\r\n", sqt);
            sqt = string.Empty;
            isFirstItem = true;
            foreach (var item in population.summaryQuality)
            {
                if (!isFirstItem)
                {
                    sqt += " - ";
                }

                sqt += item.Value;
                isFirstItem = false;

            }
            if (!String.IsNullOrEmpty(sqt))
            {
                report += String.Format("Суммарное качество популяции: {0}\r\n", sqt);
            }

            report += String.Format("Наилучшая хромосома: {0}\r\n", "p" + population.GetBestChromosome().id.ToString());
            report += String.Format("Наилучшая длина ребра: {0}\r\n", population.GetBestChromosome().length.ToString());
            report += String.Format("Худшая хромосома: {0}\r\n", "p" + population.GetWorstChromosome().id.ToString());
            report += String.Format("Худшая длина ребра: {0}\r\n", population.GetWorstChromosome().length.ToString());

            return report;
        }
        static Node Dn(Graph g, string s)
        {
            return g.FindNode(s);
        }
        public void DrawChart(Microsoft.Msagl.GraphViewerGdi.GViewer gViewer, Population population)
        {
            //gViewer1.NeedToCalculateLayout = false;
            //create a graph object 
            Microsoft.Msagl.Drawing.Graph graph = new Microsoft.Msagl.Drawing.Graph("graph");
            
            //create the graph content
            foreach(var chromosome in population.chromosomes)
            {
                graph.AddNode("p" + chromosome.id.ToString());
                foreach (var edge in population.GetEdges())
                {
                    Node n = graph.AddNode(chromosome.id.ToString() + edge.Key.ToString());
                    n.LabelText = edge.Key.ToString();
                    n = graph.AddNode(chromosome.id.ToString() + edge.Value.ToString());
                    n.LabelText = edge.Value.ToString();
                    graph.AddEdge(chromosome.id.ToString() + edge.Key.ToString(), chromosome.id.ToString() + edge.Value.ToString());
                }
            }
            
            foreach (var edge in graph.Edges)
            {
                edge.Attr.ArrowheadAtTarget = ArrowStyle.None;
            }
            foreach (var node in graph.Nodes)
            {
                if (node.Id.StartsWith("p"))
                {
                    node.Attr.Shape = Microsoft.Msagl.Drawing.Shape.Plaintext;
                }
                else
                {
                    node.Attr.Shape = Microsoft.Msagl.Drawing.Shape.Circle;
                }
            }

            /*graph.FindNode("A").Attr.FillColor = Microsoft.Msagl.Drawing.Color.Magenta;
            graph.FindNode("B").Attr.FillColor = Microsoft.Msagl.Drawing.Color.MistyRose;
            Microsoft.Msagl.Drawing.Node c = graph.FindNode("C");
            c.Attr.FillColor = Microsoft.Msagl.Drawing.Color.PaleGreen;
            c.Attr.Shape = Microsoft.Msagl.Drawing.Shape.Diamond;*/
            //bind the graph to the viewer 
            //graph.LayerConstraints.AddSameLayerNeighbors(graph.FindNode("1"), graph.FindNode("2"), graph.FindNode("3"), graph.FindNode("4"), graph.FindNode("5"));


            foreach (var chromosome in population.chromosomes)
            {
                List<Node> nl = new List<Node>();
                nl.Add(Dn(graph, "p" + chromosome.id.ToString()));
                foreach (var gene in chromosome.genes)
                {
                    nl.Add(Dn(graph, chromosome.id.ToString() + gene));
                }
                graph.LayerConstraints.AddSameLayerNeighbors(nl);
            }

            //graph.LayerConstraints.AddSameLayerNeighbors(Dn(graph, "11"), Dn(graph, "12"), Dn(graph, "13"), Dn(graph, "14"), Dn(graph, "15"));
            //graph.LayerConstraints.AddSameLayerNeighbors(Dn(graph, "21"), Dn(graph, "22"), Dn(graph, "23"), Dn(graph, "24"), Dn(graph, "25"));
            //graph.LayerConstraints.AddSameLayerNeighbors(Dn(graph, "31"), Dn(graph, "32"), Dn(graph, "33"), Dn(graph, "34"), Dn(graph, "35"));

            List<Node> cst = new List<Node>();
            foreach (var chromosome in population.chromosomes)
            {
                cst.Add(Dn(graph, chromosome.id.ToString() + chromosome.genes[0].ToString()));
            }

            for (var i = 0; i < cst.Count - 1; i++)
            {
                graph.LayerConstraints.AddUpDownConstraint(cst[i], cst[i + 1]);
            }
            //graph.LayerConstraints.AddUpDownConstraint(Dn(graph, "11"), Dn(graph, "22"));
            //graph.LayerConstraints.AddUpDownConstraint(Dn(graph, "22"), Dn(graph, "35"));

            gViewer.Graph = graph;
        }

        private void button2_Click(object sender, EventArgs e)
        {
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dgvAdjacency.Rows.Add(1, 5);
            dgvAdjacency.Rows.Add(1, 4);
            dgvAdjacency.Rows.Add(1, 3);
            dgvAdjacency.Rows.Add(1, 2);

            dgvAdjacency.Rows.Add(2, 1);
            dgvAdjacency.Rows.Add(2, 5);
            dgvAdjacency.Rows.Add(2, 3);

            dgvAdjacency.Rows.Add(3, 1);
            dgvAdjacency.Rows.Add(3, 2);
            dgvAdjacency.Rows.Add(3, 5);

            dgvAdjacency.Rows.Add(4, 1);
            dgvAdjacency.Rows.Add(4, 5);
            
            dgvAdjacency.Rows.Add(5, 1);
            dgvAdjacency.Rows.Add(5, 2);
            dgvAdjacency.Rows.Add(5, 3);
            dgvAdjacency.Rows.Add(5, 4);
        }
    }
}
