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
using System.ComponentModel.DataAnnotations.Schema;
// % protected region % [Add any further imports here] off begin
// % protected region % [Add any further imports here] end

namespace APITests.EntityObjects.Models
{
	public class ServiceCommissioningBodiesServices
	{
		public ServiceCommissioningBodiesServices() {}

		public Guid Owner { get; set; }

		/// <summary>
		/// Outgoing one to many reference
		/// </summary>
		/// <see cref="Cis.Models.ServiceCommissioningBodyEntity"/>
		public Guid ServiceCommissioningBodiesId { get; set; }
		public ServiceCommissioningBodyEntity ServiceCommissioningBodies { get; set; }

		/// <summary>
		/// Outgoing one to many reference
		/// </summary>
		/// <see cref="Cis.Models.ServiceEntity"/>
		public Guid ServicesId { get; set; }
		public ServiceEntity Services { get; set; }
	}
}