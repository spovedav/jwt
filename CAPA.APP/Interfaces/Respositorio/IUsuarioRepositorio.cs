using CAPA.DOMAIN.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace CAPA.APP.Interfaces.Respositorio
{
    public interface IUsuarioRepositorio
    {
        List<TableUsuario> GetAll();

        TableUsuario GetUsuario(string UserName, string Passs);
    }
}
