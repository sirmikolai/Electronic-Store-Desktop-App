using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicStoreWpfAndSqlLite.Enums
{
    public enum TypeOfProductEnum
    {
        [EnumMember(Value = "Smartfon")]
        Smartfon,
        [EnumMember(Value = "Laptop")]
        Laptop,
        [EnumMember(Value = "Komputer stacjonarny")]
        KomputerStacjonarny,
        [EnumMember(Value = "Procesor")]
        Procesor,
        [EnumMember(Value = "Karta graficzna")]
        KartaGraficzna,
        [EnumMember(Value = "Dysk twardy")]
        DyskTwardy,
        [EnumMember(Value = "Klawiatura")]
        Klawiatura,
        [EnumMember(Value = "Mysz")]
        Mysz,
        [EnumMember(Value = "Monitor")]
        Monitor,
        [EnumMember(Value = "Kabel")]
        Kabel,
        [EnumMember(Value = "Ładowarka")]
        Ładowarka
    }
}
