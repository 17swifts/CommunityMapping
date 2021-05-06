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
	// % protected region % [Configure entity attributes here] end
	// % protected region % [Modify class declaration here] off begin
	public class ServiceCommissioningBodyEntity : User, IOwnerAbstractModel 
	// % protected region % [Modify class declaration here] end
	{
		// % protected region % [Customise Name here] off begin
		[EntityAttribute]
		public String Name { get; set; }
		// % protected region % [Customise Name here] end

		// % protected region % [Customise Location here] off begin
		[EntityAttribute]
		public String Location { get; set; }
		// % protected region % [Customise Location here] end

		// % protected region % [Customise ProfileImage here] off begin
		[FileReference]
		public Guid? ProfileImageId { get; set; }
		[EntityForeignKey("ProfileImage", "ServiceCommissioningBodyProfileImage", false, typeof(UploadFile))]
		public UploadFile ProfileImage { get; set; }
		// % protected region % [Customise ProfileImage here] end

		// % protected region % [Add any further attributes here] off begin
		// % protected region % [Add any further attributes here] end

		public ServiceCommissioningBodyEntity()
		{
			// % protected region % [Add any constructor logic here] off begin
			// % protected region % [Add any constructor logic here] end
		}

		// % protected region % [Customise ACL attributes here] off begin
		[NotMapped]
		[JsonIgnore]
		// % protected region % [Customise ACL attributes here] end
		public override IEnumerable<IAcl> Acls => new List<IAcl>
		{
			// % protected region % [Override ACLs here] off begin
			new SuperAdministratorsScheme(),
			new AdminServiceCommissioningBodyEntity(),
			new ServiceCommissioningBodyServiceCommissioningBodyEntity(),
			// % protected region % [Override ACLs here] end
			// % protected region % [Add any further ACL entries here] off begin
			// % protected region % [Add any further ACL entries here] end
		};

		// % protected region % [Customise Servicess here] off begin
		/// <summary>
		/// Incoming many to many reference
		/// </summary>
		/// <see cref="Cis.Models.ServiceCommissioningBodiesServices"/>
		[EntityForeignKey("Servicess", "ServiceCommissioningBodies", false, typeof(ServiceCommissioningBodiesServices))]
		public ICollection<ServiceCommissioningBodiesServices> Servicess { get; set; }
		// % protected region % [Customise Servicess here] end

		public override async Task BeforeSave(
			EntityState operation,
			CisDBContext dbContext,
			IServiceProvider serviceProvider,
			CancellationToken cancellationToken = default)
		{
			// % protected region % [Add any initial before save logic here] off begin
			// % protected region % [Add any initial before save logic here] end

			if (operation == EntityState.Deleted)
			{
				if (ProfileImageId.HasValue)
				{
					var existingFile = dbContext.Files.FirstOrDefault(f => f.Id == ProfileImageId.Value);
					if (existingFile != null)
					{
						dbContext.Files.Remove(existingFile);
						await existingFile.BeforeSave(EntityState.Deleted, dbContext, serviceProvider);
					}
				}
			}

			// % protected region % [Add any before save logic here] off begin
			// % protected region % [Add any before save logic here] end
		}

		public override async Task AfterSave(
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

		public async override Task<int> CleanReference<T>(
			string reference,
			IEnumerable<T> models,
			CisDBContext dbContext,
			CancellationToken cancellation = default)
			{
			var modelList = models.Cast<ServiceCommissioningBodyEntity>().ToList();
			var ids = modelList.Select(t => t.Id).ToList();

			switch (reference)
			{
				case "Servicess":
					var servicesEntities = modelList
						.SelectMany(m => m.Servicess)
						.Select(m => m.Id);
					var oldServices = await dbContext.ServiceCommissioningBodiesServices
						.Where(m => ids.Contains(m.ServiceCommissioningBodiesId) && !servicesEntities.Contains(m.Id))
						.ToListAsync(cancellation);
					dbContext.ServiceCommissioningBodiesServices.RemoveRange(oldServices);

					return oldServices.Count;
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