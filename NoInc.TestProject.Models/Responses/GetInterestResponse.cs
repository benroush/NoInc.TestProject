namespace NoInc.TestProject.Models.Responses
{
    public class GetInterestResponse
    {
        public GetInterestResponse()
        {
        }
        
        public GetInterestResponse(int id, string name, Enums.InterestType type, bool isCurrent, string detail)
        {
            Id = id;
            Name = name;
            Type = type.ToString();
            IsCurrent = isCurrent;
            Detail = detail;
        }

        public int Id { get; }
        public string Name { get; }
        public string Type { get; }
        public bool IsCurrent { get; }
        public string Detail { get; }
    }
}