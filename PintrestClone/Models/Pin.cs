namespace PintrestClone.Models
{
    public class Pin
    {
        public virtual ApplicationUser UserId { get; set; }

        public string PhotoUrl { get; set; }
        public string Body { get; set; }
        public string PinUrl { get; set; }
    }
}