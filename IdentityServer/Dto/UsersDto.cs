namespace IdentityServer.UserDto
{
    public sealed class UsersDto
    {
        public string FullName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string UserName { get; set; }
        public string Password { get; set; } = string.Empty;
        public string UserNameorEmail { get; set; } = string.Empty;
    }
}
