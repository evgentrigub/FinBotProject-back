using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace WebApi.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        /// <summary> Общая сумма доходности за все время регистрации </summary>
        public double Profit { get; set; }
        /// <summary> Денежная сумма на счету </summary>
        public double Account { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }

        public virtual ICollection<TradingBot> TradingBots { get; set; }
        //[NotMapped]
        /// <summary>  Количество запущенных роботов у пользователя </summary>
        //public int RobotsQuantity => TradingBots.Count(r => r.IsActive);
    }
}