using MudBlazor;
using Microsoft.AspNetCore.Authorization;
using TheCatApiV2.Controller;
using TheCatApiV2.Models;
using TheCatApiV2.DatabaseModels;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;

namespace TheCatApiV2.Pages
{
    public partial class Breeds
    {

        private BreedController breedController;

        private List<BreedSelectModel> breedsSelect;
        private string bindValue;

        private BreedDatabaseModel currentBreed;


        [Authorize]
        protected override async Task OnInitializedAsync()
        {
            this.breedController = new BreedController(GetDatabaseContext);

            InitBreed();
        }

        private void InitBreed()
        {
            breedsSelect = breedController.GetSelectBreeds();
        }

        private void UpdateCurrentBreed()
        {
            currentBreed = breedController.GetBreedById(bindValue);
        }
    }
}