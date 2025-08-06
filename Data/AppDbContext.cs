using Hangfire.Common;
using Microsoft.EntityFrameworkCore;

namespace JobTracker.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options){}
    
    public DbSet<Job> Jobs { get; set; }
}