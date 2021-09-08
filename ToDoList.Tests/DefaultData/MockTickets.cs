using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.DAL.Entity;

namespace ToDoList.Tests
{
    public static class MockTickets
    {
        public static Ticket ticket = new Ticket
        {
            Id = "0f8fad5b-d9cb-469f-a165-70867728950e",
            Name = "Solomiia",
            Status = "done",
            Description = "write unit tests",
            Deadline_date = "14.06.2021",
            Created_date = "14.06.2021"
        };

        public static Ticket ticket1 = new Ticket
        {
            Id = "7c9e6679-7425-40de-944b-e07fc1f90ae7",
            Name = "Solomiia",
            Status = "done",
            Description = "write unit tests",
            Deadline_date = "14.06.2021",
            Created_date = "14.06.2021"
        };

        public static List<Ticket> tickets = new List<Ticket>()
        {
            ticket,
            ticket1
        };

    }
}
