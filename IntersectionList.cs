using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gavg
{
    public class IntersectionList
    {
        private List<Intersection> intersectionList = new List<Intersection>();
        public void Add(int startGene, int endGene)
        {
            if (!isExists(startGene, endGene))
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
        public bool isExists(int startGene, int endGene)
        {
            return intersectionList.Any(x => x.startGene == startGene && x.endGene == endGene);
        }
        public List<Intersection> GetIntersectionList()
        {
            return intersectionList;
        }
    }
}
