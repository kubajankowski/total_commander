using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Commander
{
    public partial class frmCommander : Form
    {
        /// ///////////////////////////////////////// KONSTRUKTOR /////////////////////////////////////////
        public frmCommander()
        {
            InitializeComponent();
            wyswietl(lvOkno1, sciezka1);
            wyswietl(lvOkno2, sciezka2);
            lvwColumnSorter = new ListViewColumnSorter();
            this.lvOkno1.ListViewItemSorter = lvwColumnSorter;
            this.lvOkno2.ListViewItemSorter = lvwColumnSorter;            
        }
        /// //////////////////////////////////////////////////////////////////////////////////////////////

        public ListView AktywneOkno = (ListView)null;
        public string AktywnaSciezka;
        private ListView NieAktywneOkno = null;
        private string NieAktywnaSciezka;
        private string sciezka1 = "C:\\"; // ścieżka dla lvOkno1
        private string sciezka2 = "C:\\"; // ścieżka dla lvOkno2
        private ListViewColumnSorter lvwColumnSorter;
        //////////////////////////////////
        private void Load_Image(ListViewItem item)         //Pobiera ikony dla każdego elementu w listview.
        {
            FileInfo temp = (FileInfo)item.Tag;
            if (!Detail_Icon.Images.ContainsKey(temp.Extension))
            {
                Icon ico = Icon.ExtractAssociatedIcon(temp.FullName);
                Detail_Icon.Images.Add(temp.Extension, ico);
            }
            item.ImageKey = temp.Extension;
        }

        // //////////////////////////////////////////////////////////////////////////////////////
        // Poniższa metoda wyświetli zawartość katalogu przekazanego w drugim argumencie       //
        // w oknie ListView przekazanym w pierwszym argumencie.Jeśli znajdujemy się głębiej    //
        // niż tylko na dysku(np.C:\Windows) to u góry zostanie wyświetlone "...", co pozwoli  //
        // nam wrócić do katalogu znajdującego się wyżej w hierarchii. Dla plików w kolumnie   //
        // Typ pojawi się rozszerzenie pliku, dla katalogów znajdzie się tam napis <DIR>.      //
        // Kolumna Rozmiar będzie wypełniona jedynie w przypadku pliku.                        //
        /////////////////////////////////////////////////////////////////////////////////////////
        public void wyswietl(ListView gdzie, string katalog)
        {
            gdzie.Items.Clear();
            string[] nazwy;
            ListViewItem buf;
            FileInfo plik;
            DirectoryInfo dir;
            if (!Dysk1.Items.Contains(katalog)) gdzie.Items.Add(new ListViewItem("..."));
            int i;
            nazwy = Directory.GetDirectories(katalog);
            for (i = 0; i < nazwy.Length; i++)
            {
                dir = new DirectoryInfo(nazwy[i]);
                buf = new ListViewItem(items: new string[] { dir.Name, "<DIR>", dir.CreationTime.ToString("yyyy/MM/dd HH:mm") });
                gdzie.Items.Add(buf);
                buf.ImageIndex = 0; // odniesienie do obrazka dla katalogu
            }
            string nazwapliku;
            int gdziekropka;
            nazwy = Directory.GetFiles(katalog);
            for (i = 0; i < nazwy.Length; i++)
            {
                plik = new FileInfo(nazwy[i]);
                nazwapliku = plik.Name;
                gdziekropka = plik.Name.LastIndexOf('.');
                if (gdziekropka > 0) nazwapliku = nazwapliku.Substring(0, plik.Name.LastIndexOf('.'));
                buf = new ListViewItem(new string[] { nazwapliku, plik.Extension.Replace(".", ""), plik.CreationTime.ToString("yyyy/MM/dd HH:mm") });
                gdzie.Items.Add(buf);
                //buf.ImageIndex = 1;
                buf.Tag = plik;
                Load_Image(buf);
            }
        }

        //////////////////////////////////////////////////////////////////////////////////////////   
        // Metoda "KopiujKatalog" działa w sposób rekurencyjny.Oznacza to, że jeśli kopiowany   // 
        // katalog zawiera podfoldery, to z poziomu kopiowania tego właśnie katalogu zostanie   //
        // wywołana funkcja do skopiowania podfolderu. KopiujKatalog sprawdza kolejno elementy  //
        // kopiowanej "teczki". Jeśli tym elementem jest folder, to KopiujKatalog skopiuje go   //
        // rekurencyjnie wywołując samą siebie, jeśli jest to plik - dokona się zwyczajne       //
        // kopiowanie.                                                                          //
        //////////////////////////////////////////////////////////////////////////////////////////
        private void KopiujKatalog(string zrodlo, string cel)
        {
            string[] nazwy;
            if (!Directory.Exists(cel)) Directory.CreateDirectory(cel);
            nazwy = Directory.GetFileSystemEntries(zrodlo);
            foreach (string nazwa in nazwy)
            {
                if (Directory.Exists(nazwa))
                {
                    KopiujKatalog(nazwa, cel + Path.GetFileName(nazwa) + "\\");
                }
                else
                {
                    File.Copy(nazwa, cel + Path.GetFileName(nazwa), true);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////// 
        // "frmCommander_Load" pobierze litery wszystkich dostępnych w systemie dysków, oraz    //
        // pozwoli wybrać je w kontrolkach Dysk1 i Dysk2. Ponadto dla każdej z nich spowoduje   //
        // aktywację "C:\", co w konsekwencji sprawi, że zawartość tego dysku wyświetli się     //
        // w oknach                                                                             //
        //////////////////////////////////////////////////////////////////////////////////////////
        private void frmCommander_Load(object sender, EventArgs e)
        {
            lvOkno1.SmallImageList = Detail_Icon;
            lvOkno2.SmallImageList = Detail_Icon;
            string[] nazwy;
            nazwy = Directory.GetLogicalDrives();
            foreach (string dysk in nazwy)
            {
                Dysk1.Items.Add(dysk);
                Dysk2.Items.Add(dysk);
            }
            Dysk1.SelectedIndex = Dysk1.Items.IndexOf("C:\\");
            Dysk2.SelectedIndex = Dysk2.Items.IndexOf("C:\\");

            // *********************************** DRAG & DROP ****************************************
            lvOkno1.AllowDrop = true;
            lvOkno2.AllowDrop = true;
            
            lvOkno1.DragDrop += new DragEventHandler(lvOkno1_DragDrop);  // Dodaje delegat wywołujący metodę lvOkno1_DragDrop, gdy wystąpi zdarzenie DragDrop kontrolki lvOkno1 - bardziej po ludzku: kiedy wystąpi zdarzenie DragDrop, to zostanie wywołana metoda lvOkno1_DragDrop. Zdarzenie DragDrop występuje gdy nastąpi upuszczenie przeciągniętego wcześniej obiektu w obszarze kontrolki
            lvOkno1.DragEnter += new DragEventHandler(lvOkno1_DragEnter); // Zdarzenie DragEnter występuje gdy nastąpi przeciągnięcie obiektu nad obszar kontrolki
            lvOkno1.ItemDrag += new ItemDragEventHandler(lvOkno1_ItemDrag); // Zdarzenie ItemDrag występuje kiedy rozpoczyna się przeciąganie obiektów

            lvOkno2.DragDrop += new DragEventHandler(lvOkno2_DragDrop);
            lvOkno2.DragEnter += new DragEventHandler(lvOkno2_DragEnter);
            lvOkno2.ItemDrag += new ItemDragEventHandler(lvOkno2_ItemDrag);
            // *********************************** DRAG & DROP ****************************************
        }

        ////////////////////////////////////////////////////////////////////////////////////////// 
        // Poniższe zdarzenia spowodują wyświetlenie nowo wybranego napędu we właściwym oknie   //
        // lub ewentualnie wyświetlą komunikat o błędzie, gdy np.w cdromie nie ma płyty.        //
        // Obydwa zdarzenia SelectedIndexChanged dla obu kontrolek ComboBox będą działać        //
        // dokładnie tak samo z tym, że dla odpowiednich okien i ComboBoxów.                    //
        //////////////////////////////////////////////////////////////////////////////////////////
        public void Dysk1_SelectedIndexChanged(object sender, EventArgs e)
        {
            sciezka1 = Dysk1.Text;
            AktywnaSciezka = sciezka1;
            try
            {
                wyswietl(lvOkno1, sciezka1);
            }
            catch
            {
                MessageBox.Show("Błąd przy próbie dostępu do napędu", "Błąd",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Dysk1.SelectedIndex = Dysk1.Items.IndexOf("C:\\");
            }
        }
        public void Dysk2_SelectedIndexChanged(object sender, EventArgs e)
        {
            sciezka2 = Dysk2.Text;
            AktywnaSciezka = sciezka2;
            try
            {
                wyswietl(lvOkno2, sciezka2);
            }
            catch
            {
                MessageBox.Show("Błąd przy próbie dostępu do napędu", "Błąd",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Dysk2.SelectedIndex = Dysk2.Items.IndexOf("C:\\");
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////// 
        // "frmCommander_Resize" pozwala na zmiane wielkości kontrolek ListView wraz ze zmianą  //
        // rozmiaru okna programu.                                                              //
        //////////////////////////////////////////////////////////////////////////////////////////
        private void frmCommander_Resize(object sender, EventArgs e)
        {
            if (this.WindowState != FormWindowState.Normal && this.WindowState != FormWindowState.Maximized)
                return;
            int num = (this.Size.Width - 33) / 2;
            this.lvOkno1.Width = num;
            this.lvOkno2.Width = num;
            ListView lvOkno2 = this.lvOkno2;
            Point location = this.lvOkno1.Location;
            int x = location.X + num + 3;
            location = this.lvOkno1.Location;
            int y = location.Y;
            Point point = new Point(x, y);
            lvOkno2.Location = point;
        }


        ////////////////////////////////////////////////////////////////////////////////////////// 
        // Zdarzenia "Enter" dla obu okien przydadzą się podczas kopiowania i przenoszenia.     //
        // Mają zapewnić poprawne wyświetlenia danych po wykonanych operacjach, które będą      //
        // się odbywać z aktywnego do nieaktywnego ListView'a.                                  //
        //////////////////////////////////////////////////////////////////////////////////////////
        private void lvOkno1_Enter(object sender, EventArgs e)
        {
            this.AktywneOkno = this.lvOkno1;
            this.AktywnaSciezka = this.sciezka1;
            this.NieAktywneOkno = this.lvOkno2;
            this.NieAktywnaSciezka = this.sciezka2;
        }
        private void lvOkno2_Enter(object sender, EventArgs e)
        {
            this.AktywneOkno = this.lvOkno2;
            this.AktywnaSciezka = this.sciezka2;
            this.NieAktywneOkno = this.lvOkno1;
            this.NieAktywnaSciezka = this.sciezka1;
        }

        ////////////////////////////////////////////////////////////////////////////////////////// 
        // "MouseDoubleClick" i "KeyDown" zajmują się nawigacją okien dla kontrolek lvOkno1     //
        // i lvOkno2. Zdarzenia różnią się jedynie "głównym if-em", który dla MouseDoubleClick  //
        // sprawdza czy kliknęliśmy lewym przyciskiem, a dla KeyDown - czy wcisnęliśmy Enter.   //
        // Wnętrze "if-a" sprawdza czy chcemy przejść do katalogu wyżej (element "..."),        //
        // przejść do nowego katalogu czy otworzyć plik i odpowiednio reaguje na naszą akcję.   //
        // Tzn.przechodzi poziom wyżej, wyświetla zawartość nowego katalogu lub próbuje         //
        // otworzyć plik (w przypadku niepowodzenia zostanie wyświetlony komunikat o błędzie).  //
        //////////////////////////////////////////////////////////////////////////////////////////
        private void lvOkno_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (e != null && e.Button != MouseButtons.Left)
                return;
            if (this.AktywneOkno.SelectedItems[0].Text == "...")
            {
                this.AktywnaSciezka = this.AktywnaSciezka.TrimEnd('\\');
                this.AktywnaSciezka = this.AktywnaSciezka.Substring(0, this.AktywnaSciezka.LastIndexOf('\\') + 1);
                this.wyswietl(this.AktywneOkno, this.AktywnaSciezka);
            }
            else if (this.AktywneOkno.SelectedItems[0].SubItems[1].Text == "<DIR>")
            {
                this.AktywnaSciezka = this.AktywnaSciezka + this.AktywneOkno.SelectedItems[0].Text + "\\";
                this.wyswietl(this.AktywneOkno, this.AktywnaSciezka);
            }
            else
            {
                string fileName = this.AktywnaSciezka + this.AktywneOkno.SelectedItems[0].Text + "." + this.AktywneOkno.SelectedItems[0].SubItems[1].Text;
                try
                {
                    Process.Start(fileName);
                    return;
                }
                catch
                {
                    int num = (int)MessageBox.Show("Nie można otworzyć pliku", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    return;
                }
            }
            if (this.AktywneOkno == this.lvOkno1)
                this.sciezka1 = this.AktywnaSciezka;
            else
                this.sciezka2 = this.AktywnaSciezka;
        }
        private void lvOkno_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Return)
                return;
            if (this.AktywneOkno.SelectedItems[0].Text == "...")
            {
                this.AktywnaSciezka = this.AktywnaSciezka.TrimEnd('\\');
                this.AktywnaSciezka = this.AktywnaSciezka.Substring(0, this.AktywnaSciezka.LastIndexOf('\\') + 1);
                this.wyswietl(this.AktywneOkno, this.AktywnaSciezka);
            }
            else if (this.AktywneOkno.SelectedItems[0].SubItems[1].Text == "<DIR>")
            {
                this.AktywnaSciezka = this.AktywnaSciezka + this.AktywneOkno.SelectedItems[0].Text + "\\";
                this.wyswietl(this.AktywneOkno, this.AktywnaSciezka);
            }
            else
            {
                string fileName = this.AktywnaSciezka + this.AktywneOkno.SelectedItems[0].Text + "." + this.AktywneOkno.SelectedItems[0].SubItems[1].Text;
                try
                {
                    Process.Start(fileName);
                    return;
                }
                catch
                {
                    int num = (int)MessageBox.Show("Nie można otworzyć pliku", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    return;
                }
            }
            if (this.AktywneOkno == this.lvOkno1)
                this.sciezka1 = this.AktywnaSciezka;
            else
                this.sciezka2 = this.AktywnaSciezka;
        }

        ////////////////////////////////////////////////////////////////////////////////////////// 
        // Poniżej oprogramowane zostały kliknięcia na przyciski.                               //
        // "cmdNowy_Click" - Otworzy formularz z prośbą o podanie nazwy nowego katalogu. Po     //
        // podaniu nazwy katalogu i wciśnieciu OK, zostanie utworzony nowy katalog, a wczeńśiej //
        // program sprawdzi i potwierdzi czy taki katalog już istnieje.                         //
        // "cmdKopiuj_Click" - spowoduje przekopiowanie wszystkich zaznaczonych elementów       //
        // z aktywnego okna do bieżącego katalogu w oknie nieaktywnym.Oczywiście inną funkcję   //
        // wywoła dla katalogów, a inną dla plików. Po wszystkim zaktualizuje zawartość         //
        // nieaktywnego okna, czyli tego, do którego kopiowaliśmy.                              //
        // "cmdPrzenies_Click" - robi to samo, ale po skopiowaniu kasuje pliki, które           //
        // kopiowaliśmy, czyli de facto je przenosi.                                            //
        // "cmdUsun_Click" - nie spowoduje nic innego jak usunięcie zaznaczonych elementów.     //
        // Wcześniej poprosi nas o potwierdzenie wyboru, a po wszystkim zaktualizuje zawartość  //
        // odpowiedniego okna.                                                                  //
        //////////////////////////////////////////////////////////////////////////////////////////
        private void cmdNowy_Click(object sender, EventArgs e)
        {
            NowyFolder form = new NowyFolder(AktywnaSciezka);
            form.ShowDialog(this);
            wyswietl(AktywneOkno, AktywnaSciezka);
        }
        private void cmdKopiuj_Click(object sender, EventArgs e)
        {
            if (AktywneOkno == null) return;
            for (int i = 0; i < AktywneOkno.SelectedItems.Count; i++)
            {
                if (AktywneOkno.SelectedItems[i].Text == "...") return;
                string zrodlo, cel;
                if (AktywneOkno.SelectedItems[i].SubItems[1].Text == "<DIR>")
                {
                    zrodlo = AktywnaSciezka + AktywneOkno.SelectedItems[i].Text + "\\";
                    cel = NieAktywnaSciezka + AktywneOkno.SelectedItems[i].Text + "\\";
                    KopiujKatalog(zrodlo, cel);
                }
                else
                {
                    zrodlo = AktywnaSciezka + AktywneOkno.SelectedItems[i].Text +
                    "." + AktywneOkno.SelectedItems[i].SubItems[1].Text;
                    cel = NieAktywnaSciezka + AktywneOkno.SelectedItems[i].Text +
                    "." + AktywneOkno.SelectedItems[i].SubItems[1].Text;
                    File.Copy(zrodlo, cel, true);
                }
            }
            wyswietl(NieAktywneOkno, NieAktywnaSciezka);
        }

        // *********************************** DRAG & DROP ****************************************        
        private void lvOkno1_ItemDrag(object sender, ItemDragEventArgs e) // Metoda zostaje wywołana gdy wystąpi zdarzenie przeciągnięcia obiektów kontrolki lvOkno1
        {
            lvOkno2.DoDragDrop("", DragDropEffects.Move); // Metoda .DoDragDrop() inicjuje operacje przenoszenia obiektów do kontrolki lvOkno2            
        }

        private void lvOkno1_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        private void lvOkno1_DragDrop(object sender, DragEventArgs e)
        {
            cmdPrzenies_Click(null, null); // Zostaje wywołana metoda cmdPrzenies_Click()
        }

        private void lvOkno2_ItemDrag(object sender, ItemDragEventArgs e)
        {
            lvOkno1.DoDragDrop("", DragDropEffects.Move);
        }

        private void lvOkno2_DragEnter(object sender, DragEventArgs e)
        {            
            e.Effect = DragDropEffects.Move;
        }

        private void lvOkno2_DragDrop(object sender, DragEventArgs e)
        {                        
            cmdPrzenies_Click(null, null);
        }
        // *********************************** DRAG & DROP ****************************************

        private void cmdPrzenies_Click(object sender, EventArgs e)
        {
            if (AktywneOkno == null)
            {
                return;
            }
                
            for (int i = 0; i < AktywneOkno.SelectedItems.Count; i++)
            {
                if (AktywneOkno.SelectedItems[i].Text == "...")
                {
                    return;
                }
                    
                string zrodlo, cel;
                if (AktywneOkno.SelectedItems[i].SubItems[1].Text == "<DIR>")
                {
                    zrodlo = AktywnaSciezka + AktywneOkno.SelectedItems[i].Text + "\\";
                    cel = NieAktywnaSciezka + AktywneOkno.SelectedItems[i].Text + "\\";

                    KopiujKatalog(zrodlo, cel);
                    Directory.Delete(zrodlo, true);
                }
                else
                {
                    zrodlo = AktywnaSciezka + AktywneOkno.SelectedItems[i].Text +
                    "." + AktywneOkno.SelectedItems[i].SubItems[1].Text;

                    cel = NieAktywnaSciezka + AktywneOkno.SelectedItems[i].Text +
                    "." + AktywneOkno.SelectedItems[i].SubItems[1].Text;

                    File.Copy(zrodlo, cel, true);
                    File.Delete(zrodlo);
                }
            }

            wyswietl(lvOkno1, sciezka1);
            wyswietl(lvOkno2, sciezka2);
        }
        private void cmdUsun_Click(object sender, EventArgs e)
        {
            if (AktywneOkno == null) return;
            if (AktywneOkno.SelectedItems[0].Text == "...") return;
            DialogResult odp = MessageBox.Show("Na pewno chcesz to usunac ?", "Usuń",
            MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (odp != DialogResult.Yes) return;
            string co;
            for (int i = 0; i < AktywneOkno.SelectedItems.Count; i++)
            {
                if (AktywneOkno.SelectedItems[i].SubItems[1].Text == "<DIR>")
                {
                    co = AktywnaSciezka + AktywneOkno.SelectedItems[i].Text;
                    Directory.Delete(co, true);
                }
                else
                {
                    co = AktywnaSciezka + AktywneOkno.SelectedItems[i].Text +
                    "." + AktywneOkno.SelectedItems[i].SubItems[1].Text;
                    File.Delete(co);
                }
            }
            wyswietl(AktywneOkno, AktywnaSciezka);
        }

        ////////////////////////////////////////////////////////////////////////////////////////// 
        // Poniżej oprogramowane zostały zdarzenia Click dla formy. Jeśli został naciśnięty     //
        // któryś z klawiszy funkcyjnych (zgodnie z etykietami na przyciskach) to zostanie      //
        // podjęta odpowiednia akcja.                                                           //
        //////////////////////////////////////////////////////////////////////////////////////////
        public void frmCommander_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F5:
                    this.cmdKopiuj_Click((object)null, (EventArgs)null);
                    break;
                case Keys.F6:
                    this.cmdPrzenies_Click((object)null, (EventArgs)null);
                    break;
                case Keys.F7:
                    this.cmdNowy_Click((object)null, (EventArgs)null);
                    break;
                case Keys.F8:
                    this.cmdUsun_Click((object)null, (EventArgs)null);
                    break;
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////// 
        // Metoda ColumnClick odpowiedzialna jest za sortowanie dla każdego okna z osobna i po  //
        // kliknięciu w kolumnie w danym oknie na jedną z wartości: (Nazwa, Typ, Data), dane te //
        // zostaną posortowane.                                                                 //
        //////////////////////////////////////////////////////////////////////////////////////////
        private void lvOkno1_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            if (e.Column == lvwColumnSorter.SortColumn)
            {
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
                lvwColumnSorter.SortColumn = e.Column;
                lvwColumnSorter.Order = SortOrder.Ascending;
            }
            this.lvOkno1.Sort();
        }
        private void lvOkno2_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            if (e.Column == lvwColumnSorter.SortColumn)
            {
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
                lvwColumnSorter.SortColumn = e.Column;
                lvwColumnSorter.Order = SortOrder.Ascending;
            }
            this.lvOkno2.Sort();
        }

        ////////////////////////////////////////////////////////////////////////////////////////// 
        // DRAG & DROP
        //////////////////////////////////////////////////////////////////////////////////////////
        /*public readonly string DirPath = AppDomain.CurrentDomain.BaseDirectory;      // path to the folder where the executable file is

        private void lvOkno1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                List<FileObject> files = new List<FileObject>();
                foreach (var item in lvOkno1.SelectedItems)
                {
                    if (item != null)
                    {
                        files.Add(item as FileObject);
                    }
                }
                DoDragDrop(new DataObject(DataFormats.FileDrop, new string[] { AktywnaSciezka }), DragDropEffects.Move);

                //remove ale możesz zamiast tego zrobić na nowo wyświetl żeby odświeżył jak podłączyć obsługe w plikach a nie na samych listach
                foreach (ListViewItem file in lvOkno1.SelectedItems)
                {
                    lvOkno1.Items.Remove(file);
                }
            }
        }

        private void lv_list_Drop(object sender, DragEventArgs e)
        {
            string[] file_pathes = (string[])e.Data.GetData(DataFormats.FileDrop);  // file_pathes contains pathes of dragged selected files

            //add every file to the list copping them to the application directory
            foreach (string path in (string[])e.Data.GetData(DataFormats.FileDrop))
            {
                string new_path = DirPath + Path.GetFileName(path); //New file path

                File.Copy(path, DirPath + Path.GetFileName(path));                    //copping dragged file by new_path

                //AktywneOkno.Items.Add(new FileObject(Path.GetFileName(path), new_path));  //adding FileObject (that stores file info) to the list
            }
        }*/
    }

}


