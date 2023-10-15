using DatabaseModels;

namespace TheCatApiV2.Models
{
    public class PictureAssocation
    {
        public PictureAssocation(PictureDatabaseModel picture, PictureJoinedDatabaseModel pictureJoined)
        {
            this.picture = picture;
            this.pictureJoined = pictureJoined;
        }

        public PictureDatabaseModel picture { get; set; }
        public PictureJoinedDatabaseModel pictureJoined { get; set; }
    }
}
