using MudBlazor;
using Microsoft.AspNetCore.Authorization;
using TheCatApiV2.Controller;
using TheCatApiV2.Models;
using TheCatApiV2.DatabaseModels;
using Models;
using DatabaseModels;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Identity;

namespace TheCatApiV2.Pages
{
    public partial class Breeds
    {

        private BreedController breedController;
        private PictureController pictureController;
        private PictureJoinedController pictureJoinedController;

        private List<BreedSelectModel> breedsSelect;

        private BreedDatabaseModel currentBreed;

        private List<string> pictureBreedsOne;
        private List<string> pictureBreedsTwo;

        private List<string> pictureBreedsAll;

        private string apiUrlRandomImage;

        private Picture loadPicture;

        private string currentUserId;

        public Position Position { get; set; } = Position.Left;

        [Inject]
        Microsoft.AspNetCore.Identity.UserManager<IdentityUser> userManager { get; set; }
        [CascadingParameter]
        private Task<AuthenticationState> authenticationStateTask { get; set; }


        [Authorize]
        protected override async Task OnInitializedAsync()
        {
            this.breedController = new BreedController(GetDatabaseContext);
            this.pictureController = new PictureController(GetDatabaseContext);
            this.pictureJoinedController = new PictureJoinedController(GetDatabaseContext);

            this.pictureBreedsOne = new List<string>();
            this.pictureBreedsTwo = new List<string>();
            this.pictureBreedsAll = new List<string>();

            InitBreed();
        }

        private void InitBreed()
        {
            breedsSelect = breedController.GetSelectBreeds();
        }

        private async Task UpdateCurrentBreed(string selectedValue)
        {
            currentBreed = breedController.GetBreedById(selectedValue);
            await initPicturesAsync();
        }

        private async Task initPicturesAsync()
        {
            this.apiUrlRandomImage = "http://api.thecatapi.com/v1/images/search?breed_ids=" + this.currentBreed.Id + "&api_key=live_qzhQS5XbYPlkVXpwLB9P6YwJTNREY5kFe3o5pQRWEXeFVFh74OKKBh7bu4JKcGVz";

            this.pictureBreedsOne.Clear();
            this.pictureBreedsTwo.Clear();
            this.pictureBreedsAll.Clear();

            for (int i = 0; i <= 10; i++)
            {
                string pictureA = await GetRandomPicture(this.pictureBreedsAll);
                this.pictureBreedsOne.Add(pictureA);
                this.pictureBreedsAll.Add(pictureA);

                string pictureB = await GetRandomPicture(this.pictureBreedsAll);
                this.pictureBreedsTwo.Add(pictureB);
                this.pictureBreedsAll.Add(pictureB);
            }
        }

        private void OnSelectedValue(Position value)
        {
            switch (value)
            {
                case Position.Top:
                    Position = Position.Top;
                    break;
                case Position.Start:
                    Position = Position.Start;
                    break;
                case Position.Left:
                    Position = Position.Left;
                    break;
                case Position.Right:
                    Position = Position.Right;
                    break;
                case Position.End:
                    Position = Position.End;
                    break;
                case Position.Bottom:
                    Position = Position.Bottom;
                    break;
            }
        }

        private async void AddInMyFavorites(string url)
        {
            PictureDatabaseModel pictureGetted = this.pictureController.GetByUrl(url);

            if (pictureGetted != null)
            {
                PictureJoinedDatabaseModel pictureJoined = pictureJoinedController.GetPictureJoinedByUrlAndUser(currentUserId, url);

                if (pictureJoined == null)
                {
                    pictureJoined = new PictureJoinedDatabaseModel();

                    var user = (await authenticationStateTask).User;
                    var currentUser = await userManager.GetUserAsync(user);

                    this.currentUserId = currentUser.Id;

                    pictureJoined.UserId = this.currentUserId;

                    pictureJoined.Picture = pictureGetted;
                }

                pictureJoined.IsFavorite = true;

                pictureJoinedController.UpdatePictureJoined(pictureJoined);
            }
            else
            {
                this.loadPicture = new Picture();
                this.loadPicture.UrlPicture = url;
                this.loadPicture.IdBreed = currentBreed.Id;

                PictureAssocation pictures = await CreateModelAsync();

                pictures.pictureJoined.IsFavorite = true;

                await pictureJoinedController.AddPictureJoinedAsync(pictures.pictureJoined);
            }
        }
        private async Task<PictureAssocation> CreateModelAsync()
        {
            PictureDatabaseModel picture = new PictureDatabaseModel();
            PictureJoinedDatabaseModel pictureJoined = new PictureJoinedDatabaseModel();

            picture.UrlPicture = loadPicture.UrlPicture;
            picture.BreedId = loadPicture.IdBreed;

            var user = (await authenticationStateTask).User;
            var currentUser = await userManager.GetUserAsync(user);

            this.currentUserId = currentUser.Id;

            pictureJoined.UserId = currentUserId;
            pictureJoined.Picture = picture;

            return new PictureAssocation(picture, pictureJoined);
        }
        private async
       Task<string>
GetRandomPicture(List<string> listUrl)
        {
            string url = "";
            bool isValid = false;

            using (HttpClient client = new HttpClient())
            {
                while (!isValid)
                {
                    try
                    {
                        HttpResponseMessage response = await client.GetAsync(apiUrlRandomImage);

                        if (response.IsSuccessStatusCode)
                        {
                            List<PictureJsonModel> data = await response.Content.ReadFromJsonAsync<List<PictureJsonModel>>();

                            if (data != null && data.Count > 0)
                            {
                                url = data[0].url;

                                if (!listUrl.Contains(url))
                                {
                                    isValid = true;
                                }
                                Console.WriteLine("URL du premier élément : " + url);
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

            }
            this.StateHasChanged();

            return url;
        }
    }
}