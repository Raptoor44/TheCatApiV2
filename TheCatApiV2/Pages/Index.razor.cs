using DatabaseModels;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using Models;
using System.ComponentModel;
using TheCatApiV2.Controller;
using TheCatApiV2.Data;
using TheCatApiV2.DatabaseModels;
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


        [Inject]
        Microsoft.AspNetCore.Identity.UserManager<IdentityUser> userManager { get; set; }
        [CascadingParameter]
        private Task<AuthenticationState> authenticationStateTask { get; set; }
        public DatabaseContext _dbContext { get; set; }

        protected override async Task OnInitializedAsync()
        {
            this.pictureController = new PictureController(GetDatabaseContext);
            this.pictureJoinedController = new PictureJoinedController(GetDatabaseContext);
            this.breedController = new BreedController(GetDatabaseContext);
            await GetRandomPicture();
            await this.breedController.InitBreedInDatabase();
        }

    
        private async void AddInMyFavorites()
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

            pictureJoined.IsFavorite = true;

            await pictureController.AddPictureAsync(picture);
            await pictureJoinedController.AddPictureFilledAsync(pictureJoined);

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

            this.StateHasChanged();
        }
    }
}
