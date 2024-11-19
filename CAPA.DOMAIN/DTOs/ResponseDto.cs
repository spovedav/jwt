using System;
using System.Collections.Generic;
using System.Text;

namespace CAPA.DOMAIN.DTOs
{
    public class ResponseDto<T>
    {
        public bool TieneError { get; set; } = false;
        public string Mensaje { get; set; } = string.Empty;
        public string CodigoError { get; set; } = string.Empty;
        public T Data { get; set; } = default(T);
    }
}
