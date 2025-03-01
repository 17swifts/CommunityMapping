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
import moment from 'moment';
import { action, observable } from 'mobx';
import { Model, IModelAttributes, attribute, entity } from 'Models/Model';
import * as Models from 'Models/Entities';
import * as Validators from 'Validators';
import { CRUD } from '../CRUDOptions';
import * as AttrUtils from "Util/AttributeUtils";
import { IAcl } from 'Models/Security/IAcl';
import {
	makeFetchManyToManyFunc,
	makeJoinEqualsFunc,
	makeEnumFetchFunction,
	getCreatedModifiedCrudOptions,
} from 'Util/EntityUtils';
import { VisitorsServiceEntity } from 'Models/Security/Acl/VisitorsServiceEntity';
import { ServiceCommissioningBodyServiceEntity } from 'Models/Security/Acl/ServiceCommissioningBodyServiceEntity';
import { AdminServiceEntity } from 'Models/Security/Acl/AdminServiceEntity';
import * as Enums from '../Enums';
import { EntityFormMode } from 'Views/Components/Helpers/Common';
import {SuperAdministratorScheme} from '../Security/Acl/SuperAdministratorScheme';
// % protected region % [Add any further imports here] off begin
// % protected region % [Add any further imports here] end

export interface IServiceEntityAttributes extends IModelAttributes {
	name: string;
	description: string;
	servicetype: Enums.servicetype;
	category: Enums.categories;
	active: boolean;
	noservicedays: number;
	investment: number;
	startdate: Date;
	enddate: Date;
	gender: Enums.gender;
	agemin: number;
	agemax: number;

	regionalAreaId?: string;
	regionalArea?: Models.RegionalAreaEntity | Models.IRegionalAreaEntityAttributes;
	serviceCommissioningBodiess: Array<Models.ServiceCommissioningBodiesServices | Models.IServiceCommissioningBodiesServicesAttributes>;
	// % protected region % [Add any custom attributes to the interface here] off begin
	// % protected region % [Add any custom attributes to the interface here] end
}

// % protected region % [Customise your entity metadata here] off begin
@entity('ServiceEntity', 'Service')
// % protected region % [Customise your entity metadata here] end
export default class ServiceEntity extends Model implements IServiceEntityAttributes {
	public static acls: IAcl[] = [
		new SuperAdministratorScheme(),
		new VisitorsServiceEntity(),
		new ServiceCommissioningBodyServiceEntity(),
		new AdminServiceEntity(),
		// % protected region % [Add any further ACL entries here] off begin
		// % protected region % [Add any further ACL entries here] end
	];

	/**
	 * Fields to exclude from the JSON serialization in create operations.
	 */
	public static excludeFromCreate: string[] = [
		// % protected region % [Add any custom create exclusions here] off begin
		// % protected region % [Add any custom create exclusions here] end
	];

	/**
	 * Fields to exclude from the JSON serialization in update operations.
	 */
	public static excludeFromUpdate: string[] = [
		// % protected region % [Add any custom update exclusions here] off begin
		// % protected region % [Add any custom update exclusions here] end
	];

	// % protected region % [Modify props to the crud options here for attribute 'Name'] off begin
	@Validators.Required()
	@observable
	@attribute()
	@CRUD({
		name: 'Name',
		displayType: 'textfield',
		order: 10,
		headerColumn: true,
		searchable: true,
		searchFunction: 'like',
		searchTransform: AttrUtils.standardiseString,
	})
	public name: string;
	// % protected region % [Modify props to the crud options here for attribute 'Name'] end

	// % protected region % [Modify props to the crud options here for attribute 'Description'] off begin
	@observable
	@attribute()
	@CRUD({
		name: 'Description',
		displayType: 'textfield',
		order: 20,
		headerColumn: true,
		searchable: true,
		searchFunction: 'like',
		searchTransform: AttrUtils.standardiseString,
	})
	public description: string;
	// % protected region % [Modify props to the crud options here for attribute 'Description'] end

	// % protected region % [Modify props to the crud options here for attribute 'ServiceType'] off begin
	/**
	 * Whether the service is permanent or temporary 
	 */
	@Validators.Required()
	@observable
	@attribute()
	@CRUD({
		name: 'ServiceType',
		displayType: 'enum-combobox',
		order: 30,
		headerColumn: true,
		searchable: true,
		searchFunction: 'equal',
		searchTransform: (attr: string) => {
			return AttrUtils.standardiseEnum(attr, Enums.servicetypeOptions);
		},
		enumResolveFunction: makeEnumFetchFunction(Enums.servicetypeOptions),
		displayFunction: (attribute: Enums.servicetype) => Enums.servicetypeOptions[attribute],
	})
	public servicetype: Enums.servicetype;
	// % protected region % [Modify props to the crud options here for attribute 'ServiceType'] end

	// % protected region % [Modify props to the crud options here for attribute 'Category'] off begin
	@observable
	@attribute()
	@CRUD({
		name: 'Category',
		displayType: 'enum-combobox',
		order: 40,
		headerColumn: true,
		searchable: true,
		searchFunction: 'equal',
		searchTransform: (attr: string) => {
			return AttrUtils.standardiseEnum(attr, Enums.categoriesOptions);
		},
		enumResolveFunction: makeEnumFetchFunction(Enums.categoriesOptions),
		displayFunction: (attribute: Enums.categories) => Enums.categoriesOptions[attribute],
	})
	public category: Enums.categories;
	// % protected region % [Modify props to the crud options here for attribute 'Category'] end

	// % protected region % [Modify props to the crud options here for attribute 'Active'] off begin
	/**
	 * Whether the service is currently active
	 */
	@Validators.Required()
	@observable
	@attribute()
	@CRUD({
		name: 'Active',
		displayType: 'checkbox',
		order: 50,
		headerColumn: true,
		searchable: true,
		searchFunction: 'equal',
		searchTransform: AttrUtils.standardiseBoolean,
		displayFunction: attr => attr ? 'True' : 'False',
	})
	public active: boolean = false;
	// % protected region % [Modify props to the crud options here for attribute 'Active'] end

	// % protected region % [Modify props to the crud options here for attribute 'NoServiceDays'] off begin
	/**
	 * Number of days the service is operating
	 */
	@Validators.Integer()
	@observable
	@attribute()
	@CRUD({
		name: 'NoServiceDays',
		displayType: 'textfield',
		order: 60,
		searchable: true,
		searchFunction: 'equal',
		searchTransform: AttrUtils.standardiseInteger,
	})
	public noservicedays: number;
	// % protected region % [Modify props to the crud options here for attribute 'NoServiceDays'] end

	// % protected region % [Modify props to the crud options here for attribute 'Investment'] off begin
	@Validators.Numeric()
	@observable
	@attribute()
	@CRUD({
		name: 'Investment',
		displayType: 'textfield',
		order: 70,
		searchable: true,
		searchFunction: 'equal',
		searchTransform: AttrUtils.standardiseFloat,
	})
	public investment: number;
	// % protected region % [Modify props to the crud options here for attribute 'Investment'] end

	// % protected region % [Modify props to the crud options here for attribute 'StartDate'] off begin
	/**
	 * Start data of the service
	 */
	@Validators.Required()
	@observable
	@attribute()
	@CRUD({
		name: 'StartDate',
		displayType: 'datepicker',
		order: 80,
		searchable: true,
		searchFunction: 'equal',
		searchTransform: AttrUtils.standardiseDate,
	})
	public startdate: Date;
	// % protected region % [Modify props to the crud options here for attribute 'StartDate'] end

	// % protected region % [Modify props to the crud options here for attribute 'EndDate'] off begin
	/**
	 * End dat of the service
	 */
	@observable
	@attribute()
	@CRUD({
		name: 'EndDate',
		displayType: 'datepicker',
		order: 90,
		searchable: true,
		searchFunction: 'equal',
		searchTransform: AttrUtils.standardiseDate,
	})
	public enddate: Date;
	// % protected region % [Modify props to the crud options here for attribute 'EndDate'] end

	// % protected region % [Modify props to the crud options here for attribute 'Gender'] off begin
	@observable
	@attribute()
	@CRUD({
		name: 'Gender',
		displayType: 'enum-combobox',
		order: 100,
		searchable: true,
		searchFunction: 'equal',
		searchTransform: (attr: string) => {
			return AttrUtils.standardiseEnum(attr, Enums.genderOptions);
		},
		enumResolveFunction: makeEnumFetchFunction(Enums.genderOptions),
		displayFunction: (attribute: Enums.gender) => Enums.genderOptions[attribute],
	})
	public gender: Enums.gender;
	// % protected region % [Modify props to the crud options here for attribute 'Gender'] end

	// % protected region % [Modify props to the crud options here for attribute 'AgeMin'] off begin
	@Validators.Integer()
	@observable
	@attribute()
	@CRUD({
		name: 'AgeMin',
		displayType: 'textfield',
		order: 110,
		searchable: true,
		searchFunction: 'equal',
		searchTransform: AttrUtils.standardiseInteger,
	})
	public agemin: number;
	// % protected region % [Modify props to the crud options here for attribute 'AgeMin'] end

	// % protected region % [Modify props to the crud options here for attribute 'AgeMax'] off begin
	@Validators.Integer()
	@observable
	@attribute()
	@CRUD({
		name: 'AgeMax',
		displayType: 'textfield',
		order: 120,
		searchable: true,
		searchFunction: 'equal',
		searchTransform: AttrUtils.standardiseInteger,
	})
	public agemax: number;
	// % protected region % [Modify props to the crud options here for attribute 'AgeMax'] end

	@observable
	@attribute()
	@CRUD({
		// % protected region % [Modify props to the crud options here for reference 'Regional area'] off begin
		name: 'Regional area',
		displayType: 'reference-combobox',
		order: 130,
		referenceTypeFunc: () => Models.RegionalAreaEntity,
		// % protected region % [Modify props to the crud options here for reference 'Regional area'] end
	})
	public regionalAreaId?: string;
	@observable
	@attribute({isReference: true})
	public regionalArea: Models.RegionalAreaEntity;

	@observable
	@attribute({isReference: true})
	@CRUD({
		// % protected region % [Modify props to the crud options here for reference 'Service Commissioning Bodies'] off begin
		name: 'Service Commissioning Bodies',
		displayType: 'reference-multicombobox',
		order: 140,
		isJoinEntity: true,
		referenceTypeFunc: () => Models.ServiceCommissioningBodiesServices,
		optionEqualFunc: makeJoinEqualsFunc('serviceCommissioningBodiesId'),
		referenceResolveFunction: makeFetchManyToManyFunc({
			entityName: 'serviceEntity',
			oppositeEntityName: 'serviceCommissioningBodyEntity',
			relationName: 'services',
			relationOppositeName: 'serviceCommissioningBodies',
			entity: () => Models.ServiceEntity,
			joinEntity: () => Models.ServiceCommissioningBodiesServices,
			oppositeEntity: () => Models.ServiceCommissioningBodyEntity,
		}),
		// % protected region % [Modify props to the crud options here for reference 'Service Commissioning Bodies'] end
	})
	public serviceCommissioningBodiess: Models.ServiceCommissioningBodiesServices[] = [];

	// % protected region % [Add any custom attributes to the model here] off begin
	// % protected region % [Add any custom attributes to the model here] end

	// eslint-disable-next-line @typescript-eslint/no-useless-constructor
	constructor(attributes?: Partial<IServiceEntityAttributes>) {
		// % protected region % [Add any extra constructor logic before calling super here] off begin
		// % protected region % [Add any extra constructor logic before calling super here] end

		super(attributes);

		// % protected region % [Add any extra constructor logic after calling super here] off begin
		// % protected region % [Add any extra constructor logic after calling super here] end
	}

	/**
	 * Assigns fields from a passed in JSON object to the fields in this model.
	 * Any reference objects that are passed in are converted to models if they are not already.
	 * This function is called from the constructor to assign the initial fields.
	 */
	@action
	public assignAttributes(attributes?: Partial<IServiceEntityAttributes>) {
		// % protected region % [Override assign attributes here] off begin
		super.assignAttributes(attributes);

		if (attributes) {
			if (attributes.name !== undefined) {
				this.name = attributes.name;
			}
			if (attributes.description !== undefined) {
				this.description = attributes.description;
			}
			if (attributes.servicetype !== undefined) {
				this.servicetype = attributes.servicetype;
			}
			if (attributes.category !== undefined) {
				this.category = attributes.category;
			}
			if (attributes.active !== undefined) {
				this.active = attributes.active;
			}
			if (attributes.noservicedays !== undefined) {
				this.noservicedays = attributes.noservicedays;
			}
			if (attributes.investment !== undefined) {
				this.investment = attributes.investment;
			}
			if (attributes.startdate !== undefined) {
				if (attributes.startdate === null) {
					this.startdate = attributes.startdate;
				} else {
					this.startdate = moment(attributes.startdate).toDate();
				}
			}
			if (attributes.enddate !== undefined) {
				if (attributes.enddate === null) {
					this.enddate = attributes.enddate;
				} else {
					this.enddate = moment(attributes.enddate).toDate();
				}
			}
			if (attributes.gender !== undefined) {
				this.gender = attributes.gender;
			}
			if (attributes.agemin !== undefined) {
				this.agemin = attributes.agemin;
			}
			if (attributes.agemax !== undefined) {
				this.agemax = attributes.agemax;
			}
			if (attributes.regionalAreaId !== undefined) {
				this.regionalAreaId = attributes.regionalAreaId;
			}
			if (attributes.regionalArea !== undefined) {
				if (attributes.regionalArea === null) {
					this.regionalArea = attributes.regionalArea;
				} else {
					if (attributes.regionalArea instanceof Models.RegionalAreaEntity) {
						this.regionalArea = attributes.regionalArea;
						this.regionalAreaId = attributes.regionalArea.id;
					} else {
						this.regionalArea = new Models.RegionalAreaEntity(attributes.regionalArea);
						this.regionalAreaId = this.regionalArea.id;
					}
				}
			}
			if (attributes.serviceCommissioningBodiess !== undefined && Array.isArray(attributes.serviceCommissioningBodiess)) {
				for (const model of attributes.serviceCommissioningBodiess) {
					if (model instanceof Models.ServiceCommissioningBodiesServices) {
						this.serviceCommissioningBodiess.push(model);
					} else {
						this.serviceCommissioningBodiess.push(new Models.ServiceCommissioningBodiesServices(model));
					}
				}
			}
			// % protected region % [Override assign attributes here] end

			// % protected region % [Add any extra assign attributes logic here] off begin
			// % protected region % [Add any extra assign attributes logic here] end
		}
	}

	/**
	 * Additional fields that are added to GraphQL queries when using the
	 * the managed model APIs.
	 */
	// % protected region % [Customize Default Expands here] off begin
	public defaultExpands = `
		serviceCommissioningBodiess {
			${Models.ServiceCommissioningBodiesServices.getAttributes().join('\n')}
			serviceCommissioningBodies {
				${Models.ServiceCommissioningBodyEntity.getAttributes().join('\n')}
				${Models.ServiceCommissioningBodyEntity.getFiles().map(f => f.name).join('\n')}
			}
		}
		regionalArea {
			${Models.RegionalAreaEntity.getAttributes().join('\n')}
		}
	`;
	// % protected region % [Customize Default Expands here] end

	/**
	 * The save method that is called from the admin CRUD components.
	 */
	// % protected region % [Customize Save From Crud here] off begin
	public async saveFromCrud(formMode: EntityFormMode) {
		const relationPath = {
			serviceCommissioningBodiess: {},
		};
		return this.save(
			relationPath,
			{
				options: [
					{
						key: 'mergeReferences',
						graphQlType: '[String]',
						value: [
							'serviceCommissioningBodiess',
						]
					},
				],
			}
		);
	}
	// % protected region % [Customize Save From Crud here] end

	/**
	 * Returns the string representation of this entity to display on the UI.
	 */
	public getDisplayName() {
		// % protected region % [Customise the display name for this entity] off begin
		return this.id;
		// % protected region % [Customise the display name for this entity] end
	}


	// % protected region % [Add any further custom model features here] off begin
	// % protected region % [Add any further custom model features here] end
}

// % protected region % [Modify the create and modified CRUD attributes here] off begin
/*
 * Retrieve the created and modified CRUD attributes for defining the CRUD views and decorate the class with them.
 */
const [ createdAttr, modifiedAttr ] = getCreatedModifiedCrudOptions();
CRUD(createdAttr)(ServiceEntity.prototype, 'created');
CRUD(modifiedAttr)(ServiceEntity.prototype, 'modified');
// % protected region % [Modify the create and modified CRUD attributes here] end
