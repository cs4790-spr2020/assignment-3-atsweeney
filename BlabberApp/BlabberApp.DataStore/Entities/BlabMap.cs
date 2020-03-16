using BlabberApp.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlabberApp.DataStore.Entities
{
    public class BlabMap
    {
        //Constructor
        public BlabMap(EntityTypeBuilder<Blab> entityBuilder)
        {
            entityBuilder.HasKey(t => t.UserID);
            entityBuilder.Property(t => t.SysId);
            entityBuilder.Property(t => t.DTTM).IsRequired();
            entityBuilder.Property(t => t.Message);
        }
    }
}