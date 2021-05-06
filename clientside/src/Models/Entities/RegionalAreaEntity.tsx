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
import { action, observable } from 'mobx';
import { Model, IModelAttributes, attribute, entity } from 'Models/Model';
import * as Models from 'Models/Entities';
import * as Validators from 'Validators';
import { CRUD } from '../CRUDOptions';
import * as AttrUtils from "Util/AttributeUtils";
import { IAcl } from 'Models/Security/IAcl';
import {
	makeFetchOneToManyFunc,
	getCreatedModifiedCrudOptions,
} from 'Util/EntityUtils';
import { AdminRegionalAreaEntity } from 'Models/Security/Acl/AdminRegionalAreaEntity';
import { VisitorsRegionalAreaEntity } from 'Models/Security/Acl/VisitorsRegionalAreaEntity';
import { ServiceCommissioningBodyRegionalAreaEntity } from 'Models/Security/Acl/ServiceCommissioningBodyRegionalAreaEntity';
import { EntityFormMode } from 'Views/Components/Helpers/Common';
import { TimelineModel } from 'Timelines/TimelineModel';
import {SuperAdministratorScheme} from '../Security/Acl/SuperAdministratorScheme';
// % protected region % [Add any further imports here] off begin
// % protected region % [Add any further imports here] end

export interface IRegionalAreaEntityAttributes extends IModelAttributes {
	name: string;
	nonindigenouspopulation: number;
	indigenouspopulation: number;
	pph: number;
	irsd: number;
	irsad: number;
	ieo: number;
	ier: number;
	gapScore: number;
	noservices: number;
	totalinvestment: number;

	servicess: Array<Models.ServiceEntity | Models.IServiceEntityAttributes>;
	loggedEvents: Array<Models.RegionalAreaTimelineEventsEntity | Models.IRegionalAreaTimelineEventsEntityAttributes>;
	// % protected region % [Add any custom attributes to the interface here] off begin
	// % protected region % [Add any custom attributes to the interface here] end
}

// % protected region % [Customise your entity metadata here] off begin
@entity('RegionalAreaEntity', 'Regional area')
// % protected region % [Customise your entity metadata here] end
export default class RegionalAreaEntity extends Model implements IRegionalAreaEntityAttributes, TimelineModel  {
	public static acls: IAcl[] = [
		new SuperAdministratorScheme(),
		new AdminRegionalAreaEntity(),
		new VisitorsRegionalAreaEntity(),
		new ServiceCommissioningBodyRegionalAreaEntity(),
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
	@Validators.Unique()
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

	// % protected region % [Modify props to the crud options here for attribute 'NonIndigenousPopulation'] off begin
	@Validators.Integer()
	@observable
	@attribute()
	@CRUD({
		name: 'NonIndigenousPopulation',
		displayType: 'textfield',
		order: 20,
		headerColumn: true,
		searchable: true,
		searchFunction: 'equal',
		searchTransform: AttrUtils.standardiseInteger,
	})
	public nonindigenouspopulation: number;
	// % protected region % [Modify props to the crud options here for attribute 'NonIndigenousPopulation'] end

	// % protected region % [Modify props to the crud options here for attribute 'IndigenousPopulation'] off begin
	@Validators.Integer()
	@observable
	@attribute()
	@CRUD({
		name: 'IndigenousPopulation',
		displayType: 'textfield',
		order: 30,
		headerColumn: true,
		searchable: true,
		searchFunction: 'equal',
		searchTransform: AttrUtils.standardiseInteger,
	})
	public indigenouspopulation: number;
	// % protected region % [Modify props to the crud options here for attribute 'IndigenousPopulation'] end

	// % protected region % [Modify props to the crud options here for attribute 'PPH'] off begin
	/**
	 * Potentially Preventable Hospitalisations
	 */
	@Validators.Integer()
	@observable
	@attribute()
	@CRUD({
		name: 'PPH',
		displayType: 'textfield',
		order: 40,
		headerColumn: true,
		searchable: true,
		searchFunction: 'equal',
		searchTransform: AttrUtils.standardiseInteger,
	})
	public pph: number;
	// % protected region % [Modify props to the crud options here for attribute 'PPH'] end

	// % protected region % [Modify props to the crud options here for attribute 'IRSD'] off begin
	/**
	 * The Index of Relative Socio-economic Disadvantage (IRSD) is a general socio-economic index that summarises a range of information about the economic and social conditions of people and households within an area. 
	 */
	@Validators.Integer()
	@observable
	@attribute()
	@CRUD({
		name: 'IRSD',
		displayType: 'textfield',
		order: 50,
		headerColumn: true,
		searchable: true,
		searchFunction: 'equal',
		searchTransform: AttrUtils.standardiseInteger,
	})
	public irsd: number;
	// % protected region % [Modify props to the crud options here for attribute 'IRSD'] end

	// % protected region % [Modify props to the crud options here for attribute 'IRSAD'] off begin
	/**
	 * The Index of Relative Socio-economic Advantage and Disadvantage (IRSAD) summarises information about the economic and social conditions of people and households within an area, including both relative advantage and disadvantage measures.
	 */
	@Validators.Integer()
	@observable
	@attribute()
	@CRUD({
		name: 'IRSAD',
		displayType: 'textfield',
		order: 60,
		searchable: true,
		searchFunction: 'equal',
		searchTransform: AttrUtils.standardiseInteger,
	})
	public irsad: number;
	// % protected region % [Modify props to the crud options here for attribute 'IRSAD'] end

	// % protected region % [Modify props to the crud options here for attribute 'IEO'] off begin
	/**
	 * The Index of Education and Occupation (IEO) is designed to reflect the educational and occupational level of communities. 
	 */
	@Validators.Integer()
	@observable
	@attribute()
	@CRUD({
		name: 'IEO',
		displayType: 'textfield',
		order: 70,
		searchable: true,
		searchFunction: 'equal',
		searchTransform: AttrUtils.standardiseInteger,
	})
	public ieo: number;
	// % protected region % [Modify props to the crud options here for attribute 'IEO'] end

	// % protected region % [Modify props to the crud options here for attribute 'IER'] off begin
	/**
	 * The Index of Economic Resources (IER) focuses on the financial aspects of relative socio-economic advantage and disadvantage, by summarising variables related to income and wealth. 
	 */
	@Validators.Integer()
	@observable
	@attribute()
	@CRUD({
		name: 'IER',
		displayType: 'textfield',
		order: 80,
		searchable: true,
		searchFunction: 'equal',
		searchTransform: AttrUtils.standardiseInteger,
	})
	public ier: number;
	// % protected region % [Modify props to the crud options here for attribute 'IER'] end

	// % protected region % [Modify props to the crud options here for attribute 'Gap Score'] off begin
	@Validators.Numeric()
	@observable
	@attribute()
	@CRUD({
		name: 'Gap Score',
		displayType: 'textfield',
		order: 90,
		searchable: true,
		searchFunction: 'equal',
		searchTransform: AttrUtils.standardiseFloat,
	})
	public gapScore: number;
	// % protected region % [Modify props to the crud options here for attribute 'Gap Score'] end

	// % protected region % [Modify props to the crud options here for attribute 'NoServices'] off begin
	@Validators.Integer()
	@observable
	@attribute()
	@CRUD({
		name: 'NoServices',
		displayType: 'textfield',
		order: 100,
		searchable: true,
		searchFunction: 'equal',
		searchTransform: AttrUtils.standardiseInteger,
	})
	public noservices: number;
	// % protected region % [Modify props to the crud options here for attribute 'NoServices'] end

	// % protected region % [Modify props to the crud options here for attribute 'TotalInvestment'] off begin
	@Validators.Numeric()
	@observable
	@attribute()
	@CRUD({
		name: 'TotalInvestment',
		displayType: 'textfield',
		order: 110,
		searchable: true,
		searchFunction: 'equal',
		searchTransform: AttrUtils.standardiseFloat,
	})
	public totalinvestment: number;
	// % protected region % [Modify props to the crud options here for attribute 'TotalInvestment'] end

	@observable
	@attribute({isReference: true})
	@CRUD({
		// % protected region % [Modify props to the crud options here for reference 'Services'] off begin
		name: "Servicess",
		displayType: 'reference-multicombobox',
		order: 120,
		referenceTypeFunc: () => Models.ServiceEntity,
		referenceResolveFunction: makeFetchOneToManyFunc({
			relationName: 'servicess',
			oppositeEntity: () => Models.ServiceEntity,
		}),
		// % protected region % [Modify props to the crud options here for reference 'Services'] end
	})
	public servicess: Models.ServiceEntity[] = [];

	@observable
	@attribute({isReference: true})
	@CRUD({
		// % protected region % [Modify props to the crud options here for reference 'Logged Event'] off begin
		name: "Logged Events",
		displayType: 'hidden',
		order: 130,
		referenceTypeFunc: () => Models.RegionalAreaTimelineEventsEntity,
		referenceResolveFunction: makeFetchOneToManyFunc({
			relationName: 'loggedEvents',
			oppositeEntity: () => Models.RegionalAreaTimelineEventsEntity,
		}),
		// % protected region % [Modify props to the crud options here for reference 'Logged Event'] end
	})
	public loggedEvents: Models.RegionalAreaTimelineEventsEntity[] = [];

	// % protected region % [Add any custom attributes to the model here] off begin
	// % protected region % [Add any custom attributes to the model here] end

	// eslint-disable-next-line @typescript-eslint/no-useless-constructor
	constructor(attributes?: Partial<IRegionalAreaEntityAttributes>) {
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
	public assignAttributes(attributes?: Partial<IRegionalAreaEntityAttributes>) {
		// % protected region % [Override assign attributes here] off begin
		super.assignAttributes(attributes);

		if (attributes) {
			if (attributes.name !== undefined) {
				this.name = attributes.name;
			}
			if (attributes.nonindigenouspopulation !== undefined) {
				this.nonindigenouspopulation = attributes.nonindigenouspopulation;
			}
			if (attributes.indigenouspopulation !== undefined) {
				this.indigenouspopulation = attributes.indigenouspopulation;
			}
			if (attributes.pph !== undefined) {
				this.pph = attributes.pph;
			}
			if (attributes.irsd !== undefined) {
				this.irsd = attributes.irsd;
			}
			if (attributes.irsad !== undefined) {
				this.irsad = attributes.irsad;
			}
			if (attributes.ieo !== undefined) {
				this.ieo = attributes.ieo;
			}
			if (attributes.ier !== undefined) {
				this.ier = attributes.ier;
			}
			if (attributes.gapScore !== undefined) {
				this.gapScore = attributes.gapScore;
			}
			if (attributes.noservices !== undefined) {
				this.noservices = attributes.noservices;
			}
			if (attributes.totalinvestment !== undefined) {
				this.totalinvestment = attributes.totalinvestment;
			}
			if (attributes.servicess !== undefined && Array.isArray(attributes.servicess)) {
				for (const model of attributes.servicess) {
					if (model instanceof Models.ServiceEntity) {
						this.servicess.push(model);
					} else {
						this.servicess.push(new Models.ServiceEntity(model));
					}
				}
			}
			if (attributes.loggedEvents !== undefined && Array.isArray(attributes.loggedEvents)) {
				for (const model of attributes.loggedEvents) {
					if (model instanceof Models.RegionalAreaTimelineEventsEntity) {
						this.loggedEvents.push(model);
					} else {
						this.loggedEvents.push(new Models.RegionalAreaTimelineEventsEntity(model));
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
		servicess {
			${Models.ServiceEntity.getAttributes().join('\n')}
		}
		loggedEvents {
			${Models.RegionalAreaTimelineEventsEntity.getAttributes().join('\n')}
		}
	`;
	// % protected region % [Customize Default Expands here] end

	/**
	 * The save method that is called from the admin CRUD components.
	 */
	// % protected region % [Customize Save From Crud here] off begin
	public async saveFromCrud(formMode: EntityFormMode) {
		const relationPath = {
			servicess: {},
			loggedEvents: {},
		};
		return this.save(
			relationPath,
			{
				options: [
					{
						key: 'mergeReferences',
						graphQlType: '[String]',
						value: [
							'servicess',
							'loggedEvents',
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

	/**
	 * Gets the timeline event entity type for this form.
	 */
	public getTimelineEventEntity = () => {
		// % protected region % [Modify the getTimelineEventEntity here] off begin
		return Models.RegionalAreaTimelineEventsEntity;
		// % protected region % [Modify the getTimelineEventEntity here] end
	}


	// % protected region % [Add any further custom model features here] off begin
	// % protected region % [Add any further custom model features here] end
}

// % protected region % [Modify the create and modified CRUD attributes here] off begin
/*
 * Retrieve the created and modified CRUD attributes for defining the CRUD views and decorate the class with them.
 */
const [ createdAttr, modifiedAttr ] = getCreatedModifiedCrudOptions();
CRUD(createdAttr)(RegionalAreaEntity.prototype, 'created');
CRUD(modifiedAttr)(RegionalAreaEntity.prototype, 'modified');
// % protected region % [Modify the create and modified CRUD attributes here] end
