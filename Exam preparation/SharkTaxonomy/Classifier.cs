namespace SharkTaxonomy
{
    using System.Linq;
    using System.Text;

    public class Classifier
    {
        public Classifier(int capacity)
        {
            Capacity = capacity;
            Species = new List<Shark>();
        }
        public int Capacity { get; set; }
        public List<Shark> Species { get; set; }
        public int GetCount => Species.Count;

        public void AddShark(Shark shark)
        {
            if(Capacity > GetCount && (!Species.Any(x => x.Kind == shark.Kind)))
            {
                Species.Add(shark);
            }
        }
        public bool RemoveShark(string kind)
        {
            int idxToRemove = Species.FindIndex(x => x.Kind == kind);

            if(idxToRemove != -1)
            {
                Species.RemoveAt(idxToRemove);
                return true;
            }
            return false;
        }
        public string GetLargestShark()
        {
            return Species.MaxBy(x => x.Length).ToString();
        }
        public double GetAverageLength()
        {
            return Species.Average(x => x.Length);
        }
        public string Report()
        {
            StringBuilder report = new StringBuilder();

            report.AppendLine($"{GetCount} sharks classified:");

            foreach (Shark s in Species)
            {
                report.AppendLine(s.ToString().Trim());
            }

            return report.ToString().Trim();
        }
    }
}
