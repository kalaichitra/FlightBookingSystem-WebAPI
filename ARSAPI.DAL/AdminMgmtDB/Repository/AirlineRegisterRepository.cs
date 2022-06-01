
using ARSAPI.DAL.AdminDB.Models;
using ARSAPI.DAL.Model;
using ARSAPI.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ARSAPI.DAL.AdminMgmtDB.Repository
{
    public class AirlineRegisterRepository : IAirlineRegisterRepository
    {
        private readonly AdminMgmtDBContext _dbContext;
        public AirlineRegisterRepository(AdminMgmtDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<AirlineRegDetails> GetDetails()
        {
            return _dbContext.AirlineRegDetails.ToList();
        }

        public IEnumerable<TripDetails> GetDetailsbyInput(SearchInputs searchInputs)
        {
            List<AirlineMgmt> airlineMgmtsOneTrip = new List<AirlineMgmt>();
            List<AirlineMgmt> airlineMgmtsRoundTrip = new List<AirlineMgmt>();
            if (searchInputs.TripType == 1)//One way trip
            {
                
                airlineMgmtsOneTrip = (from ar in _dbContext.AirlineRegDetails
                                       join am in _dbContext.AirlineMgmt
                                       on ar.AirlineName equals am.AirlineName
                                       where ar.IsActive == true && searchInputs.FromPlace == am.FromPlace &&
                                       searchInputs.ToPlace == am.ToPlace &&
                                       searchInputs.StartDate >= am.StartDate && searchInputs.StartDate <= am.EndDate
                                       select am).ToList();

            }
            else if(searchInputs.TripType==2)
            {
                airlineMgmtsOneTrip = (from ar in _dbContext.AirlineRegDetails
                                       join am in _dbContext.AirlineMgmt
                                       on ar.AirlineName equals am.AirlineName
                                       where ar.IsActive == true && searchInputs.FromPlace == am.FromPlace &&
                                       searchInputs.ToPlace == am.ToPlace &&
                                       searchInputs.StartDate >= am.StartDate && searchInputs.StartDate <= am.EndDate
                                       select am).ToList();

                airlineMgmtsRoundTrip = (from ar in _dbContext.AirlineRegDetails
                                         join am in _dbContext.AirlineMgmt
                                         on ar.AirlineName equals am.AirlineName
                                         where ar.IsActive == true && searchInputs.FromPlace == am.ToPlace &&
                                         searchInputs.ToPlace == am.FromPlace &&
                                         searchInputs.EndDate >= am.StartDate && searchInputs.EndDate <= am.EndDate
                                         select am).ToList();

            }
            List<SearchOutput> searchList = new List<SearchOutput>();
            List<SearchOutput> RountTripsearchList = new List<SearchOutput>();
            List<TripDetails> triplist = new List<TripDetails>();
            TripDetails objonetrip = new TripDetails();
            TripDetails objtwotrip = new TripDetails();
            if (searchInputs.TripType == 1 && airlineMgmtsOneTrip.Count > 0)
            {
                
                foreach (var details in airlineMgmtsOneTrip)
                {
                    searchList.Add(new SearchOutput
                    {
                        AirlineName = details.AirlineName,
                        FlightNo = details.FlightNo,
                        StartDate = details.StartDate,
                        TicketCost = details.TicketCost
                    });
                    objonetrip.Onetrip=searchList;
                }
                triplist.Add(objonetrip);
            }


            if (searchInputs.TripType == 2 && airlineMgmtsRoundTrip.Count > 0)
            {
                foreach (var details in airlineMgmtsOneTrip)
                {
                    searchList.Add(new SearchOutput
                    {
                        AirlineName = details.AirlineName,
                        FlightNo = details.FlightNo,
                        StartDate = details.StartDate,
                        TicketCost = details.TicketCost
                    });
                   // objonetrip.Onetrip = searchList;
                }
                //triplist.Add(objtwotrip);
                foreach (var details in airlineMgmtsRoundTrip)
                {
                    RountTripsearchList.Add(new SearchOutput
                    {
                        AirlineName = details.AirlineName,
                        FlightNo = details.FlightNo,
                        StartDate = details.StartDate,
                        TicketCost = details.TicketCost
                    });
                    //objtwotrip.Roundtrip = searchList;
                }
               // triplist.Add(objtwotrip);
            }
            triplist.Add(new TripDetails { Onetrip=searchList,Roundtrip= RountTripsearchList });
            return triplist;
        }

        public void InsertDetails(AirlineRegDetails airlineRegDetails)
        {
            _dbContext.Add(airlineRegDetails);
            save();
        }

        public void DeleteAirlineDetails(string AirlineName)
        {
            var airlineDetail = _dbContext.AirlineRegDetails.Where(c => c.AirlineName == AirlineName).FirstOrDefault();
            _dbContext.AirlineRegDetails.Remove(airlineDetail);
            save();
        }
        public void DeleteAirlineScheduleDetails(string AirlineName)
        {
            var airlineMgmts = _dbContext.AirlineMgmt.Where(c => c.AirlineName == AirlineName).ToList();
            _dbContext.AirlineMgmt.RemoveRange(airlineMgmts);
            save();
        }

        public void save()
        {
            _dbContext.SaveChanges();
        }

        public void UpdateAirlineDetails(AirlineRegDetails airlineDetails)
        {
            _dbContext.Entry(airlineDetails).State = EntityState.Modified;
            save();
        }

        public Coupon GetCouponDetails(string discount)
        {
            return _dbContext.Coupon.Where(c => c.DicountCode==discount).FirstOrDefault();
        }

        public void InsertCouponDetails(Coupon airlineRegDetails)
        {
            
        }

        //public void DeleteAirlineScheduleDetails(string AirlineName)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
