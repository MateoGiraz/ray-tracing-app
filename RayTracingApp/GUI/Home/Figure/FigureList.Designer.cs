﻿namespace GUI
{
    partial class FigureList
    {
        /// <summary> 
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnAddFigure = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnAddFigure
            // 
            this.btnAddFigure.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(39)))), ((int)(((byte)(58)))));
            this.btnAddFigure.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddFigure.FlatAppearance.BorderSize = 0;
            this.btnAddFigure.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddFigure.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddFigure.ForeColor = System.Drawing.Color.White;
            this.btnAddFigure.Location = new System.Drawing.Point(330, 56);
            this.btnAddFigure.Name = "btnAddFigure";
            this.btnAddFigure.Size = new System.Drawing.Size(176, 65);
            this.btnAddFigure.TabIndex = 0;
            this.btnAddFigure.Text = "Add Figure";
            this.btnAddFigure.UseVisualStyleBackColor = false;
            // 
            // FigureList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(65)))));
            this.Controls.Add(this.btnAddFigure);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.MaximumSize = new System.Drawing.Size(834, 604);
            this.MinimumSize = new System.Drawing.Size(834, 604);
            this.Name = "FigureList";
            this.Size = new System.Drawing.Size(834, 604);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnAddFigure;
    }
}
