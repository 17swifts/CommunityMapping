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

import { IAdminEntityAttributes as IAdminEntityAttributesImport } from './AdminEntity';
import { IRegionalAreaEntityAttributes as IRegionalAreaEntityAttributesImport } from './RegionalAreaEntity';
import { IServiceEntityAttributes as IServiceEntityAttributesImport } from './ServiceEntity';
import { IServiceCommissioningBodyEntityAttributes as IServiceCommissioningBodyEntityAttributesImport } from './ServiceCommissioningBodyEntity';
import { IMetricEntityAttributes as IMetricEntityAttributesImport } from './MetricEntity';
import { IRegionalAreaTimelineEventsEntityAttributes as IRegionalAreaTimelineEventsEntityAttributesImport } from './RegionalAreaTimelineEventsEntity';
import { IServiceCommissioningBodiesServicesAttributes as IServiceCommissioningBodiesServicesAttributesImport } from './ServiceCommissioningBodiesServices';

export { default as User } from './User';

export { default as AdminEntity } from './AdminEntity';
export type IAdminEntityAttributes = IAdminEntityAttributesImport;

export { default as RegionalAreaEntity } from './RegionalAreaEntity';
export type IRegionalAreaEntityAttributes = IRegionalAreaEntityAttributesImport;

export { default as ServiceEntity } from './ServiceEntity';
export type IServiceEntityAttributes = IServiceEntityAttributesImport;

export { default as ServiceCommissioningBodyEntity } from './ServiceCommissioningBodyEntity';
export type IServiceCommissioningBodyEntityAttributes = IServiceCommissioningBodyEntityAttributesImport;

export { default as MetricEntity } from './MetricEntity';
export type IMetricEntityAttributes = IMetricEntityAttributesImport;

export { default as RegionalAreaTimelineEventsEntity } from './RegionalAreaTimelineEventsEntity';
export type IRegionalAreaTimelineEventsEntityAttributes = IRegionalAreaTimelineEventsEntityAttributesImport;

export { default as ServiceCommissioningBodiesServices } from './ServiceCommissioningBodiesServices';
export type IServiceCommissioningBodiesServicesAttributes = IServiceCommissioningBodiesServicesAttributesImport;

