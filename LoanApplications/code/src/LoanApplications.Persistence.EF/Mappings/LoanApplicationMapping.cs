using System;
using System.Collections.Generic;
using System.Text;
using LoanApplications.Domain.Model.LoanApplications;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LoanApplications.Persistence.EF.Mappings
{
    public class LoanApplicationMapping : IEntityTypeConfiguration<LoanApplication>
    {
        public void Configure(EntityTypeBuilder<LoanApplication> builder)
        {
            builder.ToTable("LoanApplications").HasKey(a => a.Id);
            builder.Property(a => a.Id).ValueGeneratedNever();
            builder.Property(a => a.LoanAmount);
            builder.Property(a => a.PaybackPeriod);
            builder.Property(a => a.ApplicantId);
            builder.Property(a => a.State)
                .HasColumnName("State")
                .HasConversion(
                    a => LoanApplicationStateValueFactory.GetValue(a.GetType()),
                    a => LoanApplicationStateValueFactory.GetState(a)
                );
        }
    }
}
