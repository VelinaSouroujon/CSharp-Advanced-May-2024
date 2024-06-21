using System.Text;

namespace DataCenter
{
    public class Rack
    {
        public Rack(int slots)
        {
            Slots = slots;
            Servers = new List<Server>();
        }
        public int Slots { get; set; }
        public List<Server> Servers { get; set; }
        public int GetCount => Servers.Count;

        public void AddServer(Server server)
        {
            if(Slots <= GetCount || Servers.Any(x => x.SerialNumber == server.SerialNumber))
            {
                return;
            }
            Servers.Add(server);
        }
        public bool RemoveServer(string serialNumber)
        {
            int idxToRemove = Servers.FindIndex(x => x.SerialNumber == serialNumber);

            if(idxToRemove == -1)
            {
                return false;
            }

            Servers.RemoveAt(idxToRemove);
            return true;
        }
        public string GetHighestPowerUsage()
        {
            return Servers.MaxBy(x => x.PowerUsage).ToString();
        }
        public int GetTotalCapacity()
        {
            return Servers.Sum(x => x.Capacity);
        }
        public string DeviceManager()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{GetCount} servers operating:");

            foreach(Server server in Servers)
            {
                sb.AppendLine(server.ToString());
            }

            return sb.ToString().Trim();
        }
    }
}
