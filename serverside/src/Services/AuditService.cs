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
using Cis.Models;
using Cis.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json.Linq;

// % protected region % [Add any additional imports here] off begin
// % protected region % [Add any additional imports here] end

namespace Cis.Services
{
	public class AuditService : IAuditService
	{
		private readonly IHttpContextAccessor _httpContextAccessor;

		/// <inheritdoc />
		public List<AuditLog> Logs { get; } = new List<AuditLog>();

		public AuditService(IHttpContextAccessor httpContextAccessor)
		{
			_httpContextAccessor = httpContextAccessor;
			_httpContextAccessor?.HttpContext?.Items.TryAdd("AuditLogs", Logs);
		}

		/// <inheritdoc />
		public void CreateReadAudit(string userId, string userName, string modelName, object data = null)
		{
			var audit = new AuditLog
			{
				UserName = userName,
				UserId = userId,
				Id = Guid.NewGuid(),
				Action = "Read",
				TablePk = null,
				AuditData = data == null ? null : JObject.FromObject(data),
				AuditDate = DateTime.UtcNow,
				EntityType = modelName,
				HttpContextId = _httpContextAccessor?.HttpContext?.TraceIdentifier
			};

			Logs.Add(audit);
		}
		// % protected region % [Add any additional methods here] off begin
		// % protected region % [Add any additional methods here] end
	}
}