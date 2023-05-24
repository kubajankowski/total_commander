using System;
using System.Collections;
using System.Windows.Forms;

/// Klasa odpowiadaj�ca za implementacje interfejsu 'IComparer' por�wnuj�cego ze sob� dwa obiekty.
public class ListViewColumnSorter : IComparer
{
    private int ColumnToSort; /// Okresla kolumne do sortowania
    private SortOrder OrderOfSort; /// Okre�la kolejno�� sortowania.
    private CaseInsensitiveComparer ObjectCompare; /// Porownanie obiektow bez wzgledu na wielko�� liter

    /// Konstruktor klasy //////////////////////////////////////////////////////////////////////////////
    public ListViewColumnSorter()
    {
        ColumnToSort = 0;
        OrderOfSort = SortOrder.None;
        ObjectCompare = new CaseInsensitiveComparer();
    }

    /// Ta metoda jest dziedziczona z interfejsu IComparer. Por�wnuje dwa przekazane obiekty przy u�yciu por�wnania bez uwzgl�dniania wielko�ci liter.
    /// <param name="x">Pierwszy obiekt do por�wnania</param>
    /// <param name="y">Drugi obiekt do por�wnania</param>
    /// <returns>Wynik por�wnania. �0� je�li r�wne, ujemne, je�li �x� jest mniejsze ni� �y� i dodatnie, je�li �x� jest wi�ksze ni� �y�</returns>
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

        // Obliczanie poprawnej warto�ci zwrotu na podstawie por�wnania obiekt�w
        if (OrderOfSort == SortOrder.Ascending)
        {
            return compareResult; // Przy sortowaniu rosn�cym, zwraca wynik operacji por�wnania
        }
        else if (OrderOfSort == SortOrder.Descending)
        {
            return (-compareResult); // Przy sortowaniu malejacym, zwraca wynik operacji por�wnania
        }
        else
        {
            return 0; // Zwraca "0" jesli porownywane obiekty sa rowne
        }
    }

    /// Pobiera warto�� kolumny, do kt�rej ma zosta� zastosowana operacja sortowania (domy�lnie �0�).
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

    /// SortOrder ustawia kolejno�� sortowania do zastosowania (na przyk�ad �Rosn�co� lub �Malej�co�).
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