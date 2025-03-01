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
using System.Linq;
using System.Text;
using EntityObject.Enums;
using APITests.Classes;
using APITests.Attributes;
using APITests.Attributes.Validators;
using RestSharp;
using TestDataLib;

namespace APITests.EntityObjects.Models
{
	public class RegionalAreaEntity : BaseEntity
	{
		// 
		[Unique]
		[Required]
		[EntityAttribute]
		public String Sa2id { get; set; }
		// 
		[Required]
		[EntityAttribute]
		public String Sa3id { get; set; }
		// 
		[EntityAttribute]
		public String Sa3name { get; set; }
		// Potentially Preventable Hospitalisations
		[EntityAttribute]
		public int? Numofpph { get; set; }
		// 
		[EntityAttribute]
		public Double? Percentpphperday { get; set; }
		// 
		[EntityAttribute]
		public String Sa2name { get; set; }
		// 
		[EntityAttribute]
		public int? Indigenous { get; set; }
		// 
		[EntityAttribute]
		public int? Nonindigenous { get; set; }
		// The Index of Relative Socio-economic Disadvantage (IRSD) is a general socio-economic index that summarises a range of information about the economic and social conditions of people and households within an area. 
		[EntityAttribute]
		public int? Irsd { get; set; }
		// The Index of Relative Socio-economic Advantage and Disadvantage (IRSAD) summarises information about the economic and social conditions of people and households within an area, including both relative advantage and disadvantage measures.
		[EntityAttribute]
		public int? Irsad { get; set; }
		// The Index of Economic Resources (IER) focuses on the financial aspects of relative socio-economic advantage and disadvantage, by summarising variables related to income and wealth. 
		[EntityAttribute]
		public int? Ier { get; set; }
		// The Index of Education and Occupation (IEO) is designed to reflect the educational and occupational level of communities. 
		[EntityAttribute]
		public int? Ieo { get; set; }
		// 
		[EntityAttribute]
		public Double? GapScore { get; set; }
		// 
		[EntityAttribute]
		public int? Australianrank { get; set; }

		/// <summary>
		/// Outgoing one to many reference
		/// </summary>
		/// <see cref="Cis.Models.Services"/>
		public List<Guid> ServicesIds { get; set; }
		public ICollection<ServiceEntity> Servicess { get; set; }


		public RegionalAreaEntity()
		{
			EntityName = "RegionalAreaEntity";
			InitialiseReferences();
		}

		public RegionalAreaEntity(ConfigureOptions option)
		{
			Configure(option);
			InitialiseReferences();
		}

		public override void Configure(ConfigureOptions option)
		{
			switch (option)
			{
				case ConfigureOptions.CREATE_ATTRIBUTES_AND_REFERENCES:
					SetValidEntityAttributes();
					SetValidEntityAssociations();
					break;
				case ConfigureOptions.CREATE_ATTRIBUTES_ONLY:
					SetValidEntityAttributes();
					break;
				case ConfigureOptions.CREATE_REFERENCES_ONLY:
					SetValidEntityAssociations();
					break;
				case ConfigureOptions.CREATE_INVALID_ATTRIBUTES:
					break;
				case ConfigureOptions.CREATE_INVALID_ATTRIBUTES_VALID_REFERENCES:
					SetValidEntityAssociations();
					break;
			}
		}

		private void InitialiseReferences()
		{
		}

		public override (int min, int max) GetLengthValidatorMinMax(string attribute)
		{
			switch(attribute)
			{
				default:
					throw new Exception($"{attribute} does not exist or does not have a length validator");
			}
		}

		// % protected region % [Customize GetInvalidMutatedJsons here] off begin
		/// <summary>
		/// Returns a list of invalid/mutated jsons and expected errors. The expected errors are the errors that
		/// should be returned when trying to use the invalid/mutated jsons in a create api request.
		/// </summary>
		/// <returns></returns>
		public override IEnumerable<(string error, RestSharp.JsonObject jsonObject)> GetInvalidMutatedJsons()
		{
			return GetInvalidEntities<RegionalAreaEntity>()
				.Select(x => (x.error, x.entity.ToJson()));
		}
		// % protected region % [Customize GetInvalidMutatedJsons here] end

		public override Dictionary<string, string> ToDictionary()
		{
			var entityVar = new Dictionary<string, string>()
			{
				{"id" , Id.ToString()},
				{"sa2id" , Sa2id},
				{"sa3id" , Sa3id},
				{"sa3name" , Sa3name},
				{"numofpph" , Numofpph.ToString()},
				{"percentpphperday" , Percentpphperday.ToString()},
				{"sa2name" , Sa2name},
				{"indigenous" , Indigenous.ToString()},
				{"nonindigenous" , Nonindigenous.ToString()},
				{"irsd" , Irsd.ToString()},
				{"irsad" , Irsad.ToString()},
				{"ier" , Ier.ToString()},
				{"ieo" , Ieo.ToString()},
				{"gapScore" , GapScore.ToString()},
				{"australianrank" , Australianrank.ToString()},
			};


			return entityVar;
		}

		// % protected region % [Customize ToJson here] off begin
		public override RestSharp.JsonObject ToJson()
		{
			var entityVar = new RestSharp.JsonObject
			{
				["id"] = Id,
			};
			if(Sa2id != null) 
			{
				entityVar["sa2id"] = Sa2id.ToString();
			}
			if(Sa3id != null) 
			{
				entityVar["sa3id"] = Sa3id.ToString();
			}
			if(Sa3name != null) 
			{
				entityVar["sa3name"] = Sa3name.ToString();
			}
			if(Numofpph != null) 
			{
				entityVar["numofpph"] = Numofpph;
			}
			if(Percentpphperday != null) 
			{
				entityVar["percentpphperday"] = Percentpphperday.ToString();
			}
			if(Sa2name != null) 
			{
				entityVar["sa2name"] = Sa2name.ToString();
			}
			if(Indigenous != null) 
			{
				entityVar["indigenous"] = Indigenous;
			}
			if(Nonindigenous != null) 
			{
				entityVar["nonindigenous"] = Nonindigenous;
			}
			if(Irsd != null) 
			{
				entityVar["irsd"] = Irsd;
			}
			if(Irsad != null) 
			{
				entityVar["irsad"] = Irsad;
			}
			if(Ier != null) 
			{
				entityVar["ier"] = Ier;
			}
			if(Ieo != null) 
			{
				entityVar["ieo"] = Ieo;
			}
			if(GapScore != null) 
			{
				entityVar["gapScore"] = GapScore.ToString();
			}
			if(Australianrank != null) 
			{
				entityVar["australianrank"] = Australianrank;
			}
			if (ServicesIds != default)
			{
				entityVar["servicess"] = Servicess.Select(x => x.ToJson());
			}

			return entityVar;
		}
		// % protected region % [Customize ToJson here] end


		public override void SetReferences (Dictionary<string, ICollection<Guid>> entityReferences)
		{
			foreach (var (key, guidCollection) in entityReferences)
			{
				switch (key)
				{
					default:
						throw new Exception($"{key} not valid reference key");
				}
			}
		}

		private void SetOneReference (string key, Guid guid)
		{
			switch (key)
			{
				default:
					throw new Exception($"{key} not valid reference key");
			}
		}

		private void SetManyReference (string key, ICollection<Guid> guids)
		{
			switch (key)
			{
				default:
					throw new Exception($"{key} not valid reference key");
			}
		}

		public override List<Guid> GetManyToManyReferences (string reference)
		{
			switch (reference)
			{
				default:
					throw new Exception($"{reference} not valid many to many reference key");
			}
		}

		private List<RestSharp.JsonObject> FormatManyToManyJsonList(string key, List<Guid> values)
		{
			var manyToManyList = new List<RestSharp.JsonObject>();
			values?.ForEach(x => manyToManyList.Add(new RestSharp.JsonObject {[key] = x }));
			return manyToManyList;
		}

		/// <summary>
		/// Gets an entity that violates the validators of its attributes,
		/// if any attributes have a validator to violate.
		/// </summary>
		// TODO needs some warning if trying to get an invalid entity, and the entity
		// attributes don't actually have any validators to violate.
		public static RegionalAreaEntity GetEntity(bool isValid, string fixedValue = null)
		{
			if (isValid && !string.IsNullOrEmpty(fixedValue))
			{
				return GetValidEntity(fixedValue);
			}
			return isValid ? GetValidEntity() : GetInvalidEntity<RegionalAreaEntity>().entity;
		}

		/// <summary>
		/// Created parents entities and set the association id's of this entity
		/// to those of the created parents.
		/// </summary>
		private void SetValidEntityAssociations()
		{
		}

		/// <summary>
		/// Gets an entity with attributes that conform to any attribute validators.
		/// </summary>
		private void SetValidEntityAttributes()
		{
			// % protected region % [Override generated entity attributes here] off begin
			PopulateAttributes();
			// % protected region % [Override generated entity attributes here] end
		}

		/// <summary>
		/// Gets an entity with attributes that conform to any attribute validators.
		/// </summary>
		public static RegionalAreaEntity GetValidEntity(string fixedStrValue = null)
		{
			var regionalAreaEntity = new RegionalAreaEntity
			{
			};
			regionalAreaEntity.PopulateAttributes();
			// % protected region % [Customize valid entity before return here] off begin
			// % protected region % [Customize valid entity before return here] end

			return regionalAreaEntity;
		}

		public override Guid Save()
		{
			return SaveThroughGraphQl(this);
		}
	}
}
