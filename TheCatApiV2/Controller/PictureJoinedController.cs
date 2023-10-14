using DatabaseModels;
using System.Data.Entity;
using TheCatApiV2.Data;

namespace TheCatApiV2.Controller
{
    public class PictureJoinedController
    {
        public DatabaseContext _dbContext { get; set; }

        public PictureJoinedController(DatabaseContext param)
        {
            this._dbContext = param;
        }

        public async Task AddPictureFilledAsync(PictureJoinedDatabaseModel pictureJoinParam)
        {

            if (pictureJoinParam == null)
            {
                throw new ArgumentNullException(nameof(pictureJoinParam));
            }

            if (!_dbContext.PicturesJoinedDatabaseModels.Where(pictureJoined => pictureJoined.Picture.UrlPicture == pictureJoinParam.Picture.UrlPicture).Any())
            {
                await _dbContext.PicturesJoinedDatabaseModels.AddAsync(pictureJoinParam);
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task<List<PictureJoinedDatabaseModel>> GetAllInformationsFavoritesPictureByIdUser(string idUserParam)
        {
            if (string.IsNullOrEmpty(idUserParam))
            {
                throw new ArgumentNullException(nameof(idUserParam));
            }

            var pictureController = new PictureController(_dbContext);
            var userPictures = pictureController.GetPicturesByUserId();


            var favoritesPictures = _dbContext.PicturesJoinedDatabaseModels
                .Where(pictureJoined => pictureJoined.User.Id == idUserParam)
                .ToList();

            foreach (PictureJoinedDatabaseModel pictureJoined in favoritesPictures) //Nous sommes obligé d'utiliser une boucle foreach car le "Include" ne fonctionne pas
            {
                foreach (PictureDatabaseModel picture in userPictures)
                {
                    if (pictureJoined.PictureId == picture.Id)
                    {
                        pictureJoined.Picture = picture;
                    }
                }
            }

            return favoritesPictures;
        }
    }
}
