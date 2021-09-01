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
	[Table("RegionalArea")]
	// % protected region % [Configure entity attributes here] end
	// % protected region % [Modify class declaration here] off begin
	public class RegionalAreaEntity : IOwnerAbstractModel 
	// % protected region % [Modify class declaration here] end
	{
		[Key]
		public Guid Id { get; set; }
		public Guid Owner { get; set; }
		public DateTime Created { get; set; }
		public DateTime Modified { get; set; }

		[Required]
		// % protected region % [Customise Sa2id here] off begin
		[EntityAttribute]
		public String Sa2id { get; set; }
		// % protected region % [Customise Sa2id here] end

		[Required]
		// % protected region % [Customise Sa3id here] off begin
		[EntityAttribute]
		public String Sa3id { get; set; }
		// % protected region % [Customise Sa3id here] end

		// % protected region % [Customise Sa3name here] off begin
		[EntityAttribute]
		public String Sa3name { get; set; }
		// % protected region % [Customise Sa3name here] end

		/// <summary>
		/// Potentially Preventable Hospitalisations
		/// </summary>
		// % protected region % [Customise Numofpph here] off begin
		[EntityAttribute]
		public int? Numofpph { get; set; }
		// % protected region % [Customise Numofpph here] end

		// % protected region % [Customise Percentpphperday here] off begin
		[EntityAttribute]
		public Double? Percentpphperday { get; set; }
		// % protected region % [Customise Percentpphperday here] end

		// % protected region % [Customise Sa2name here] off begin
		[EntityAttribute]
		public String Sa2name { get; set; }
		// % protected region % [Customise Sa2name here] end

		// % protected region % [Customise Indigenous here] off begin
		[EntityAttribute]
		public int? Indigenous { get; set; }
		// % protected region % [Customise Indigenous here] end

		// % protected region % [Customise Nonindigenous here] off begin
		[EntityAttribute]
		public int? Nonindigenous { get; set; }
		// % protected region % [Customise Nonindigenous here] end

		/// <summary>
		/// The Index of Relative Socio-economic Disadvantage (IRSD) is a general socio-economic index that summarises a range of information about the economic and social conditions of people and households within an area. 
		/// </summary>
		// % protected region % [Customise Irsd here] off begin
		[EntityAttribute]
		public int? Irsd { get; set; }
		// % protected region % [Customise Irsd here] end

		/// <summary>
		/// The Index of Relative Socio-economic Advantage and Disadvantage (IRSAD) summarises information about the economic and social conditions of people and households within an area, including both relative advantage and disadvantage measures.
		/// </summary>
		// % protected region % [Customise Irsad here] off begin
		[EntityAttribute]
		public int? Irsad { get; set; }
		// % protected region % [Customise Irsad here] end

		/// <summary>
		/// The Index of Economic Resources (IER) focuses on the financial aspects of relative socio-economic advantage and disadvantage, by summarising variables related to income and wealth. 
		/// </summary>
		// % protected region % [Customise Ier here] off begin
		[EntityAttribute]
		public int? Ier { get; set; }
		// % protected region % [Customise Ier here] end

		/// <summary>
		/// The Index of Education and Occupation (IEO) is designed to reflect the educational and occupational level of communities. 
		/// </summary>
		// % protected region % [Customise Ieo here] off begin
		[EntityAttribute]
		public int? Ieo { get; set; }
		// % protected region % [Customise Ieo here] end

		// % protected region % [Customise GapScore here] off begin
		[EntityAttribute]
		public Double? GapScore { get; set; }
		// % protected region % [Customise GapScore here] end

		// % protected region % [Customise Australianrank here] off begin
		[EntityAttribute]
		public int? Australianrank { get; set; }
		// % protected region % [Customise Australianrank here] end

		// % protected region % [Add any further attributes here] off begin
		// % protected region % [Add any further attributes here] end

		public RegionalAreaEntity()
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
			new VisitorsRegionalAreaEntity(),
			new ServiceCommissioningBodyRegionalAreaEntity(),
			new AdminRegionalAreaEntity(),
			// % protected region % [Override ACLs here] end
			// % protected region % [Add any further ACL entries here] off begin
			// % protected region % [Add any further ACL entries here] end
		};

		// % protected region % [Customise Servicess here] off begin
		/// <summary>
		/// Incoming one to many reference
		/// </summary>
		/// <see cref="Cis.Models.ServiceEntity"/>
		[EntityForeignKey("Servicess", "RegionalArea", false, typeof(ServiceEntity))]
		public ICollection<ServiceEntity> Servicess { get; set; }
		// % protected region % [Customise Servicess here] end

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
			var modelList = models.Cast<RegionalAreaEntity>().ToList();
			var ids = modelList.Select(t => t.Id).ToList();

			switch (reference)
			{
				case "Servicess":
					var servicesIds = modelList.SelectMany(x => x.Servicess.Select(m => m.Id)).ToList();
					var oldservices = await dbContext.ServiceEntity
						.Where(m => m.RegionalAreaId.HasValue && ids.Contains(m.RegionalAreaId.Value))
						.Where(m => !servicesIds.Contains(m.Id))
						.ToListAsync(cancellation);

					foreach (var services in oldservices)
					{
						services.RegionalAreaId = null;
					}

					dbContext.ServiceEntity.UpdateRange(oldservices);
					return oldservices.Count;
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