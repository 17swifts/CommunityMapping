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
// % protected region % [Add any extra imports here] off begin
// % protected region % [Add any extra imports here] end

namespace Cis.Models
{
	public class RegionalAreaEntityDto : ModelDto<RegionalAreaEntity>
	{
		// % protected region % [Customise Sa2code here] off begin
		public int? Sa2code { get; set; }
		// % protected region % [Customise Sa2code here] end

		// % protected region % [Customise Name here] off begin
		public String Name { get; set; }
		// % protected region % [Customise Name here] end

		// % protected region % [Customise Nonindigenouspopulation here] off begin
		public int? Nonindigenouspopulation { get; set; }
		// % protected region % [Customise Nonindigenouspopulation here] end

		// % protected region % [Customise Indigenouspopulation here] off begin
		public int? Indigenouspopulation { get; set; }
		// % protected region % [Customise Indigenouspopulation here] end

		// % protected region % [Customise Pph here] off begin
		/// <summary>
		/// Potentially Preventable Hospitalisations
		/// </summary>
		public int? Pph { get; set; }
		// % protected region % [Customise Pph here] end

		// % protected region % [Customise Irsd here] off begin
		/// <summary>
		/// The Index of Relative Socio-economic Disadvantage (IRSD) is a general socio-economic index that summarises a range of information about the economic and social conditions of people and households within an area. 
		/// </summary>
		public int? Irsd { get; set; }
		// % protected region % [Customise Irsd here] end

		// % protected region % [Customise Irsad here] off begin
		/// <summary>
		/// The Index of Relative Socio-economic Advantage and Disadvantage (IRSAD) summarises information about the economic and social conditions of people and households within an area, including both relative advantage and disadvantage measures.
		/// </summary>
		public int? Irsad { get; set; }
		// % protected region % [Customise Irsad here] end

		// % protected region % [Customise Ieo here] off begin
		/// <summary>
		/// The Index of Education and Occupation (IEO) is designed to reflect the educational and occupational level of communities. 
		/// </summary>
		public int? Ieo { get; set; }
		// % protected region % [Customise Ieo here] end

		// % protected region % [Customise Ier here] off begin
		/// <summary>
		/// The Index of Economic Resources (IER) focuses on the financial aspects of relative socio-economic advantage and disadvantage, by summarising variables related to income and wealth. 
		/// </summary>
		public int? Ier { get; set; }
		// % protected region % [Customise Ier here] end

		// % protected region % [Customise GapScore here] off begin
		public Double? GapScore { get; set; }
		// % protected region % [Customise GapScore here] end

		// % protected region % [Customise Noservices here] off begin
		public int? Noservices { get; set; }
		// % protected region % [Customise Noservices here] end

		// % protected region % [Customise Totalinvestment here] off begin
		public Double? Totalinvestment { get; set; }
		// % protected region % [Customise Totalinvestment here] end


		// % protected region % [Add any extra attributes here] off begin
		// % protected region % [Add any extra attributes here] end

		public RegionalAreaEntityDto(RegionalAreaEntity model)
		{
			LoadModelData(model);
			// % protected region % [Add any constructor logic here] off begin
			// % protected region % [Add any constructor logic here] end
		}

		public RegionalAreaEntityDto()
		{
			// % protected region % [Add any parameterless constructor logic here] off begin
			// % protected region % [Add any parameterless constructor logic here] end
		}

		public override RegionalAreaEntity ToModel()
		{
			// % protected region % [Add any extra ToModel logic here] off begin
			// % protected region % [Add any extra ToModel logic here] end

			return new RegionalAreaEntity
			{
				Id = Id,
				Created = Created,
				Modified = Modified,
				Sa2code = Sa2code,
				Name = Name,
				Nonindigenouspopulation = Nonindigenouspopulation,
				Indigenouspopulation = Indigenouspopulation,
				Pph = Pph,
				Irsd = Irsd,
				Irsad = Irsad,
				Ieo = Ieo,
				Ier = Ier,
				GapScore = GapScore,
				Noservices = Noservices,
				Totalinvestment = Totalinvestment,
				// % protected region % [Add any extra model properties here] off begin
				// % protected region % [Add any extra model properties here] end
			};
		}

		public override ModelDto<RegionalAreaEntity> LoadModelData(RegionalAreaEntity model)
		{
			Id = model.Id;
			Created = model.Created;
			Modified = model.Modified;
			Sa2code = model.Sa2code;
			Name = model.Name;
			Nonindigenouspopulation = model.Nonindigenouspopulation;
			Indigenouspopulation = model.Indigenouspopulation;
			Pph = model.Pph;
			Irsd = model.Irsd;
			Irsad = model.Irsad;
			Ieo = model.Ieo;
			Ier = model.Ier;
			GapScore = model.GapScore;
			Noservices = model.Noservices;
			Totalinvestment = model.Totalinvestment;

			// % protected region % [Add any extra loading data logic here] off begin
			// % protected region % [Add any extra loading data logic here] end

			return this;
		}

		// % protected region % [Add any extra methods here] off begin
		// % protected region % [Add any extra methods here] end
	}
}