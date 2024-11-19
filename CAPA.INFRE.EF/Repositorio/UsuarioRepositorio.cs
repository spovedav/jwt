using CAPA.APP.Interfaces.Respositorio;
using CAPA.DOMAIN.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace CAPA.INFRE.EF.Repositorio
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        private readonly AppDbContext _db;

        public UsuarioRepositorio(AppDbContext _db)
        {
            this._db = _db;
        }

        public List<TableUsuario> GetAll()
        {
            return Datos();
        }

        public TableUsuario GetUsuario(string UserName, string Passs)
        {
            var datos = Datos();

            return datos.Where(x => x.UserName.Equals(UserName, StringComparison.OrdinalIgnoreCase) &&
                                   x.UserName.Equals(UserName, StringComparison.OrdinalIgnoreCase))
                .FirstOrDefault();
        }


        private List<TableUsuario> Datos()
        {
            var lista = _db.TableUsuario.ToList();

            return lista;
        }

    }
}
