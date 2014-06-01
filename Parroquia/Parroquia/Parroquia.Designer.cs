using System.Windows.Forms;
namespace Parroquia
{
    partial class Parroquia
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.archivoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.informacionDeLaParroquiaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ingresosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.egresosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.respaldoDeBDToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.salirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.librosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bautismoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.confirmaciónToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.primeraComuniónToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.matrimonioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ayudaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.descargarManualDeUsuarioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.acercaDeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.acercaDeToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.label3 = new System.Windows.Forms.Label();
            this.busqueda = new System.Windows.Forms.TextBox();
            this.libromatrimonio = new System.Windows.Forms.RadioButton();
            this.librocomunion = new System.Windows.Forms.RadioButton();
            this.libroconfirmacion = new System.Windows.Forms.RadioButton();
            this.librobautismo = new System.Windows.Forms.RadioButton();
            this.todo = new System.Windows.Forms.RadioButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pause = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            btnbuscar = new System.Windows.Forms.Button();
            this.fondoImg = new System.Windows.Forms.PictureBox();
            this.tablaBusqueda = new System.Windows.Forms.DataGridView();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.reg_encontrados = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.ip = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fondoImg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tablaBusqueda)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.archivoToolStripMenuItem,
            this.librosToolStripMenuItem,
            this.ayudaToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(947, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // archivoToolStripMenuItem
            // 
            this.archivoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.informacionDeLaParroquiaToolStripMenuItem,
            this.ingresosToolStripMenuItem,
            this.egresosToolStripMenuItem,
            this.respaldoDeBDToolStripMenuItem,
            this.salirToolStripMenuItem});
            this.archivoToolStripMenuItem.Name = "archivoToolStripMenuItem";
            this.archivoToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.archivoToolStripMenuItem.Text = "Archivo";
            // 
            // informacionDeLaParroquiaToolStripMenuItem
            // 
            this.informacionDeLaParroquiaToolStripMenuItem.Name = "informacionDeLaParroquiaToolStripMenuItem";
            this.informacionDeLaParroquiaToolStripMenuItem.Size = new System.Drawing.Size(221, 22);
            this.informacionDeLaParroquiaToolStripMenuItem.Text = "Información de la parroquia";
            this.informacionDeLaParroquiaToolStripMenuItem.Click += new System.EventHandler(this.informacionDeLaParroquiaToolStripMenuItem_Click);
            // 
            // ingresosToolStripMenuItem
            // 
            this.ingresosToolStripMenuItem.Name = "ingresosToolStripMenuItem";
            this.ingresosToolStripMenuItem.Size = new System.Drawing.Size(221, 22);
            this.ingresosToolStripMenuItem.Text = "Ingresos";
            this.ingresosToolStripMenuItem.Click += new System.EventHandler(this.ingresosToolStripMenuItem_Click);
            // 
            // egresosToolStripMenuItem
            // 
            this.egresosToolStripMenuItem.Name = "egresosToolStripMenuItem";
            this.egresosToolStripMenuItem.Size = new System.Drawing.Size(221, 22);
            this.egresosToolStripMenuItem.Text = "Egresos";
            this.egresosToolStripMenuItem.Click += new System.EventHandler(this.egresosToolStripMenuItem_Click);
            // 
            // respaldoDeBDToolStripMenuItem
            // 
            this.respaldoDeBDToolStripMenuItem.Name = "respaldoDeBDToolStripMenuItem";
            this.respaldoDeBDToolStripMenuItem.Size = new System.Drawing.Size(221, 22);
            this.respaldoDeBDToolStripMenuItem.Text = "Respaldo de BD";
            this.respaldoDeBDToolStripMenuItem.Click += new System.EventHandler(this.respaldoDeBDToolStripMenuItem_Click);
            // 
            // salirToolStripMenuItem
            // 
            this.salirToolStripMenuItem.Name = "salirToolStripMenuItem";
            this.salirToolStripMenuItem.Size = new System.Drawing.Size(221, 22);
            this.salirToolStripMenuItem.Text = "Salir";
            this.salirToolStripMenuItem.Click += new System.EventHandler(this.Salir_Click);
            // 
            // librosToolStripMenuItem
            // 
            this.librosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bautismoToolStripMenuItem,
            this.confirmaciónToolStripMenuItem,
            this.primeraComuniónToolStripMenuItem,
            this.matrimonioToolStripMenuItem});
            this.librosToolStripMenuItem.Name = "librosToolStripMenuItem";
            this.librosToolStripMenuItem.Size = new System.Drawing.Size(51, 20);
            this.librosToolStripMenuItem.Text = "Libros";
            // 
            // bautismoToolStripMenuItem
            // 
            this.bautismoToolStripMenuItem.Name = "bautismoToolStripMenuItem";
            this.bautismoToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.bautismoToolStripMenuItem.Text = "Bautismo";
            this.bautismoToolStripMenuItem.Click += new System.EventHandler(this.bautismoToolStripMenuItem_Click);
            // 
            // confirmaciónToolStripMenuItem
            // 
            this.confirmaciónToolStripMenuItem.Name = "confirmaciónToolStripMenuItem";
            this.confirmaciónToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.confirmaciónToolStripMenuItem.Text = "Confirmación";
            this.confirmaciónToolStripMenuItem.Click += new System.EventHandler(this.confirmaciónToolStripMenuItem_Click);
            // 
            // primeraComuniónToolStripMenuItem
            // 
            this.primeraComuniónToolStripMenuItem.Name = "primeraComuniónToolStripMenuItem";
            this.primeraComuniónToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.primeraComuniónToolStripMenuItem.Text = "Primera comunión";
            this.primeraComuniónToolStripMenuItem.Click += new System.EventHandler(this.primeraComuniónToolStripMenuItem_Click);
            // 
            // matrimonioToolStripMenuItem
            // 
            this.matrimonioToolStripMenuItem.Name = "matrimonioToolStripMenuItem";
            this.matrimonioToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.matrimonioToolStripMenuItem.Text = "Matrimonio";
            this.matrimonioToolStripMenuItem.Click += new System.EventHandler(this.matrimonioToolStripMenuItem_Click);
            // 
            // ayudaToolStripMenuItem
            // 
            this.ayudaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.descargarManualDeUsuarioToolStripMenuItem,
            this.acercaDeToolStripMenuItem,
            this.acercaDeToolStripMenuItem1});
            this.ayudaToolStripMenuItem.Name = "ayudaToolStripMenuItem";
            this.ayudaToolStripMenuItem.Size = new System.Drawing.Size(53, 20);
            this.ayudaToolStripMenuItem.Text = "Ayuda";
            // 
            // descargarManualDeUsuarioToolStripMenuItem
            // 
            this.descargarManualDeUsuarioToolStripMenuItem.Name = "descargarManualDeUsuarioToolStripMenuItem";
            this.descargarManualDeUsuarioToolStripMenuItem.Size = new System.Drawing.Size(227, 22);
            this.descargarManualDeUsuarioToolStripMenuItem.Text = "Descargar manual de usuario";
            this.descargarManualDeUsuarioToolStripMenuItem.Click += new System.EventHandler(this.descargarManualDeUsuarioToolStripMenuItem_Click);
            // 
            // acercaDeToolStripMenuItem
            // 
            this.acercaDeToolStripMenuItem.Name = "acercaDeToolStripMenuItem";
            this.acercaDeToolStripMenuItem.Size = new System.Drawing.Size(227, 22);
            this.acercaDeToolStripMenuItem.Text = "Enviar correo electrónico";
            this.acercaDeToolStripMenuItem.Click += new System.EventHandler(this.acercaDeToolStripMenuItem_Click);
            // 
            // acercaDeToolStripMenuItem1
            // 
            this.acercaDeToolStripMenuItem1.Name = "acercaDeToolStripMenuItem1";
            this.acercaDeToolStripMenuItem1.Size = new System.Drawing.Size(227, 22);
            this.acercaDeToolStripMenuItem1.Text = "Acerca de...";
            this.acercaDeToolStripMenuItem1.Click += new System.EventHandler(this.acercaDeToolStripMenuItem1_Click_1);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(21, 177);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 18);
            this.label3.TabIndex = 4;
            this.label3.Text = "BÚSQUEDA";
            // 
            // busqueda
            // 
            this.busqueda.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.busqueda.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.busqueda.Location = new System.Drawing.Point(128, 174);
            this.busqueda.Name = "busqueda";
            this.busqueda.Size = new System.Drawing.Size(469, 26);
            this.busqueda.TabIndex = 1;
            this.busqueda.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
            // 
            // libromatrimonio
            // 
            this.libromatrimonio.AutoSize = true;
            this.libromatrimonio.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.libromatrimonio.Location = new System.Drawing.Point(16, 124);
            this.libromatrimonio.Name = "libromatrimonio";
            this.libromatrimonio.Size = new System.Drawing.Size(142, 19);
            this.libromatrimonio.TabIndex = 6;
            this.libromatrimonio.Text = "Libros de matrimonio";
            this.libromatrimonio.UseVisualStyleBackColor = true;
            // 
            // librocomunion
            // 
            this.librocomunion.AutoSize = true;
            this.librocomunion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.librocomunion.Location = new System.Drawing.Point(16, 99);
            this.librocomunion.Name = "librocomunion";
            this.librocomunion.Size = new System.Drawing.Size(180, 19);
            this.librocomunion.TabIndex = 5;
            this.librocomunion.Text = "Libros de primera comunión";
            this.librocomunion.UseVisualStyleBackColor = true;
            // 
            // libroconfirmacion
            // 
            this.libroconfirmacion.AutoSize = true;
            this.libroconfirmacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.libroconfirmacion.Location = new System.Drawing.Point(16, 74);
            this.libroconfirmacion.Name = "libroconfirmacion";
            this.libroconfirmacion.Size = new System.Drawing.Size(150, 19);
            this.libroconfirmacion.TabIndex = 4;
            this.libroconfirmacion.Text = "Libros de confirmación";
            this.libroconfirmacion.UseVisualStyleBackColor = true;
            // 
            // librobautismo
            // 
            this.librobautismo.AutoSize = true;
            this.librobautismo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.librobautismo.Location = new System.Drawing.Point(16, 49);
            this.librobautismo.Name = "librobautismo";
            this.librobautismo.Size = new System.Drawing.Size(130, 19);
            this.librobautismo.TabIndex = 3;
            this.librobautismo.Text = "Libros de bautismo";
            this.librobautismo.UseVisualStyleBackColor = true;
            // 
            // todo
            // 
            this.todo.AutoSize = true;
            this.todo.Checked = true;
            this.todo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.todo.Location = new System.Drawing.Point(16, 24);
            this.todo.Name = "todo";
            this.todo.Size = new System.Drawing.Size(53, 19);
            this.todo.TabIndex = 3;
            this.todo.TabStop = true;
            this.todo.Text = "Todo";
            this.todo.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.pause);
            this.panel2.Controls.Add(this.button2);
            this.panel2.Controls.Add(this.button1);
            this.panel2.Controls.Add(btnbuscar);
            this.panel2.Controls.Add(this.busqueda);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.fondoImg);
            this.panel2.Location = new System.Drawing.Point(12, 31);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(693, 211);
            this.panel2.TabIndex = 1;
            // 
            // pause
            // 
            this.pause.Location = new System.Drawing.Point(37, 3);
            this.pause.Name = "pause";
            this.pause.Size = new System.Drawing.Size(31, 23);
            this.pause.TabIndex = 8;
            this.pause.Text = "| |";
            this.pause.UseVisualStyleBackColor = true;
            this.pause.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(2, 3);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(31, 23);
            this.button2.TabIndex = 7;
            this.button2.Text = "<";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(74, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(31, 23);
            this.button1.TabIndex = 6;
            this.button1.Text = ">";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // btnbuscar
            // 
            btnbuscar.BackColor = System.Drawing.Color.Transparent;
            btnbuscar.Location = new System.Drawing.Point(603, 174);
            btnbuscar.Name = "btnbuscar";
            btnbuscar.Size = new System.Drawing.Size(66, 26);
            btnbuscar.TabIndex = 2;
            btnbuscar.Text = "Buscar";
            btnbuscar.UseVisualStyleBackColor = false;
            btnbuscar.Click += new System.EventHandler(this.button1_Click);
            // 
            // fondoImg
            // 
            this.fondoImg.Image = global::Parroquia.Properties.Resources.p13;
            this.fondoImg.Location = new System.Drawing.Point(-1, -1);
            this.fondoImg.Name = "fondoImg";
            this.fondoImg.Size = new System.Drawing.Size(693, 211);
            this.fondoImg.TabIndex = 5;
            this.fondoImg.TabStop = false;
            // 
            // tablaBusqueda
            // 
            this.tablaBusqueda.AccessibleName = "";
            this.tablaBusqueda.AllowUserToAddRows = false;
            this.tablaBusqueda.AllowUserToDeleteRows = false;
            this.tablaBusqueda.AllowUserToOrderColumns = true;
            this.tablaBusqueda.AllowUserToResizeRows = false;
            this.tablaBusqueda.BackgroundColor = System.Drawing.SystemColors.Window;
            this.tablaBusqueda.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            this.tablaBusqueda.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.tablaBusqueda.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tablaBusqueda.Location = new System.Drawing.Point(12, 248);
            this.tablaBusqueda.MultiSelect = false;
            this.tablaBusqueda.Name = "tablaBusqueda";
            this.tablaBusqueda.ReadOnly = true;
            this.tablaBusqueda.RowHeadersWidth = 100;
            this.tablaBusqueda.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.tablaBusqueda.Size = new System.Drawing.Size(921, 364);
            this.tablaBusqueda.TabIndex = 4;
            this.tablaBusqueda.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 647);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(947, 22);
            this.statusStrip1.TabIndex = 9;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(9, 651);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(42, 15);
            this.label6.TabIndex = 10;
            this.label6.Text = "Hora:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(57, 651);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(32, 15);
            this.label7.TabIndex = 11;
            this.label7.Text = "-----";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(626, 615);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(296, 32);
            this.label1.TabIndex = 12;
            this.label1.Text = "Simpus Soluciones Informáticas :: Derechos reservados 2014 Prototipo de prueba.";
            // 
            // timer2
            // 
            this.timer2.Enabled = true;
            this.timer2.Interval = 60000;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.libromatrimonio);
            this.groupBox1.Controls.Add(this.todo);
            this.groupBox1.Controls.Add(this.librocomunion);
            this.groupBox1.Controls.Add(this.librobautismo);
            this.groupBox1.Controls.Add(this.libroconfirmacion);
            this.groupBox1.Location = new System.Drawing.Point(711, 31);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(224, 152);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Buscar en ...";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(711, 196);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(175, 15);
            this.label2.TabIndex = 14;
            this.label2.Text = "Total de registros encontrados:";
            // 
            // reg_encontrados
            // 
            this.reg_encontrados.AutoSize = true;
            this.reg_encontrados.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.reg_encontrados.Location = new System.Drawing.Point(884, 197);
            this.reg_encontrados.Name = "reg_encontrados";
            this.reg_encontrados.Size = new System.Drawing.Size(14, 15);
            this.reg_encontrados.TabIndex = 15;
            this.reg_encontrados.Text = "0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(711, 219);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(21, 15);
            this.label4.TabIndex = 16;
            this.label4.Text = "IP:";
            // 
            // ip
            // 
            this.ip.AutoSize = true;
            this.ip.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ip.Location = new System.Drawing.Point(737, 219);
            this.ip.Name = "ip";
            this.ip.Size = new System.Drawing.Size(58, 15);
            this.ip.TabIndex = 17;
            this.ip.Text = "127.0.0.1";
            // 
            // Parroquia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(947, 669);
            this.Controls.Add(this.ip);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.reg_encontrados);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.tablaBusqueda);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.menuStrip1);
            this.HelpButton = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Parroquia";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Parroquía de Nuestra Señora de Guadalupe";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fondoImg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tablaBusqueda)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem archivoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem informacionDeLaParroquiaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem librosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ayudaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ingresosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem egresosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bautismoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem confirmaciónToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem primeraComuniónToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem matrimonioToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem descargarManualDeUsuarioToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem acercaDeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem respaldoDeBDToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem salirToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem acercaDeToolStripMenuItem1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RadioButton libromatrimonio;
        private System.Windows.Forms.RadioButton librocomunion;
        private System.Windows.Forms.RadioButton libroconfirmacion;
        private System.Windows.Forms.RadioButton librobautismo;
        private System.Windows.Forms.RadioButton todo;
        private System.Windows.Forms.Panel panel2;
        public TextBox busqueda;
        public DataGridView tablaBusqueda;
        private StatusStrip statusStrip1;
        private Label label6;
        private Label label7;
        private Timer timer1;
        private PictureBox fondoImg;
        private Label label1;
        private Timer timer2;
        private Button button2;
        private Button button1;
        private SaveFileDialog saveFileDialog1;
        private GroupBox groupBox1;
        private Label label2;
        private Label reg_encontrados;
        private Button pause;
        private Label label4;
        private Label ip;
        public static Button btnbuscar;


    }
}

