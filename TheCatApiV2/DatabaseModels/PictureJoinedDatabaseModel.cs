
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Web.Providers.Entities;
using Microsoft.AspNetCore.Identity;

namespace DatabaseModels
{
    public class PictureJoinedDatabaseModel
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key, Column(Order = 0)]
        public int Id { get; set; }


        public string UserId { get; set; }
        public virtual IdentityUser User { get; set; }


        public int PictureId { get; set; }

        [ForeignKey("PictureId")]
        public virtual PictureDatabaseModel Picture { get; set; }

        public bool IsFavorite { get; set; }
        public bool isLiked { get; set; }
        public bool isBadLike { get; set; }
    }
}
