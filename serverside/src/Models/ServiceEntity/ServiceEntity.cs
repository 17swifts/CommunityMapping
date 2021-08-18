/*
 * @bot-written
 *
 * WARNING AND NOTICE
 * Any access, download, storage, and/or use of this source code is subject to the terms and conditions of the
 * Full Software Licence as accepted by you before being granted access to this source code and other materials,
 * the terms of which can be accessed on the Codebots website at https://codebots.com/full-software-licence. Any
 * commercial use in contravention of the terms of the Full Software Licence may be pursued by Codebots through
 * licence termination and further legal action, and be required to indemnify Codebots for any loss or damage,
 * including interest and costs. You are deemed to have accepted the terms of the Full Software Licence on any
 * access, download, storage, and/or use of this source code.
 *
 * BOT WARNING
 * This file is bot-written.
 * Any changes out side of "protected regions" will be lost next time the bot makes any changes.
 */
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Cis.Enums;
using Cis.Security;
using Cis.Security.Acl;
using Cis.Validators;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Z.EntityFramework.Plus;
// % protected region % [Add any further imports here] off begin
// % protected region % [Add any further imports here] end

namespace Cis.Models {
	// % protected region % [Configure entity attributes here] off begin
	[Table("Service")]
	// % protected region % [Configure entity attributes here] end
	// % protected region % [Modify class declaration here] off begin
	public class ServiceEntity : IOwnerAbstractModel 
	// % protected region % [Modify class declaration here] end
	{
		[Key]
		public Guid Id { get; set; }
		public Guid Owner { get; set; }
		public DateTime Created { get; set; }
		public DateTime Modified { get; set; }

		[Required]
		// % protected region % [Customise Name here] off begin
		[EntityAttribute]
		public String Name { get; set; }
		// % protected region % [Customise Name here] end

		// % protected region % [Customise Description here] off begin
		[EntityAttribute]
		public String Description { get; set; }
		// % protected region % [Customise Description here] end

		/// <summary>
		/// Whether the service is permanent or temporary 
		/// </summary>
		[Required]
		// % protected region % [Customise Servicetype here] off begin
		[EntityAttribute]
		public Servicetype Servicetype { get; set; }
		// % protected region % [Customise Servicetype here] end

		[Required]
		// % protected region % [Customise Category here] off begin
		[EntityAttribute]
		public Categories Category { get; set; }
		// % protected region % [Customise Category here] end

		/// <summary>
		/// Whether the service is currently active
		/// </summary>
		[Required]
		// % protected region % [Customise Active here] off begin
		[EntityAttribute]
		public Boolean? Active { get; set; }
		// % protected region % [Customise Active here] end

		/// <summary>
		/// Number of days the service is operating
		/// </summary>
		// % protected region % [Customise Noservicedays here] off begin
		[EntityAttribute]
		public int? Noservicedays { get; set; }
		// % protected region % [Customise Noservicedays here] end

		// % protected region % [Customise Investment here] off begin
		[EntityAttribute]
		public Double? Investment { get; set; }
		// % protected region % [Customise Investment here] end

		/// <summary>
		/// Start data of the service
		/// </summary>
		[Required]
		// % protected region % [Customise Startdate here] off begin
		[EntityAttribute]
		public DateTime? Startdate { get; set; }
		// % protected region % [Customise Startdate here] end

		/// <summary>
		/// End dat of the service
		/// </summary>
		// % protected region % [Customise Enddate here] off begin
		[EntityAttribute]
		public DateTime? Enddate { get; set; }
		// % protected region % [Customise Enddate here] end

		// % protected region % [Customise Gender here] off begin
		[EntityAttribute]
		public Gender Gender { get; set; }
		// % protected region % [Customise Gender here] end

		// % protected region % [Customise Agemin here] off begin
		[EntityAttribute]
		public int? Agemin { get; set; }
		// % protected region % [Customise Agemin here] end

		// % protected region % [Customise Agemax here] off begin
		[EntityAttribute]
		public int? Agemax { get; set; }
		// % protected region % [Customise Agemax here] end

		// % protected region % [Add any further attributes here] off begin
		// % protected region % [Add any further attributes here] end

		public ServiceEntity()
		{
			// % protected region % [Add any constructor logic here] off begin
			// % protected region % [Add any constructor logic here] end
		}

		// % protected region % [Customise ACL attributes here] off begin
		[NotMapped]
		[JsonIgnore]
		// % protected region % [Customise ACL attributes here] end
		public IEnumerable<IAcl> Acls => new List<IAcl>
		{
			// % protected region % [Override ACLs here] off begin
			new SuperAdministratorsScheme(),
			new VisitorsServiceEntity(),
			new ServiceCommissioningBodyServiceEntity(),
			new AdminServiceEntity(),
			// % protected region % [Override ACLs here] end
			// % protected region % [Add any further ACL entries here] off begin
			// % protected region % [Add any further ACL entries here] end
		};

		// % protected region % [Customise RegionalArea here] off begin
		/// <summary>
		/// Outgoing one to many reference
		/// </summary>
		/// <see cref="Cis.Models.RegionalAreaEntity"/>
		public Guid? RegionalAreaId { get; set; }
		[EntityForeignKey("RegionalArea", "Servicess", false, typeof(RegionalAreaEntity))]
		public RegionalAreaEntity RegionalArea { get; set; }
		// % protected region % [Customise RegionalArea here] end

		// % protected region % [Customise ServiceCommissioningBodiess here] off begin
		/// <summary>
		/// Outgoing many to many reference
		/// </summary>
		/// <see cref="Cis.Models.ServiceCommissioningBodiesServices"/>
		[EntityForeignKey("ServiceCommissioningBodiess", "Services", false, typeof(ServiceCommissioningBodiesServices))]
		public ICollection<ServiceCommissioningBodiesServices> ServiceCommissioningBodiess { get; set; }
		// % protected region % [Customise ServiceCommissioningBodiess here] end

		public async Task BeforeSave(
			EntityState operation,
			CisDBContext dbContext,
			IServiceProvider serviceProvider,
			CancellationToken cancellationToken = default)
		{
			// % protected region % [Add any initial before save logic here] off begin
			// % protected region % [Add any initial before save logic here] end

			// % protected region % [Add any before save logic here] off begin
			// % protected region % [Add any before save logic here] end
		}

		public async Task AfterSave(
			EntityState operation,
			CisDBContext dbContext,
			IServiceProvider serviceProvider,
			ICollection<ChangeState> changes,
			CancellationToken cancellationToken = default)
		{
			// % protected region % [Add any initial after save logic here] off begin
			// % protected region % [Add any initial after save logic here] end

			// % protected region % [Add any after save logic here] off begin
			// % protected region % [Add any after save logic here] end
		}

		public async Task<int> CleanReference<T>(
			string reference,
			IEnumerable<T> models,
			CisDBContext dbContext,
			CancellationToken cancellation = default)
			where T : IOwnerAbstractModel
			{
			var modelList = models.Cast<ServiceEntity>().ToList();
			var ids = modelList.Select(t => t.Id).ToList();

			switch (reference)
			{
				case "ServiceCommissioningBodiess":
					var serviceCommissioningBodiesEntities = modelList
						.SelectMany(m => m.ServiceCommissioningBodiess)
						.Select(m => m.Id);
					var oldServiceCommissioningBodies = await dbContext.ServiceCommissioningBodiesServices
						.Where(m => ids.Contains(m.ServicesId) && !serviceCommissioningBodiesEntities.Contains(m.Id))
						.ToListAsync(cancellation);
					dbContext.ServiceCommissioningBodiesServices.RemoveRange(oldServiceCommissioningBodies);

					return oldServiceCommissioningBodies.Count;
				// % protected region % [Add any extra clean reference logic here] off begin
				// % protected region % [Add any extra clean reference logic here] end
				default:
					return 0;
			}
		}

		// % protected region % [Add any further references here] off begin
		// % protected region % [Add any further references here] end
	}
}