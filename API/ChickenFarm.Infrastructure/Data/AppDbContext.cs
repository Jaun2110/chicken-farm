using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChickenFarm.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ChickenFarm.Infrastructure.Data
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
public DbSet<Flock> Flocks => Set<Flock>();
public DbSet<EggRecord> EggRecords => Set<EggRecord>();
public DbSet<Order> Orders => Set<Order>();
public DbSet<Paddock> Paddocks => Set<Paddock>();

    }
}