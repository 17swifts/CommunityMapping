using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using Cis.Models;
using Microsoft.EntityFrameworkCore;

namespace Cis.Services.Tasks
{
	public class ServiceActiveStatusTask
	{
        private readonly CisDBContext _dbContext;

        public ServiceActiveStatusTask(CisDBContext dbContext)
        {
            // Retrieve a dbContext from dependency injection and assign it to a class variable
            _dbContext = dbContext;
        }
        public async Task UpdateServiceActiveStatus(CancellationToken cancellationToken = default)
        {
            // Get all the currently active services
            var activeServices = await _dbContext.ServiceEntity
				.Where(t => t.Active == true)
				.ToListAsync(cancellationToken);
            
            foreach (var activeService in activeServices)
			{
                var currentDate = DateTime.Now;
                if(activeService.Enddate.HasValue){
                    if(activeService.Enddate > currentDate){
                        activeService.Active = false;
                    }
                }
                else{
                    if(activeService.Startdate.HasValue && activeService.Noservicedays.HasValue){
                        var endDate = activeService.Startdate.Value.AddDays((double)activeService.Noservicedays);
                        if(endDate > currentDate){
                            activeService.Active = false;
                        }
                        activeService.Enddate = endDate;
                    }
                }
			}
            // Save back to the database
            await _dbContext.SaveChangesAsync(cancellationToken);
        }
	}
}

