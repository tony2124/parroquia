﻿namespace Parroquia
{
    partial class Informacion
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
        private void InitializeComponent()
        {
            this.nombre_parroquia = new System.Windows.Forms.TextBox();
            this.nombre_parroco = new System.Windows.Forms.TextBox();
            this.ubicacion_parroquia = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.guardar = new System.Windows.Forms.Button();
            this.cancelar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // nombre_parroquia
            // 
            this.nombre_parroquia.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nombre_parroquia.Location = new System.Drawing.Point(11, 27);
            this.nombre_parroquia.Name = "nombre_parroquia";
            this.nombre_parroquia.Size = new System.Drawing.Size(270, 24);
            this.nombre_parroquia.TabIndex = 3;
            // 
            // nombre_parroco
            // 
            this.nombre_parroco.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nombre_parroco.Location = new System.Drawing.Point(11, 78);
            this.nombre_parroco.Name = "nombre_parroco";
            this.nombre_parroco.Size = new System.Drawing.Size(270, 24);
            this.nombre_parroco.TabIndex = 4;
            // 
            // ubicacion_parroquia
            // 
            this.ubicacion_parroquia.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ubicacion_parroquia.Location = new System.Drawing.Point(11, 130);
            this.ubicacion_parroquia.Name = "ubicacion_parroquia";
            this.ubicacion_parroquia.Size = new System.Drawing.Size(270, 24);
            this.ubicacion_parroquia.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(193, 15);
            this.label1.TabIndex = 4;
            this.label1.Text = "NOMBRE DE LA PARROQUIA";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(168, 15);
            this.label2.TabIndex = 5;
            this.label2.Text = "NOMBRE DEL PÁRROCO";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 112);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(206, 15);
            this.label3.TabIndex = 6;
            this.label3.Text = "UBICACIÓN DE LA PARROQUIA";
            // 
            // guardar
            // 
            this.guardar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.guardar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.guardar.Location = new System.Drawing.Point(402, 371);
            this.guardar.Name = "guardar";
            this.guardar.Size = new System.Drawing.Size(75, 44);
            this.guardar.TabIndex = 1;
            this.guardar.Text = "GUARDAR";
            this.guardar.UseVisualStyleBackColor = true;
            this.guardar.Click += new System.EventHandler(this.guardar_Click);
            // 
            // cancelar
            // 
            this.cancelar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelar.Location = new System.Drawing.Point(483, 371);
            this.cancelar.Name = "cancelar";
            this.cancelar.Size = new System.Drawing.Size(75, 44);
            this.cancelar.TabIndex = 2;
            this.cancelar.Text = "CERRAR";
            this.cancelar.UseVisualStyleBackColor = true;
            this.cancelar.Click += new System.EventHandler(this.cancelar_Click);
            // 
            // Informacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Parroquia.Properties.Resources.parroq;
            this.CancelButton = this.cancelar;
            this.ClientSize = new System.Drawing.Size(570, 427);
            this.Controls.Add(this.cancelar);
            this.Controls.Add(this.guardar);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ubicacion_parroquia);
            this.Controls.Add(this.nombre_parroco);
            this.Controls.Add(this.nombre_parroquia);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Informacion";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "INFORMACIÓN";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox nombre_parroquia;
        private System.Windows.Forms.TextBox nombre_parroco;
        private System.Windows.Forms.TextBox ubicacion_parroquia;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button guardar;
        private System.Windows.Forms.Button cancelar;
    }
}