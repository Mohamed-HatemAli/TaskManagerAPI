namespace TaskManager.Core.Features.User.Queries.Results
{
    public class GetUserByIdResponse
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string PhoneNumber { get; set; } = string.Empty;
    }
}
