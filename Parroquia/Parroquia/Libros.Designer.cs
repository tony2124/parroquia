using System;
namespace Parroquia
{
    public partial class Libros
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        /// 

        public void Pintar()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Libros));

            //Realizo la consulto a la tabla libros
            conjuntoDatos = BDatos.obtenerBasesDatosMySQL("select nombre_libro from libros where id_categoria='" + CATEGORIA + "';");
            //Se contabiliza para saber cuantos registros tiene 
            //la consulta que se hizo a la tabla libros
            if (conjuntoDatos.HasRows)
            {
                eliminarLibroButton.Enabled = true;
                tamanio = 0;
                while (conjuntoDatos.Read())
                {
                    tamanio++;
                }
                conjuntoDatos.Close();


                conjuntoDatos = BDatos.obtenerBasesDatosMySQL("select id_libro, id_categoria, nombre_libro from libros where id_categoria='" + CATEGORIA + "';");

                /*Se inicializan los componentes que integraran 
            * los libros virtuales*/
                this.panelitos = new System.Windows.Forms.Panel[tamanio];
                this.libritos = new System.Windows.Forms.Button[tamanio];
                this.etiquetaLibro = new System.Windows.Forms.Label[tamanio];
                this.etiquetaNombre = new System.Windows.Forms.Label[tamanio];

                /*Inicializacion y agregacion de los componentes que integran
                 la ventana libros*/
                int i = 0;
                int u = 4, v = 4;

                while (conjuntoDatos.Read())
                {
                    this.panelitos[i] = new System.Windows.Forms.Panel();
                    this.libritos[i] = new System.Windows.Forms.Button();
                    this.etiquetaLibro[i] = new System.Windows.Forms.Label();
                    this.etiquetaNombre[i] = new System.Windows.Forms.Label();

                    this.libritos[i].Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
                    this.libritos[i].Location = new System.Drawing.Point(4, 4);
                    this.libritos[i].Name = conjuntoDatos.GetString(0);
                    this.libritos[i].Size = new System.Drawing.Size(73, 73);
                    this.libritos[i].UseVisualStyleBackColor = true;
                    this.libritos[i].Click += new System.EventHandler(this.Insertar);

                    this.etiquetaLibro[i].AutoSize = true;
                    this.etiquetaLibro[i].Location = new System.Drawing.Point(4, 84);
                    this.etiquetaLibro[i].Name = "label" + (i + 1);
                    this.etiquetaLibro[i].Size = new System.Drawing.Size(36, 13);
                    this.etiquetaLibro[i].Text = "Libro: ";

                    this.etiquetaNombre[i].AutoSize = true;
                    this.etiquetaNombre[i].Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    this.etiquetaNombre[i].Location = new System.Drawing.Point(40, 85);
                    this.etiquetaNombre[i].Name = "label" + (i + 1);
                    this.etiquetaNombre[i].Text = conjuntoDatos.GetString(2);

                    this.panelitos[i].Controls.Add(libritos[i]);
                    this.panelitos[i].Controls.Add(etiquetaLibro[i]);
                    this.panelitos[i].Controls.Add(etiquetaNombre[i]);
                    this.panelitos[i].Location = new System.Drawing.Point(u, v);
                    this.panelitos[i].Size = new System.Drawing.Size(123, 108);
                    this.panelitos[i].Name = "panel" + (i + 1);
                    this.panelContenedorLibros.Controls.Add(this.panelitos[i]);
                    u += 124;
                    //cada 5 libros agrega una fila de libros nueva en la ventana
                    if ((i + 1) % 4 == 0) { v = v + 131; u = 4; }
                    i++;

                }


            }
            else
            {
                this.panelContenedorLibros.Controls.Add(this.label1);
                eliminarLibroButton.Enabled = false;
            }

            //Cierro el lector de los datos consultados en Mysql
            conjuntoDatos.Close();
            BDatos.Desconectar();
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Libros));
            this.panelContenedorLibros = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.crearLibroButton = new System.Windows.Forms.Button();
            this.eliminarLibroButton = new System.Windows.Forms.Button();
            this.editarLibroButton = new System.Windows.Forms.Button();
            this.cancelarVentanaLibrosBtn = new System.Windows.Forms.Button();         
            this.panelContenedorLibros.SuspendLayout();
            this.SuspendLayout();
            // 
            // eliminarLibroButton
            // 
            this.eliminarLibroButton.Location = new System.Drawing.Point(102, 300);
            this.eliminarLibroButton.Name = "eliminarLibroButton";
            this.eliminarLibroButton.Size = new System.Drawing.Size(83, 25);
            this.eliminarLibroButton.TabIndex = 2;
            this.eliminarLibroButton.Text = "Eliminar libro";
            this.eliminarLibroButton.Enabled = false;
            this.eliminarLibroButton.UseVisualStyleBackColor = true;
            this.eliminarLibroButton.Click += new System.EventHandler(this.eliminarLibro);
           
            // 
            // panelContenedorLibros
            // 

            //Mando llamar metodo que agrega los botones al panel de libros
            Pintar();

            this.panelContenedorLibros.AutoScroll = true;
            this.panelContenedorLibros.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelContenedorLibros.Location = new System.Drawing.Point(13, 13);
            this.panelContenedorLibros.Name = "panelContenedorLibros";
            this.panelContenedorLibros.Size = new System.Drawing.Size(535, 274);
            this.panelContenedorLibros.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(150, 100);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(227, 13);
            this.label1.TabIndex = 0;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Text = "No tiene libros en esta categoría de "+Categorias;
            
            // 
            // crearLibroButton
            // 
            this.crearLibroButton.Location = new System.Drawing.Point(12, 300);
            this.crearLibroButton.Name = "crearLibroButton";
            this.crearLibroButton.Size = new System.Drawing.Size(83, 25);
            this.crearLibroButton.TabIndex = 1;
            this.crearLibroButton.Tag = "Crear libro";
            this.crearLibroButton.Text = "Crear libro";
            this.crearLibroButton.UseVisualStyleBackColor = true;
            this.crearLibroButton.Click += new System.EventHandler(this.crearLibro);
            // 
            // editarLibroButton
            // 
            this.editarLibroButton.Location = new System.Drawing.Point(192, 300);
            this.editarLibroButton.Name = "editarLibroButton";
            this.editarLibroButton.Size = new System.Drawing.Size(83, 25);
            this.editarLibroButton.TabIndex = 1;
            this.editarLibroButton.Tag = "Editar libro";
            this.editarLibroButton.Text = "Editar libro";
            this.editarLibroButton.UseVisualStyleBackColor = true;
            this.editarLibroButton.Click += new System.EventHandler(this.editarLibro);
           
            // 
            // cancelarVentanaLibrosBtn
            // 
            this.cancelarVentanaLibrosBtn.Image = ((System.Drawing.Image)(resources.GetObject("cancelarVentanaLibrosBtn.Image")));
            this.cancelarVentanaLibrosBtn.Location = new System.Drawing.Point(443, 293);
            this.cancelarVentanaLibrosBtn.Name = "cancelarVentanaLibrosBtn";
            this.cancelarVentanaLibrosBtn.Size = new System.Drawing.Size(105, 38);
            this.cancelarVentanaLibrosBtn.TabIndex = 3;
            this.cancelarVentanaLibrosBtn.UseVisualStyleBackColor = true;
            this.cancelarVentanaLibrosBtn.Click += new System.EventHandler(this.cancelarVentana);
            // 
            // Libros
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(560, 335);
            this.Controls.Add(this.cancelarVentanaLibrosBtn);
            this.Controls.Add(this.eliminarLibroButton);
            this.Controls.Add(this.editarLibroButton);
            this.Controls.Add(this.crearLibroButton);
            this.Controls.Add(this.panelContenedorLibros);
            this.MaximizeBox = false;
            this.Name = "Libros";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Libros de "+Categorias;
            this.panelContenedorLibros.ResumeLayout(false);
            this.panelContenedorLibros.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelContenedorLibros;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button crearLibroButton;
        private System.Windows.Forms.Button eliminarLibroButton;
        private System.Windows.Forms.Button editarLibroButton;
        private System.Windows.Forms.Button cancelarVentanaLibrosBtn;
        private System.Windows.Forms.Button[] libritos;
        private System.Windows.Forms.Panel[] panelitos;
        private System.Windows.Forms.Label[] etiquetaLibro;
        private System.Windows.Forms.Label[] etiquetaNombre;
    }
}