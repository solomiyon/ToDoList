using ToDoList.Controllers;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using ToDoList.BLL;
using ToDoList.DAL.Entity;

namespace ToDoList.Tests
{
    class TicketControllerTests
    {
        private readonly Mock<ITicketService> _ticketService;

        public TicketControllerTests()
        {
            _ticketService = new Mock<ITicketService>();
        }

        private TicketController CreateTicketController => new TicketController(_ticketService.Object);

        [Test]
        public void AddTicketTest_Valid()
        {
            //Arrange
            Ticket ticket = new Ticket();
            _ticketService.Setup(t => t.AddTicket(ticket));
            var tick = CreateTicketController;

            //Act
            var res = tick.AddTicket(ticket);


            //Assert
            Assert.NotNull(res);
        }

        [Test]
        public void AddTicketTest_Fail()
        {
            //Arrange
            Ticket ticket = new Ticket();
            _ticketService.Setup(t => t.AddTicket(ticket));
            var tick = CreateTicketController;

            //Act
            var res = tick.AddTicket(null);


            //Assert
            Assert.NotNull(res);
        }

        [Test]
        public void DeleteTicketTest_Valid()
        {
            //Arrange
            Ticket ticket = new Ticket();
            _ticketService.Setup(t => t.DeleteTicket(ticket.Id));
            var tick = CreateTicketController;

            //Act
            var res = tick.DeleteTicket(ticket.Id);


            //Assert
            Assert.NotNull(res);
        }

        [Test]
        public void DeleteTicketTest_Fail()
        {
            //Arrange
            Ticket ticket = new Ticket();
            _ticketService.Setup(t => t.DeleteTicket(ticket.Id));
            var tick = CreateTicketController;

            //Act
            var res = tick.DeleteTicket(null);


            //Assert
            Assert.NotNull(res);
        }

        [Test]
        public void EditTicketTest_Valid()
        {
            //Arrange
            Ticket ticket = new Ticket();
            _ticketService.Setup(t => t.EditTicket(ticket.Id, ticket));
            var tick = CreateTicketController;

            //Act
            var res = tick.EditTicket(ticket.Id, ticket);


            //Assert
            Assert.NotNull(res);
        }

        [Test]
        public void EditTicketTest_Fail()
        {
            //Arrange
            Ticket ticket = new Ticket();
            _ticketService.Setup(t => t.EditTicket(ticket.Id, ticket));
            var tick = CreateTicketController;

            //Act
            var res = tick.EditTicket(null, null);


            //Assert
            Assert.NotNull(res);
        }

        [Test]
        public void GetAllTicketTest_Valid()
        {
            
            var tick = CreateTicketController;

            //Act
            var res = tick.GetAllTickets();

            //Assert
            Assert.NotNull(res);
        }

    }
}
