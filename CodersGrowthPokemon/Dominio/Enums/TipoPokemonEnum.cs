using LinqToDB.Mapping;

namespace Dominio.Enums
{
    public enum TipoPokemonEnum
    {
        [MapValue(Value = "Agua")]
        Agua = 1,

        [MapValue(Value = "Fogo")]
        Fogo = 2,

        [MapValue(Value = "Planta")]
        Planta = 3,

        [MapValue(Value = "Eletrico")]
        Eletrico = 4,

        [MapValue(Value = "Gelo")]
        Gelo = 5,

        [MapValue(Value = "Lutador")]
        Lutador = 6,

        [MapValue(Value = "Psiquico")]
        Psiquico = 7,

        [MapValue(Value = "Terra")]
        Terra = 8,

        [MapValue(Value = "Voador")]
        Voador = 9,

        [MapValue(Value = "Veneno")]
        Veneno = 10,

        [MapValue(Value = "Rocha")]
        Rocha = 11,

        [MapValue(Value = "Inseto")]
        Inseto = 12,

        [MapValue(Value = "Fantasma")]
        Fantasma = 13,

        [MapValue(Value = "Noturno")]
        Noturno = 14,

        [MapValue(Value = "Aco")]
        Aco = 15,

        [MapValue(Value = "Dragao")]
        Dragao = 16,

        [MapValue(Value = "Normal")]
        Normal = 17
    }
}
