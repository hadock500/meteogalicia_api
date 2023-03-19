using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace meteogalicia_api
{
    public class Sky
    {
        [JsonProperty("mañana")]
        public DayClimate   Morning { get; set; }
        [JsonProperty("noche")]
        public NightClimate Night { get; set; }
        [JsonProperty("tarde")]
        public DayClimate   Afternoon { get; set; }
    }

    public class RainPercentage
    {
        [JsonProperty("mañana")]
        public int Morning { get; set; }
        [JsonProperty("noche")]
        public int Night { get; set; }
        [JsonProperty("tarde")]
        public int Afternoon { get; set; }
    }

    public class Prediction
    {
        [JsonProperty("fecha")]
        public DateTime         Date { get; set; }
        [JsonProperty("cielo")]
        public Sky?             Sky { get; set; }
        [JsonProperty("probabilidadLluvia")]
        public RainPercentage?  Rain { get; set; }
        [JsonProperty("tMax")]
        public int              TMax { get; set; }
        [JsonProperty("tMin")]
        public int              TMin { get; set; }
    }

    public enum DayClimate
    {
        [EnumMember(Value = "No disponible")]
        NoDisponible = -9999,
        [EnumMember(Value = "Despejado")]
        Despejado = 101,
        [EnumMember(Value = "Nubes altas")]
        NubesAltas = 102,
        [EnumMember(Value = "Nubes y claros")]
        NubesYClaros = 103,
        [EnumMember(Value = "Nublado 75%")]
        Nublado75 = 104,
        [EnumMember(Value = "Cubierto")]
        Cubierto = 105,
        [EnumMember(Value = "Nieblas")]
        Nieblas = 106,
        [EnumMember(Value = "Chubasco")]
        Chubasco = 107,
        [EnumMember(Value = "Chubasco (75%)")]
        Chubasco75 = 108,
        [EnumMember(Value = "Chubasco nieve")]
        ChubascoNieve = 109,
        [EnumMember(Value = "Llovizna")]
        Llovizna = 110,
        [EnumMember(Value = "Lluvia")]
        Lluvia = 111,
        [EnumMember(Value = "Nieve")]
        Nieve = 112,
        [EnumMember(Value = "Tormenta")]
        Tormenta = 113,
        [EnumMember(Value = "Bruma")]
        Bruma = 114,
        [EnumMember(Value = "Bancos de niebla")]
        BancosNiebla = 115,
        [EnumMember(Value = "Nubes medias")]
        NubesMedias = 116,
        [EnumMember(Value = "Lluvia débil")]
        LluviaDebil = 117,
        [EnumMember(Value = "Chubascos débiles")]
        ChubascosDebiles = 118,
        [EnumMember(Value = "Tormenta con pocas nubes")]
        TormentaPocasNubes = 119,
        [EnumMember(Value = "Agua nieve")]
        AguaNieve = 120,
        [EnumMember(Value = "Granizo")]
        Granizo = 121,
    }

    public enum NightClimate
    {
        [EnumMember(Value = "No disponible")]
        NoDisponible = -9999,
        [EnumMember(Value = "Despejado")]
        Despejado = 201,
        [EnumMember(Value = "Nubes altas")]
        NubesAltas = 202,
        [EnumMember(Value = "Nubes y claros")]
        NubesYClaros = 203,
        [EnumMember(Value = "Nublado 75%")]
        Nublado75 = 204,
        [EnumMember(Value = "Cubierto")]
        Cubierto = 205,
        [EnumMember(Value = "Nieblas")]
        Nieblas = 206,
        [EnumMember(Value = "Chubasco")]
        Chubasco = 207,
        [EnumMember(Value = "Chubasco (75%)")]
        Chubasco75 = 208,
        [EnumMember(Value = "Chubasco nieve")]
        ChubascoNieve = 209,
        [EnumMember(Value = "Llovizna")]
        Llovizna = 210,
        [EnumMember(Value = "Lluvia")]
        Lluvia = 211,
        [EnumMember(Value = "Nieve")]
        Nieve = 212,
        [EnumMember(Value = "Tormenta")]
        Tormenta = 213,
        [EnumMember(Value = "Bruma")]
        Bruma = 214,
        [EnumMember(Value = "Bancos de niebla")]
        BancosNiebla = 215,
        [EnumMember(Value = "Nubes medias")]
        NubesMedias = 216,
        [EnumMember(Value = "Lluvia débil")]
        LluviaDebil = 217,
        [EnumMember(Value = "Chubascos débiles")]
        ChubascosDebiles = 218,
        [EnumMember(Value = "Tormenta con pocas nubes")]
        TormentaPocasNubes = 219,
        [EnumMember(Value = "Agua nieve")]
        AguaNieve = 220,
        [EnumMember(Value = "Granizo")]
        Granizo = 221
    }
}

