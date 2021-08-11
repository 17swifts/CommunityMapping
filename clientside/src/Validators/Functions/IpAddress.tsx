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

import { Symbols } from 'Symbols';
import { Model } from 'Models/Model';
import { initValidators, IModelAttributeValidationError, ErrorType } from '../Util';
// % protected region % [Add extra imports and exports here] off begin
// % protected region % [Add extra imports and exports here] end

// % protected region % [Override isIP here] off begin
export function isIP(url: string): boolean {
	return /^((25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.){3}(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)$/.test(url);
}
// % protected region % [Override isIP here] end

// % protected region % [Override validate here] off begin
export default function validate() {
	return (target: object, key: string) => {
		initValidators(target, key);
		target[Symbols.validatorMap][key].push('Url');
		target[Symbols.validator].push(
			(model: Model): Promise<IModelAttributeValidationError | null> => new Promise(resolve => {
				if (model[key] === null || model[key] === undefined) {
					resolve(null);
				} else {
					resolve(isIP(model[key])
						? null
						: {
							errorType: ErrorType.INVALID,
							errorMessage: 'The value is not a valid IP address',
							attributeName: key,
							target: model,
						});
				}
			}),
		);
	};
}
// % protected region % [Override validate here] end
