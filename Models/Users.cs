namespace DotnetAPI.Models
{
    public partial class User
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Gender { get; set; }
        public bool Active { get; set; }

        public User()
        {
            if (FirstName == null)
            {
                FirstName = "";
            }

            if (LastName == null)
            {
                LastName = "";
            }

            if (Email == null)
            {
                Email = "";  // Corrected Email assignment
            }

            if (Gender == null)
            {
                Gender = "";
            }
        } // Closing brace for the constructor
    } // Closing brace for the class
}
