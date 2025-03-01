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
using System.Linq;
using FluentAssertions;
using Cis.Controllers.Entities;
using Cis.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ServersideTests.Helpers;
using ServersideTests.Helpers.EntityFactory;
using Xunit;
// % protected region % [Add any extra imports here] off begin
// % protected region % [Add any extra imports here] end

// % protected region % [Add any additional imports here] off begin
// % protected region % [Add any additional imports here] end

namespace ServersideTests.Tests.Integration.BotWritten
{
	[Trait("Category", "BotWritten")]
	[Trait("Category", "Unit")]
	public class CrudTests : IDisposable
	{
		private readonly IHost _host;
		private readonly CisDBContext _database;
		private readonly IServiceScope _scope;
		private readonly IServiceProvider _serviceProvider;
		// % protected region % [Add any additional members here] off begin
		// % protected region % [Add any additional members here] end

		public CrudTests()
		{
			// % protected region % [Configure constructor here] off begin
			_host = ServerBuilder.CreateServer();
			_scope = _host.Services.CreateScope();
			_serviceProvider = _scope.ServiceProvider;
			_database = _serviceProvider.GetRequiredService<CisDBContext>();
			// % protected region % [Configure constructor here] end
		}
		public void Dispose()
		{
			// % protected region % [Configure dispose here] off begin
			_host?.Dispose();
			_database?.Dispose();
			_scope?.Dispose();
			// % protected region % [Configure dispose here] end
		}

		// % protected region % [Add custom Admin Entity traits here] off begin
		// % protected region % [Add custom Admin Entity traits here] end
		// % protected region % [Customise Admin Entity crud tests here] off begin
		[Fact]
		public async void AdminEntityControllerGetTest()
		{
			// Arrange
			using var controller = _serviceProvider.GetRequiredService<AdminEntityController>();
			var entities = new EntityFactory<AdminEntity>(10)
				.UseAttributes()
				.UseReferences()
				.UseOwner(Guid.NewGuid())
				.Generate()
				.ToList();
			_database.AddRange(entities);
			await _database.SaveChangesAsync();

			// Act
			var data = await controller.Get(null, default);

			// Assert
			data.Data.Select(d => d.Id).Should().Contain(entities.Select(d => d.Id));
		}
		// % protected region % [Customise Admin Entity crud tests here] end
		// % protected region % [Add custom Regional area Entity traits here] off begin
		// % protected region % [Add custom Regional area Entity traits here] end
		// % protected region % [Customise Regional area Entity crud tests here] off begin
		[Fact]
		public async void RegionalAreaEntityControllerGetTest()
		{
			// Arrange
			using var controller = _serviceProvider.GetRequiredService<RegionalAreaEntityController>();
			var entities = new EntityFactory<RegionalAreaEntity>(10)
				.UseAttributes()
				.UseReferences()
				.UseOwner(Guid.NewGuid())
				.Generate()
				.ToList();
			_database.AddRange(entities);
			await _database.SaveChangesAsync();

			// Act
			var data = await controller.Get(null, default);

			// Assert
			data.Data.Select(d => d.Id).Should().Contain(entities.Select(d => d.Id));
		}
		// % protected region % [Customise Regional area Entity crud tests here] end
		// % protected region % [Add custom Service Entity traits here] off begin
		// % protected region % [Add custom Service Entity traits here] end
		// % protected region % [Customise Service Entity crud tests here] off begin
		[Fact]
		public async void ServiceEntityControllerGetTest()
		{
			// Arrange
			using var controller = _serviceProvider.GetRequiredService<ServiceEntityController>();
			var entities = new EntityFactory<ServiceEntity>(10)
				.UseAttributes()
				.UseReferences()
				.UseOwner(Guid.NewGuid())
				.Generate()
				.ToList();
			_database.AddRange(entities);
			await _database.SaveChangesAsync();

			// Act
			var data = await controller.Get(null, default);

			// Assert
			data.Data.Select(d => d.Id).Should().Contain(entities.Select(d => d.Id));
		}
		// % protected region % [Customise Service Entity crud tests here] end
		// % protected region % [Add custom Service Commissioning Body Entity traits here] off begin
		// % protected region % [Add custom Service Commissioning Body Entity traits here] end
		// % protected region % [Customise Service Commissioning Body Entity crud tests here] off begin
		[Fact]
		public async void ServiceCommissioningBodyEntityControllerGetTest()
		{
			// Arrange
			using var controller = _serviceProvider.GetRequiredService<ServiceCommissioningBodyEntityController>();
			var entities = new EntityFactory<ServiceCommissioningBodyEntity>(10)
				.UseAttributes()
				.UseReferences()
				.UseOwner(Guid.NewGuid())
				.Generate()
				.ToList();
			_database.AddRange(entities);
			await _database.SaveChangesAsync();

			// Act
			var data = await controller.Get(null, default);

			// Assert
			data.Data.Select(d => d.Id).Should().Contain(entities.Select(d => d.Id));
		}
		// % protected region % [Customise Service Commissioning Body Entity crud tests here] end

	// % protected region % [Add any additional tests here] off begin
	// % protected region % [Add any additional tests here] end
	}
}