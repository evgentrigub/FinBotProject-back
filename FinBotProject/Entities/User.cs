using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using WebApi.Interfaces.Enums;

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
        /// <summary> Риск профиль пользователя /// </summary>
        public RiskType RiskType { get;  set; }
        /// <value>The password hash </value>
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }

        public virtual ICollection<TradingBot> TradingBots { get; set; }
        /// <summary>  Количество запущенных роботов у пользователя </summary>
        ///public int RobotsQuantity => TradingBots.Count(r => r.IsActive);
    }
}