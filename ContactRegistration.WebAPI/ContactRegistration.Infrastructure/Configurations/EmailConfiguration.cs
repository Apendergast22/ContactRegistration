
namespace ContactRegistration.Infrastructure.Configurations;

public class EmailConfiguration : IEntityTypeConfiguration<Email>
{
    public void Configure(EntityTypeBuilder<Email> builder)
    {
        builder.ToTable("email");

        builder.HasKey(p => p.EmailId);

        builder.Property(p => p.EmailId)
            .HasColumnName("emailId")
            .HasColumnType("INTEGER")
            .HasColumnOrder(0)
            .IsRequired();

        builder.Property(p => p.Address)
            .HasColumnName("address")
            .HasColumnType("nvarchar")
            .HasMaxLength(100)
            .IsRequired(true);

        builder.HasOne(x => x.Contact)
            .WithMany(x => x.Emails)
            .HasForeignKey(x => x.ContactId)
            .OnDelete(deleteBehavior: DeleteBehavior.Cascade);
    }
}
