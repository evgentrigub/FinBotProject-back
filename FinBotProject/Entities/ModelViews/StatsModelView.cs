using System;
using WebApi.Interfaces.Enums;

namespace WebApi.Entities.ModelViews
{
    public class StatsModelView
    {
        /// <summary> Общая сумма доходности за все время регистрации </summary>
        public double Profit { get; set; }
        /// <summary> Денежная сумма на счету </summary>
        public double Account { get; set; }
        /// <summary> Риск профиль пользователя /// </summary>
        public RiskType RiskType { get; set; }
        ///<summary> Количество роботов у пользователя ///</summary>
        public int RobotsQuantity { get; set; }
    }
}
