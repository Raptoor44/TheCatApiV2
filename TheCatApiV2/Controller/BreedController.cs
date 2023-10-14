using DatabaseModels;
using TheCatApiV2.Data;
using TheCatApiV2.DatabaseModels;
using TheCatApiV2.Models;

namespace TheCatApiV2.Controller
{
    public class BreedController
    {
        public DatabaseContext _dbContext { get; set; }

        private string apiUrlGetAllBreeds = "https://api.thecatapi.com/v1/breeds";

        public BreedController(DatabaseContext param)
        {
            this._dbContext = param;
        }

        public bool verifyToUpdate(int countParam)
        {
            bool result = _dbContext.BreedsDatabaseModel.Count() == countParam;

            return !result;
        }

        public async Task AddBreedsAsync(List<BreedDatabaseModel> breeds)
        {

            if (breeds == null)
            {
                throw new ArgumentNullException(nameof(breeds));
            }
            
            _dbContext.BreedsDatabaseModel.AddRange(breeds);
            await _dbContext.SaveChangesAsync();
        }

        public async Task InitBreedInDatabase()
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    HttpResponseMessage response = await client.GetAsync(apiUrlGetAllBreeds);

                    if (response.IsSuccessStatusCode)
                    {
                        List<BreedJsonModel> data = await response.Content.ReadFromJsonAsync<List<BreedJsonModel>>();

                        if (data != null && data.Count > 0 && verifyToUpdate(data.Count))
                        {
                            if (verifyToUpdate(data.Count))
                            {
                                List<BreedDatabaseModel> breeds = new List<BreedDatabaseModel>();
                                for (int i = 0; i < data.Count; i++)
                                {
                                    breeds = MapBreed(data, i, breeds);
                                }

                                await AddBreedsAsync(breeds);
                            }
                            else
                            {
                                Console.WriteLine("La console est déjà mis à jour");
                            }
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

        private List<BreedDatabaseModel> MapBreed(List<BreedJsonModel> data, int i, List<BreedDatabaseModel> breeds)
        {
            var breedJson = data[i];

      
            BreedDatabaseModel breedDatabase = new BreedDatabaseModel();
            breeds.Add(breedDatabase = new BreedDatabaseModel
            {
                Id = breedJson.id,
                Name = breedJson.name,
                CfaUrl = breedJson.cfa_url,
                VetstreetUrl = breedJson.vetstreet_url,
                VcahospitalsUrl = breedJson.vcahospitals_url,
                Temperament = breedJson.temperament,
                Origin = breedJson.origin,
                CountryCodes = breedJson.country_codes,
                CountryCode = breedJson.country_code,
                Description = breedJson.description,
                LifeSpan = breedJson.life_span,
                Indoor = breedJson.indoor,
                Lap = breedJson.lap,
                AltNames = breedJson.alt_names,
                Adaptability = breedJson.adaptability,
                AffectionLevel = breedJson.affection_level,
                ChildFriendly = breedJson.child_friendly,
                DogFriendly = breedJson.dog_friendly,
                EnergyLevel = breedJson.energy_level,
                Grooming = breedJson.grooming,
                HealthIssues = breedJson.health_issues,
                Intelligence = breedJson.intelligence,
                SheddingLevel = breedJson.shedding_level,
                SocialNeeds = breedJson.social_needs,
                StrangerFriendly = breedJson.stranger_friendly,
                Vocalisation = breedJson.vocalisation,
                Experimental = breedJson.experimental,
                Hairless = breedJson.hairless,
                Natural = breedJson.natural,
                Rare = breedJson.rare,
                Rex = breedJson.rex,
                SuppressedTail = breedJson.suppressed_tail,
                ShortLegs = breedJson.short_legs,
                WikipediaUrl = breedJson.wikipedia_url,
                Hypoallergenic = breedJson.hypoallergenic,
                ReferenceImageId = breedJson.reference_image_id,
                Imperial = breedJson.weight.imperial,
                Metric = breedJson.weight.metric
            });

            return breeds;
        }
    }
}
