namespace WalletFinanzas
{
    partial class RecomendacionesForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.btnGenerarRecomendación = new System.Windows.Forms.Button();
            this.btnRegresar = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.txtRecomendaciones = new System.Windows.Forms.TextBox();
            this.lblTituloRecomendaciones = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblTituloRecomendaciones
            // 
            this.lblTituloRecomendaciones.AutoSize = true;
            this.lblTituloRecomendaciones.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTituloRecomendaciones.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblTituloRecomendaciones.Location = new System.Drawing.Point(12, 15);
            this.lblTituloRecomendaciones.Name = "lblTituloRecomendaciones";
            this.lblTituloRecomendaciones.Size = new System.Drawing.Size(205, 20);
            this.lblTituloRecomendaciones.TabIndex = 4; // Nueva TabIndex
            this.lblTituloRecomendaciones.Text = "Sus Consejos Personalizados:";
            // 
            // btnGenerarRecomendación
            // 
            this.btnGenerarRecomendación.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.btnGenerarRecomendación.FlatAppearance.BorderSize = 0;
            this.btnGenerarRecomendación.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGenerarRecomendación.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnGenerarRecomendación.ForeColor = System.Drawing.Color.White;
            this.btnGenerarRecomendación.Location = new System.Drawing.Point(12, 306);
            this.btnGenerarRecomendación.Name = "btnGenerarRecomendación";
            this.btnGenerarRecomendación.Size = new System.Drawing.Size(180, 35);
            this.btnGenerarRecomendación.TabIndex = 1;
            this.btnGenerarRecomendación.Text = "💡 Generar";
            this.btnGenerarRecomendación.UseVisualStyleBackColor = false;
            this.btnGenerarRecomendación.Click += new System.EventHandler(this.btnGenerarRecomendación_Click);
            // 
            // btnRegresar
            // 
            this.btnRegresar.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnRegresar.FlatAppearance.BorderColor = System.Drawing.Color.LightGray;
            this.btnRegresar.FlatAppearance.BorderSize = 1;
            this.btnRegresar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRegresar.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnRegresar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnRegresar.Location = new System.Drawing.Point(372, 306);
            this.btnRegresar.Name = "btnRegresar";
            this.btnRegresar.Size = new System.Drawing.Size(100, 35);
            this.btnRegresar.TabIndex = 2;
            this.btnRegresar.Text = "⬅️ Regresar";
            this.btnRegresar.UseVisualStyleBackColor = false;
            this.btnRegresar.Click += new System.EventHandler(this.btnRegresar_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(12, 275);
            this.progressBar1.MarqueeAnimationSpeed = 30;
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(460, 23);
            this.progressBar1.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.progressBar1.TabIndex = 3;
            this.progressBar1.Visible = false;
            // 
            // txtRecomendaciones
            // 
            this.txtRecomendaciones.BackColor = System.Drawing.Color.White;
            this.txtRecomendaciones.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtRecomendaciones.Location = new System.Drawing.Point(12, 40); // Ajustado Y por el label
            this.txtRecomendaciones.Multiline = true;
            this.txtRecomendaciones.Name = "txtRecomendaciones";
            this.txtRecomendaciones.ReadOnly = true;
            this.txtRecomendaciones.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtRecomendaciones.Size = new System.Drawing.Size(460, 225); // Altura ajustada
            this.txtRecomendaciones.TabIndex = 0;
            // 
            // RecomendacionesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F); // Ajustado para Segoe UI 9F
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(242)))), ((int)(((byte)(245)))));
            this.ClientSize = new System.Drawing.Size(484, 353); // Altura ajustada
            this.Controls.Add(this.lblTituloRecomendaciones);
            this.Controls.Add(this.txtRecomendaciones);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.btnRegresar);
            this.Controls.Add(this.btnGenerarRecomendación);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RecomendacionesForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Recomendaciones Financieras IA"; // Texto actualizado
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnGenerarRecomendación;
        private System.Windows.Forms.Button btnRegresar;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.TextBox txtRecomendaciones;
        private System.Windows.Forms.Label lblTituloRecomendaciones; // Declaración del nuevo Label
    }
}