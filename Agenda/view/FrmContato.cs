using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Agenda.controller;
using Agenda.model;

namespace Agenda.view
{
    public partial class FrmContato : Form
    {
        private Label lblTextBox1;
        private Label lblTextBox2;
        private Label lblTextBox3;
        private TextBox txt1;
        private TextBox txt2;
        private TextBox txt3;
        private Button btnNovo;
        private Button btnGravar;
        private Button btnPesquisar;
        private Button btnDeletar;
        private Button btnListar;
        private DataGridView dgvContatos;

        Contatos contacts = new Contatos();
        Contato contato = new Contato();

        public FrmContato()
        {
            InitializeComponent();

            this.lblTextBox1 = new Label();
            lblTextBox1.Name = "lblTextBox1";
            lblTextBox1.Location = new Point(10, 10);
            lblTextBox1.Size = new Size(50, 20);
            lblTextBox1.TabIndex = 0;
            lblTextBox1.Text = "Email:";

            this.lblTextBox2 = new Label();
            lblTextBox2.Name = "lblTextBox2";
            lblTextBox2.Location = new Point(10, 50);
            lblTextBox2.Size = new Size(50, 20);
            lblTextBox2.TabIndex = 1;
            lblTextBox2.Text = "Nome:";

            this.lblTextBox3 = new Label();
            lblTextBox3.Name = "lblTextBox3";
            lblTextBox3.Location = new Point(10, 90);
            lblTextBox3.Size = new Size(50, 20);
            lblTextBox3.TabIndex = 2;
            lblTextBox3.Text = "Fone:";

            this.txt1 = new TextBox();
            txt1.Name = "txt1";
            txt1.Location = new Point(60, 10);
            txt1.Size = new Size(100, 20);
            txt1.TabIndex = 3;

            this.txt2 = new TextBox();
            txt2.Name = "txt2";
            txt2.Location = new Point(60, 50);
            txt2.Size = new Size(100, 20);
            txt2.TabIndex = 4;

            this.txt3 = new TextBox();
            txt3.Name = "txt3";
            txt3.Location = new Point(60, 90);
            txt3.Size = new Size(50, 20);
            txt3.TabIndex = 5;

            this.btnNovo = new Button();
            btnNovo.Name = "btnNovo";
            btnNovo.Location = new Point(10, 175);
            btnNovo.Size = new Size(70, 20);
            btnNovo.TabIndex = 6;
            btnNovo.Text = "Novo";
            btnNovo.UseVisualStyleBackColor = true;
            btnNovo.Click += new EventHandler(btnNewClicked);

            this.btnGravar = new Button();
            btnGravar.Name = "btnGravar";
            btnGravar.Location = new Point(85, 175);
            btnGravar.Size = new Size(70, 20);
            btnGravar.TabIndex = 7;
            btnGravar.Text = "Gravar";
            btnGravar.UseVisualStyleBackColor = true;
            btnGravar.Click += new EventHandler(btnGravarClicked);

            this.btnPesquisar = new Button();
            btnPesquisar.Name = "btnPesquisar";
            btnPesquisar.Location = new Point(160, 175);
            btnPesquisar.Size = new Size(70, 20);
            btnPesquisar.TabIndex = 8;
            btnPesquisar.Text = "Pesquisar";
            btnPesquisar.UseVisualStyleBackColor = true;
            btnPesquisar.Click += new EventHandler(Pesquisar);

            this.btnDeletar = new Button();
            btnDeletar.Name = "btnDeletar";
            btnDeletar.Location = new Point(235, 175);
            btnDeletar.Size = new Size(70, 20);
            btnDeletar.TabIndex = 9;
            btnDeletar.Text = "Deletar";
            btnDeletar.UseVisualStyleBackColor = true;
            btnDeletar.Click += new EventHandler(Excluir);

            this.btnListar = new Button();
            btnListar.Name = "btnListar";
            btnListar.Location = new Point(310, 175);
            btnListar.Size = new Size(70, 20);
            btnListar.TabIndex = 10;
            btnListar.Text = "Listar";
            btnListar.UseVisualStyleBackColor = true;
            btnListar.Click += new EventHandler(PopularDgv);

            this.dgvContatos = new DataGridView();
            dgvContatos.Location = new Point(210, 10);

            // Form
            this.AutoScaleDimensions = new SizeF(6F, 13F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(450, 250);
            this.Controls.Add(this.lblTextBox1);
            this.Controls.Add(this.lblTextBox2);
            this.Controls.Add(this.lblTextBox3);
            this.Controls.Add(this.txt1);
            this.Controls.Add(this.txt2);
            this.Controls.Add(this.txt3);
            this.Controls.Add(this.btnNovo);
            this.Controls.Add(this.btnGravar);
            this.Controls.Add(this.btnPesquisar);
            this.Controls.Add(this.btnDeletar);
            this.Controls.Add(this.btnListar);
            this.Controls.Add(this.dgvContatos);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        public void LimparForm()
        {
            txt1.Text = "";
            txt2.Text = "";
            txt3.Text = "";
            txt1.Focus();
        }

        public void QtContatos()
        {
            MessageBox.Show("\nQuantidade de Contatos: " + contacts.ListaContatos.Count.ToString());
        }
        public void btnNewClicked(object sender, EventArgs e)
        {
            LimparForm();
        }

        public void btnGravarClicked(object sender, EventArgs e)
        {
            if (txt1.Text.Equals(""))
            {
                MessageBox.Show("Digite o e-mail");
            }
            else
            {
                if (contacts.pesquisar(new Contato(txt1.Text)).Email == "")
                {
                    this.contacts.incluir(new Contato(txt1.Text, txt2.Text, txt3.Text));
                    LimparForm();
                }
                else
                {
                    this.contacts.alterar(new Contato(txt1.Text, txt2.Text, txt3.Text));
                }
            }
        }

        public void Pesquisar(object sender, EventArgs e)
        {
            contacts.pesquisar(contato);
        }

        public void Excluir(object sender, EventArgs e)
        {
            contacts.excluir(contato);
        }

        public void PopularDgv(object sender, EventArgs e)
        {
            QtContatos();
            foreach (Contato co in contacts.listAll())
            {
                MessageBox.Show("\n" + co.data());
            }
        }
    }
}
