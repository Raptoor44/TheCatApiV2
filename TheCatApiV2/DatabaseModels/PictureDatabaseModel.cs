using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using TheCatApiV2.DatabaseModels;

namespace DatabaseModels
{
    public class PictureDatabaseModel
    {

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key, Column(Order = 0)]
        public int Id { get; set; }
        public string UrlPicture { get; set; }
        public int NumberLiked { get; set; } = 0;
        public int NumberBad { get; set; } = 0;

        public virtual List<PictureJoinedDatabaseModel>? Pictures { get; set; }

        public string? BreedId { get; set; }
        public virtual BreedDatabaseModel? Breed { get; set; }
    }
}
