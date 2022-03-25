namespace API_REST.Models
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IList<Worker> Workers { get; set; }
    }
}

