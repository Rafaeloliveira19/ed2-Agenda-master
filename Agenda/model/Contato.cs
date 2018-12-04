using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agenda.model
{
    class Contato
    {
        #region Atributos
        private string email; //ID
        private string nome;
        private string fone;
        #endregion

        #region Propriedades
        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        public string Nome
        {
            get { return nome; }
            set { nome = value; }
        }

        public string Fone
        {
            get { return fone; }
            set { fone = value; }
        }
        #endregion

        #region Construtores
        public Contato(string email, string nome, string fone)
        {
            this.email = email;
            this.nome = nome;
            this.fone = fone;
        }

        public Contato(string email)
        {
            this.email = email;
        }

        public Contato()
            : this("", "", "")
        {
        }
        #endregion

        #region Sobreescritas
        public override bool Equals(object obj)
        {
            Contato c = (Contato)obj;
            return this.email.Equals(c.email);
        }
        #endregion

        #region MetodosFuncionais
        public string data()
        {
            return this.email.ToString() + " - " + this.nome + " - " +
                this.fone.ToString();
        }
        public bool validaEmail()
        {
            if (this.email.Contains("@"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion
    }
}
