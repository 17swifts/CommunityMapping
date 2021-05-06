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
	/// The controller that provides rest endpoints for the RegionalAreaTimelineEventsEntity model
	/// </summary>
	// % protected region % [Override controller attributes here] off begin
	[Route("/api/entity/RegionalAreaTimelineEventsEntity")]
	[Authorize]
	[ApiController]
	// % protected region % [Override controller attributes here] end
	public class RegionalAreaTimelineEventsEntityController : BaseApiController
	{
		private readonly ITimelineGroupingService _groupingService;
		private readonly ICrudService _crudService;
		// % protected region % [Add any extra class variables here] off begin
		// % protected region % [Add any extra class variables here] end

		public RegionalAreaTimelineEventsEntityController(
			// % protected region % [Add any extra constructor arguments here] off begin
			// % protected region % [Add any extra constructor arguments here] end
			ITimelineGroupingService groupingService,
			ICrudService crudService)
		{
			_groupingService = groupingService;
			_crudService = crudService;
			// % protected region % [Add any extra constructor logic here] off begin
			// % protected region % [Add any extra constructor logic here] end
		}

		/// <summary>
		/// Get the RegionalAreaTimelineEventsEntity for the given id
		/// </summary>
		/// <param name="id">The id of the RegionalAreaTimelineEventsEntity to be fetched</param>
		/// <param name="cancellation">A cancellation token</param>
		/// <returns>The RegionalAreaTimelineEventsEntity object with the given id</returns>
		// % protected region % [Override get attributes here] off begin
		[HttpGet]
		[Route("{id}")]
		[AllowAnonymous]
		// % protected region % [Override get attributes here] end
		public async Task<RegionalAreaTimelineEventsEntityDto> Get(Guid id, CancellationToken cancellation)
		{
			// % protected region % [Override Get by id here] off begin
			var result = _crudService.GetById<RegionalAreaTimelineEventsEntity>(id);
			return await result
				.Select(model => new RegionalAreaTimelineEventsEntityDto(model))
				.AsNoTracking()
				.FirstOrDefaultAsync(cancellation);
			// % protected region % [Override Get by id here] end
		}

		/// <summary>
		/// Gets all RegionalAreaTimelineEventsEntitys with pagination support
		/// </summary>
		/// <param name="options">Filtering params</param>
		/// <param name="cancellation">A cancellation token</param>
		/// <returns>A list of RegionalAreaTimelineEventsEntitys</returns>
		// % protected region % [Override get list attributes here] off begin
		[HttpGet]
		[Route("")]
		[AllowAnonymous]
		// % protected region % [Override get list attributes here] end
		public async Task<EntityControllerData<RegionalAreaTimelineEventsEntityDto>> Get(
			[FromQuery]RegionalAreaTimelineEventsEntityOptions options,
			CancellationToken cancellation)
		{
			// % protected region % [Override Get here] off begin
			return new EntityControllerData<RegionalAreaTimelineEventsEntityDto>
			{
				Data = await _crudService.Get<RegionalAreaTimelineEventsEntity>(new Pagination(options))
					.AsNoTracking()
					.Select(model => new RegionalAreaTimelineEventsEntityDto(model))
					.ToListAsync(cancellation),
				Count = await _crudService.Get<RegionalAreaTimelineEventsEntity>()
					.AsNoTracking()
					.CountAsync(cancellation)
			};
			// % protected region % [Override Get here] end
		}

		/// <summary>
		/// Create RegionalAreaTimelineEventsEntity
		/// </summary>
		/// <param name="model">The new RegionalAreaTimelineEventsEntity to be created</param>
		/// <param name="cancellation">The cancellation token for this operation</param>
		/// <returns>The RegionalAreaTimelineEventsEntity object after creation</returns>
		// % protected region % [Override post attributes here] off begin
		[HttpPost]
		[Route("")]
		[Consumes("application/json")]
		[Authorize]
		// % protected region % [Override post attributes here] end
		public async Task<RegionalAreaTimelineEventsEntityDto> Post(
			[BindRequired, FromBody] RegionalAreaTimelineEventsEntityDto model,
			CancellationToken cancellation)
		{
			// % protected region % [Override Post here] off begin
			if (model.Id != Guid.Empty)
			{
				Response.StatusCode = (int)HttpStatusCode.BadRequest;
				return null;
			}

			return new RegionalAreaTimelineEventsEntityDto(await _crudService.Create(model.ToModel(), cancellation: cancellation));
			// % protected region % [Override Post here] end
		}

		/// <summary>
		/// Create RegionalAreaTimelineEventsEntity
		/// </summary>
		/// <param name="cancellation">The cancellation token</param>
		/// <returns>The RegionalAreaTimelineEventsEntity object after creation</returns>
		// % protected region % [Override post form attributes here] off begin
		[HttpPost]
		[Route("")]
		[Consumes("multipart/form-data")]
		[Authorize]
		// % protected region % [Override post form attributes here] end
		public async Task<RegionalAreaTimelineEventsEntityDto> PostForm(CancellationToken cancellation)
		{
			// % protected region % [Override Post form here] off begin
			var form = await Request.ReadFormAsync(cancellation);
			form.TryGetValue("variables", out var variables);
			var model = JsonConvert.DeserializeObject<RegionalAreaTimelineEventsEntityDto>(variables.First());
			if (model.Id != Guid.Empty)
			{
				Response.StatusCode = (int)HttpStatusCode.BadRequest;
				return null;
			}

			var result = await _crudService.Create(model.ToModel(), new UpdateOptions
			{
				Files = form.Files,
			}, cancellation);

			return new RegionalAreaTimelineEventsEntityDto(result);
			// % protected region % [Override Post form here] end
		}

		/// <summary>
		/// Update an RegionalAreaTimelineEventsEntity
		/// </summary>
		/// <param name="model">The RegionalAreaTimelineEventsEntity to be updated</param>
		/// <param name="cancellation">The cancellation token</param>
		/// <returns>The RegionalAreaTimelineEventsEntity object after it has been updated</returns>
		// % protected region % [Override put attributes here] off begin
		[HttpPut]
		[Consumes("application/json")]
		[Authorize]
		// % protected region % [Override put attributes here] end
		public async Task<RegionalAreaTimelineEventsEntityDto> Put(
			[BindRequired, FromBody] RegionalAreaTimelineEventsEntityDto model,
			CancellationToken cancellation)
		{
			// % protected region % [Override Put here] off begin
			if (Guid.Empty == model.Id)
			{
				Response.StatusCode = (int)HttpStatusCode.BadRequest;
				return null;
			}

			return new RegionalAreaTimelineEventsEntityDto(await _crudService.Update(model.ToModel(), cancellation: cancellation));
			// % protected region % [Override Put here] end
		}

		/// <summary>
		/// Update an RegionalAreaTimelineEventsEntity
		/// </summary>
		/// <param name="cancellation">The cancellation token</param>
		/// <returns>The RegionalAreaTimelineEventsEntity object after it has been updated</returns>
		// % protected region % [Override put form attributes here] off begin
		[HttpPut]
		[Consumes("multipart/form-data")]
		[Authorize]
		// % protected region % [Override put form attributes here] end
		public async Task<RegionalAreaTimelineEventsEntityDto> PutForm(CancellationToken cancellation)
		{
			// % protected region % [Override Put form here] off begin
			var form = await Request.ReadFormAsync(cancellation);
			form.TryGetValue("variables", out var variables);
			var model = JsonConvert.DeserializeObject<RegionalAreaTimelineEventsEntityDto>(variables.First());

			if (Guid.Empty == model.Id)
			{
				Response.StatusCode = (int)HttpStatusCode.BadRequest;
				return null;
			}

			return new RegionalAreaTimelineEventsEntityDto(await _crudService.Update(model.ToModel(), new UpdateOptions
			{
				Files = form.Files,
			}, cancellation));
			// % protected region % [Override Put form here] end
		}

		/// <summary>
		/// Deletes a RegionalAreaTimelineEventsEntity
		/// </summary>
		/// <param name="id">The id of the RegionalAreaTimelineEventsEntity to delete</param>
		/// <param name="cancellation">The cancellation token</param>
		/// <returns>The ids of the deleted RegionalAreaTimelineEventsEntitys</returns>
		// % protected region % [Override delete attributes here] off begin
		[HttpDelete]
		[Route("{id}")]
		[Authorize]
		// % protected region % [Override delete attributes here] end
		public async Task<Guid> Delete(Guid id, CancellationToken cancellation)
		{
			// % protected region % [Override Delete here] off begin
			return await _crudService.Delete<RegionalAreaTimelineEventsEntity>(id, cancellation: cancellation);
			// % protected region % [Override Delete here] end
		}

		/// <summary>
		/// Export the list of Regional area Timeline Eventss with given the provided conditions
		/// </summary>
		/// <param name="conditions">The conditions to export with</param>
		/// <param name="cancellationToken">The cancellation token for the request</param>
		/// <returns>A csv file containing the export of Regional area Timeline Eventss</returns>
		// % protected region % [Override export attributes here] off begin
		[HttpGet]
		[Route("export")]
		[Produces("text/csv")]
		[AllowAnonymous]
		// % protected region % [Override export attributes here] end
		public async Task Export(
			[FromQuery]IEnumerable<WhereExpression> conditions,
			CancellationToken cancellationToken)
		{
			// % protected region % [Override Export here] off begin
			var queryable = _crudService.Get<RegionalAreaTimelineEventsEntity>()
				.AsNoTracking()
				.AddWhereFilter(conditions);

			await WriteQueryableCsvAsync(
				queryable.Select(r => new RegionalAreaTimelineEventsEntityDto(r)),
				"export_regional_area_timeline_events.csv",
				cancellationToken);
			// % protected region % [Override Export here] end
		}

		/// <summary>
		/// Export a list of Regional area Timeline Eventss with given the provided conditions
		/// This is a post endpoint for easier composition of complex conditions
		/// </summary>
		/// <param name="conditions">The conditions to export with</param>
		/// <param name="cancellationToken">The cancellation token for the request</param>
		/// <returns>A csv file containing the export of Regional area Timeline Eventss</returns>
		// % protected region % [Override export post attributes here] off begin
		[HttpPost]
		[Route("export")]
		[Produces("text/csv")]
		[AllowAnonymous]
		// % protected region % [Override export post attributes here] end
		public async Task ExportPost(
			[FromBody]IEnumerable<IEnumerable<WhereExpression>> conditions,
			CancellationToken cancellationToken)
		{
			// % protected region % [Override ExportPost here] off begin
			var queryable = _crudService.Get<RegionalAreaTimelineEventsEntity>()
				.AsNoTracking()
				.AddConditionalWhereFilter(conditions);

			await WriteQueryableCsvAsync(
				queryable.Select(r => new RegionalAreaTimelineEventsEntityDto(r)),
				"export_regional_area_timeline_events.csv",
				cancellationToken);
			// % protected region % [Override ExportPost here] end
		}
		/// <summary>
		/// Gets a list of distinct action types across the timeline event entity
		/// </summary>
		/// <returns>A list of action types</returns>
		// % protected region % [Override GetActionTypes attributes here] off begin
		[HttpGet]
		[Route("action-types")]
		[AllowAnonymous]
		// % protected region % [Override GetActionTypes attributes here] end
		public IEnumerable<string> GetActionTypes()
		{
			// % protected region % [Override GetActionTypes here] off begin
			return _crudService
			.Get<RegionalAreaTimelineEventsEntity>()
			.Select(x => x.Action)
			.Distinct()
			.ToList();
			// % protected region % [Override GetActionTypes here] end
		}
		/// <summary>
		/// Gets a list of distinct weeks or months where timeline events have been created.
		/// The list is limited to 7 date ranges
		/// </summary>
		/// <param name="timelineFilter">A list of up to 7 date ranges</param>
		/// <returns></returns>
		// % protected region % [Override GetQuickJumpOptions attributes here] off begin
		[HttpPost]
		[Route("quick-jump-options")]
		[AllowAnonymous]
		// % protected region % [Override GetQuickJumpOptions attributes here] end
		public async Task<IEnumerable<DateRange>> GetQuickJumpOptions(TimelineFilter timelineFilter)
		{
			// % protected region % [Override GetQuickJumpOptions here] off begin
			return _crudService.GetDistinctDatesForTimeFrame<RegionalAreaTimelineEventsEntity>(timelineFilter.TimeFrame, timelineFilter.Conditions)
				.OrderByDescending(x => x)
				.Take(7)
				.Select(x => new DateRange(x, timelineFilter.TimeFrame));
			// % protected region % [Override GetQuickJumpOptions here] end
		}

		/// <summary>
		/// Takes a date range, and creates a list of data for datetime points within the range to be graphed
		/// on a timeline graph
		/// </summary>
		/// <param name="timelineFilter">Filter to apply to timeline events</param>
		/// <returns>A list of TimelineGroupDateQueryResult containing information about events during a date range</returns>
		// % protected region % [Override GetTimelineGraphData attributes here] off begin
		[HttpPost]
		[Route("timeline-graph-data")]
		[AllowAnonymous]
		// % protected region % [Override GetTimelineGraphData attributes here] end
		public async Task<IOrderedEnumerable<TimelineGroupDateQueryResult<RegionalAreaTimelineEventsEntity>>> GetTimelineGraphData(TimelineFilter timelineFilter)
		{
			// % protected region % [Override GetTimelineGraphData here] off begin
			return await _groupingService.GraphQueryGroupingResult<RegionalAreaTimelineEventsEntity>(timelineFilter);
			// % protected region % [Override GetTimelineGraphData here] end
		}

		public class RegionalAreaTimelineEventsEntityOptions : PaginationOptions
		{
			// % protected region % [Add any get params here] off begin
			// % protected region % [Add any get params here] end
		}

		// % protected region % [Add any further endpoints here] off begin
		// % protected region % [Add any further endpoints here] end
	}
}

