using System;
using System.Collections.Generic;
using System.Linq;

namespace gavg
{
    public class Chromosome
    {
        private List<Intersection> intersectionList = new List<Intersection>();

        public int id { get; set; }
        public int priority { get; set; }
        public int generation { get; set; }
        public int[] genes { get; set; }
        public int length { get; set; }
        public Chromosome(int[] genes)
        {
            this.generation = 0;
            this.genes = genes;
        }
        public void AddIntersection(int startGene, int endGene)
        {
            if (!IsIntersectionExists(startGene, endGene))
            {
                Intersection data = new Intersection
                {
                    startGene = startGene,
                    endGene = endGene,
                    intersection = 1
                };
                intersectionList.Add(data);
            }
            else
            {
                var data = intersectionList.Where(x => x.startGene == startGene && x.endGene == endGene).FirstOrDefault();
                data.intersection = data.intersection + 1;
            }
        }
        public void ClearIntersections()
        {
            intersectionList.Clear();
        }
        public bool IsIntersectionExists(int startGene, int endGene)
        {
            return intersectionList.Any(x => x.startGene == startGene && x.endGene == endGene);
        }
        public List<Intersection> GetIntersectionList()
        {
            return intersectionList;
        }
        public int GetLength()
        {
            return this.length;
        }
        public void CalcLength()
        {
            this.length = intersectionList.Sum(x => x.intersection);
        }
    }
}
