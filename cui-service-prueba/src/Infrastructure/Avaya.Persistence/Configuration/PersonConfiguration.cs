namespace Ibero.Services.Avaya.Persistence.Configuration
{
    using Ibero.Services.Avaya.Core.Entities;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    class PersonConfiguration : IEntityTypeConfiguration<Person>
    {

        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder.HasKey(e => e.Id_Banner);

            builder.Property(e => e.Num_Document)
                .HasMaxLength(20);

            builder.Property(e => e.Nam_Person)
                .HasMaxLength(250);

            builder.Property(e => e.Last_NamePerson)
                .HasMaxLength(250);

            // Data Seeding
            builder.HasData(new[]
            {
                new Person { Id_Banner = "100059339", Num_Document = "1023931504", Nam_Person = "JESSICA BRIGIT", Last_NamePerson = "PAEZ LOPEZ" }
            });
        }
    }
}
