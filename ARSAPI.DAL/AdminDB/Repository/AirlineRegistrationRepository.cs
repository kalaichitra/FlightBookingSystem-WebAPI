//using ARSAPI.DAL.AdminDB.Models;
//using ARSAPI.DAL.Models;
//using Microsoft.EntityFrameworkCore;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;

//namespace ARSAPI.DAL.AdminDB.Repository
//{
//    public class AirlineRegistrationRepository : IAirlineRegistrationRepository
//    {
//        private readonly AdminDBContext _dbContext;
//        public AirlineRegistrationRepository(AdminDBContext dbContext)
//        {
//            _dbContext = dbContext;
//        }

//        public void DeleteDetails(int airlineID)
//        {
//            var airlineDetail = _dbContext.AirlineRegistration.Find(airlineID);
//            _dbContext.AirlineRegistration.Remove(airlineDetail);
//            save();
//        }

//        public IEnumerable<AirlineRegistration> GetDetails()
//        {
//            AirlineRegistration airlineRegistration = new AirlineRegistration();

//            var airlineDetails = (from ar in _dbContext.AirlineRegistration
//                       join am in _dbContext.AirlineMgmt 
//                       on ar.AirlineId equals am.AirlineId select ar);
//            List<AirlineMgmt> result = null;
//            foreach (var detail in airlineDetails)
//            {
//                airlineRegistration = detail;
//                result = _dbContext.AirlineMgmt.Where(
//                           s => s.AirlineId == detail.AirlineId).ToList();
//            }
//            airlineRegistration.AirlineMgmt = result;
            
//            _dbContext.AirlineRegistration.Add(airlineRegistration);

//            return _dbContext.AirlineRegistration.ToList();
//        }

//        public AirlineRegistration GetDetailsById(int airlineID)
//        {
//            return _dbContext.AirlineRegistration.Where(c => c.AirlineId == airlineID).FirstOrDefault();
//        }
//        public IEnumerable<SearchOutput> GetDetailsbyInput(SearchInputs searchInputs)
//        {
//            var airlineDetails = (from  am in _dbContext.AirlineMgmt
//                                  select am).Where(x =>
//                            searchInputs.FromPlace == x.FromPlace &&
//                           searchInputs.ToPlace == x.ToPlace &&
//                           searchInputs.StartDate >= x.StartDate && searchInputs.StartDate <=x.EndDate).ToList();
//            //  && searchInputs.EndDate >= x.StartDate && searchInputs.EndDate <= x.EndDate)
//            List<SearchOutput> searchList = new List<SearchOutput>();
//            if (airlineDetails != null)
//               {
                
//                foreach (var details in airlineDetails)
//                {
//                    SearchOutput searchObj = new SearchOutput();
//                    searchObj.AirlineName = details.AirlineName;
//                    searchObj.FlightNo = details.FlightNo;
//                    searchObj.StartDate = details.StartDate;
//                    searchObj.TicketCost = details.TicketCost;
//                    var logoDetail = (from ar in _dbContext.AirlineRegistration select ar).Where(x => x.AirlineId == details.AirlineId);
//                    foreach (var Logo in logoDetail)
//                    {
//                        searchObj.Logo = Logo.Logo;
//                    }
//                    searchList.Add(searchObj);
//                }
               
//            }
//           // SearchOutput=
//            return searchList;
//        }


//        public void InsertDetails(AirlineRegistration airlineRegistration)
//        {
//            _dbContext.Add(airlineRegistration);
//            save();
//        }
//        public void InsertscheduleDetails(AirlineMgmt airlineMgmt)
//        {
//            var AirlineRegistration = new AirlineRegistration();
//            AirlineRegistration = (AirlineRegistration)(from ar in _dbContext.AirlineRegistration select ar).Where(x => x.AirlineName == airlineMgmt.AirlineName);
//           // var AirlineRegistration = new AirlineRegistration();
//           AirlineRegistration.AirlineMgmt.Add(airlineMgmt);
//            _dbContext.AirlineMgmt.Add(airlineMgmt);

//            save();
//        }
            
//        public void UpdateAirline(AirlineRegistration airlineRegistration)
//        {
//            _dbContext.Entry(airlineRegistration).State = EntityState.Modified;
//            save();
//        }

//        public void save()
//        {
//            _dbContext.SaveChanges();
//        }

        
//    }
//}
