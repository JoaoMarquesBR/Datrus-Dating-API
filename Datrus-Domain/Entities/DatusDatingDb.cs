using Microsoft.EntityFrameworkCore;

namespace Datrus_Domain.Entities;

public partial class DatusDatingDb : DbContext
{
    public DatusDatingDb()
    {
    }

    public DatusDatingDb(DbContextOptions<DatusDatingDb> options)
        : base(options)
    {
    }
    
    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UsersMatch> UsersMatches { get; set; }

    public virtual DbSet<LikesSent> LikesSent { get; set; }

    public virtual DbSet<UserPreferences> UsersPreferences{ get; set; }

}
