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
using System.Linq;
using System.Collections.Generic;
using Cis.Enums;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
// % protected region % [Add any extra imports here] off begin
// % protected region % [Add any extra imports here] end

namespace Cis.Models
{
	public class ServiceEntityDto : ModelDto<ServiceEntity>
	{
		// % protected region % [Customise Name here] off begin
		public String Name { get; set; }
		// % protected region % [Customise Name here] end

		// % protected region % [Customise Servicetype here] off begin
		/// <summary>
		/// Whether the service is permanent or temporary 
		/// </summary>
		[JsonProperty("servicetype")]
		[JsonConverter(typeof(StringEnumConverter))]
		public Servicetype Servicetype { get; set; }
		// % protected region % [Customise Servicetype here] end

		// % protected region % [Customise Category here] off begin
		[JsonProperty("category")]
		[JsonConverter(typeof(StringEnumConverter))]
		public Categories Category { get; set; }
		// % protected region % [Customise Category here] end

		// % protected region % [Customise Active here] off begin
		/// <summary>
		/// Whether the service is currently active
		/// </summary>
		public Boolean? Active { get; set; }
		// % protected region % [Customise Active here] end

		// % protected region % [Customise Noservicedays here] off begin
		/// <summary>
		/// Number of days the service is operating
		/// </summary>
		public int? Noservicedays { get; set; }
		// % protected region % [Customise Noservicedays here] end

		// % protected region % [Customise Investment here] off begin
		public Double? Investment { get; set; }
		// % protected region % [Customise Investment here] end

		// % protected region % [Customise Startdate here] off begin
		/// <summary>
		/// Start data of the service
		/// </summary>
		public DateTime? Startdate { get; set; }
		// % protected region % [Customise Startdate here] end

		// % protected region % [Customise Enddate here] off begin
		/// <summary>
		/// End dat of the service
		/// </summary>
		public DateTime? Enddate { get; set; }
		// % protected region % [Customise Enddate here] end


		// % protected region % [Customise RegionalAreaId here] off begin
		public Guid? RegionalAreaId { get; set; }
		// % protected region % [Customise RegionalAreaId here] end

		// % protected region % [Add any extra attributes here] off begin
		// % protected region % [Add any extra attributes here] end

		public ServiceEntityDto(ServiceEntity model)
		{
			LoadModelData(model);
			// % protected region % [Add any constructor logic here] off begin
			// % protected region % [Add any constructor logic here] end
		}

		public ServiceEntityDto()
		{
			// % protected region % [Add any parameterless constructor logic here] off begin
			// % protected region % [Add any parameterless constructor logic here] end
		}

		public override ServiceEntity ToModel()
		{
			// % protected region % [Add any extra ToModel logic here] off begin
			// % protected region % [Add any extra ToModel logic here] end

			return new ServiceEntity
			{
				Id = Id,
				Created = Created,
				Modified = Modified,
				Name = Name,
				Servicetype = Servicetype,
				Category = Category,
				Active = Active,
				Noservicedays = Noservicedays,
				Investment = Investment,
				Startdate = Startdate,
				Enddate = Enddate,
				RegionalAreaId  = RegionalAreaId,
				// % protected region % [Add any extra model properties here] off begin
				// % protected region % [Add any extra model properties here] end
			};
		}

		public override ModelDto<ServiceEntity> LoadModelData(ServiceEntity model)
		{
			Id = model.Id;
			Created = model.Created;
			Modified = model.Modified;
			Name = model.Name;
			Servicetype = model.Servicetype;
			Category = model.Category;
			Active = model.Active;
			Noservicedays = model.Noservicedays;
			Investment = model.Investment;
			Startdate = model.Startdate;
			Enddate = model.Enddate;
			RegionalAreaId  = model.RegionalAreaId;

			// % protected region % [Add any extra loading data logic here] off begin
			// % protected region % [Add any extra loading data logic here] end

			return this;
		}

		// % protected region % [Add any extra methods here] off begin
		// % protected region % [Add any extra methods here] end
	}
}