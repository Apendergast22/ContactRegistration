
namespace ContactRegistration.Infrastructure.Configurations;

public class ContactConfiguration : IEntityTypeConfiguration<Contact>
{
    public void Configure(EntityTypeBuilder<Contact> builder)
    {
        builder.ToTable("contact");

        builder.HasKey(p => p.Id);

        builder.Property(p => p.Id)
            .HasColumnName("id")
            .HasColumnType("INTEGER")
            .HasColumnOrder(0)
            .IsRequired();

        builder.Property(p => p.Name)
            .HasColumnName("name")
            .HasColumnType("nvarchar")
            .HasMaxLength(100)
            .IsRequired(true);

        builder.Property(p => p.BirthDate)
            .HasColumnName("dateOfBirth")
            .HasColumnType("date")            
            .IsRequired(false);
    }
}
