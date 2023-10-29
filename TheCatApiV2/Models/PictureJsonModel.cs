namespace Models
{
    public class PictureJsonModel
    {
        public class Breed
        {
            public string? id { get; set; }
        }
        public string url { get; set; }
        public List<Breed> breeds { get; set; }
    }
}
