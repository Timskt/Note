using System.Configuration;
using Microsoft.EntityFrameworkCore;
using Note.Unity.DbModels;

namespace Note.Common.DataBase;

public class DataContext:DbContext
{
    public DataContext()
    {
        
    }

    public DataContext(DbContextOptions<DataContext> options):base(options)
    {
        
    }
    
    public virtual DbSet<CardConfig> CardConfigs { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        optionsBuilder.UseSqlite(ConfigurationManager.AppSettings["dbConnectString"])
            .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
    }
}