namespace EmailHandler.Models
{
    public class Activity
    {
        public string UserName { get; set; }

        public string ActivityName { get; set; }

        public DateTime ActivityDate { get; set; }

        public string ActivityLocation { get; set; }

        public string RedirectUrl { get; set; }
    }
}
