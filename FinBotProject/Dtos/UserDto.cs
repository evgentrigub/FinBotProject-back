namespace WebApi.Dtos
{
    public class UserDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        /// <summary> Общая сумма доходности за все время регистрации </summary>
        public double Profit { get; set; }
        /// <summary> Денежная сумма на счету </summary>
        public double Account { get; set; }
        public int RobotsQuantity { get; set; }
    }
}