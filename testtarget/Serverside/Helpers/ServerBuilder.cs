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
using System.Security.Claims;
using AspNet.Security.OpenIdConnect.Primitives;
using Autofac.Extensions.DependencyInjection;
using Cis;
using Cis.Helpers;
using Cis.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;
// % protected region % [Add any extra imports here] off begin
// % protected region % [Add any extra imports here] end

namespace ServersideTests.Helpers
{
	public static class ServerBuilder
	{
		/// <summary>
		/// Creates a web host with an in memory database for testing
		/// </summary>
		/// <param name="builderOptions">Options for the host</param>
		/// <returns>The new web host</returns>
		public static IHost CreateServer(ServerBuilderOptions builderOptions = null)
		{
			builderOptions ??= new ServerBuilderOptions();

			// % protected region % [Add any additional actions before build here] off begin
			// % protected region % [Add any additional actions before build here] end

			var host = Host.CreateDefaultBuilder()
				.UseServiceProviderFactory(new AutofacServiceProviderFactory())
				.ConfigureAppConfiguration((builderContext, config) =>
				{
					// % protected region % [Configure app configuration here] off begin
					var env = builderContext.HostingEnvironment;
					config.Sources.Clear();
					config.AddXmlFile("appsettings.xml", optional: false, reloadOnChange: false);
					config.AddXmlFile($"appsettings.Test.xml", optional: true, reloadOnChange: false);
					config.AddEnvironmentVariables();
					// % protected region % [Configure app configuration here] end
				})
				.UseEnvironment("Development")
				.ConfigureServices((hostBuilder, sc) =>
				{
					// % protected region % [Configure services here] off begin
					// Replace the application database with a test configuration
					var dbOptions = builderOptions.DatabaseOptions(builderOptions, hostBuilder);
					sc.AddDbContextFactory<CisDBContext>(dbOptions);
					sc.AddDbContext<CisDBContext>(dbOptions);

					// Replace the implementation of the IHttpContextAccessor to only provide a testing context
					sc.AddScoped<IHttpContextAccessor>(serviceProvider =>
					{
						var httpContext = new DefaultHttpContext
						{
							User = builderOptions.UserPrincipal,
							RequestServices = serviceProvider,
							ServiceScopeFactory = serviceProvider.GetRequiredService<IServiceScopeFactory>(),
						};
						return new HttpContextAccessor { HttpContext = httpContext };
					});

					// Configure any custom services
					builderOptions.ConfigureServices?.Invoke(sc, builderOptions);
					// % protected region % [Configure services here] end
				})
				.ConfigureWebHostDefaults(builder =>
				{
					// % protected region % [Change Startup to custom Startup class here] off begin
					builder.UseStartup<Startup>();
					// % protected region % [Change Startup to custom Startup class here] end
				})
				.UseSerilog()
				.Build();

			if (builderOptions.InitialiseData)
			{
				// % protected region % [Configure data initialisation here] off begin
				var dataSeed = host.Services.GetRequiredService<DataSeedHelper>();
				dataSeed.Initialize().Wait();
				// % protected region % [Configure data initialisation here] end
			}

			// % protected region % [Add any additional actions after build here] off begin
			// % protected region % [Add any additional actions after build here] end

			return host;
		}

		/// <summary>
		/// Creates a claims principal for a user
		/// </summary>
		/// <param name="userId">The id of the user</param>
		/// <param name="userName">The username of the user</param>
		/// <param name="email">The email of the user</param>
		/// <param name="roles">The groups that the user is in</param>
		/// <returns>A claims principal to represent this information</returns>
		public static ClaimsPrincipal CreateUserPrincipal(Guid userId, string userName, string email, IEnumerable<string> roles)
		{
			var identity = new ClaimsIdentity(
				CookieAuthenticationDefaults.AuthenticationScheme,
				OpenIdConnectConstants.Claims.Name,
				OpenIdConnectConstants.Claims.Role);
			identity.AddClaim(new Claim("UserId", userId.ToString()));
			identity.AddClaim(new Claim(OpenIdConnectConstants.Claims.Subject, userId.ToString()));
			identity.AddClaim(new Claim(OpenIdConnectConstants.Claims.Name, userName));
			identity.AddClaims(roles.Select(r => new Claim(ClaimTypes.Role, r)));

			// % protected region % [Add any additional claims here] off begin
			// % protected region % [Add any additional claims here] end

			return new ClaimsPrincipal(identity);
		}
	}
}