using Senai.Quiron.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Quiron.WebApi.Interfaces
{
    public interface IDoutoresProvider
    {
        void Cadastrar(Doutores doutor);
        void Atualizar(int idDoutor, Doutores doutor);
        IEnumerable<Doutores> Listar();
        Doutores BuscarPorId(int doutorId);
        void Excluir(Doutores doutor);
    }
}
