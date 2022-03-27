using System;
using System.Collections;
using System.Windows.Forms;

namespace Processos_MXM
{
    public class ListViewColumnSorter : IComparer
    {
        // Especifica a coluna que será ordenada
        private int ColumnToSort;

        // Especifica a ordem que será realizada (Ascendente || Descendente)
        private SortOrder OrderOfSort;

        // Case Senstivive para comparar os objetos
        private CaseInsensitiveComparer ObjectCompare;


        // Construtor que inicializa os elementos 
        public ListViewColumnSorter()
        {
            // Iniciliaza a coluna com 0
            ColumnToSort = 0;

            // Inicializa a ordem da coluna para nenhum
            OrderOfSort = SortOrder.None;

            // Inicializa o case sensitive 
            ObjectCompare = new CaseInsensitiveComparer();
        }

        // Esse método herda da interface IComparer que compara os dois objetos passados usando o case insenstive na comparação
        // O resultado da comparação: "0" se igual, negativo se 'x' for menor que 'y' e positivo se 'x' for maior que 'y'
        public int Compare(object x, object y)
        {
            int compareResult;
            ListViewItem listviewX, listviewY;

            //Converte os objetos a serem comparados aos objetos ListViewItem
            listviewX = (ListViewItem)x;
            listviewY = (ListViewItem)y;

            decimal num = 0;
            if (decimal.TryParse(listviewX.SubItems[ColumnToSort].Text, out num))
            {
                compareResult = decimal.Compare(num, Convert.ToDecimal(listviewY.SubItems[ColumnToSort].Text));
            }
            else
            {
                // Compara os dois items
                compareResult = ObjectCompare.Compare(listviewX.SubItems[ColumnToSort].Text, listviewY.SubItems[ColumnToSort].Text);
            }

            // Calcular o valor de retorno correto com base na comparação de objetos
            if (OrderOfSort == SortOrder.Ascending)
            {
                // A classificação crescente está selecionada, retorna o resultado normal da operação de comparação
                return compareResult;
            }
            else if (OrderOfSort == SortOrder.Descending)
            {
                // A classificação decrescente está selecionada, retorna o resultado negativo da operação de comparação
                return (-compareResult);
            }
            else
            {
                // Retorna '0' para indicar que eles são iguais
                return 0;
            }
        }

        // Obtém ou define o número da coluna à qual aplicar a operação de classificação (o padrão é '0').
        public int SortColumn
        {
            set
            {
                ColumnToSort = value;
            }
            get
            {
                return ColumnToSort;
            }
        }

        // Obtém ou define a ordem de classificação a ser aplicada (por exemplo, 'Ascendente' ou 'Decrescente').
        public SortOrder Order
        {
            set
            {
                OrderOfSort = value;
            }
            get
            {
                return OrderOfSort;
            }
        }
    }
}