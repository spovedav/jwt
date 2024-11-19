using CAPA.APP.Interfaces.Respositorio;
using CAPA.DOMAIN.Entity;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace CAPA.INFRE.Respositorio
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        private readonly IDbConnection db;
        public UsuarioRepositorio(IDbConnection db)
        {
            this.db = db;  
        }

        public List<TableUsuario> GetAll()
        {
            return Datos();
        }

        public TableUsuario GetUsuario(string UserName, string Passs)
        {
            var datos = Datos();

            return datos.Where(x=> x.UserName.Equals(UserName, StringComparison.OrdinalIgnoreCase) &&
                                   x.UserName.Equals(UserName, StringComparison.OrdinalIgnoreCase))
                .FirstOrDefault();
        }


        private List<TableUsuario> Datos()
        {
            var lista = db.Query<TableUsuario>("select * from TableUsuario").ToList();

            return lista;
        }

    }
}
