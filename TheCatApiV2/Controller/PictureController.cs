using Microsoft.EntityFrameworkCore; // Assurez-vous d'utiliser uniquement Microsoft.EntityFrameworkCore
using System;
using TheCatApiV2.Data;
using System.Collections.Generic; // Importez System.Collections.Generic pour List<T>

namespace DatabaseModels
{
    public class PictureController
    {
        public DatabaseContext _dbContext { get; set; }

        public PictureController(DatabaseContext param)
        {
            this._dbContext = param;
        }

        public async Task AddPictureAsync(PictureDatabaseModel picture)
        {
            if (picture == null)
            {
                throw new ArgumentNullException(nameof(picture));
            }

            if (!_dbContext.PicturesDatabaseModel.Any(p => p.UrlPicture == picture.UrlPicture)) // Correction de la requête LINQ
            {
                await _dbContext.PicturesDatabaseModel.AddAsync(picture);
                await _dbContext.SaveChangesAsync();
            }
        }

        public List<PictureDatabaseModel> GetPicturesByUserId()
        {
            return _dbContext.PicturesDatabaseModel
                .Include(picture => picture.Breed)
                .ToList();
        }
    }
}
