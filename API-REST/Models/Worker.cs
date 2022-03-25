namespace API_REST.Models
{
    public class Worker
    {
        public long Id { get; set; }
        public string? Name { get; set; }
        public string? LastName { get; set; }
        public string? email { get; set; }
        public  Department? Department { get; set; }
        public  int? DepartmentId { get; set; }
        public string? Position { get; set; }
        public Status? Status { get; set; }
        public Level? Level { get; set; }
    }
}
public enum Status { Active, Onboarding, Awaiting, Disable }
public enum Level { Internal, Junior, Senior }