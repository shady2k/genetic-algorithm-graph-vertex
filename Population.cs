using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gavg
{
    public class Population
    {
        private int lastChromosomeID = 0;
        public int generation { get; private set; } = 1;
        public Dictionary<int, int> summaryQuality { get; private set; } = new Dictionary<int, int>();
        private List<KeyValuePair<int, int>> adjacencyList = new List<KeyValuePair<int, int>>();
        public List<Chromosome> chromosomes { get; private set; } = new List<Chromosome>();
        public int GenerateNewChromosomeID()
        {
            lastChromosomeID++;
            return lastChromosomeID;
        }
        public void AddAdjacencyEdge(int startVertex, int endVertex)
        {
            AddEdge(startVertex, endVertex);
        }
        public List<KeyValuePair<int, int>> GetEdges()
        {
            return adjacencyList;
        }
        public List<int> GetNodes()
        {
            List<int> ua = new List<int>();
            foreach(var item in adjacencyList)
            {
                ua.Add(item.Key);
                ua.Add(item.Value);
            }
            ua.Distinct().ToList();
            return ua;
        }
        public void AddChromosome(Chromosome chromosome)
        {
            chromosome.id = GenerateNewChromosomeID();
            chromosome.generation = generation;
            calcChromosomeLength(chromosome);
            chromosomes.Add(chromosome);
        }
        public void ReplaceChromosomeGenes(Chromosome chromosome, int[] newGenes)
        {
            chromosome.genes = newGenes;
            calcChromosomeLength(chromosome);
        }
        private void calcChromosomeLength(Chromosome chromosome)
        {
            chromosome.ClearIntersections();
            int[] genes = chromosome.genes;
            foreach (var edge in adjacencyList)
            {
                bool isStartFound = false;
                for (int i = 0; i < genes.Length - 1; i++)
                {
                    int cg = genes[i];
                    int ng = genes[i + 1];

                    if (isStartFound)
                    {
                        chromosome.AddIntersection(cg, ng);
                        if (ng == edge.Value || ng == edge.Key)
                        {
                            break;
                        }
                    }
                    else
                    {
                        if (cg == edge.Key || cg == edge.Value)
                        {
                            isStartFound = true;
                            chromosome.AddIntersection(cg, ng);
                            if (ng == edge.Value || ng == edge.Key)
                            {
                                break;
                            }
                        }
                    }
                }
            }
            chromosome.CalcLength();
        }
        public bool AdjacencyListContainsKeyValue(int expectedKey, int expectedValue)
        {
            bool t1 = adjacencyList.Any(kvp => kvp.Key == expectedKey && kvp.Value == expectedValue);
            bool t2 = adjacencyList.Any(kvp => kvp.Key == expectedValue && kvp.Value == expectedKey);
            return t1 || t2;
        }
        public void AddEdge(int startVertex, int endVertex)
        {
            if (startVertex == endVertex)
            {
                return;
            }
            if (startVertex > endVertex)
            {
                int sv = startVertex;
                int ev = endVertex;
                startVertex = ev;
                endVertex = sv;
            }
            if (!AdjacencyListContainsKeyValue(startVertex, endVertex))
            {
                adjacencyList.Add(new KeyValuePair<int, int>(startVertex, endVertex));
            }
        }
        private void CalcSummaryQuality()
        {
            summaryQuality.Add(generation, chromosomes.Sum(x => x.length));
        }
        public void Complete()
        {
            CalcSummaryQuality();
        }
        public void Mutation()
        {
            CalcSummaryQuality();
            Chromosome chromosome = GetBestChromosome();
            int[] genes = chromosome.genes;
            int[] newGenes = new int[genes.Length];
            genes.CopyTo(newGenes, 0);
            Array.Reverse(newGenes, generation, newGenes.Length - generation);
            Selection(newGenes);
        }
        public void Selection(int[] newGenes)
        {
            generation++;
            Chromosome worstChromosome = GetWorstChromosome();
            worstChromosome.generation = generation;
            ReplaceChromosomeGenes(worstChromosome, newGenes);
        }
        public Chromosome GetBestChromosome()
        {
            return chromosomes.OrderBy(x => x.length).ThenBy(x => x.id).Take(1).FirstOrDefault();
        }
        public Chromosome GetWorstChromosome()
        {
            return chromosomes.OrderByDescending(x => x.length).ThenByDescending(x => x.id).Take(1).FirstOrDefault();
        }
        public void DeleteWorstChromosome()
        {
            List<Chromosome> newChromosomes = new List<Chromosome>();
            newChromosomes = chromosomes.OrderByDescending(x => x.length).ThenBy(x => x.id).Skip(1).ToList();
            chromosomes = newChromosomes;
        }
    }
}
