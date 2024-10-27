namespace DotnetAPI.Dots
{
    public partial class UserDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Gender { get; set; }
        public bool Active { get; set; }

        public UserDto()
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
                Email = "";  
            }

            if (Gender == null)
            {
                Gender = "";
            }
        } 
    } 
}
