using Microsoft.EntityFrameworkCore;

Console.WriteLine("Hello, World!");



public abstract class BaseType
{
    public BaseType(OwnedType ownedType)
    {
        OwnedType = ownedType;
    }

    protected BaseType(){}

    public Guid Id { get; } = Guid.NewGuid();
    public OwnedType OwnedType { get; }
}

public class SubTypeOne : BaseType
{
    public SubTypeOne(OwnedType ownedType) : base(ownedType) {}
    private SubTypeOne() {}
}

public class SubTypeTwo : BaseType
{
    public SubTypeTwo(OwnedType ownedType) : base(ownedType) {}
    private SubTypeTwo() {}
}


public class OwnedType
{
    public OwnedType(Guid id)
    {
        Id = id;
    }
    public Guid Id { get; }
}



public class TestDbContext : DbContext
{
    public TestDbContext() : base(new DbContextOptionsBuilder<TestDbContext>().UseSqlServer().Options) {}

    public DbSet<SubTypeOne> SubTypeOnes { get; set; }

    public DbSet<SubTypeTwo> SubTypeTwos { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);


modelBuilder.Owned<OwnedType>();
modelBuilder.Entity<BaseType>(baseType =>
{
    baseType.UseTpcMappingStrategy();

    baseType.Property(x => x.Id);
    baseType.OwnsOne(x => x.OwnedType, cfg => cfg.Property(x => x.Id));
});
    }
}