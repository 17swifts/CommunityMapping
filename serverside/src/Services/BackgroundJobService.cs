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
using System.Linq.Expressions;
using System.Threading.Tasks;
using Cis.Configuration;
using Cis.Services.Interfaces;
using GraphQL.Utilities;
using Hangfire;
using Microsoft.Extensions.Options;

// % protected region % [Add any additional imports here] off begin
// % protected region % [Add any additional imports here] end

namespace Cis.Services
{
	public class BackgroundJobService : IBackgroundJobService
	{

		// % protected region % [Override class properties here] off begin
		private readonly IServiceProvider _serviceProvider;
		private readonly IOptions<SchedulerConfiguration> _schedulerConfiguration;
		// % protected region % [Override class properties here] end

		// % protected region % [Add any extra class properties here] off begin
		// % protected region % [Add any extra class properties here] end

		// % protected region % [Override constructor here] off begin
		public BackgroundJobService(IServiceProvider serviceProvider, IOptions<SchedulerConfiguration> schedulerConfiguration)
		{
			_serviceProvider = serviceProvider;
			_schedulerConfiguration = schedulerConfiguration;
		}
		// % protected region % [Override constructor here] end

		// % protected region % [Override StartBackgroundJob here] off begin
		/// <inheritdoc />
		public void StartBackgroundJob<T>(Expression<Func<T, Task>> job)
		{
			if (_schedulerConfiguration.Value.DisableTaskRunner)
			{
				var service = _serviceProvider.GetRequiredService<T>();
				job.Compile().Invoke(service).Wait();
			}
			else
			{
				BackgroundJob.Enqueue(job);
			}
		}
		// % protected region % [Override StartBackgroundJob here] end

		// % protected region % [Override StartBackgroundJob Action overload here] off begin
		/// <inheritdoc />
		public void StartBackgroundJob<T>(Expression<Action<T>> job)
		{
			if (_schedulerConfiguration.Value.DisableTaskRunner)
			{
				var service = _serviceProvider.GetRequiredService<T>();
				job.Compile().Invoke(service);
			}
			else
			{
				BackgroundJob.Enqueue(job);
			}
		}
		// % protected region % [Override StartBackgroundJob Action overload here] end

		// % protected region % [Add any additional methods here] off begin
		// % protected region % [Add any additional methods here] end
	}
}