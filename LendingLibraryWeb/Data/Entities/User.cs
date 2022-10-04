namespace LendingLibraryWeb.Data.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public UserType UserType { get; set; }
    }

    public enum UserType
    {
        Admin,
        Member
    }
}