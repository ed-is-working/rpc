using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using rpc.Models.Enums;

namespace rpc.DTOs.Character
{
    // considered to call it GetCharacterResponseDTO.cs
    public class GetCharacterDTO
    {
    public int Id { get; set; } = 1;
    public string Name { get; set; } = "Frodo";

    public string EMail{ get; set; } = "";

    public int Strength { get; set; } = 10;

    public int Defense { get; set; } = 10;

    public int HitPoints { get; set; } = 100;

    public int Intelligence { get; set; } = 10;

    public RpgClass Class { get; set; } = RpgClass.Knight; // this will be and admin or user for generic usage
    
    }
}