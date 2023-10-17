﻿using DatabaseModels;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Identity;
using TheCatApiV2.Controller;
using TheCatApiV2.DatabaseModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components.Web;
using MudBlazor;

namespace TheCatApiV2.Pages
{
    public partial class FavoritesPage
    {
        private PictureJoinedController pictureJoinedController;

        private List<PictureJoinedDatabaseModel> picturesJoined;
        private List<BreedDatabaseModel> breeds = new List<BreedDatabaseModel>();
        private List<PictureDatabaseModel> pictures = new List<PictureDatabaseModel>();

        private IdentityUser currentUser;
        private string username;

        [Inject]
        Microsoft.AspNetCore.Identity.UserManager<IdentityUser> userManager { get; set; }
        [CascadingParameter]
        private Task<AuthenticationState> authenticationStateTask { get; set; }

        [Authorize]
        protected override async Task OnInitializedAsync()
        {
            this.pictureJoinedController = new PictureJoinedController(GetDatabaseContext);
            this.picturesJoined = new List<PictureJoinedDatabaseModel>();

            var user = (await authenticationStateTask).User;
            currentUser = await userManager.GetUserAsync(user);

            string userId = currentUser.Id;
            this.username = currentUser.UserName;

            this.picturesJoined = await pictureJoinedController.GetAllInformationsFavoritesPictureByIdUser(userId);
            DispatchByBreed();
        }

        private void DispatchByBreed()
        {
            foreach (PictureJoinedDatabaseModel pictureJoined in this.picturesJoined)
            {
                if (pictureJoined.Picture.BreedId != null)
                {
                    if (!breeds.Contains(pictureJoined.Picture.Breed))
                    {
                        breeds.Add(pictureJoined.Picture.Breed);
                    }
                }
            }

            foreach (PictureJoinedDatabaseModel pictureJoined in this.picturesJoined)
            {
                if (pictureJoined.Picture.BreedId != null && pictureJoined.IsFavorite)
                {
                    this.pictures.Add(pictureJoined.Picture);
                }
            }
        }

        private void DeleteFavorite(MouseEventArgs e, PictureDatabaseModel parametre)
        {
            pictureJoinedController.DeleteFavoritByPicture(parametre, currentUser);
            picturesJoined.Remove(picturesJoined.Where(pictureJoined => pictureJoined.Id == parametre.Id).FirstOrDefault());
            pictures.Remove(pictures.Where(picture => picture.Id == parametre.Id).FirstOrDefault());
            this.StateHasChanged();
        }

        private void UpdateBadLike(MouseEventArgs e, PictureJoinedDatabaseModel pictureJoinedParam)
        {
            if (!pictureJoinedParam.isBadLike)
            {
                pictureJoinedParam.Picture.NumberBad++;
                pictureJoinedParam.isBadLike = true;
                
                if(pictureJoinedParam.isLiked)
                {
                    pictureJoinedParam.isLiked = false;
                    pictureJoinedParam.Picture.NumberLiked--;
                }
            }
            else
            {
                pictureJoinedParam.Picture.NumberBad--;
                pictureJoinedParam.isBadLike = false;
            }

            this.pictureJoinedController.UpdatePictureJoined(pictureJoinedParam);
            this.StateHasChanged();
        }

        private void UpdateLike(MouseEventArgs e, PictureJoinedDatabaseModel pictureJoinedParam)
        {
            if (!pictureJoinedParam.isLiked)
            {
                pictureJoinedParam.Picture.NumberLiked++;
                pictureJoinedParam.isLiked = true;

                if (pictureJoinedParam.isBadLike)
                {
                    pictureJoinedParam.isBadLike = false;
                    pictureJoinedParam.Picture.NumberBad--;
                }
            }
            else
            {
                pictureJoinedParam.Picture.NumberLiked--;
                pictureJoinedParam.isLiked = false;
            }

            this.pictureJoinedController.UpdatePictureJoined(pictureJoinedParam);
            this.StateHasChanged();
        }
    }
}
