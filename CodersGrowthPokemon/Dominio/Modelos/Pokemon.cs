﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio.Enums;
using LinqToDB.Mapping;
using LinqToDB.Common;

namespace CrudWinFormsBancoMemoria.Models
{
    [Table("pokemons")]
    public class Pokemon
    {
        [PrimaryKey, Identity]
        public int Id { get; set; }

        [Column("nome"), NotNull]
        public string Nome { get; set; }

        [Column("apelido"), NotNull]
        public string Apelido { get; set; }

        [Column("nivel"), NotNull]
        public int Nivel { get; set; }

        [Column("altura"), NotNull]
        public decimal Altura { get; set; }

        [Column("shiny"), NotNull]
        public Boolean Shiny { get; set; }

        [Column("data_de_captura"), NotNull]
        public DateTime DataDeCaptura { get; set; }

        [Column("tipo_principal"), NotNull]
        public TipoPokemonEnum TipoPrincipal { get; set; }

        [Column("tipo_secundario"), Nullable]
        public TipoPokemonEnum? TipoSecundario { get; set; }

        [Column("foto"), Nullable]
        public string? Foto { get; set; }
    }
}
