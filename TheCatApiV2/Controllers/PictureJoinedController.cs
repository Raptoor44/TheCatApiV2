using DatabaseModels;
using Microsoft.AspNetCore.Identity;
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

        public async Task AddPictureJoinedAsync(PictureJoinedDatabaseModel pictureJoinParam)
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
                .Where(pictureJoined => pictureJoined.User.Id == idUserParam && pictureJoined.IsFavorite)
                .ToList();

            foreach (PictureJoinedDatabaseModel pictureJoined in favoritesPictures) //Nous sommes obligé d'utiliser une boucle foreach car le "Include" ne fonctionne pas.
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

        public async Task DeleteFavoritByPicture(PictureDatabaseModel pictureParam, IdentityUser currentUserParam)
        {
            if (pictureParam == null)
            {
                throw new ArgumentNullException(nameof(pictureParam));
            }

            if (currentUserParam == null)
            {
                throw new ArgumentNullException(nameof(currentUserParam));
            }

            var pictureJoinedToUnFavorite = _dbContext.PicturesJoinedDatabaseModels
                .FirstOrDefault(pictureJoined => pictureJoined.PictureId == pictureParam.Id && pictureJoined.UserId == currentUserParam.Id);

            if (pictureJoinedToUnFavorite != null)
            {
                pictureJoinedToUnFavorite.IsFavorite = false;

                _dbContext.PicturesJoinedDatabaseModels.Update(pictureJoinedToUnFavorite);
                await _dbContext.SaveChangesAsync();
            }
        }

        public PictureJoinedDatabaseModel GetByPicture(PictureDatabaseModel pictureParam)
        {

            if (pictureParam == null)
            {
                throw new ArgumentNullException(nameof(pictureParam));
            }

            return _dbContext.PicturesJoinedDatabaseModels.Where(picture => picture.Picture == pictureParam).FirstOrDefault();
        }

        public void UpdatePictureJoined(PictureJoinedDatabaseModel pictureJoinedParam)
        {
            if (pictureJoinedParam == null)
            {
                throw new ArgumentNullException(nameof(pictureJoinedParam));
            }

            _dbContext.Update(pictureJoinedParam);
            _dbContext.SaveChanges();
        }

        public List<PictureJoinedDatabaseModel> GetAllFavoritesWithoutBreed(string currentUserParam)
        {
            return _dbContext.PicturesJoinedDatabaseModels.Where(pictureJoined => pictureJoined.Picture.BreedId == null && pictureJoined.IsFavorite && pictureJoined.User.Id == currentUserParam).Include(pictureJoined => pictureJoined.Picture).ToList();
        }

        public List<PictureJoinedDatabaseModel> GetAllPicturesByUserId(string currentUserParam)
        {
            return _dbContext.PicturesJoinedDatabaseModels.Where(pictureJoined => pictureJoined.UserId == currentUserParam).Include(pictureJoined => pictureJoined.Picture).ToList();
        }

        public PictureJoinedDatabaseModel GetPictureJoinedByUrlAndUser(string currentUserParam, string url)
        {
            return _dbContext.PicturesJoinedDatabaseModels.Where(pictureJoined => pictureJoined.UserId == currentUserParam && pictureJoined.Picture.UrlPicture == url)
                .Include(pictureJoined => pictureJoined.User)
                .Include(pictureJoined => pictureJoined.Picture)
                .FirstOrDefault();
        }
    }
}
