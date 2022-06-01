using ARSAPI.DAL.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ARSAPI.DAL.AdminMgmtDB.Repository
{
    public class AirlineScheduleRepository : IAirlineScheduleRepository
    {
        private readonly AdminMgmtDBContext _dbContext;
        public AirlineScheduleRepository(AdminMgmtDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<AirlineMgmt> GetDetails()
        {
            return _dbContext.AirlineMgmt.ToList();
        }

        public void InsertDetails(AirlineMgmt airlineMgmtDetails)
        {
            _dbContext.Add(airlineMgmtDetails);
            save();
        }

        public void save()
        {
            _dbContext.SaveChanges();
        }

        public void UpdateAirlineDetails(AirlineMgmt airlineMgmtDetails)
        {
            _dbContext.Entry(airlineMgmtDetails).State = EntityState.Modified;
            save();
        }
    }

        
    }

