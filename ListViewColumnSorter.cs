using System;
using System.Collections;
using System.Windows.Forms;

/// Klasa odpowiadaj¹ca za implementacje interfejsu 'IComparer' porównuj¹cego ze sob¹ dwa obiekty.
public class ListViewColumnSorter : IComparer
{
    private int ColumnToSort; /// Okresla kolumne do sortowania
    private SortOrder OrderOfSort; /// Okreœla kolejnoœæ sortowania.
    private CaseInsensitiveComparer ObjectCompare; /// Porownanie obiektow bez wzgledu na wielkoœæ liter

    /// Konstruktor klasy //////////////////////////////////////////////////////////////////////////////
    public ListViewColumnSorter()
    {
        ColumnToSort = 0;
        OrderOfSort = SortOrder.None;
        ObjectCompare = new CaseInsensitiveComparer();
    }

    /// Ta metoda jest dziedziczona z interfejsu IComparer. Porównuje dwa przekazane obiekty przy u¿yciu porównania bez uwzglêdniania wielkoœci liter.
    /// <param name="x">Pierwszy obiekt do porównania</param>
    /// <param name="y">Drugi obiekt do porównania</param>
    /// <returns>Wynik porównania. „0” jeœli równe, ujemne, jeœli „x” jest mniejsze ni¿ „y” i dodatnie, jeœli „x” jest wiêksze ni¿ „y”</returns>
    public int Compare(object x, object y)
    {
        int compareResult;
        ListViewItem listviewX, listviewY;

        listviewX = (ListViewItem)x;
        listviewY = (ListViewItem)y;

        decimal num = 0;
        if (ColumnToSort > listviewX.SubItems.Count - 1)
            return 0;
        if (decimal.TryParse(listviewX.SubItems[ColumnToSort].Text, out num))
        {
            compareResult = decimal.Compare(num, Convert.ToDecimal(listviewY.SubItems[ColumnToSort].Text));
        }
        else
        {
            compareResult = ObjectCompare.Compare(listviewX.SubItems[ColumnToSort].Text, listviewY.SubItems[ColumnToSort].Text);
        }

        // Obliczanie poprawnej wartoœci zwrotu na podstawie porównania obiektów
        if (OrderOfSort == SortOrder.Ascending)
        {
            return compareResult; // Przy sortowaniu rosn¹cym, zwraca wynik operacji porównania
        }
        else if (OrderOfSort == SortOrder.Descending)
        {
            return (-compareResult); // Przy sortowaniu malejacym, zwraca wynik operacji porównania
        }
        else
        {
            return 0; // Zwraca "0" jesli porownywane obiekty sa rowne
        }
    }

    /// Pobiera wartoœæ kolumny, do której ma zostaæ zastosowana operacja sortowania (domyœlnie „0”).
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

    /// SortOrder ustawia kolejnoœæ sortowania do zastosowania (na przyk³ad „Rosn¹co” lub „Malej¹co”).
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