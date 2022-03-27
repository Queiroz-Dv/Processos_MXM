using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;

namespace Processos_MXM
{
    public partial class FrmProcesso : Form
    {
        private ListViewColumnSorter lvwColumnSorter;
        public FrmProcesso()
        {
            InitializeComponent();
            InitListView();
            lvwColumnSorter = new ListViewColumnSorter();
            this.lstProcesso.ListViewItemSorter = lvwColumnSorter;

        }
        private void InitListView()
        {
            //Inicia alterando as configurações da view
            lstProcesso.View = View.Details;
            lstProcesso.GridLines = true;
            lstProcesso.FullRowSelect = true;

            //Adiciona Colunas com os seus tamanhos
            lstProcesso.Columns.Add("Nome", 200);
            lstProcesso.Columns.Add("Id", 60);
            lstProcesso.Columns.Add("Status", 60);
            lstProcesso.Columns.Add("RAM", 120);
            lstProcesso.Columns.Add("Memória Fisica", 120);
        }

        private void FrmProcesso_Load(object sender, EventArgs e)
        {
            //Carregamento automático
            ListarProcessos();
        }

        public void ListarProcessos()
        {
            // Carrega a máquina local adicionando ela ao método GetProcess
            string localProcess = Environment.MachineName;
            var processos = Process.GetProcesses(localProcess);
            foreach (Process processo in processos)
            {
                //Foreach para adicionar os processos
                ListViewItem list = new ListViewItem();

                // Status para saber se um dos processos está ou não respondendo
                string st = (processo.Responding == true ? "Rodando" : "Travado");

                var nome = processo.ProcessName;
                var id = processo.Id.ToString();
                
                //Atribuição a variavel status
                var status = st;

                // Primeiro chamamos o método que converte os bytes em strings pra melhor
                // compreensão passando o processo e a propriedade Private Memory
                var ram = ConverterByte(processo.PrivateMemorySize64);

                // Memória Física dos processos convertido
                var memoriaFisica = ConverterByte(processo.WorkingSet64);

                // Adiciona cada processo em uma lista
                list.Text = nome;
                list.SubItems.Add(id);
                list.SubItems.Add(status);
                list.SubItems.Add(ram);
                list.SubItems.Add(memoriaFisica);

                // Adiciona todos os processos no ListView para apresentação
                lstProcesso.Items.Add(list);

            }

        }

        private void lstProcesso_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            // Determina se a coluna clicada já é a coluna sendo ordenada 
            if (e.Column == lvwColumnSorter.SortColumn)
            {

                // Condição que reverte a ordem da coluna
                if (lvwColumnSorter.Order == SortOrder.Ascending)
                {
                    lvwColumnSorter.Order = SortOrder.Descending;
                }
                else
                {
                    lvwColumnSorter.Order = SortOrder.Ascending;
                }
            }
            else
            {
                // Adiciona uma numeração para a coluna com o padrão ascendente
                lvwColumnSorter.SortColumn = e.Column;
                lvwColumnSorter.Order = SortOrder.Ascending;
            }
            // Adiciona a nova configuração ao listview
            this.lstProcesso.Sort();
        }

        public string ConverterByte(long numero)
        {  // Complexo
           //Lista de sufixos que serão usados para formatação
            List<string> suffixes = new List<string> { " B", " KB", " MB", " GB", " TB", " PB" };

            for (int i = 0; i < suffixes.Count; i++)
            {
                // Pra cada processo em sexecução que for menor que a quantidade dos sufixos
                // será executado o loop que faz a potência de 1024 mais a quantidade de bites do processo dividido pelo bites recebido
                long temp = numero / (int)Math.Pow(1024, i + 1);

                if (temp == 0)
                {
                    // Quando chegar a 0 é feito outro cálculo para acrescentar o sufixo
                    return (numero / (int)Math.Pow(1024, i)) + suffixes[i];
                }
            }

            return numero.ToString();
        }
    }

}





