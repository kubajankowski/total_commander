
namespace Commander
{
    partial class frmCommander
    {
        /// <summary>
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod generowany przez Projektanta formularzy systemu Windows

        /// <summary>
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCommander));
            this.lvOkno1 = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lvOkno2 = new System.Windows.Forms.ListView();
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Dysk1 = new System.Windows.Forms.ComboBox();
            this.Dysk2 = new System.Windows.Forms.ComboBox();
            this.cmdOtworz = new System.Windows.Forms.Button();
            this.cmdKopiuj = new System.Windows.Forms.Button();
            this.cmdPrzenies = new System.Windows.Forms.Button();
            this.cmdUsun = new System.Windows.Forms.Button();
            this.Detail_Icon = new System.Windows.Forms.ImageList(this.components);
            this.SuspendLayout();
            // 
            // lvOkno1
            // 
            this.lvOkno1.AllowDrop = true;
            this.lvOkno1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lvOkno1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lvOkno1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.lvOkno1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lvOkno1.FullRowSelect = true;
            this.lvOkno1.HideSelection = false;
            this.lvOkno1.LabelEdit = true;
            this.lvOkno1.Location = new System.Drawing.Point(12, 42);
            this.lvOkno1.Margin = new System.Windows.Forms.Padding(4);
            this.lvOkno1.MinimumSize = new System.Drawing.Size(550, 470);
            this.lvOkno1.Name = "lvOkno1";
            this.lvOkno1.Size = new System.Drawing.Size(550, 470);
            this.lvOkno1.TabIndex = 3;
            this.lvOkno1.UseCompatibleStateImageBehavior = false;
            this.lvOkno1.View = System.Windows.Forms.View.Details;
            this.lvOkno1.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.lvOkno1_ColumnClick);
            this.lvOkno1.Enter += new System.EventHandler(this.lvOkno1_Enter);
            this.lvOkno1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lvOkno_KeyDown);
            this.lvOkno1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lvOkno_MouseDoubleClick);
            this.lvOkno1.Resize += new System.EventHandler(this.frmCommander_Resize);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Nazwa";
            this.columnHeader1.Width = 182;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Typ";
            this.columnHeader2.Width = 70;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Data";
            this.columnHeader3.Width = 150;
            // 
            // lvOkno2
            // 
            this.lvOkno2.AllowDrop = true;
            this.lvOkno2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvOkno2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lvOkno2.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6});
            this.lvOkno2.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lvOkno2.FullRowSelect = true;
            this.lvOkno2.HideSelection = false;
            this.lvOkno2.LabelEdit = true;
            this.lvOkno2.Location = new System.Drawing.Point(575, 42);
            this.lvOkno2.Margin = new System.Windows.Forms.Padding(4);
            this.lvOkno2.MinimumSize = new System.Drawing.Size(550, 470);
            this.lvOkno2.Name = "lvOkno2";
            this.lvOkno2.Size = new System.Drawing.Size(550, 470);
            this.lvOkno2.TabIndex = 4;
            this.lvOkno2.UseCompatibleStateImageBehavior = false;
            this.lvOkno2.View = System.Windows.Forms.View.Details;
            this.lvOkno2.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.lvOkno2_ColumnClick);
            this.lvOkno2.Enter += new System.EventHandler(this.lvOkno2_Enter);
            this.lvOkno2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lvOkno_KeyDown);
            this.lvOkno2.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lvOkno_MouseDoubleClick);
            this.lvOkno2.Resize += new System.EventHandler(this.frmCommander_Resize);
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Nazwa";
            this.columnHeader4.Width = 182;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Typ";
            this.columnHeader5.Width = 70;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Data";
            this.columnHeader6.Width = 150;
            // 
            // Dysk1
            // 
            this.Dysk1.FormattingEnabled = true;
            this.Dysk1.Location = new System.Drawing.Point(13, 10);
            this.Dysk1.Margin = new System.Windows.Forms.Padding(4);
            this.Dysk1.Name = "Dysk1";
            this.Dysk1.Size = new System.Drawing.Size(77, 24);
            this.Dysk1.TabIndex = 5;
            this.Dysk1.SelectedIndexChanged += new System.EventHandler(this.Dysk1_SelectedIndexChanged);
            // 
            // Dysk2
            // 
            this.Dysk2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.Dysk2.FormattingEnabled = true;
            this.Dysk2.Location = new System.Drawing.Point(570, 10);
            this.Dysk2.Margin = new System.Windows.Forms.Padding(4);
            this.Dysk2.Name = "Dysk2";
            this.Dysk2.Size = new System.Drawing.Size(80, 24);
            this.Dysk2.TabIndex = 6;
            this.Dysk2.SelectedIndexChanged += new System.EventHandler(this.Dysk2_SelectedIndexChanged);
            // 
            // cmdOtworz
            // 
            this.cmdOtworz.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.cmdOtworz.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdOtworz.Location = new System.Drawing.Point(275, 527);
            this.cmdOtworz.Name = "cmdOtworz";
            this.cmdOtworz.Size = new System.Drawing.Size(120, 50);
            this.cmdOtworz.TabIndex = 7;
            this.cmdOtworz.Text = "Kopiuj\r\nF5";
            this.cmdOtworz.UseVisualStyleBackColor = true;
            this.cmdOtworz.Click += new System.EventHandler(this.cmdKopiuj_Click);
            this.cmdOtworz.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmCommander_KeyDown);
            // 
            // cmdKopiuj
            // 
            this.cmdKopiuj.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.cmdKopiuj.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdKopiuj.Location = new System.Drawing.Point(427, 527);
            this.cmdKopiuj.Name = "cmdKopiuj";
            this.cmdKopiuj.Size = new System.Drawing.Size(120, 50);
            this.cmdKopiuj.TabIndex = 8;
            this.cmdKopiuj.Text = "ZmPrzen\r\nF6";
            this.cmdKopiuj.UseVisualStyleBackColor = true;
            this.cmdKopiuj.Click += new System.EventHandler(this.cmdPrzenies_Click);
            this.cmdKopiuj.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmCommander_KeyDown);
            // 
            // cmdPrzenies
            // 
            this.cmdPrzenies.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.cmdPrzenies.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdPrzenies.Location = new System.Drawing.Point(582, 527);
            this.cmdPrzenies.Name = "cmdPrzenies";
            this.cmdPrzenies.Size = new System.Drawing.Size(120, 50);
            this.cmdPrzenies.TabIndex = 9;
            this.cmdPrzenies.Text = "UtwKat\r\nF7";
            this.cmdPrzenies.UseVisualStyleBackColor = true;
            this.cmdPrzenies.Click += new System.EventHandler(this.cmdNowy_Click);
            this.cmdPrzenies.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmCommander_KeyDown);
            // 
            // cmdUsun
            // 
            this.cmdUsun.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.cmdUsun.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.cmdUsun.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdUsun.Location = new System.Drawing.Point(737, 527);
            this.cmdUsun.Name = "cmdUsun";
            this.cmdUsun.Size = new System.Drawing.Size(120, 50);
            this.cmdUsun.TabIndex = 10;
            this.cmdUsun.Text = "Usuń\r\nF8";
            this.cmdUsun.UseVisualStyleBackColor = true;
            this.cmdUsun.Click += new System.EventHandler(this.cmdUsun_Click);
            this.cmdUsun.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmCommander_KeyDown);
            // 
            // Detail_Icon
            // 
            this.Detail_Icon.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("Detail_Icon.ImageStream")));
            this.Detail_Icon.TransparentColor = System.Drawing.Color.Transparent;
            this.Detail_Icon.Images.SetKeyName(0, "Folder-icon.png");
            this.Detail_Icon.Images.SetKeyName(1, "file_type_icons_flat_-13.png");
            // 
            // frmCommander
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1138, 589);
            this.Controls.Add(this.cmdUsun);
            this.Controls.Add(this.cmdPrzenies);
            this.Controls.Add(this.cmdKopiuj);
            this.Controls.Add(this.cmdOtworz);
            this.Controls.Add(this.Dysk2);
            this.Controls.Add(this.Dysk1);
            this.Controls.Add(this.lvOkno2);
            this.Controls.Add(this.lvOkno1);
            this.KeyPreview = true;
            this.MinimumSize = new System.Drawing.Size(1156, 636);
            this.Name = "frmCommander";
            this.Text = "_-== WSB Commander==-_";
            this.Load += new System.EventHandler(this.frmCommander_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmCommander_KeyDown);
            this.Resize += new System.EventHandler(this.frmCommander_Resize);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView lvOkno1;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ListView lvOkno2;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ComboBox Dysk1;
        private System.Windows.Forms.ComboBox Dysk2;
        private System.Windows.Forms.Button cmdOtworz;
        private System.Windows.Forms.Button cmdKopiuj;
        private System.Windows.Forms.Button cmdPrzenies;
        private System.Windows.Forms.Button cmdUsun;
        private System.Windows.Forms.ImageList Detail_Icon;
    }
}

