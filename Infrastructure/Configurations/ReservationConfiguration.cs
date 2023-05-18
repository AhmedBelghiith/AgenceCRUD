using ApplicationCore.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Configurations
{
    public class ReservationConfiguration : IEntityTypeConfiguration<Reservation>
    {
        public void Configure(EntityTypeBuilder<Reservation> builder)
        {
            builder.HasOne(p => p.Pack).WithMany(p => p.Reservations).HasForeignKey(p => p.PackFK);
            builder.HasOne(c=>c.Client).WithMany(c => c.Reservations).HasForeignKey(c => c.ClientFK);
            builder.HasKey(r=> new {r.PackFK,r.ClientFK, r.DateReservation});
        }
    }
}
