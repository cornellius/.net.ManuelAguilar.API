using Microsoft.EntityFrameworkCore;
using ManuelAguilar.API.Domain;

namespace ManuelAguilar.API.Data
{
	public class ApiDbContext : DbContext
	{
		public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options)
		{

		}

        public virtual DbSet<Author> Authors { get; set; }

        public virtual DbSet<Post> Posts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

			modelBuilder.Entity<Post>(entity =>
			{
				entity.HasOne(a => a.Author)
                    .WithMany(p => p.Posts)
                    .HasForeignKey(x => x.AuthorId)
                    .OnDelete(DeleteBehavior.Restrict)
					.HasConstraintName("FK_Author");
			});

            // Populate database with initial authors
            modelBuilder.Entity<Author>().HasData(
                new Author
                {
                    Id = 1,
                    Name = "John",
                    Surname = "Smith"
                },
                new Author
                {
                    Id = 2,
                    Name = "Matthias",
                    Surname = "Summer"
                },
                new Author
                {
                    Id = 3,
                    Name = "Josh",
                    Surname = "Garret"
            });
        }
    }
}