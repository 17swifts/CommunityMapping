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
using Cis.Helpers;
using Cis.Models.Interfaces;
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
	/// <summary>
	/// Timeline Events Of Regional area
	/// </summary>
	// % protected region % [Configure entity attributes here] off begin
	[Table("RegionalAreaTimelineEvents")]
	// % protected region % [Configure entity attributes here] end
	// % protected region % [Modify class declaration here] off begin
	public class RegionalAreaTimelineEventsEntity : IOwnerAbstractModel, ITimelineEventEntity  
	// % protected region % [Modify class declaration here] end
	{
		[Key]
		public Guid Id { get; set; }
		public Guid Owner { get; set; }
		public DateTime Created { get; set; }
		public DateTime Modified { get; set; }

		/// <summary>
		/// The action taken
		/// </summary>
		// % protected region % [Customise Action here] off begin
		[EntityAttribute]
		public String Action { get; set; }
		// % protected region % [Customise Action here] end

		/// <summary>
		/// The title of the action taken
		/// </summary>
		// % protected region % [Customise ActionTitle here] off begin
		[EntityAttribute]
		public String ActionTitle { get; set; }
		// % protected region % [Customise ActionTitle here] end

		/// <summary>
		/// Decription of the event
		/// </summary>
		// % protected region % [Customise Description here] off begin
		[EntityAttribute]
		public String Description { get; set; }
		// % protected region % [Customise Description here] end

		/// <summary>
		/// Id of the group the events belong to
		/// </summary>
		[Required]
		// % protected region % [Customise GroupId here] off begin
		[EntityAttribute]
		public Guid? GroupId { get; set; }
		// % protected region % [Customise GroupId here] end

		// % protected region % [Add any further attributes here] off begin
		// % protected region % [Add any further attributes here] end

		public RegionalAreaTimelineEventsEntity()
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

		// % protected region % [Customise Entity here] off begin
		/// <summary>
		/// Outgoing one to many reference
		/// </summary>
		/// <see cref="Cis.Models.RegionalAreaEntity"/>
		public Guid? EntityId { get; set; }
		[EntityForeignKey("Entity", "LoggedEvents", false, typeof(RegionalAreaEntity))]
		public RegionalAreaEntity Entity { get; set; }
		// % protected region % [Customise Entity here] end

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
			var modelList = models.Cast<RegionalAreaTimelineEventsEntity>().ToList();
			var ids = modelList.Select(t => t.Id).ToList();

			switch (reference)
			{
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