namespace Transaction.Domain.Dtos.Requests
{
    public class CreateNewUserRequest
    {
        public string Name { get; set; } = string.Empty;
        public int Age { get; set; }
    }
}