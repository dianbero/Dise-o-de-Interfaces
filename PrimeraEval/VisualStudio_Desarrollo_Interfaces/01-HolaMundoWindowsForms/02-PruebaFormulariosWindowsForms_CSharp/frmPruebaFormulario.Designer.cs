namespace _02_PruebaFormulariosWindowsForms_CSharp
{
    partial class frmPruebaFormulario
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

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.rdbPatata = new System.Windows.Forms.RadioButton();
            this.rdbZanahoria = new System.Windows.Forms.RadioButton();
            this.rdbTomate = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(90, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Elige un alimento:";
            // 
            // rdbPatata
            // 
            this.rdbPatata.AutoSize = true;
            this.rdbPatata.Location = new System.Drawing.Point(93, 70);
            this.rdbPatata.Name = "rdbPatata";
            this.rdbPatata.Size = new System.Drawing.Size(56, 17);
            this.rdbPatata.TabIndex = 1;
            this.rdbPatata.TabStop = true;
            this.rdbPatata.Text = "Patata";
            this.rdbPatata.UseVisualStyleBackColor = true;
            // 
            // rdbZanahoria
            // 
            this.rdbZanahoria.AutoSize = true;
            this.rdbZanahoria.Location = new System.Drawing.Point(93, 93);
            this.rdbZanahoria.Name = "rdbZanahoria";
            this.rdbZanahoria.Size = new System.Drawing.Size(73, 17);
            this.rdbZanahoria.TabIndex = 2;
            this.rdbZanahoria.TabStop = true;
            this.rdbZanahoria.Text = "Zanahoria";
            this.rdbZanahoria.UseVisualStyleBackColor = true;
            // 
            // rdbTomate
            // 
            this.rdbTomate.AutoSize = true;
            this.rdbTomate.Location = new System.Drawing.Point(93, 116);
            this.rdbTomate.Name = "rdbTomate";
            this.rdbTomate.Size = new System.Drawing.Size(61, 17);
            this.rdbTomate.TabIndex = 3;
            this.rdbTomate.TabStop = true;
            this.rdbTomate.Text = "Tomate";
            this.rdbTomate.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(93, 155);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 13);
            this.label2.TabIndex = 4;
            // 
            // frmPruebaFormulario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.rdbTomate);
            this.Controls.Add(this.rdbZanahoria);
            this.Controls.Add(this.rdbPatata);
            this.Controls.Add(this.label1);
            this.Name = "frmPruebaFormulario";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton rdbPatata;
        private System.Windows.Forms.RadioButton rdbZanahoria;
        private System.Windows.Forms.RadioButton rdbTomate;
        private System.Windows.Forms.Label label2;
    }
}

