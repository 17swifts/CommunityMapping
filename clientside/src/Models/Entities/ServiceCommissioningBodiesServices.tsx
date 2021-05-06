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
import { Model, IModelAttributes, attribute, entity } from 'Models/Model';
import * as Models from 'Models/Entities';
import { IAcl } from '../Security/IAcl';
import { observable } from 'mobx';
import { AdminServicesReferenceManyToMany } from '../Security/Acl/AdminServicesReferenceManyToMany';
import { ServiceCommissioningBodyServicesReferenceManyToMany } from '../Security/Acl/ServiceCommissioningBodyServicesReferenceManyToMany';

// % protected region % [Add any further imports here] off begin
// % protected region % [Add any further imports here] end

export interface IServiceCommissioningBodiesServicesAttributes extends IModelAttributes {
	serviceCommissioningBodiesId: string;
	servicesId: string;

	serviceCommissioningBodies: Models.ServiceCommissioningBodyEntity | Models.IServiceCommissioningBodyEntityAttributes;
	services: Models.ServiceEntity | Models.IServiceEntityAttributes;
	// % protected region % [Add any custom attributes to the interface here] off begin
	// % protected region % [Add any custom attributes to the interface here] end
}

@entity('ServiceCommissioningBodiesServices')
export default class ServiceCommissioningBodiesServices extends Model implements IServiceCommissioningBodiesServicesAttributes {
	public static acls: IAcl[] = [
		new AdminServicesReferenceManyToMany(),
		new ServiceCommissioningBodyServicesReferenceManyToMany(),
		// % protected region % [Add any further ACL entries here] off begin
		// % protected region % [Add any further ACL entries here] end
	];

	@observable
	@attribute()
	public serviceCommissioningBodiesId: string;

	@observable
	@attribute()
	public servicesId: string;

	@observable
	@attribute({isReference: true})
	public serviceCommissioningBodies: Models.ServiceCommissioningBodyEntity;

	@observable
	@attribute({isReference: true})
	public services: Models.ServiceEntity;
	// % protected region % [Add any custom attributes to the model here] off begin
	// % protected region % [Add any custom attributes to the model here] end

	constructor(attributes?: Partial<IServiceCommissioningBodiesServicesAttributes>) {
		// % protected region % [Add any extra constructor logic before calling super here] off begin
		// % protected region % [Add any extra constructor logic before calling super here] end

		super(attributes);

		if (attributes) {
			if (attributes.serviceCommissioningBodiesId) {
				this.serviceCommissioningBodiesId = attributes.serviceCommissioningBodiesId;
			}
			if (attributes.servicesId) {
				this.servicesId = attributes.servicesId;
			}

			if (attributes.serviceCommissioningBodies) {
				if (attributes.serviceCommissioningBodies instanceof Models.ServiceCommissioningBodyEntity) {
					this.serviceCommissioningBodies = attributes.serviceCommissioningBodies;
					this.serviceCommissioningBodiesId = attributes.serviceCommissioningBodies.id;
				} else {
					this.serviceCommissioningBodies = new Models.ServiceCommissioningBodyEntity(attributes.serviceCommissioningBodies);
					this.serviceCommissioningBodiesId = this.serviceCommissioningBodies.id;
				}
			} else if (attributes.serviceCommissioningBodiesId !== undefined) {
				this.serviceCommissioningBodiesId = attributes.serviceCommissioningBodiesId;
			}

			if (attributes.services) {
				if (attributes.services instanceof Models.ServiceEntity) {
					this.services = attributes.services;
					this.servicesId = attributes.services.id;
				} else {
					this.services = new Models.ServiceEntity(attributes.services);
					this.servicesId = this.services.id;
				}
			} else if (attributes.servicesId !== undefined) {
				this.servicesId = attributes.servicesId;
			}
		}

		// % protected region % [Add any extra constructor logic after calling super here] off begin
		// % protected region % [Add any extra constructor logic after calling super here] end
	}

	// % protected region % [Add any further custom model features here] off begin
	// % protected region % [Add any further custom model features here] end
}