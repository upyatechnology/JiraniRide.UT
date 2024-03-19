using Application.Contracts;
using Domain.Common;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public class JiraniDbContext : DbContext
    {
        private readonly ILoggedInUserService? _loggedInUserService;
        public JiraniDbContext(DbContextOptions<JiraniDbContext> options)
            :base(options)
        {
            
        }

        public JiraniDbContext(DbContextOptions<JiraniDbContext> options, ILoggedInUserService loggedInUserService)
            : base(options)
        {
            _loggedInUserService = loggedInUserService;
        }

        public DbSet<Driver> Drivers { get; set; }
        public DbSet<DriverRouteCreate> Categories { get; set; }
        public DbSet<RiderRouteCreate> Orders { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(JiraniDbContext).Assembly);

            //seed data, added through migrations
            var routeGuid = Guid.Parse("{B0788D2F-8003-43C1-92A4-EDC76A7C5DDE}");
            var driverGuid = Guid.Parse("{6313179F-7837-473A-A4D5-A5571B43E6A6}");
            var rideRequestGuid = Guid.Parse("{BF3F3002-7E53-441E-8B76-F6280BE284AA}");

            modelBuilder.Entity<Driver>().HasData(new Driver
            {
                
            });
            modelBuilder.Entity<RiderRouteCreate>().HasData(new RiderRouteCreate
            {
               
            });
            modelBuilder.Entity<DriverRouteCreate>().HasData(new DriverRouteCreate
            {
                
            });
          

           

            //modelBuilder.Entity<Event>().HasData(new Event
            //{
            //    EventId = Guid.Parse("{62787623-4C52-43FE-B0C9-B7044FB5929B}"),
            //    Name = "Spanish guitar hits with Manuel",
            //    Price = 25,
            //    Artist = "Manuel Santinonisi",
            //    Date = DateTime.Now.AddMonths(4),
            //    Description = "Get on the hype of Spanish Guitar concerts with Manuel.",
            //    ImageUrl = "https://gillcleerenpluralsight.blob.core.windows.net/files/GloboTicket/guitar.jpg",
            //    CategoryId = concertGuid
            //});

            //modelBuilder.Entity<Event>().HasData(new Event
            //{
            //    EventId = Guid.Parse("{1BABD057-E980-4CB3-9CD2-7FDD9E525668}"),
            //    Name = "Techorama Belgium",
            //    Price = 400,
            //    Artist = "Many",
            //    Date = DateTime.Now.AddMonths(10),
            //    Description = "The best tech conference in the world",
            //    ImageUrl = "https://gillcleerenpluralsight.blob.core.windows.net/files/GloboTicket/conf.jpg",
            //    CategoryId = conferenceGuid
            //});

           


            //modelBuilder.Entity<Order>().HasData(new Order
            //{
            //    Id = Guid.Parse("{771CCA4B-066C-4AC7-B3DF-4D12837FE7E0}"),
            //    OrderTotal = 85,
            //    OrderPaid = true,
            //    OrderPlaced = DateTime.Now,
            //    UserId = Guid.Parse("{D97A15FC-0D32-41C6-9DDF-62F0735C4C1C}")
           // });

            
           
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries<AuditableEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedDate = DateTime.Now;
                        entry.Entity.CreatedBy = _loggedInUserService.UserId;
                        break;
                    case EntityState.Modified:
                        entry.Entity.LastModifiedDate = DateTime.Now;
                        entry.Entity.LastModifiedBy = _loggedInUserService.UserId;
                        break;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
