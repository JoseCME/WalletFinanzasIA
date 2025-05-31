namespace WalletFinanzas
{
    partial class IngresarDatosForm
    {
        private System.ComponentModel.IContainer components = null;

        // --- Controles Originales (Nombres sin cambios) ---
        private System.Windows.Forms.Label lblBalance;
        private System.Windows.Forms.Label lblIngresos;
        private System.Windows.Forms.Label lblGastos;
        private System.Windows.Forms.Label lblIngresosTitle;
        private System.Windows.Forms.Label lblDescripciónIngreso;
        private System.Windows.Forms.TextBox txtDescripciónIngreso;
        private System.Windows.Forms.Label lblMontoIngreso;
        private System.Windows.Forms.TextBox txtMontoIngreso;
        private System.Windows.Forms.Label lblCategoriaIngreso;
        private System.Windows.Forms.TextBox txtCategoriaIngreso;
        private System.Windows.Forms.Button btnGuardarIngreso;
        private System.Windows.Forms.Label lblGastosTitle;
        private System.Windows.Forms.Label lblDescripciónGasto;
        private System.Windows.Forms.TextBox txtDescripciónGasto;
        private System.Windows.Forms.Label lblMontoGasto;
        private System.Windows.Forms.TextBox txtMontoGasto;
        private System.Windows.Forms.Label lblCategoriaGasto;
        private System.Windows.Forms.TextBox txtCategoriaGasto;
        private System.Windows.Forms.Button btnAgregarGasto;
        private System.Windows.Forms.Button btnSubirImagenGasto;
        private System.Windows.Forms.Button btnGrabarAudioGasto;
        private System.Windows.Forms.Button btnRegresar;
        private System.Windows.Forms.Label lblEstadoProcesamiento;

        // --- Nuevos Controles Estructurales ---
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Panel pnlMainContent;
        private System.Windows.Forms.Panel pnlIngresos;
        private System.Windows.Forms.Panel pnlGastos;
        private System.Windows.Forms.Panel pnlFooter;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblBalance = new System.Windows.Forms.Label();
            this.lblIngresos = new System.Windows.Forms.Label();
            this.lblGastos = new System.Windows.Forms.Label();
            this.pnlMainContent = new System.Windows.Forms.Panel();
            this.pnlIngresos = new System.Windows.Forms.Panel();
            this.lblIngresosTitle = new System.Windows.Forms.Label();
            this.lblDescripciónIngreso = new System.Windows.Forms.Label();
            this.txtDescripciónIngreso = new System.Windows.Forms.TextBox();
            this.lblMontoIngreso = new System.Windows.Forms.Label();
            this.txtMontoIngreso = new System.Windows.Forms.TextBox();
            this.lblCategoriaIngreso = new System.Windows.Forms.Label();
            this.txtCategoriaIngreso = new System.Windows.Forms.TextBox();
            this.btnGuardarIngreso = new System.Windows.Forms.Button();
            this.pnlGastos = new System.Windows.Forms.Panel();
            this.lblGastosTitle = new System.Windows.Forms.Label();
            this.lblDescripciónGasto = new System.Windows.Forms.Label();
            this.txtDescripciónGasto = new System.Windows.Forms.TextBox();
            this.lblMontoGasto = new System.Windows.Forms.Label();
            this.txtMontoGasto = new System.Windows.Forms.TextBox();
            this.lblCategoriaGasto = new System.Windows.Forms.Label();
            this.txtCategoriaGasto = new System.Windows.Forms.TextBox();
            this.btnAgregarGasto = new System.Windows.Forms.Button();
            this.btnSubirImagenGasto = new System.Windows.Forms.Button();
            this.btnGrabarAudioGasto = new System.Windows.Forms.Button();
            this.pnlFooter = new System.Windows.Forms.Panel();
            this.btnRegresar = new System.Windows.Forms.Button();
            this.lblEstadoProcesamiento = new System.Windows.Forms.Label();

            this.pnlHeader.SuspendLayout();
            this.pnlMainContent.SuspendLayout();
            this.pnlIngresos.SuspendLayout();
            this.pnlGastos.SuspendLayout();
            this.pnlFooter.SuspendLayout();
            this.SuspendLayout();

            // 
            // pnlHeader
            // 
            this.pnlHeader.Controls.Add(this.lblGastos);
            this.pnlHeader.Controls.Add(this.lblIngresos);
            this.pnlHeader.Controls.Add(this.lblBalance);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(900, 60);
            this.pnlHeader.TabIndex = 0;
            // 
            // lblBalance
            // 
            this.lblBalance.AutoSize = true;
            this.lblBalance.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold);
            this.lblBalance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblBalance.Location = new System.Drawing.Point(30, 20);
            this.lblBalance.Name = "lblBalance";
            this.lblBalance.Size = new System.Drawing.Size(120, 20); // Approx size
            this.lblBalance.Text = "Balance: Q0.00";
            // 
            // lblIngresos
            // 
            this.lblIngresos.AutoSize = true;
            this.lblIngresos.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold);
            this.lblIngresos.ForeColor = System.Drawing.Color.ForestGreen;
            this.lblIngresos.Location = new System.Drawing.Point(300, 20); // Adjusted X
            this.lblIngresos.Name = "lblIngresos";
            this.lblIngresos.Size = new System.Drawing.Size(120, 20); // Approx size
            this.lblIngresos.Text = "Ingresos: Q0.00";
            // 
            // lblGastos
            // 
            this.lblGastos.AutoSize = true;
            this.lblGastos.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold);
            this.lblGastos.ForeColor = System.Drawing.Color.Crimson;
            this.lblGastos.Location = new System.Drawing.Point(570, 20); // Adjusted X
            this.lblGastos.Name = "lblGastos";
            this.lblGastos.Size = new System.Drawing.Size(110, 20); // Approx size
            this.lblGastos.Text = "Gastos: Q0.00";
            // 
            // pnlMainContent
            // 
            this.pnlMainContent.Controls.Add(this.pnlIngresos);
            this.pnlMainContent.Controls.Add(this.pnlGastos);
            this.pnlMainContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMainContent.Location = new System.Drawing.Point(0, 60);
            this.pnlMainContent.Name = "pnlMainContent";
            this.pnlMainContent.Padding = new System.Windows.Forms.Padding(10);
            this.pnlMainContent.Size = new System.Drawing.Size(900, 410); // Adjusted height
            this.pnlMainContent.TabIndex = 1;
            // 
            // pnlIngresos
            // 
            this.pnlIngresos.Controls.Add(this.lblIngresosTitle);
            this.pnlIngresos.Controls.Add(this.lblDescripciónIngreso);
            this.pnlIngresos.Controls.Add(this.txtDescripciónIngreso);
            this.pnlIngresos.Controls.Add(this.lblMontoIngreso);
            this.pnlIngresos.Controls.Add(this.txtMontoIngreso);
            this.pnlIngresos.Controls.Add(this.lblCategoriaIngreso);
            this.pnlIngresos.Controls.Add(this.txtCategoriaIngreso);
            this.pnlIngresos.Controls.Add(this.btnGuardarIngreso);
            this.pnlIngresos.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlIngresos.Location = new System.Drawing.Point(10, 10);
            this.pnlIngresos.Name = "pnlIngresos";
            this.pnlIngresos.Padding = new System.Windows.Forms.Padding(15);
            this.pnlIngresos.Size = new System.Drawing.Size(430, 390); // Adjusted width and height
            this.pnlIngresos.TabIndex = 0;
            this.pnlIngresos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            // 
            // lblIngresosTitle
            // 
            this.lblIngresosTitle.AutoSize = true;
            this.lblIngresosTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblIngresosTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblIngresosTitle.Location = new System.Drawing.Point(20, 20);
            this.lblIngresosTitle.Name = "lblIngresosTitle";
            this.lblIngresosTitle.Size = new System.Drawing.Size(130, 21);
            this.lblIngresosTitle.Text = "Ingresar Ingreso";
            // 
            // lblDescripciónIngreso
            // 
            this.lblDescripciónIngreso.AutoSize = true;
            this.lblDescripciónIngreso.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblDescripciónIngreso.Location = new System.Drawing.Point(20, 60);
            this.lblDescripciónIngreso.Name = "lblDescripciónIngreso";
            this.lblDescripciónIngreso.Size = new System.Drawing.Size(70, 15);
            this.lblDescripciónIngreso.Text = "Descripción:";
            // 
            // txtDescripciónIngreso
            // 
            this.txtDescripciónIngreso.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtDescripciónIngreso.Location = new System.Drawing.Point(23, 80);
            this.txtDescripciónIngreso.Name = "txtDescripciónIngreso";
            this.txtDescripciónIngreso.Size = new System.Drawing.Size(380, 23);
            this.txtDescripciónIngreso.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            // 
            // lblMontoIngreso
            // 
            this.lblMontoIngreso.AutoSize = true;
            this.lblMontoIngreso.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblMontoIngreso.Location = new System.Drawing.Point(20, 120);
            this.lblMontoIngreso.Name = "lblMontoIngreso";
            this.lblMontoIngreso.Size = new System.Drawing.Size(64, 15);
            this.lblMontoIngreso.Text = "Monto (Q):";
            // 
            // txtMontoIngreso
            // 
            this.txtMontoIngreso.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtMontoIngreso.Location = new System.Drawing.Point(23, 140);
            this.txtMontoIngreso.Name = "txtMontoIngreso";
            this.txtMontoIngreso.Size = new System.Drawing.Size(380, 23);
            this.txtMontoIngreso.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            // 
            // lblCategoriaIngreso
            // 
            this.lblCategoriaIngreso.AutoSize = true;
            this.lblCategoriaIngreso.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblCategoriaIngreso.Location = new System.Drawing.Point(20, 180);
            this.lblCategoriaIngreso.Name = "lblCategoriaIngreso";
            this.lblCategoriaIngreso.Size = new System.Drawing.Size(61, 15);
            this.lblCategoriaIngreso.Text = "Categoría:";
            // 
            // txtCategoriaIngreso
            // 
            this.txtCategoriaIngreso.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtCategoriaIngreso.Location = new System.Drawing.Point(23, 200);
            this.txtCategoriaIngreso.Name = "txtCategoriaIngreso";
            this.txtCategoriaIngreso.Size = new System.Drawing.Size(380, 23);
            this.txtCategoriaIngreso.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            // 
            // btnGuardarIngreso
            // 
            this.btnGuardarIngreso.BackColor = System.Drawing.Color.ForestGreen;
            this.btnGuardarIngreso.FlatAppearance.BorderSize = 0;
            this.btnGuardarIngreso.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardarIngreso.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnGuardarIngreso.ForeColor = System.Drawing.Color.White;
            this.btnGuardarIngreso.Location = new System.Drawing.Point(23, 250);
            this.btnGuardarIngreso.Name = "btnGuardarIngreso";
            this.btnGuardarIngreso.Size = new System.Drawing.Size(380, 35);
            this.btnGuardarIngreso.Text = "💾 Guardar Ingreso";
            this.btnGuardarIngreso.UseVisualStyleBackColor = false;
            this.btnGuardarIngreso.Click += new System.EventHandler(this.btnGuardarIngreso_Click);
            // 
            // pnlGastos
            // 
            this.pnlGastos.Controls.Add(this.lblGastosTitle);
            this.pnlGastos.Controls.Add(this.lblDescripciónGasto);
            this.pnlGastos.Controls.Add(this.txtDescripciónGasto);
            this.pnlGastos.Controls.Add(this.lblMontoGasto);
            this.pnlGastos.Controls.Add(this.txtMontoGasto);
            this.pnlGastos.Controls.Add(this.lblCategoriaGasto);
            this.pnlGastos.Controls.Add(this.txtCategoriaGasto);
            this.pnlGastos.Controls.Add(this.btnAgregarGasto);
            this.pnlGastos.Controls.Add(this.btnSubirImagenGasto);
            this.pnlGastos.Controls.Add(this.btnGrabarAudioGasto);
            this.pnlGastos.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlGastos.Location = new System.Drawing.Point(460, 10); // Adjusted X
            this.pnlGastos.Name = "pnlGastos";
            this.pnlGastos.Padding = new System.Windows.Forms.Padding(15);
            this.pnlGastos.Size = new System.Drawing.Size(430, 390); // Adjusted width and height
            this.pnlGastos.TabIndex = 1;
            this.pnlGastos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            // 
            // lblGastosTitle
            // 
            this.lblGastosTitle.AutoSize = true;
            this.lblGastosTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblGastosTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblGastosTitle.Location = new System.Drawing.Point(20, 20);
            this.lblGastosTitle.Name = "lblGastosTitle";
            this.lblGastosTitle.Size = new System.Drawing.Size(120, 21);
            this.lblGastosTitle.Text = "Ingresar Gasto";
            // 
            // lblDescripciónGasto
            // 
            this.lblDescripciónGasto.AutoSize = true;
            this.lblDescripciónGasto.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblDescripciónGasto.Location = new System.Drawing.Point(20, 60);
            this.lblDescripciónGasto.Name = "lblDescripciónGasto";
            this.lblDescripciónGasto.Size = new System.Drawing.Size(70, 15);
            this.lblDescripciónGasto.Text = "Descripción:";
            // 
            // txtDescripciónGasto
            // 
            this.txtDescripciónGasto.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtDescripciónGasto.Location = new System.Drawing.Point(23, 80);
            this.txtDescripciónGasto.Name = "txtDescripciónGasto";
            this.txtDescripciónGasto.Size = new System.Drawing.Size(380, 23);
            this.txtDescripciónGasto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            // 
            // lblMontoGasto
            // 
            this.lblMontoGasto.AutoSize = true;
            this.lblMontoGasto.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblMontoGasto.Location = new System.Drawing.Point(20, 120);
            this.lblMontoGasto.Name = "lblMontoGasto";
            this.lblMontoGasto.Size = new System.Drawing.Size(64, 15);
            this.lblMontoGasto.Text = "Monto (Q):";
            // 
            // txtMontoGasto
            // 
            this.txtMontoGasto.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtMontoGasto.Location = new System.Drawing.Point(23, 140);
            this.txtMontoGasto.Name = "txtMontoGasto";
            this.txtMontoGasto.Size = new System.Drawing.Size(380, 23);
            this.txtMontoGasto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            // 
            // lblCategoriaGasto
            // 
            this.lblCategoriaGasto.AutoSize = true;
            this.lblCategoriaGasto.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblCategoriaGasto.Location = new System.Drawing.Point(20, 180);
            this.lblCategoriaGasto.Name = "lblCategoriaGasto";
            this.lblCategoriaGasto.Size = new System.Drawing.Size(61, 15);
            this.lblCategoriaGasto.Text = "Categoría:";
            // 
            // txtCategoriaGasto
            // 
            this.txtCategoriaGasto.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtCategoriaGasto.Location = new System.Drawing.Point(23, 200);
            this.txtCategoriaGasto.Name = "txtCategoriaGasto";
            this.txtCategoriaGasto.Size = new System.Drawing.Size(380, 23);
            this.txtCategoriaGasto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            // 
            // btnAgregarGasto
            // 
            this.btnAgregarGasto.BackColor = System.Drawing.Color.Crimson;
            this.btnAgregarGasto.FlatAppearance.BorderSize = 0;
            this.btnAgregarGasto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregarGasto.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnAgregarGasto.ForeColor = System.Drawing.Color.White;
            this.btnAgregarGasto.Location = new System.Drawing.Point(23, 250);
            this.btnAgregarGasto.Name = "btnAgregarGasto";
            this.btnAgregarGasto.Size = new System.Drawing.Size(380, 35);
            this.btnAgregarGasto.Text = "➕ Agregar Gasto";
            this.btnAgregarGasto.UseVisualStyleBackColor = false;
            this.btnAgregarGasto.Click += new System.EventHandler(this.btnAgregarGasto_Click);
            // 
            // btnSubirImagenGasto
            // 
            this.btnSubirImagenGasto.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnSubirImagenGasto.FlatAppearance.BorderColor = System.Drawing.Color.LightGray;
            this.btnSubirImagenGasto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSubirImagenGasto.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnSubirImagenGasto.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnSubirImagenGasto.Location = new System.Drawing.Point(23, 295);
            this.btnSubirImagenGasto.Name = "btnSubirImagenGasto";
            this.btnSubirImagenGasto.Size = new System.Drawing.Size(185, 30);
            this.btnSubirImagenGasto.Text = "📷 Subir Imagen";
            this.btnSubirImagenGasto.UseVisualStyleBackColor = false;
            this.btnSubirImagenGasto.Click += new System.EventHandler(this.btnSubirImagenGasto_Click);
            // 
            // btnGrabarAudioGasto
            // 
            this.btnGrabarAudioGasto.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnGrabarAudioGasto.FlatAppearance.BorderColor = System.Drawing.Color.LightGray;
            this.btnGrabarAudioGasto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGrabarAudioGasto.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnGrabarAudioGasto.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnGrabarAudioGasto.Location = new System.Drawing.Point(218, 295);
            this.btnGrabarAudioGasto.Name = "btnGrabarAudioGasto";
            this.btnGrabarAudioGasto.Size = new System.Drawing.Size(185, 30);
            this.btnGrabarAudioGasto.Text = "🎤 Grabar Audio";
            this.btnGrabarAudioGasto.UseVisualStyleBackColor = false;
            this.btnGrabarAudioGasto.Click += new System.EventHandler(this.btnGrabarAudioGasto_Click);
            // 
            // pnlFooter
            // 
            this.pnlFooter.Controls.Add(this.btnRegresar);
            this.pnlFooter.Controls.Add(this.lblEstadoProcesamiento);
            this.pnlFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlFooter.Location = new System.Drawing.Point(0, 470); // Adjusted Y
            this.pnlFooter.Name = "pnlFooter";
            this.pnlFooter.Size = new System.Drawing.Size(900, 50);
            this.pnlFooter.TabIndex = 2;
            // 
            // btnRegresar
            // 
            this.btnRegresar.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnRegresar.FlatAppearance.BorderColor = System.Drawing.Color.LightGray;
            this.btnRegresar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRegresar.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnRegresar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnRegresar.Location = new System.Drawing.Point(750, 10); // Adjusted X
            this.btnRegresar.Name = "btnRegresar";
            this.btnRegresar.Size = new System.Drawing.Size(120, 30);
            this.btnRegresar.Text = "⬅️ Regresar";
            this.btnRegresar.UseVisualStyleBackColor = false;
            this.btnRegresar.Click += new System.EventHandler(this.btnRegresar_Click);
            // 
            // lblEstadoProcesamiento
            // 
            this.lblEstadoProcesamiento.AutoSize = true;
            this.lblEstadoProcesamiento.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic);
            this.lblEstadoProcesamiento.Location = new System.Drawing.Point(30, 18);
            this.lblEstadoProcesamiento.Name = "lblEstadoProcesamiento";
            this.lblEstadoProcesamiento.Size = new System.Drawing.Size(0, 15);
            this.lblEstadoProcesamiento.Visible = false;
            // 
            // IngresarDatosForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F); // Segoe UI 9F
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(242)))), ((int)(((byte)(245)))));
            this.ClientSize = new System.Drawing.Size(900, 520); // Adjusted Size
            this.Controls.Add(this.pnlMainContent);
            this.Controls.Add(this.pnlHeader);
            this.Controls.Add(this.pnlFooter);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "IngresarDatosForm";
            this.Text = "Ingresar Datos Financieros";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;

            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlMainContent.ResumeLayout(false);
            this.pnlIngresos.ResumeLayout(false);
            this.pnlIngresos.PerformLayout();
            this.pnlGastos.ResumeLayout(false);
            this.pnlGastos.PerformLayout();
            this.pnlFooter.ResumeLayout(false);
            this.pnlFooter.PerformLayout();
            this.ResumeLayout(false);
        }
    }
}