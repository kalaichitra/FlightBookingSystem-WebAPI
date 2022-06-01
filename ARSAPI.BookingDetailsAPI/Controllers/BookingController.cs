
using ARSAPI.DAL.Models;
using ARSAPI.DAL.TicketDetailDB.Repository;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Transactions;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ARSAPI.UserMgmtAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly ITicketDetailsRepository _ticketRepository;
        public BookingController(ITicketDetailsRepository ticketRepository)
        {
            _ticketRepository = ticketRepository;
        }


        //[HttpGet("{PNR}", Name = "Get")]
        [HttpGet]
        public IActionResult Get(string PNR)
        {

            var bookingDetails = _ticketRepository.GetDetailsById(PNR);
            return new OkObjectResult(bookingDetails);
        }
        [HttpGet]
        [Route("GetbyEmailID")]
        public IActionResult GetbyEmailID(string email)
        {

            var bookingDetails = _ticketRepository.GetDetailsByEmail(email);
            return new OkObjectResult(bookingDetails);
        }

        // POST api/<BookingController>
        [HttpPost]
        public IActionResult Post([FromBody] TicketDetails ticketDetails)
        {
            Random RandomNumber = new Random();
            int no = RandomNumber.Next(10, 9999);
            List<int> seatNo = new List<int>();
            int NoOfSeats = ticketDetails.NoOfSeats;
            for(int i=1; i<= NoOfSeats;i++)
            {
               seatNo.Add(RandomNumber.Next(1, 200));
            }
            ticketDetails.SeatNo=string.Join(",", seatNo);
            //ticketDetails.SeatNo = seatNo.ToString();
            using (var scope = new TransactionScope())
            {
                    ticketDetails.PnrNo = Convert.ToString("PNR" + no);
               // ticketDetails.SeatNo = "21";
                _ticketRepository.InsertDetails(ticketDetails);
                scope.Complete();
                return CreatedAtAction(nameof(Get), new { id = ticketDetails.BookingId }, ticketDetails);
            }
        }
       
        // DELETE api/<BookingController>/5
       [HttpDelete("{pnr}")]
        public IActionResult Delete(string pnr)
        {

            _ticketRepository.DeleteDetails(pnr);
            return new OkResult();
        }
    }
}
