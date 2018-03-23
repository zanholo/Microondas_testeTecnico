using MicroOndas.Classes;
using System;
using System.IO;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;

namespace MicroOndas
{
    public partial class Pagina : System.Web.UI.Page
    {
        Aquecimento aquecimento = new Aquecimento();
        List<ProdutosProntos> ProdutosProntos = new List<ProdutosProntos>();
        ListProdutosProntos ListProdutosProntos = new ListProdutosProntos();

        protected void Page_Load(object sender, EventArgs e)
        {
            criaProdutos();
            if (!Page.IsPostBack)
            {
                preencheComboProdutosProntos();
            }

        }


        private void preencheComboProdutosProntos()
        {
            ddlProdutos.Items.Clear();
            foreach (ProdutosProntos produto in ProdutosProntos)
            {
                ListItem lst = new ListItem(produto.NomeProduto, produto.Id.ToString());
                ddlProdutos.Items.Add(new ListItem(produto.NomeProduto));
            }
        }

        private void criaProdutos()
        {
            ListProdutosProntos ListProdutosProntos = new ListProdutosProntos();
            ProdutosProntos = ListProdutosProntos.RetornaLista();
        }


        protected bool Validacoes(Aquecimento aquecimento)
        {
            int potencia = 0;
            int tempo = 0;

            aquecimento.Produto = txtProduto.Text;

            try
            {
                tempo = Convert.ToInt32(txtTempo.Text);
                if (tempo < 1)
                {
                    lblTempo.Visible = true;
                    lblTempo.Text = "O tempo não pode ser menor que 1 segundo.";

                }
                if (tempo > 120)
                {
                    lblTempo.Visible = true;
                    lblTempo.Text = "O tempo não pode ser maior que 120 segundos.";
                    return false;
                }
            }
            catch (Exception e)
            {
                lblTempo.Visible = true;
                return false;
            }

            try
            {
                potencia = Convert.ToInt32(txtPotencia.Text);

                if (potencia > 10)
                {
                    lblPotencia.Text = "Potencia não pode exceder o valor 10.";
                    lblPotencia.Visible = true;
                    return false;
                }

                if (potencia < 1)
                {
                    lblPotencia.Text = "Potencia não pode ser menor que o 1.";
                    lblPotencia.Visible = true;
                    return false;
                }
            }
            catch (Exception e)
            {
                lblPotencia.Visible = true;
                return false;
            }

            aquecimento.Potencia = potencia;
            aquecimento.Tempo = tempo;

            return true;
        }

        protected bool ValidacoesCadastro(Aquecimento aquecimento)
        {
            int potencia = 0;
            int tempo = 0;

            aquecimento.Produto = txtProdCad.Text;

            try
            {
                tempo = Convert.ToInt32(txtTempoCad.Text);
                if (tempo < 1)
                {
                    lblcadTempo.Visible = true;
                    lblcadTempo.Text = "O tempo não pode ser menor que 1 segundo.";

                }
                if (tempo > 120)
                {
                    lblcadTempo.Visible = true;
                    lblcadTempo.Text = "O tempo não pode ser maior que 120 segundos.";
                    return false;
                }
            }
            catch (Exception e)
            {
                lblTempo.Visible = true;
                return false;
            }

            try
            {
                potencia = Convert.ToInt32(txtPotCad.Text);

                if (potencia > 10)
                {
                    lblCadPot.Text = "Potencia não pode exceder o valor 10.";
                    lblCadPot.Visible = true;
                    return false;
                }

                if (potencia < 1)
                {
                    lblCadPot.Text = "Potencia não pode ser menor que o 1.";
                    lblCadPot.Visible = true;
                    return false;
                }
            }
            catch (Exception e)
            {
                lblPotencia.Visible = true;
                return false;
            }

            if (txtCarCad.Text.Trim() == "")
            {
                lblCadCara.Text = "Texto necessário..";
                lblCadCara.Visible = true;
                return false;
            }

            aquecimento.Potencia = potencia;
            aquecimento.Tempo = tempo;

            return true;
        }

        private void Inicializar()
        {

            lblTempo.Text = "Tempo Selecionado não é válida.";
            lblPotencia.Text = "Potência Selecionado não é válida.";
            lblPotencia.Visible = false;
            lblTempo.Visible = false;

            btnPausar.Text = "Pausar";
            Session["timer"] = 0;
            Session["potencia"] = "";
            Session["aquecimento"] = "";
            pnlMensagem.Visible = false;

        }

        protected void btnIniciar_Click(object sender, EventArgs e)
        {
            this.Inicializar();
            if (Validacoes(aquecimento))
            {
                ProcessoAquecimento(aquecimento);
            }
        }

        protected void btnRapidoAquecimento_Click(object sender, EventArgs e)
        {
            Aquecimento aquecimento = new Aquecimento();

            this.Inicializar();
            txtPotencia.Text = "8";
            txtTempo.Text = "30";

            if (Validacoes(aquecimento))
            {
                this.ProcessoAquecimento(aquecimento);
            }
        }



        protected void ProcessoAquecimento(Aquecimento aquecimento)
        {
            Session["timer"] = aquecimento.Tempo;
            Session["potencia"] = aquecimento.Potencia;

            string arquivo = txtProduto.Text;
            if (File.Exists(arquivo))
                Session["produto"] = txtProduto.Text;
            tmrTimer.Enabled = true;

        }

        protected void Timer(object sender, EventArgs e)
        {
            int timer = Convert.ToInt32(Session["timer"].ToString());
            if (timer > 0)
            {
                lblTimer.Text = timer.ToString();
                lblTimer.Visible = true;
                timer -= 1;
                Session["timer"] = timer.ToString();
                if (Session["aquecimento"] != null && Session["aquecimento"].ToString().Trim() != "")
                {
                    txtProduto.Text = txtProduto.Text + Session["aquecimento"].ToString();
                    if (Session["produto"] != null && Session["produto"].ToString() != "")
                    {
                        this.escreverArquivo(Session["aquecimento"].ToString());
                    }
                }
                else
                {
                    string potenciaPontos = "";
                    for (int i = 0; i < Convert.ToInt32(Session["potencia"].ToString()); i++)
                    {
                        potenciaPontos = potenciaPontos + ".";
                    }
                    txtProduto.Text = txtProduto.Text + potenciaPontos;

                    if (Session["produto"] != null && Session["produto"].ToString() != "")
                    {
                        this.escreverArquivo(potenciaPontos);
                    }
                }
            }
            if (timer == 0)
            {
                lblTimer.Text = "Aquecido";
                tmrTimer.Enabled = false;

                lblMensagemFinalizacao.Text = txtProduto.Text + " foi aquecido.";
                pnlMensagem.Visible = true;
            }
        }


        public void escreverArquivo(string texto)
        {

            StreamWriter arquivo = new StreamWriter(Session["produto"].ToString(), true, Encoding.ASCII);

            arquivo.Write(texto);

            arquivo.Close();
        }


        protected void AlteraProgramacao(object sender, EventArgs e)
        {
            tmrTimer.Enabled = false;
            int selecionado = Convert.ToInt32(ddlProdutos.SelectedIndex);

            txtProduto.Text = ProdutosProntos[selecionado].NomeProduto.ToString();
            txtInstrucao.Text = ProdutosProntos[selecionado].Instrucoes.ToString();
            txtPotencia.Text = ProdutosProntos[selecionado].Aquecimento.Potencia.ToString();
            txtInstrucao.Text = ProdutosProntos[selecionado].Instrucoes.ToString();
            txtTempo.Text = ProdutosProntos[selecionado].Aquecimento.Tempo.ToString();
            Session["aquecimento"] = ProdutosProntos[selecionado].Aquecer.ToString();

        }

        protected void btnLimpar_Click(object sender, EventArgs e)
        {
            Inicializar();
            txtProduto.Text = "";
            txtInstrucao.Text = "";
            txtPotencia.Text = "";
            txtTempo.Text = "";
            ddlProdutos.SelectedIndex = 0;
            tmrTimer.Enabled = false;
            lblTimer.Visible = false;
            pnlMensagem.Visible = false;
            btnPausar.Visible = true;
            btnRetomar.Visible = false;
        }

        protected void btnCadastrar_Click(object sender, EventArgs e)
        {
            if (ValidacoesCadastro(aquecimento))
            {
                ProdutosProntos produto = new ProdutosProntos();
                Aquecimento aqueci = new Aquecimento();

                produto.Instrucoes = txtInstCad.Text;
                produto.NomeProduto = txtProdCad.Text;
                produto.Aquecer = txtCarCad.Text;
                aqueci.Potencia = Convert.ToInt32(txtPotCad.Text);
                aqueci.Tempo = Convert.ToInt32(txtTempoCad.Text);

                ProdutosProntos = ListProdutosProntos.InsereRetornaLista(produto, aqueci);

                txtInstCad.Text = "";
                txtProdCad.Text = "";
                txtCarCad.Text = "";
                txtPotCad.Text = "";
                txtTempoCad.Text = "";

                preencheComboProdutosProntos(); //Atualiza os itens da lista
            }
        }

        protected void btnParar_Click(object sender, EventArgs e)
        {
            Inicializar();
            txtProduto.Text = "";
            txtInstrucao.Text = "";
            txtPotencia.Text = "";
            txtTempo.Text = "";
            ddlProdutos.SelectedIndex = 0;
            tmrTimer.Enabled = false;
            lblTimer.Visible = false;
            pnlMensagem.Visible = true;

            lblMensagemFinalizacao.Text = "Aquecimento Parado";
        }

        protected void btnPausar_Click(object sender, EventArgs e)
        {
            tmrTimer.Enabled = false;
            lblMensagemFinalizacao.Visible = true;
            lblMensagemFinalizacao.Text = "Aquecimento Pausado";
            Session["timer"] = lblTimer.Text;

            btnPausar.Visible = false;
            btnRetomar.Visible = true;

        }

        protected void btnRetomar_Click(object sender, EventArgs e)
        {
            lblMensagemFinalizacao.Visible = false;
            btnPausar.Text = "Pausar";
            tmrTimer.Enabled = true;

            btnPausar.Visible = true;
            btnRetomar.Visible = false;
        }
    }
}