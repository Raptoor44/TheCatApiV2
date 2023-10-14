using DatabaseModels;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Identity;
using TheCatApiV2.Controller;
using System.Collections.Generic;
using TheCatApiV2.DatabaseModels;
using System.Linq;
using System.Net.NetworkInformation;
using TheCatApiV2.Data;
using TheCatApiV2.DatabaseModels;

namespace TheCatApiV2.Pages
{
    public partial class FavoritesPage
    {
        private PictureJoinedController pictureFilledController;

        private List<PictureJoinedDatabaseModel> picturesJoined;
        private List<BreedDatabaseModel> breeds = new List<BreedDatabaseModel>();

        private IdentityUser currentUser;
        private string username;

        [Inject]
        Microsoft.AspNetCore.Identity.UserManager<IdentityUser> userManager { get; set; }
        [CascadingParameter]
        private Task<AuthenticationState> authenticationStateTask { get; set; }

        protected override async Task OnInitializedAsync()
        {
            this.pictureFilledController = new PictureJoinedController(GetDatabaseContext);
            this.picturesJoined = new List<PictureJoinedDatabaseModel>();

            var user = (await authenticationStateTask).User;
            currentUser = await userManager.GetUserAsync(user);

            string userId = currentUser.Id;
            this.username = currentUser.UserName;



            this.picturesJoined = await pictureFilledController.GetAllInformationsFavoritesPictureByIdUser(userId);
            DispatchByBreed();
        }

        private void DispatchByBreed()
        {
            foreach(PictureJoinedDatabaseModel pictureJoined in this.picturesJoined)
            {
                if (pictureJoined.Picture.BreedId != null)
                {
                    if (!breeds.Contains(pictureJoined.Picture.Breed))
                    {
                        breeds.Add(pictureJoined.Picture.Breed);
                    }
                }
            }
        }

    }
}
