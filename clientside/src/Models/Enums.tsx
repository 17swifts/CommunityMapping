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

export type categories =
	// % protected region % [Override categories keys here] off begin
	'ABORIGINAL_SERVICE' |
		'ACCOMMODATION_SERVICE' |
		'ADVOCACY_SERVICE' |
		'ALCOHOL_AND_DRUG_SERVICE' |
		'ARTS_AND_CREATIVES' |
		'COMMUNITY_CENTRES_HALLS_AND_FACILITIES' |
		'COMMUNITY_CLUB' |
		'CRISIS_AND_EMERGENCY_SERVICE' |
		'CULTURAL_AND_MIGRANT_SERVICE' |
		'DISABILITY_SERVICE' |
		'EDUCATION' |
		'EMPLOYMENT_AND_TRAINING' |
		'HEALTH_SERVICE' |
		'INFORMATION_AND_COUNSELLING' |
		'LEGAL_SERVICE' |
		'RELIGION_AND_PHILOSOPHY' |
		'SELF_HELP' |
		'SPORT' |
		'TRANSPORT_SERVICE' |
		'WELFARE_ASSISTANCE' |
		'YOUTH_SERVICE';
	// % protected region % [Override categories keys here] end

export const categoriesOptions: { [key in categories]: string } = {
	// % protected region % [Override categories display fields here] off begin
	ABORIGINAL_SERVICE: 'Aboriginal Service',
	ACCOMMODATION_SERVICE: 'Accommodation Service',
	ADVOCACY_SERVICE: 'Advocacy Service',
	ALCOHOL_AND_DRUG_SERVICE: 'Alcohol and Drug Service',
	ARTS_AND_CREATIVES: 'Arts and Creatives',
	COMMUNITY_CENTRES_HALLS_AND_FACILITIES: 'Community Centres Halls and Facilities',
	COMMUNITY_CLUB: 'Community Club',
	CRISIS_AND_EMERGENCY_SERVICE: 'Crisis and Emergency Service',
	CULTURAL_AND_MIGRANT_SERVICE: 'Cultural and Migrant Service',
	DISABILITY_SERVICE: 'Disability Service',
	EDUCATION: 'Education',
	EMPLOYMENT_AND_TRAINING: 'Employment and Training',
	HEALTH_SERVICE: 'Health Service',
	INFORMATION_AND_COUNSELLING: 'Information and Counselling',
	LEGAL_SERVICE: 'Legal Service',
	RELIGION_AND_PHILOSOPHY: 'Religion and Philosophy',
	SELF_HELP: 'Self Help',
	SPORT: 'Sport',
	TRANSPORT_SERVICE: 'Transport Service',
	WELFARE_ASSISTANCE: 'Welfare Assistance',
	YOUTH_SERVICE: 'Youth Service',
	// % protected region % [Override categories display fields here] end
};

export type servicetype =
	// % protected region % [Override servicetype keys here] off begin
	'PERMANENT' |
		'VISITING';
	// % protected region % [Override servicetype keys here] end

export const servicetypeOptions: { [key in servicetype]: string } = {
	// % protected region % [Override servicetype display fields here] off begin
	PERMANENT: 'Permanent',
	VISITING: 'Visiting',
	// % protected region % [Override servicetype display fields here] end
};

export type gender =
	// % protected region % [Override gender keys here] off begin
	'FEMALE' |
		'MALE' |
		'OTHER' |
		'BOTH';
	// % protected region % [Override gender keys here] end

export const genderOptions: { [key in gender]: string } = {
	// % protected region % [Override gender display fields here] off begin
	FEMALE: 'Female',
	MALE: 'Male',
	OTHER: 'Other',
	BOTH: 'Both',
	// % protected region % [Override gender display fields here] end
};

// % protected region % [Add any extra enums here] off begin
// % protected region % [Add any extra enums here] end
