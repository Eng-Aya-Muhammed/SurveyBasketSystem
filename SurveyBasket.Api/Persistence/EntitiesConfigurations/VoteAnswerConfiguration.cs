using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using SurveyBasket.API.Entities;

namespace SurveyBasket.API.Persistence.EntitiesConfigurations
{
    public class VoteAnswerConfiguration : IEntityTypeConfiguration<VoteAnswer>
    {
        public void Configure(EntityTypeBuilder<VoteAnswer> builder)
        {
            builder.HasIndex(x => new { x.VoteId, x.QuestionId }).IsUnique();
        }
    }
}
