using DatabaseModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using Models;
using MudBlazor;
using TheCatApiV2.Controller;
using TheCatApiV2.Data;
using TheCatApiV2.Models;

namespace TheCatApiV2.Pages
{
    public partial class Index
    {


        private PictureController pictureController;
        private PictureJoinedController pictureJoinedController;
        private BreedController breedController;

        private Picture loadPicture = new Picture();
        private string apiUrlRandomImage = "http://api.thecatapi.com/v1/images/search?api_key=live_qzhQS5XbYPlkVXpwLB9P6YwJTNREY5kFe3o5pQRWEXeFVFh74OKKBh7bu4JKcGVz";

        private Variant variantLike;
        private Variant variantBadLike;

        private List<PictureDatabaseModel> pictures;

        [Inject]
        Microsoft.AspNetCore.Identity.UserManager<IdentityUser> userManager { get; set; }
        [CascadingParameter]
        private Task<AuthenticationState> authenticationStateTask { get; set; }
        public DatabaseContext _dbContext { get; set; }

        [Authorize]
        protected override async Task OnInitializedAsync()
        {
            this.pictureController = new PictureController(GetDatabaseContext);
            this.pictureJoinedController = new PictureJoinedController(GetDatabaseContext);
            this.breedController = new BreedController(GetDatabaseContext);

            await GetRandomPicture();
            GetIsLike();
            await this.breedController.InitBreedInDatabase();

            InitGlobalScore();
        }

        private async void GetIsLike()
        {

            PictureDatabaseModel pictureIsLike = this.pictureController.GetByUrl(loadPicture.UrlPicture);

            if (pictureIsLike != null)
            {
                PictureJoinedDatabaseModel pictureJoined = this.pictureJoinedController.GetByPicture(pictureIsLike);
                if (pictureJoined != null)
                {
                    if (pictureJoined.isLiked)
                    {
                        variantLike = Variant.Filled;
                    }
                    else
                    {
                        variantLike = Variant.Outlined;
                    }

                    if (pictureJoined.isBadLike)
                    {
                        variantBadLike = Variant.Filled;
                    }
                    else
                    {
                        variantBadLike = Variant.Outlined;
                    }
                }
            }
            this.StateHasChanged();
        }

        private async void Like()
        {
            PictureDatabaseModel pictureLike = this.pictureController.GetByUrl(loadPicture.UrlPicture);

            if (pictureLike != null)
            {
                PictureJoinedDatabaseModel pictureJoined = this.pictureJoinedController.GetByPicture(pictureLike);

                if (!pictureJoined.isLiked)
                {
                    pictureLike.NumberLiked++;
                    pictureJoined.isLiked = true;

                    if(pictureJoined.isBadLike)
                    {
                        pictureLike.NumberBad--;
                        pictureJoined.isBadLike = false;
                    }
                }
                else
                {
                    pictureLike.NumberBad--;
                    pictureJoined.isLiked = false;
                }

                pictureJoinedController.UpdatePictureJoined(pictureJoined);
            }
            else
            {
                PictureAssocation pictures = await CreateModelAsync();

                pictures.picture.NumberLiked++;
                pictures.pictureJoined.isLiked = true;

                await pictureJoinedController.AddPictureJoinedAsync(pictures.pictureJoined);
            }
            GetIsLike();
        }

        private async void BadLike()
        {
            PictureDatabaseModel pictureBadLike = this.pictureController.GetByUrl(loadPicture.UrlPicture);

            if (pictureBadLike != null)
            {
                PictureJoinedDatabaseModel pictureJoined = this.pictureJoinedController.GetByPicture(pictureBadLike);

                if (!pictureJoined.isBadLike)
                {
                    pictureBadLike.NumberBad++;
                    pictureJoined.isBadLike = true;

                    if (pictureJoined.isLiked)
                    {
                        pictureBadLike.NumberLiked--;
                        pictureJoined.isLiked = false;
                    }
                }
                else
                {
                    pictureBadLike.NumberBad--;
                    pictureJoined.isBadLike = false;
                }

                pictureJoinedController.UpdatePictureJoined(pictureJoined);
            }
            else
            {
                PictureAssocation pictures = await CreateModelAsync();

                pictures.picture.NumberBad++;
                pictures.pictureJoined.isBadLike = true;

                await pictureJoinedController.AddPictureJoinedAsync(pictures.pictureJoined);
            }
            GetIsLike();
        }
        private async void AddInMyFavorites()
        {
            PictureDatabaseModel pictureFavorite = this.pictureController.GetByUrl(loadPicture.UrlPicture);

            if (pictureFavorite != null)
            {
                PictureJoinedDatabaseModel pictureJoined = this.pictureJoinedController.GetByPicture(pictureFavorite);

                pictureJoined.IsFavorite = true;

                pictureJoinedController.UpdatePictureJoined(pictureJoined);
            }
            else
            {
                PictureAssocation pictures = await CreateModelAsync();

                pictures.pictureJoined.IsFavorite = true;

                await pictureJoinedController.AddPictureJoinedAsync(pictures.pictureJoined);
            }
            GetIsLike();
            GetRandomPicture();
        }

        private async
        Task
GetRandomPicture()
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    HttpResponseMessage response = await client.GetAsync(apiUrlRandomImage);

                    if (response.IsSuccessStatusCode)
                    {
                        List<PictureJsonModel> data = await response.Content.ReadFromJsonAsync<List<PictureJsonModel>>();

                        if (data != null && data.Count > 0)
                        {
                            loadPicture.UrlPicture = data[0].url;
                            loadPicture.IdBreed = data[0].breeds[0].id;
                            Console.WriteLine("URL du premier élément : " + loadPicture.UrlPicture);
                        }
                        else
                        {
                            Console.WriteLine("Aucune image disponible.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Erreur HTTP : " + response.StatusCode);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Erreur : " + ex.Message);
                }
            }

            variantBadLike = Variant.Outlined;
            variantLike = Variant.Outlined;

            this.StateHasChanged();
        }

        private async Task<PictureAssocation> CreateModelAsync()
        {
            PictureDatabaseModel picture = new PictureDatabaseModel();
            PictureJoinedDatabaseModel pictureJoined = new PictureJoinedDatabaseModel();

            picture.UrlPicture = loadPicture.UrlPicture;
            picture.BreedId = loadPicture.IdBreed;

            var user = (await authenticationStateTask).User;
            var currentUser = await userManager.GetUserAsync(user);

            string userId = currentUser.Id;


            pictureJoined.UserId = userId;
            pictureJoined.Picture = picture;

            return new PictureAssocation(picture, pictureJoined);
        }

        private void InitGlobalScore()
        {
            this.pictures = this.pictureController.GetTopLike();
        }
    }
}
