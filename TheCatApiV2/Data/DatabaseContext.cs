using DatabaseModels;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TheCatApiV2.DatabaseModels;

namespace TheCatApiV2.Data
{
    public class DatabaseContext : IdentityDbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options)
            : base(options)
        {
        }

        public DbSet<PictureDatabaseModel> PicturesDatabaseModel { get; set; }
        public DbSet<PictureJoinedDatabaseModel> PicturesJoinedDatabaseModels { get; set; }
        public DbSet<BreedDatabaseModel> BreedsDatabaseModel { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<PictureJoinedDatabaseModel>()
                .HasOne(pictureJoined => pictureJoined.Picture) // La propriété de navigation vers PictureDatabaseModel
                .WithMany(picture => picture.Pictures)  // La propriété de navigation inverse dans PictureDatabaseModel
                .HasForeignKey(pjm => pjm.PictureId); // Clé étrangère dans PictureJoinedDatabaseModel

            modelBuilder.Entity<PictureDatabaseModel>()
                .HasMany(picture => picture.Pictures) // La propriété de navigation vers PictureJoinedDatabaseModel
                .WithOne(pictureJoined => pictureJoined.Picture) // La propriété de navigation inverse dans PictureJoinedDatabaseModel
                .HasForeignKey(pictureJoined => pictureJoined.PictureId); // Clé étrangère dans PictureJoinedDatabaseModel
        }
    }
}
