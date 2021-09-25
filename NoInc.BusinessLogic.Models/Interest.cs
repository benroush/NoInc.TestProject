using NoInc.Enums;

namespace NoInc.BusinessLogic.Models
{
    public class Interest
    {
        public Interest()
        {
        }

        public Interest(int id, string name, InterestType type, bool isCurrent, string detail)
        {
            Id = id;
            Name = name;
            Type = type;
            IsCurrent = isCurrent;
            Detail = detail;
        }

        public Interest(string name, InterestType type, bool isCurrent, string detail)
        {
            Name = name;
            Type = type;
            IsCurrent = isCurrent;
            Detail = detail;
        }

        public int Id { get; }
        public string Name { get; }
        public InterestType Type { get; }
        public bool IsCurrent { get; }
        public string Detail { get; }
    }
}