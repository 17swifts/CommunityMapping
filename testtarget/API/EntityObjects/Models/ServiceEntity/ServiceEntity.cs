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
	public class ServiceEntity : BaseEntity
	{
		// 
		[Required]
		[EntityAttribute]
		public String Name { get; set; }
		// Whether the service is permanent or temporary 
		[Required]
		[EntityAttribute]
		public Servicetype Servicetype { get; set; }
		// 
		[Required]
		[EntityAttribute]
		public Categories Category { get; set; }
		// Whether the service is currently active
		[Required]
		[EntityAttribute]
		public Boolean? Active { get; set; }
		// Number of days the service is operating
		[EntityAttribute]
		public int? Noservicedays { get; set; }
		// 
		[EntityAttribute]
		public Double? Investment { get; set; }
		// Start data of the service
		[Required]
		[EntityAttribute]
		public DateTime? Startdate { get; set; }
		// End dat of the service
		[EntityAttribute]
		public DateTime? Enddate { get; set; }

		/// <summary>
		/// Incoming one to many reference
		/// </summary>
		/// <see cref="Cis.Models.RegionalArea"/>
		public Guid? RegionalAreaId { get; set; }

		/// <summary>
		/// Incoming many to many reference
		/// </summary>
		/// <see cref="Cis.Models.ServiceCommissioningBodies"/>
		public List<Guid> ServiceCommissioningBodiesIds { get; set; }
		public ICollection<ServiceCommissioningBodiesServices> ServiceCommissioningBodiess { get; set; }


		public ServiceEntity()
		{
			EntityName = "ServiceEntity";
			InitialiseReferences();
		}

		public ServiceEntity(ConfigureOptions option)
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
			References.Add(new Reference
			{
				EntityName = "RegionalAreaEntity",
				OppositeName = "RegionalArea",
				Name = "Services",
				Optional = true,
				Type = ReferenceType.ONE,
				OppositeType = ReferenceType.MANY
			});
			References.Add(new Reference
			{
				EntityName = "ServiceCommissioningBodyEntity",
				OppositeName = "ServiceCommissioningBodies",
				Name = "Services",
				Optional = true,
				Type = ReferenceType.MANY,
				OppositeType = ReferenceType.MANY
			});
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
			return GetInvalidEntities<ServiceEntity>()
				.Select(x => (x.error, x.entity.ToJson()));
		}
		// % protected region % [Customize GetInvalidMutatedJsons here] end

		public override Dictionary<string, string> ToDictionary()
		{
			var entityVar = new Dictionary<string, string>()
			{
				{"id" , Id.ToString()},
				{"name" , Name},
				{"servicetype" , Servicetype.ToString()},
				{"category" , Category.ToString()},
				{"active" , Active.ToString()},
				{"noservicedays" , Noservicedays.ToString()},
				{"investment" , Investment.ToString()},
				{"startdate" ,((DateTime)Startdate).ToIsoString()},
				{"enddate" ,((DateTime)Enddate).ToIsoString()},
			};

			if (RegionalAreaId != default)
			{
				entityVar["regionalAreaId"] = RegionalAreaId.ToString();
			}

			return entityVar;
		}

		// % protected region % [Customize ToJson here] off begin
		public override RestSharp.JsonObject ToJson()
		{
			var entityVar = new RestSharp.JsonObject
			{
				["id"] = Id,
			};
			if(Name != null) 
			{
				entityVar["name"] = Name.ToString();
			}
			if(Servicetype != null) 
			{
				entityVar["servicetype"] = Servicetype.ToString();
			}
			if(Category != null) 
			{
				entityVar["category"] = Category.ToString();
			}
			if(Active != null) 
			{
				entityVar["active"] = Active.ToString();
			}
			if(Noservicedays != null) 
			{
				entityVar["noservicedays"] = Noservicedays;
			}
			if(Investment != null) 
			{
				entityVar["investment"] = Investment.ToString();
			}
			if(Startdate != null) 
			{
				entityVar["startdate"] = Startdate?.ToString("s");
			}
			if(Enddate != null) 
			{
				entityVar["enddate"] = Enddate?.ToString("s");
			}
			if (RegionalAreaId  != default)
			{
				entityVar["regionalAreaId"] = RegionalAreaId.ToString();
			}
			if (ServiceCommissioningBodiesIds != default)
			{
				entityVar["serviceCommissioningBodiess"] = FormatManyToManyJsonList("serviceCommissioningBodiesId", ServiceCommissioningBodiesIds);
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
					case "RegionalAreaId":
						ReferenceIdDictionary.Add("RegionalAreaId", guidCollection.FirstOrDefault());
						SetOneReference(key, guidCollection.FirstOrDefault());
						break;
					case "ServiceCommissioningBodiesId":
						SetManyReference(key, guidCollection);
						break;
					default:
						throw new Exception($"{key} not valid reference key");
				}
			}
		}

		private void SetOneReference (string key, Guid guid)
		{
			switch (key)
			{
				case "RegionalAreaId":
					RegionalAreaId = guid;
					break;
				default:
					throw new Exception($"{key} not valid reference key");
			}
		}

		private void SetManyReference (string key, ICollection<Guid> guids)
		{
			switch (key)
			{
				case "ServiceCommissioningBodiesId":
					ServiceCommissioningBodiesIds = guids.ToList();
					ServiceCommissioningBodiess  = new List<ServiceCommissioningBodiesServices>{};
					foreach(var ServiceCommissioningBodiesId in guids)
					{
						ServiceCommissioningBodiess.Add
						(
							new ServiceCommissioningBodiesServices()
							{
								ServicesId = Id,
								ServiceCommissioningBodiesId = ServiceCommissioningBodiesId,
							}
						);
					}
					break;
				default:
					throw new Exception($"{key} not valid reference key");
			}
		}

		public override List<Guid> GetManyToManyReferences (string reference)
		{
			switch (reference)
			{
				case "ServiceCommissioningBodiess":
					return ServiceCommissioningBodiesIds;
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
		public static ServiceEntity GetEntity(bool isValid, string fixedValue = null)
		{
			if (isValid && !string.IsNullOrEmpty(fixedValue))
			{
				return GetValidEntity(fixedValue);
			}
			return isValid ? GetValidEntity() : GetInvalidEntity<ServiceEntity>().entity;
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
		public static ServiceEntity GetValidEntity(string fixedStrValue = null)
		{
			var serviceEntity = new ServiceEntity
			{
			};
			serviceEntity.PopulateAttributes();
			// % protected region % [Customize valid entity before return here] off begin
			// % protected region % [Customize valid entity before return here] end

			return serviceEntity;
		}

		public override Guid Save()
		{
			return SaveThroughGraphQl(this);
		}
	}
}
