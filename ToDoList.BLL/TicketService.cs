using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ToDoList.DAL.Entity;
using ToDoList.DAL.UnitOfWork;
using System.Linq;

namespace ToDoList.BLL
{
    public class TicketService : ITicketService
    {
        private readonly IUnitOfWork _unitOfWork;
        public TicketService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> AddTicket(Ticket ticket)
        {
            if (ticket != null)
            {
                await _unitOfWork.Repository<Ticket>().AddAsync(ticket);
                await _unitOfWork.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<List<Ticket>> GetAllTickets()
        {
            var tickets = await _unitOfWork.Repository<Ticket>().GetAllAsync();
            if(tickets != null)
            {
                return tickets.ToList();
            }
            return null;
        }

        public async Task EditTicket(string id, Ticket ticket)
        {
            var updatedTicket = await _unitOfWork.Repository<Ticket>().GetAsync(t => t.Id == id.ToString());;
            updatedTicket.Id = ticket.Id;
            updatedTicket.Name = ticket.Name;
            updatedTicket.Created_date = ticket.Created_date;
            updatedTicket.Deadline_date = ticket.Deadline_date;
            updatedTicket.Description = ticket.Description;
            updatedTicket.Status = ticket.Status;
            await _unitOfWork.Repository<Ticket>().UpdateAsync(updatedTicket);
            await _unitOfWork.SaveChangesAsync();
            return;
        }

        public async Task DeleteTicket(string id)
        {
            var ticket = await _unitOfWork.Repository<Ticket>().GetAsync(t => t.Id == id.ToString());
            _unitOfWork.Repository<Ticket>().Remove(ticket);
            await _unitOfWork.SaveChangesAsync();
        }


    }
}
