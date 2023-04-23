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
            this.picAddFigure = new System.Windows.Forms.PictureBox();
            this.lblAddFigure = new System.Windows.Forms.Label();
            this.picIconPlus = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picAddFigure)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picIconPlus)).BeginInit();
            this.SuspendLayout();
            // 
            // picAddFigure
            // 
            this.picAddFigure.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picAddFigure.Image = global::GUI.Properties.Resources.loginBackground;
            this.picAddFigure.Location = new System.Drawing.Point(310, 44);
            this.picAddFigure.Name = "picAddFigure";
            this.picAddFigure.Size = new System.Drawing.Size(198, 72);
            this.picAddFigure.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picAddFigure.TabIndex = 1;
            this.picAddFigure.TabStop = false;
            this.picAddFigure.Click += new System.EventHandler(this.picAddFigure_Click);
            // 
            // lblAddFigure
            // 
            this.lblAddFigure.AutoSize = true;
            this.lblAddFigure.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(158)))), ((int)(((byte)(140)))));
            this.lblAddFigure.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAddFigure.ForeColor = System.Drawing.Color.White;
            this.lblAddFigure.Location = new System.Drawing.Point(370, 69);
            this.lblAddFigure.Name = "lblAddFigure";
            this.lblAddFigure.Size = new System.Drawing.Size(111, 23);
            this.lblAddFigure.TabIndex = 2;
            this.lblAddFigure.Text = "Add Figure";
            // 
            // picIconPlus
            // 
            this.picIconPlus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(158)))), ((int)(((byte)(140)))));
            this.picIconPlus.Image = global::GUI.Properties.Resources.plus;
            this.picIconPlus.Location = new System.Drawing.Point(342, 69);
            this.picIconPlus.Name = "picIconPlus";
            this.picIconPlus.Size = new System.Drawing.Size(22, 22);
            this.picIconPlus.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picIconPlus.TabIndex = 3;
            this.picIconPlus.TabStop = false;
            // 
            // FigureList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(65)))));
            this.Controls.Add(this.picIconPlus);
            this.Controls.Add(this.lblAddFigure);
            this.Controls.Add(this.picAddFigure);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.MaximumSize = new System.Drawing.Size(834, 604);
            this.MinimumSize = new System.Drawing.Size(834, 604);
            this.Name = "FigureList";
            this.Size = new System.Drawing.Size(834, 604);
            ((System.ComponentModel.ISupportInitialize)(this.picAddFigure)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picIconPlus)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox picAddFigure;
        private System.Windows.Forms.Label lblAddFigure;
        private System.Windows.Forms.PictureBox picIconPlus;
    }
}
