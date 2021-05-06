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
import * as React from 'react';
import { SERVER_URL } from 'Constants';
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
	getCreatedModifiedCrudOptions,
} from 'Util/EntityUtils';
import { AdminServiceCommissioningBodyEntity } from 'Models/Security/Acl/AdminServiceCommissioningBodyEntity';
import { ServiceCommissioningBodyServiceCommissioningBodyEntity } from 'Models/Security/Acl/ServiceCommissioningBodyServiceCommissioningBodyEntity';
import { EntityFormMode } from 'Views/Components/Helpers/Common';
import {SuperAdministratorScheme} from '../Security/Acl/SuperAdministratorScheme';
// % protected region % [Add any further imports here] off begin
// % protected region % [Add any further imports here] end

export interface IServiceCommissioningBodyEntityAttributes extends IModelAttributes {
	email: string;
	name: string;
	location: string;
	profileImageId: string;
	profileImage: Blob;

	servicess: Array<Models.ServiceCommissioningBodiesServices | Models.IServiceCommissioningBodiesServicesAttributes>;
	// % protected region % [Add any custom attributes to the interface here] off begin
	// % protected region % [Add any custom attributes to the interface here] end
}

// % protected region % [Customise your entity metadata here] off begin
@entity('ServiceCommissioningBodyEntity', 'Service Commissioning Body')
// % protected region % [Customise your entity metadata here] end
export default class ServiceCommissioningBodyEntity extends Model implements IServiceCommissioningBodyEntityAttributes {
	public static acls: IAcl[] = [
		new SuperAdministratorScheme(),
		new AdminServiceCommissioningBodyEntity(),
		new ServiceCommissioningBodyServiceCommissioningBodyEntity(),
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
		'email',
		// % protected region % [Add any custom update exclusions here] off begin
		// % protected region % [Add any custom update exclusions here] end
	];

	// % protected region % [Modify props to the crud options here for attribute 'Email'] off begin
	@Validators.Email()
	@Validators.Required()
	@observable
	@attribute()
	@CRUD({
		name: 'Email',
		displayType: 'displayfield',
		order: 10,
		createFieldType: 'textfield',
		headerColumn: true,
		searchable: true,
		searchFunction: 'like',
		searchTransform: AttrUtils.standardiseString,
	})
	public email: string;
	// % protected region % [Modify props to the crud options here for attribute 'Email'] end

	// % protected region % [Modify props to the crud options here for attribute 'Password'] off begin
	@Validators.Length(6)
	@observable
	@CRUD({
		name: 'Password',
		displayType: 'hidden',
		order: 20,
		createFieldType: 'password',
	})
	public password: string;
	// % protected region % [Modify props to the crud options here for attribute 'Password'] end

	// % protected region % [Modify props to the crud options here for attribute 'Confirm Password'] off begin
	@Validators.Custom('Password Match', (e: string, target: ServiceCommissioningBodyEntity) => {
		return new Promise(resolve => resolve(target.password !== e ? "Password fields do not match" : null))
	})
	@observable
	@CRUD({
		name: 'Confirm Password',
		displayType: 'hidden',
		order: 30,
		createFieldType: 'password',
	})
	public _confirmPassword: string;
	// % protected region % [Modify props to the crud options here for attribute 'Confirm Password'] end

	// % protected region % [Modify props to the crud options here for attribute 'Name'] off begin
	@observable
	@attribute()
	@CRUD({
		name: 'Name',
		displayType: 'textfield',
		order: 40,
		headerColumn: true,
		searchable: true,
		searchFunction: 'like',
		searchTransform: AttrUtils.standardiseString,
	})
	public name: string;
	// % protected region % [Modify props to the crud options here for attribute 'Name'] end

	// % protected region % [Modify props to the crud options here for attribute 'Location'] off begin
	@observable
	@attribute()
	@CRUD({
		name: 'Location',
		displayType: 'textfield',
		order: 50,
		headerColumn: true,
		searchable: true,
		searchFunction: 'like',
		searchTransform: AttrUtils.standardiseString,
	})
	public location: string;
	// % protected region % [Modify props to the crud options here for attribute 'Location'] end

	// % protected region % [Modify props to the crud options here for attribute 'Profile Image'] off begin
	@observable
	@attribute({file: 'profileImage'})
	@CRUD({
		name: 'Profile Image',
		displayType: 'file',
		order: 60,
		headerColumn: true,
		searchable: true,
		searchFunction: 'equal',
		searchTransform: AttrUtils.standardiseUuid,
		inputProps: {
			imageOnly: true,
		},
		fileAttribute: 'profileImage',
		displayFunction: attr => attr 
			? <img src={`${SERVER_URL}/api/files/${attr}`} alt='A Service Commissioning Body' style={{maxWidth: '300px'}} />
			: 'No File Attached',
	})
	public profileImageId: string;
	@observable
	public profileImage: Blob;
	// % protected region % [Modify props to the crud options here for attribute 'Profile Image'] end

	@observable
	@attribute({isReference: true})
	@CRUD({
		// % protected region % [Modify props to the crud options here for reference 'Services'] off begin
		name: 'Services',
		displayType: 'reference-multicombobox',
		order: 70,
		isJoinEntity: true,
		referenceTypeFunc: () => Models.ServiceCommissioningBodiesServices,
		optionEqualFunc: makeJoinEqualsFunc('servicesId'),
		referenceResolveFunction: makeFetchManyToManyFunc({
			entityName: 'serviceCommissioningBodyEntity',
			oppositeEntityName: 'serviceEntity',
			relationName: 'serviceCommissioningBodies',
			relationOppositeName: 'services',
			entity: () => Models.ServiceCommissioningBodyEntity,
			joinEntity: () => Models.ServiceCommissioningBodiesServices,
			oppositeEntity: () => Models.ServiceEntity,
		}),
		// % protected region % [Modify props to the crud options here for reference 'Services'] end
	})
	public servicess: Models.ServiceCommissioningBodiesServices[] = [];

	// % protected region % [Add any custom attributes to the model here] off begin
	// % protected region % [Add any custom attributes to the model here] end

	// eslint-disable-next-line @typescript-eslint/no-useless-constructor
	constructor(attributes?: Partial<IServiceCommissioningBodyEntityAttributes>) {
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
	public assignAttributes(attributes?: Partial<IServiceCommissioningBodyEntityAttributes>) {
		// % protected region % [Override assign attributes here] off begin
		super.assignAttributes(attributes);

		if (attributes) {
			if (attributes.email !== undefined) {
				this.email = attributes.email;
			}
			if (attributes.name !== undefined) {
				this.name = attributes.name;
			}
			if (attributes.location !== undefined) {
				this.location = attributes.location;
			}
			if (attributes.profileImage !== undefined) {
				this.profileImage = attributes.profileImage;
			}
			if (attributes.profileImageId !== undefined) {
				this.profileImageId = attributes.profileImageId;
			}
			if (attributes.servicess !== undefined && Array.isArray(attributes.servicess)) {
				for (const model of attributes.servicess) {
					if (model instanceof Models.ServiceCommissioningBodiesServices) {
						this.servicess.push(model);
					} else {
						this.servicess.push(new Models.ServiceCommissioningBodiesServices(model));
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
			${Models.ServiceCommissioningBodiesServices.getAttributes().join('\n')}
			services {
				${Models.ServiceEntity.getAttributes().join('\n')}
			}
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
		};

		if (formMode === 'create') {
			relationPath['password'] = {};

			if (this.password !== this._confirmPassword) {
				throw Error("Password fields do not match");
			}
		}
		return this.save(
			relationPath,
			{
				graphQlInputType: formMode === 'create'
					? `[${this.getModelName()}CreateInput]`
					: `[${this.getModelName()}Input]`,
				options: [
					{
						key: 'mergeReferences',
						graphQlType: '[String]',
						value: [
							'servicess',
						]
					},
				],
				contentType: 'multipart/form-data',
			}
		);
	}
	// % protected region % [Customize Save From Crud here] end

	/**
	 * Returns the string representation of this entity to display on the UI.
	 */
	public getDisplayName() {
		// % protected region % [Customise the display name for this entity] off begin
		return this.email;
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
CRUD(createdAttr)(ServiceCommissioningBodyEntity.prototype, 'created');
CRUD(modifiedAttr)(ServiceCommissioningBodyEntity.prototype, 'modified');
// % protected region % [Modify the create and modified CRUD attributes here] end
