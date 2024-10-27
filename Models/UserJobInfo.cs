namespace DotnetAPI.Models
{
    public partial class UsersJobInfo
    {
        public int UserId { get; set; }
        public string JobTitle { get; set; }
        public string Department { get; set; }

        public UsersJobInfo()
        {
            // Use '==' for comparison
            if (JobTitle == null)
            {
                JobTitle = "";
            }

            if (Department == null)
            {
                Department = "";
            }
        } // Closing brace for the constructor

    } // Closing brace for the class
}
