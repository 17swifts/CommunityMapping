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
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Cis.Helpers;
using Cis.Models;
using Cis.Services;
using Cis.Services.Interfaces;
using GraphQL.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
// % protected region % [Add any extra imports here] off begin
// % protected region % [Add any extra imports here] end

namespace Cis.Controllers.Entities
{
	/// <summary>
	/// The controller that provides rest endpoints for the ServiceCommissioningBodyEntity model
	/// </summary>
	// % protected region % [Override controller attributes here] off begin
	[Route("/api/entity/ServiceCommissioningBodyEntity")]
	[Authorize]
	[ApiController]
	// % protected region % [Override controller attributes here] end
	public class ServiceCommissioningBodyEntityController : BaseApiController
	{
		private readonly ICrudService _crudService;
		// % protected region % [Add any extra class variables here] off begin
		// % protected region % [Add any extra class variables here] end

		public ServiceCommissioningBodyEntityController(
			// % protected region % [Add any extra constructor arguments here] off begin
			// % protected region % [Add any extra constructor arguments here] end
			ICrudService crudService)
		{
			_crudService = crudService;
			// % protected region % [Add any extra constructor logic here] off begin
			// % protected region % [Add any extra constructor logic here] end
		}

		/// <summary>
		/// Get the ServiceCommissioningBodyEntity for the given id
		/// </summary>
		/// <param name="id">The id of the ServiceCommissioningBodyEntity to be fetched</param>
		/// <param name="cancellation">A cancellation token</param>
		/// <returns>The ServiceCommissioningBodyEntity object with the given id</returns>
		// % protected region % [Override get attributes here] off begin
		[HttpGet]
		[Route("{id}")]
		[Authorize]
		// % protected region % [Override get attributes here] end
		public async Task<ServiceCommissioningBodyEntityDto> Get(Guid id, CancellationToken cancellation)
		{
			// % protected region % [Override Get by id here] off begin
			var result = _crudService.GetById<ServiceCommissioningBodyEntity>(id);
			return await result
				.Select(model => new ServiceCommissioningBodyEntityDto(model))
				.AsNoTracking()
				.FirstOrDefaultAsync(cancellation);
			// % protected region % [Override Get by id here] end
		}

		/// <summary>
		/// Gets all ServiceCommissioningBodyEntitys with pagination support
		/// </summary>
		/// <param name="options">Filtering params</param>
		/// <param name="cancellation">A cancellation token</param>
		/// <returns>A list of ServiceCommissioningBodyEntitys</returns>
		// % protected region % [Override get list attributes here] off begin
		[HttpGet]
		[Route("")]
		[Authorize]
		// % protected region % [Override get list attributes here] end
		public async Task<EntityControllerData<ServiceCommissioningBodyEntityDto>> Get(
			[FromQuery]ServiceCommissioningBodyEntityOptions options,
			CancellationToken cancellation)
		{
			// % protected region % [Override Get here] off begin
			return new EntityControllerData<ServiceCommissioningBodyEntityDto>
			{
				Data = await _crudService.Get<ServiceCommissioningBodyEntity>(new Pagination(options))
					.AsNoTracking()
					.Select(model => new ServiceCommissioningBodyEntityDto(model))
					.ToListAsync(cancellation),
				Count = await _crudService.Get<ServiceCommissioningBodyEntity>()
					.AsNoTracking()
					.CountAsync(cancellation)
			};
			// % protected region % [Override Get here] end
		}

		/// <summary>
		/// Create ServiceCommissioningBodyEntity
		/// </summary>
		/// <param name="model">The new ServiceCommissioningBodyEntity to be created</param>
		/// <param name="cancellation">The cancellation token for this operation</param>
		/// <returns>The ServiceCommissioningBodyEntity object after creation</returns>
		// % protected region % [Override post attributes here] off begin
		[HttpPost]
		[Route("")]
		[Consumes("application/json")]
		[Authorize]
		// % protected region % [Override post attributes here] end
		public async Task<ServiceCommissioningBodyEntityDto> Post(
			[BindRequired, FromBody] ServiceCommissioningBodyEntityDto model,
			CancellationToken cancellation)
		{
			// % protected region % [Override Post here] off begin
			if (model.Id != Guid.Empty)
			{
				Response.StatusCode = (int)HttpStatusCode.BadRequest;
				return null;
			}

			return new ServiceCommissioningBodyEntityDto(await _crudService.Create(model.ToModel(), cancellation: cancellation));
			// % protected region % [Override Post here] end
		}

		/// <summary>
		/// Create ServiceCommissioningBodyEntity
		/// </summary>
		/// <param name="cancellation">The cancellation token</param>
		/// <returns>The ServiceCommissioningBodyEntity object after creation</returns>
		// % protected region % [Override post form attributes here] off begin
		[HttpPost]
		[Route("")]
		[Consumes("multipart/form-data")]
		[Authorize]
		// % protected region % [Override post form attributes here] end
		public async Task<ServiceCommissioningBodyEntityDto> PostForm(CancellationToken cancellation)
		{
			// % protected region % [Override Post form here] off begin
			var form = await Request.ReadFormAsync(cancellation);
			form.TryGetValue("variables", out var variables);
			var model = JsonConvert.DeserializeObject<ServiceCommissioningBodyEntityDto>(variables.First());
			if (model.Id != Guid.Empty)
			{
				Response.StatusCode = (int)HttpStatusCode.BadRequest;
				return null;
			}

			var result = await _crudService.Create(model.ToModel(), new UpdateOptions
			{
				Files = form.Files,
			}, cancellation);

			return new ServiceCommissioningBodyEntityDto(result);
			// % protected region % [Override Post form here] end
		}

		/// <summary>
		/// Update an ServiceCommissioningBodyEntity
		/// </summary>
		/// <param name="model">The ServiceCommissioningBodyEntity to be updated</param>
		/// <param name="cancellation">The cancellation token</param>
		/// <returns>The ServiceCommissioningBodyEntity object after it has been updated</returns>
		// % protected region % [Override put attributes here] off begin
		[HttpPut]
		[Consumes("application/json")]
		[Authorize]
		// % protected region % [Override put attributes here] end
		public async Task<ServiceCommissioningBodyEntityDto> Put(
			[BindRequired, FromBody] ServiceCommissioningBodyEntityDto model,
			CancellationToken cancellation)
		{
			// % protected region % [Override Put here] off begin
			if (Guid.Empty == model.Id)
			{
				Response.StatusCode = (int)HttpStatusCode.BadRequest;
				return null;
			}

			return new ServiceCommissioningBodyEntityDto(await _crudService.Update(model.ToModel(), cancellation: cancellation));
			// % protected region % [Override Put here] end
		}

		/// <summary>
		/// Update an ServiceCommissioningBodyEntity
		/// </summary>
		/// <param name="cancellation">The cancellation token</param>
		/// <returns>The ServiceCommissioningBodyEntity object after it has been updated</returns>
		// % protected region % [Override put form attributes here] off begin
		[HttpPut]
		[Consumes("multipart/form-data")]
		[Authorize]
		// % protected region % [Override put form attributes here] end
		public async Task<ServiceCommissioningBodyEntityDto> PutForm(CancellationToken cancellation)
		{
			// % protected region % [Override Put form here] off begin
			var form = await Request.ReadFormAsync(cancellation);
			form.TryGetValue("variables", out var variables);
			var model = JsonConvert.DeserializeObject<ServiceCommissioningBodyEntityDto>(variables.First());

			if (Guid.Empty == model.Id)
			{
				Response.StatusCode = (int)HttpStatusCode.BadRequest;
				return null;
			}

			return new ServiceCommissioningBodyEntityDto(await _crudService.Update(model.ToModel(), new UpdateOptions
			{
				Files = form.Files,
			}, cancellation));
			// % protected region % [Override Put form here] end
		}

		/// <summary>
		/// Deletes a ServiceCommissioningBodyEntity
		/// </summary>
		/// <param name="id">The id of the ServiceCommissioningBodyEntity to delete</param>
		/// <param name="cancellation">The cancellation token</param>
		/// <returns>The ids of the deleted ServiceCommissioningBodyEntitys</returns>
		// % protected region % [Override delete attributes here] off begin
		[HttpDelete]
		[Route("{id}")]
		[Authorize]
		// % protected region % [Override delete attributes here] end
		public async Task<Guid> Delete(Guid id, CancellationToken cancellation)
		{
			// % protected region % [Override Delete here] off begin
			return await _crudService.Delete<ServiceCommissioningBodyEntity>(id, cancellation: cancellation);
			// % protected region % [Override Delete here] end
		}

		/// <summary>
		/// Export the list of Service Commissioning Bodys with given the provided conditions
		/// </summary>
		/// <param name="conditions">The conditions to export with</param>
		/// <param name="cancellationToken">The cancellation token for the request</param>
		/// <returns>A csv file containing the export of Service Commissioning Bodys</returns>
		// % protected region % [Override export attributes here] off begin
		[HttpGet]
		[Route("export")]
		[Produces("text/csv")]
		[Authorize]
		// % protected region % [Override export attributes here] end
		public async Task Export(
			[FromQuery]IEnumerable<WhereExpression> conditions,
			CancellationToken cancellationToken)
		{
			// % protected region % [Override Export here] off begin
			var queryable = _crudService.Get<ServiceCommissioningBodyEntity>()
				.AsNoTracking()
				.AddWhereFilter(conditions);

			await WriteQueryableCsvAsync(
				queryable.Select(r => new ServiceCommissioningBodyEntityDto(r)),
				"export_service_commissioning_body.csv",
				cancellationToken);
			// % protected region % [Override Export here] end
		}

		/// <summary>
		/// Export a list of Service Commissioning Bodys with given the provided conditions
		/// This is a post endpoint for easier composition of complex conditions
		/// </summary>
		/// <param name="conditions">The conditions to export with</param>
		/// <param name="cancellationToken">The cancellation token for the request</param>
		/// <returns>A csv file containing the export of Service Commissioning Bodys</returns>
		// % protected region % [Override export post attributes here] off begin
		[HttpPost]
		[Route("export")]
		[Produces("text/csv")]
		[Authorize]
		// % protected region % [Override export post attributes here] end
		public async Task ExportPost(
			[FromBody]IEnumerable<IEnumerable<WhereExpression>> conditions,
			CancellationToken cancellationToken)
		{
			// % protected region % [Override ExportPost here] off begin
			var queryable = _crudService.Get<ServiceCommissioningBodyEntity>()
				.AsNoTracking()
				.AddConditionalWhereFilter(conditions);

			await WriteQueryableCsvAsync(
				queryable.Select(r => new ServiceCommissioningBodyEntityDto(r)),
				"export_service_commissioning_body.csv",
				cancellationToken);
			// % protected region % [Override ExportPost here] end
		}

		public class ServiceCommissioningBodyEntityOptions : PaginationOptions
		{
			// % protected region % [Add any get params here] off begin
			// % protected region % [Add any get params here] end
		}

		// % protected region % [Add any further endpoints here] off begin
		// % protected region % [Add any further endpoints here] end
	}
}

