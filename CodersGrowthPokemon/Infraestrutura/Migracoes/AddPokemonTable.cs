using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudWinFormsBancoMemoria.Migracoes
{
    [Migration(20231120080600)]
    public class AddPokemonTable : Migration
    {
        public override void Up()
        {
            Create.Table("pokemons")
                .WithColumn("id").AsInt32().NotNullable().PrimaryKey().Identity()
                .WithColumn("nome").AsString().NotNullable()
                .WithColumn("apelido").AsString().NotNullable()
                .WithColumn("nivel").AsInt32().NotNullable()
                .WithColumn("altura").AsCustom("DECIMAL(3,2)").NotNullable()
                .WithColumn("shiny").AsBoolean().NotNullable()
                .WithColumn("data_de_captura").AsDateTime().NotNullable()
                .WithColumn("tipo_principal").AsString().NotNullable()
                .WithColumn("tipo_secundario").AsString().Nullable()
                .WithColumn("foto").AsCustom("VARCHAR(MAX)").Nullable();        }

        public override void Down()
        {
            Delete.Table("pokemons");
        }
    }
}
