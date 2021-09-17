using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Cis.Models;
using Cis.Services;

namespace Cis.Services
{
	public class ServiceManagementService
	{
		/// <summary>
		/// Updates the active status on all the tanks using custom business logic
		/// </summary>
		public static async Task UpdateServiceActiveStatus(CrudService crudService)
		{
			// get all the tanks with clean status
			var activeServices = crudService.Get<ServiceEntity>()
				.Where(t => t.Active == true)
				.ToList();

			foreach (var activeService in activeServices)
			{
                var currentDate = DateTime.Now;
                if(activeService.Enddate.HasValue){
                    if(activeService.Enddate > currentDate){
                        activeService.Active = false;
                        await crudService.Update(activeService);
                    }
                }
                else{
                    if(activeService.Startdate.HasValue && activeService.Noservicedays.HasValue){
                        var endDate = activeService.Startdate.Value.AddDays((double)activeService.Noservicedays);
                        if(endDate > currentDate){
                            activeService.Active = false;
                        }
                        activeService.Enddate = endDate;
                        await crudService.Update(activeService);
                    }
                }
			}
		}
	}
}

