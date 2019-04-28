using System;
namespace WebApi.Interfaces.Enums
{
    public enum RiskType
    {
        Guaranteed = 5,
        Conservative = 10,
        Moderate = 15,
        Growth = 25,
        AggressiveGrowth = 30,
        MaximumGrowth = 40 
    }
}
