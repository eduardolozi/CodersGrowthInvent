using LinqToDB.Mapping;

namespace Dominio.Enums
{
    public enum TipoPokemon
    {
        [MapValue("Agua")]
        Agua = 1,

        [MapValue("Fogo")]
        Fogo = 2,

        [MapValue("Planta")]
        Planta = 3,

        [MapValue("Eletrico")]
        Eletrico = 4,

        [MapValue("Gelo")]
        Gelo = 5,

        [MapValue("Lutador")]
        Lutador = 6,

        [MapValue("Psiquico")]
        Psiquico = 7,

        [MapValue("Terra")]
        Terra = 8,

        [MapValue("Voador")]
        Voador = 9,

        [MapValue("Veneno")]
        Veneno = 10,

        [MapValue("Rocha")]
        Rocha = 11,

        [MapValue("Inseto")]
        Inseto = 12,

        [MapValue("Fantasma")]
        Fantasma = 13,

        [MapValue("Noturno")]
        Noturno = 14,

        [MapValue("Aco")]
        Aco = 15,

        [MapValue("Dragao")]
        Dragao = 16,

        [MapValue("Normal")]
        Normal = 17
    }
}
