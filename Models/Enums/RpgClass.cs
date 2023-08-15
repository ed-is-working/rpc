using System.Text.Json.Serialization;

namespace rpc.Models.Enums
{

    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum RpgClass
    {
       Knight = 1,
       Mage = 2,
       Cleric = 3,
       NPC = 4,
       Admin = 10000,
       User =  9999,
    }
}