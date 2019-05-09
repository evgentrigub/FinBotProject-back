using System;
namespace WebApi.Interfaces.Enums
{
    public enum Industry
    {
        /// <summary>
        /// Для не assets
        /// </summary>
        Other = 0,
        /// <summary> Информационные технологии /// </summary>
        IT = 1,
        /// <summary>  Здравоохранение /// </summary>
        Medicine = 2,
        /// <summary> Машиностроение и транспорт /// </summary>
        Transport = 3,
        /// <summary> Недвижимость /// </summary>
        RealEstate = 4,
        /// <summary> Потребительские товары и услуги /// </summary>
        Consumption = 5,
        /// <summary> Финансовый сектор /// </summary>
        Finance = 6,
        /// <summary> Энергетика /// </summary>
        Energy = 7,
        /// <summary> Сырьевая промышленность /// </summary>
        RawMaterial = 8,
        /// <summary> Электроэнергетика /// </summary>
        ElecticPower = 9,
        /// <summary> Телеклммуникации /// </summary>
        Telecommunication = 10
    }
}
