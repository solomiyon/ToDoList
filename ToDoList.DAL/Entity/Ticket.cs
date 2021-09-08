

namespace ToDoList.DAL.Entity
{
    public class Ticket
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Created_date { get; set; }
        public string Deadline_date { get; set; }
        public string Status { get; set; }
    }
}
