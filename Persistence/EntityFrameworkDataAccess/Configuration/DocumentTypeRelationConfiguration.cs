using Domain.Entities.Lookups;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityFrameworkDataAccess.Configuration
{
    public class DocumentTypeRelationConfiguration : IEntityTypeConfiguration<DocumentTypeRelation>
    {
        public void Configure(EntityTypeBuilder<DocumentTypeRelation> builder)
        {
            builder.ToTable("DocumentTypeRelations");
           builder.HasKey(t => new { t.DocumentTypeId, t.RelationId, t.GenderId });
        }
    }
}
