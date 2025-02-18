namespace Transaction.Application.Dtos.Responses
{
    public class CreateNewUserResponse
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Age { get; set; }
    }
}