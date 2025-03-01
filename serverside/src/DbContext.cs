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
using Hangfire.EntityFrameworkCore;
using Npgsql;
using Audit.EntityFramework;
using Microsoft.AspNetCore.DataProtection.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Cis.Enums;
// % protected region % [Add any extra imports here] off begin
// % protected region % [Add any extra imports here] end

namespace Cis.Models {
	// % protected region % [Change the class signature here] off begin
	public class CisDBContext : AuditIdentityDbContext<User, Group, Guid>, IDataProtectionKeyContext
	// % protected region % [Change the class signature here] end
	{
		public string SessionUserId { get; set; }
		public string SessionUser { get; set; }
		public string SessionId { get; set; }

		// % protected region % [Add any custom class variables] off begin
		// % protected region % [Add any custom class variables] end

		public DbSet<UploadFile> Files { get; set; }
		public DbSet<AdminEntity> AdminEntity { get; set; }
		public DbSet<RegionalAreaEntity> RegionalAreaEntity { get; set; }
		public DbSet<ServiceEntity> ServiceEntity { get; set; }
		public DbSet<ServiceCommissioningBodyEntity> ServiceCommissioningBodyEntity { get; set; }
		public DbSet<ServiceCommissioningBodiesServices> ServiceCommissioningBodiesServices { get; set; }
		public DbSet<DataProtectionKey> DataProtectionKeys { get; set; }

		static CisDBContext()
		{
			NpgsqlConnection.GlobalTypeMapper.MapEnum<Categories>();
			NpgsqlConnection.GlobalTypeMapper.MapEnum<Servicetype>();
			NpgsqlConnection.GlobalTypeMapper.MapEnum<Gender>();
			// % protected region % [Add extra methods to the static constructor here] off begin
			// % protected region % [Add extra methods to the static constructor here] end
		}

		public CisDBContext(
			// % protected region % [Add any custom constructor paramaters] off begin
			// % protected region % [Add any custom constructor paramaters] end
			DbContextOptions<CisDBContext> options)
			: base(options)
		{
			// % protected region % [Add any constructor config here] off begin
			// % protected region % [Add any constructor config here] end
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			// % protected region % [Customise Hangfire configuration here] off begin
			modelBuilder.OnHangfireModelCreating();
			// % protected region % [Customise Hangfire configuration here] end

			modelBuilder.HasPostgresEnum<Categories>();
			modelBuilder.HasPostgresEnum<Servicetype>();
			modelBuilder.HasPostgresEnum<Gender>();
			// Configure models from the entity diagram
			modelBuilder.HasPostgresExtension("uuid-ossp");
			modelBuilder.ApplyConfiguration(new AdminEntityConfiguration());
			modelBuilder.ApplyConfiguration(new RegionalAreaEntityConfiguration());
			modelBuilder.ApplyConfiguration(new ServiceEntityConfiguration());
			modelBuilder.ApplyConfiguration(new ServiceCommissioningBodyEntityConfiguration());
			modelBuilder.ApplyConfiguration(new ServiceCommissioningBodiesServicesConfiguration());

			// Configure the user and group models
			modelBuilder.ApplyConfiguration(new UserConfiguration());
			modelBuilder.ApplyConfiguration(new GroupConfiguration());

			// Configure the file upload models
			modelBuilder.ApplyConfiguration(new UploadFileConfiguration());

			// % protected region % [Add any further model config here] off begin
			// % protected region % [Add any further model config here] end
		}

		/// <summary>
		/// Gets a DbSet of a certain type from the context
		/// </summary>
		/// <param name="name">The name of the DbSet to retrieve</param>
		/// <typeparam name="T">The type to cast the DbSet to</typeparam>
		/// <returns>A DbSet of the given type</returns>
		[Obsolete("Please obtain the db set from the db context with generic type param instead.")]
		public DbSet<T> GetDbSet<T>(string name = null) where T : class, IAbstractModel
		{
			// % protected region % [Add any extra logic on GetDbSet here] off begin
			// % protected region % [Add any extra logic on GetDbSet here] end

			return GetType().GetProperty(name ?? typeof(T).Name).GetValue(this, null) as DbSet<T>;
		}

		/// <summary>
		/// Gets a DbSet as an IQueryable over the owner abstract model
		/// </summary>
		/// <param name="name">The name of the DbSet to retrieve</param>
		/// <returns>The DbSet as an IQueryable over the OwnerAbstractModel or null if it doesn't exist</returns>
		public IQueryable GetOwnerDbSet(string name)
		{
			return GetType().GetProperty(name).GetValue(this, null) as IQueryable;
		}

		// % protected region % [Add any extra db config here] off begin
		// % protected region % [Add any extra db config here] end
	}
}
