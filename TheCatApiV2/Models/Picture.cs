namespace Models
{
    public class Picture
    {
        public int Id { get; set; }
        public string UrlPicture { get; set; }
        public bool IsLiked { get; set; }
        public bool IsBad { get; set; }
        public string IdBreed { get; set; }
    }
}
