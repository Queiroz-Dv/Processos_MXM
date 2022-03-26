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
            // AdmMode();
            lvwColumnSorter = new ListViewColumnSorter();
            this.lstProcesso.ListViewItemSorter = lvwColumnSorter;

            InitListView();
        }
        private void InitListView()
        {
            lstProcesso.View = View.Details;
            lstProcesso.GridLines = true;
            lstProcesso.FullRowSelect = true;

            //Adiciona Coluna
            lstProcesso.Columns.Add("Nome", 200);
            lstProcesso.Columns.Add("Id", 60);
            lstProcesso.Columns.Add("Status", 60);
            lstProcesso.Columns.Add("RAM", 120);
            lstProcesso.Columns.Add("Memória Fisica", 120);
        }

        private void FrmProcesso_Load(object sender, EventArgs e)
        {
            ListarProcessos();
        }

        public void ListarProcessos()
        {

            string localProcess = Environment.MachineName;
            var processos = Process.GetProcesses(localProcess);
            foreach (Process processo in processos)
            {
                ListViewItem list = new ListViewItem();
                string st = (processo.Responding == true ? "Rodando" : "Travado");
                var nome = processo.ProcessName;
                var id = processo.Id.ToString();
                var status = st;
                var ram = ConverterByte(processo.PrivateMemorySize64);
                var memoriaFisica = processo.WorkingSet64.ToString();

                list.Text = nome;
                list.SubItems.Add(id);
                list.SubItems.Add(status);
                list.SubItems.Add(ram);
                list.SubItems.Add(memoriaFisica);
                //list.Text = nome;
                // list.SubItems.Add(id);
                lstProcesso.Items.Add(list);

            }
            
        }

        private void lstProcesso_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            // Determine if clicked column is already the column that is being sorted.
            if (e.Column == lvwColumnSorter.SortColumn)
            {
                // Reverse the current sort direction for this column.
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
                // Set the column number that is to be sorted; default to ascending.
                lvwColumnSorter.SortColumn = e.Column;
                lvwColumnSorter.Order = SortOrder.Ascending;
            }

            // Perform the sort with these new sort options.
            this.lstProcesso.Sort();
        }

        public string ConverterByte(long numero)
        {  // Complexo
           //Lista de sufixos que serão usados 
            List<string> suffixes = new List<string> { " B", " KB", " MB", " GB", " TB", " PB" };

            for (int i = 0; i < suffixes.Count; i++)
            {
                long temp = numero / (int)Math.Pow(1024, i + 1);

                if (temp == 0)
                {
                    return (numero / (int)Math.Pow(1024, i)) + suffixes[i];
                }
            }

            return numero.ToString();
        }
    }

    /* Não funciona porque está executando uma propriedade em 64bits 
    private void AdmMode()
    {
        WindowsPrincipal principal = new WindowsPrincipal(WindowsIdentity.GetCurrent());
        bool adminMode = principal.IsInRole(WindowsBuiltInRole.Administrator);

        if (!adminMode)
        {
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.Verb = "runas";
            startInfo.FileName = Assembly.GetExecutingAssembly().CodeBase;
            try
            {
                Process.Start(startInfo);
                MessageBox.Show("Admin Mode", "Admin", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
           catch
           {

                throw new Exception("Acesso Negado");
            }
       }
    }

     void ProcessosExe()
     {
      Funciona mas não pega memória RAM

        ManagementClass management = new ManagementClass("Win32_Process");
        ManagementObjectCollection collection = management.GetInstances();
        foreach (ManagementObject processo in collection)
       {
         Process pro = new Process();
            ListViewItem list = new ListViewItem();
          list.Text = (processo["ProcessId"].ToString());
            list.SubItems.Add((string)processo["Name"]);
            list.SubItems.Add((string)processo["ExecutablePath"]);
            // list.SubItems.Add((string)processo["WorkingSet"]); --Não funciona
           // list.SubItems.Add((string)processo["PercentProcessorTime"]); -- Não funciona
            try
            {
                FileVersionInfo info = FileVersionInfo.GetVersionInfo((string)processo["ExecutablePath"]);
                list.SubItems.Add(info.FileDescription);
           }
            catch
           {
               list.SubItems.Add("Indisponível");
            }

            lstProcessos.Items.Add(list);
       } 

     */


}





