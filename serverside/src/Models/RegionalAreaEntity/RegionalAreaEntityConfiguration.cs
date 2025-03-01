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
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
// % protected region % [Add any further imports here] off begin
// % protected region % [Add any further imports here] end

namespace Cis.Models {
	public class RegionalAreaEntityConfiguration : IEntityTypeConfiguration<RegionalAreaEntity>
	{
		public void Configure(EntityTypeBuilder<RegionalAreaEntity> builder)
		{
			AbstractModelConfiguration.Configure(builder);

			// % protected region % [Override Servicess RegionalArea configuration here] off begin
			builder
				.HasMany(e => e.Servicess)
				.WithOne(e => e.RegionalArea)
				.OnDelete(DeleteBehavior.Restrict);
			// % protected region % [Override Servicess RegionalArea configuration here] end

			// % protected region % [Override Sa2id index configuration here] off begin
			builder.HasIndex(e => e.Sa2id).IsUnique();
			// % protected region % [Override Sa2id index configuration here] end

			// % protected region % [Override Sa3id index configuration here] off begin
			builder.HasIndex(e => e.Sa3id);
			// % protected region % [Override Sa3id index configuration here] end

			// % protected region % [Override Sa3name index configuration here] off begin
			builder.HasIndex(e => e.Sa3name);
			// % protected region % [Override Sa3name index configuration here] end

			// % protected region % [Override Sa2name index configuration here] off begin
			builder.HasIndex(e => e.Sa2name);
			// % protected region % [Override Sa2name index configuration here] end

			// % protected region % [Override GapScore index configuration here] off begin
			builder.HasIndex(e => e.GapScore);
			// % protected region % [Override GapScore index configuration here] end

			// % protected region % [Add any extra db model config options here] off begin
			// % protected region % [Add any extra db model config options here] end
		}
	}
}