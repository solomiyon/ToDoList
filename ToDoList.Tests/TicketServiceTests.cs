using Moq;
using NUnit.Framework;
using NUnit.Framework.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using ToDoList.BLL;
using ToDoList.DAL.Entity;
using ToDoList.DAL.UnitOfWork;

namespace ToDoList.Tests
{
    [TestFixture]
     class TicketServiceTests
     {
        private ITicketService _ticketService;
        private Mock<IUnitOfWork> _unitOfWork;

        [SetUp]
        public void SetUp()
        {
            _unitOfWork = new Mock<IUnitOfWork>();
            _ticketService = new TicketService(_unitOfWork.Object); 
        }

        [Test]
        public async Task GetAllTicket_ReturnsTickets()
        {
            //Arrange
            _unitOfWork.Setup(t => t.Repository<Ticket>().GetAllAsync(It.IsAny<Expression<Func<Ticket, bool>>>()))
                .ReturnsAsync(MockTickets.tickets.AsQueryable());

            //Act
            var res = await _ticketService.GetAllTickets();

            //Assert
            Assert.NotNull(res);
            Assert.IsInstanceOf<IEnumerable<Ticket>>(res);
        }

        [Test]
        public async Task GetAllTicket_ReturnsTickets_Fail()
        {
            //Arrange
            _unitOfWork.Setup(t => t.Repository<Ticket>().GetAllAsync(It.IsAny<Expression<Func<Ticket, bool>>>()));
                

            //Act
            var res = await _ticketService.GetAllTickets();

            //Assert
            Assert.NotNull(res);
            Assert.IsInstanceOf<IEnumerable<Ticket>>(res);
        }

        [Test]
        public async Task AddTicket_Success()
        {
            //Arrange
            _unitOfWork.Setup(t => t.Repository<Ticket>().AddAsync(It.IsAny<Ticket>()));

            //Act
            var res = await  _ticketService.AddTicket(MockTickets.ticket);

            //Assert
            Assert.IsTrue(res);
        }

        [Test]
        public async Task AddTicket_Failed()
        {
            //Arrange
            _unitOfWork.Setup(t => t.Repository<Ticket>().AddAsync(It.IsAny<Ticket>()));

            //Act
            var res = await _ticketService.AddTicket(null);

            //Assert
            Assert.IsFalse(res);
        }

        [Test]
        public async Task DeleteTicket_Success()
        {
            //Arrange
            _unitOfWork.Setup(t => t.Repository<Ticket>().GetAsync(It.IsAny<Expression<Func<Ticket, bool>>>()));
            _unitOfWork.Setup(t => t.Repository<Ticket>().Remove(It.IsAny<Ticket>()));


            //Act
            var res = _ticketService.DeleteTicket(MockTickets.ticket.Id);

            //Assert
            Assert.NotNull(res);
        }

        [Test]
        public async Task DeleteTicket_Fail()
        {
            //Arrange
            _unitOfWork.Setup(t => t.Repository<Ticket>().GetAsync(It.IsAny<Expression<Func<Ticket, bool>>>()));
            _unitOfWork.Setup(t => t.Repository<Ticket>().Remove(It.IsAny<Ticket>()));

            

            //Act
            var res = _ticketService.DeleteTicket(null);

            //Assert
            Assert.NotNull(res);
        }

        [Test]
        public async Task EditTicket_Success()
        {
            //Arrange
            _unitOfWork.Setup(t => t.Repository<Ticket>().GetAsync(It.IsAny<Expression<Func<Ticket, bool>>>()));
            _unitOfWork.Setup(t => t.Repository<Ticket>().UpdateAsync(MockTickets.ticket));
            

            //Act
            var res = _ticketService.EditTicket(MockTickets.ticket.Id, MockTickets.ticket);

            //Assert
            Assert.NotNull(res);
        }


        [Test]
        public async Task EditTicket_Fail()
        {
            //Arrange
            _unitOfWork.Setup(t => t.Repository<Ticket>().GetAsync(It.IsAny<Expression<Func<Ticket, bool>>>()));
            _unitOfWork.Setup(t => t.Repository<Ticket>().UpdateAsync(MockTickets.ticket));


            //Act
            var res = _ticketService.EditTicket(null, null);

            //Assert
            Assert.NotNull(res);
        }

        //public async Task GetAllTicket_FailedReturnsTickets()
        //{
        //    //Arrange
        //    _unitOfWork.Setup(t => t.Repository<Ticket>().GetAllAsync(It.IsAny<Expression<Func<Ticket, bool>>>()))
        //        .ReturnsAsync(MockTickets.tickets.AsQueryable());

        //    //Act
        //    var res = await _ticketService.GetAllTickets();

        //    //Assert
        //    Assert.NotNull(res);
        //    Assert.IsInstanceOf<IEnumerable<Ticket>>(res);
        //}
    }
}
