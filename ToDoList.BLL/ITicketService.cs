using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ToDoList.DAL.Entity;

namespace ToDoList.BLL
{
    public interface ITicketService
    {
        Task DeleteTicket(string id);
        Task EditTicket(string id, Ticket ticket);
        Task<List<Ticket>> GetAllTickets();
        Task<bool> AddTicket(Ticket ticket);
    }
}
