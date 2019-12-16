using Senai.Quiron.WebApi.Domains;
using Senai.Quiron.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Quiron.WebApi.Providers
{
    public class DoutoresProvider : IDoutoresProvider
    {

        private DatabaseContext _context { get; set; }

        public DoutoresProvider(DatabaseContext context)
        {
            _context = context;
        }

        public void Atualizar(int idDoutor, Doutores doutor)
        {
            _context.Doutores.Update(doutor);
        }

        public Doutores BuscarPorId(int doutorId)
        {
            return _context.Doutores.Find(doutorId);
        }

        public void Cadastrar(Doutores doutor)
        {
          if(doutor == null)
            {
                throw new Exception(message:"Há alguma informação faltando.");
            }
            else
            {
                _context.Doutores.Add(doutor);
                _context.SaveChanges();
            }
        }

        public void Excluir(Doutores doutor)
        {
            _context.Doutores.Remove(doutor);
            _context.SaveChanges();
        }

        public IEnumerable<Doutores> Listar()
        {
            return _context.Doutores.ToList();
        }
    }
}
