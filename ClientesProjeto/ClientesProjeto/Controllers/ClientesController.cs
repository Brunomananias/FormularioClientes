using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ClientesProjeto.Controllers
{
    
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private readonly Conexoes.SqlServer _Sql;

        public ClientesController()
        {
            _Sql = new Conexoes.SqlServer();
        }

        [HttpPost("v1/Clientes")]
        public void InserirClientes(Entidades.Clientes cliente)
        {
            _Sql.InserirClientes(cliente);
        }

        [HttpGet("v1/Alunos")]
        public List<Entidades.Clientes> ListarClientes()
        {
            return _Sql.ListarClientes();
        }
    }
}
