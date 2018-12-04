using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Agenda.model;

namespace Agenda.controller
{
    class Contatos
    {
        private List<Contato> listaContatos;

        public List<Contato> ListaContatos
        {
            get { return listaContatos; }
        }

        public Contatos()
        {
            this.listaContatos = new List<Contato>();
        }

        public void incluir(Contato c)
        {
            this.listaContatos.Add(c);
        }

        public void alterar(Contato c)
        {
            int indexOfContact = this.listaContatos.IndexOf(c);
            this.listaContatos[indexOfContact] = c;
        }

        public bool excluir(Contato c)
        {
            return this.listaContatos.Remove(c);
        }

        public Contato pesquisar(Contato c)
        {
            Contato retorno = new Contato();

            foreach (Contato co in ListaContatos)
            {
                if (co.Equals(c))
                {
                    retorno = co;
                }
            }
            return retorno;
        }

        public List<Contato> listAll()
        {
            return this.listaContatos;
        }
    }
}
