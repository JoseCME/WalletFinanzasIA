namespace WalletFinanzas
{
    partial class CotizarProductoForm
    {
        // --- Controles Originales (Nombres sin cambios) ---
        private System.Windows.Forms.Label lblNombreProducto;
        private System.Windows.Forms.TextBox txtNombreProducto;
        private System.Windows.Forms.Label lblCostoProducto;
        private System.Windows.Forms.TextBox txtCostoProducto;
        private System.Windows.Forms.Label lblCuotas;
        private System.Windows.Forms.TextBox txtCuotas;
        private System.Windows.Forms.Button btnSubirImagen;
        private System.Windows.Forms.Button btnCotizar;
        private System.Windows.Forms.Label lblEstadoProcesamiento;
        private System.Windows.Forms.Button btnRegresar;
        private System.Windows.Forms.ProgressBar progressBar2;

        // --- Nuevos Controles Estructurales ---
        private System.Windows.Forms.Panel pnlMainInputArea;
        private System.Windows.Forms.Panel pnlActionsAndStatus;

        private System.ComponentModel.IContainer components = null;

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
            this.lblNombreProducto = new System.Windows.Forms.Label();
            this.txtNombreProducto = new System.Windows.Forms.TextBox();
            this.lblCostoProducto = new System.Windows.Forms.Label();
            this.txtCostoProducto = new System.Windows.Forms.TextBox();
            this.lblCuotas = new System.Windows.Forms.Label();
            this.txtCuotas = new System.Windows.Forms.TextBox();
            this.btnSubirImagen = new System.Windows.Forms.Button();
            this.btnCotizar = new System.Windows.Forms.Button();
            this.lblEstadoProcesamiento = new System.Windows.Forms.Label();
            this.btnRegresar = new System.Windows.Forms.Button();
            this.progressBar2 = new System.Windows.Forms.ProgressBar();
            this.pnlMainInputArea = new System.Windows.Forms.Panel();
            this.pnlActionsAndStatus = new System.Windows.Forms.Panel();

            this.pnlMainInputArea.SuspendLayout();
            this.pnlActionsAndStatus.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlMainInputArea
            // 
            this.pnlMainInputArea.Controls.Add(this.lblNombreProducto);
            this.pnlMainInputArea.Controls.Add(this.txtNombreProducto);
            this.pnlMainInputArea.Controls.Add(this.lblCostoProducto);
            this.pnlMainInputArea.Controls.Add(this.txtCostoProducto);
            this.pnlMainInputArea.Controls.Add(this.lblCuotas);
            this.pnlMainInputArea.Controls.Add(this.txtCuotas);
            this.pnlMainInputArea.Controls.Add(this.btnSubirImagen);
            this.pnlMainInputArea.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMainInputArea.Location = new System.Drawing.Point(0, 0);
            this.pnlMainInputArea.Name = "pnlMainInputArea";
            this.pnlMainInputArea.Padding = new System.Windows.Forms.Padding(20);
            this.pnlMainInputArea.Size = new System.Drawing.Size(460, 210); // ClientHeight - pnlActionsAndStatus.Height
            this.pnlMainInputArea.TabIndex = 0;
            // 
            // lblNombreProducto
            // 
            this.lblNombreProducto.AutoSize = true;
            this.lblNombreProducto.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombreProducto.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblNombreProducto.Location = new System.Drawing.Point(20, 20);
            this.lblNombreProducto.Name = "lblNombreProducto";
            this.lblNombreProducto.Size = new System.Drawing.Size(132, 17);
            this.lblNombreProducto.TabIndex = 0;
            this.lblNombreProducto.Text = "Nombre del Producto:";
            // 
            // txtNombreProducto
            // 
            this.txtNombreProducto.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNombreProducto.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.txtNombreProducto.Location = new System.Drawing.Point(23, 40);
            this.txtNombreProducto.Name = "txtNombreProducto";
            this.txtNombreProducto.Size = new System.Drawing.Size(414, 25);
            this.txtNombreProducto.TabIndex = 0;
            this.txtNombreProducto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            // 
            // lblCostoProducto
            // 
            this.lblCostoProducto.AutoSize = true;
            this.lblCostoProducto.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.lblCostoProducto.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblCostoProducto.Location = new System.Drawing.Point(20, 75);
            this.lblCostoProducto.Name = "lblCostoProducto";
            this.lblCostoProducto.Size = new System.Drawing.Size(91, 17);
            this.lblCostoProducto.Text = "Costo Total (Q):";
            // 
            // txtCostoProducto
            // 
            this.txtCostoProducto.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.txtCostoProducto.Location = new System.Drawing.Point(23, 95);
            this.txtCostoProducto.Name = "txtCostoProducto";
            this.txtCostoProducto.Size = new System.Drawing.Size(190, 25);
            this.txtCostoProducto.TabIndex = 1;
            this.txtCostoProducto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            // 
            // lblCuotas
            // 
            this.lblCuotas.AutoSize = true;
            this.lblCuotas.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.lblCuotas.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblCuotas.Location = new System.Drawing.Point(225, 75);
            this.lblCuotas.Name = "lblCuotas";
            this.lblCuotas.Size = new System.Drawing.Size(122, 17);
            this.lblCuotas.Text = "Número de Cuotas:";
            // 
            // txtCuotas
            // 
            this.txtCuotas.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCuotas.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.txtCuotas.Location = new System.Drawing.Point(228, 95);
            this.txtCuotas.Name = "txtCuotas";
            this.txtCuotas.Size = new System.Drawing.Size(209, 25);
            this.txtCuotas.TabIndex = 2;
            this.txtCuotas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            // 
            // btnSubirImagen
            // 
            this.btnSubirImagen.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSubirImagen.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnSubirImagen.FlatAppearance.BorderColor = System.Drawing.Color.LightGray;
            this.btnSubirImagen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSubirImagen.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnSubirImagen.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnSubirImagen.Location = new System.Drawing.Point(23, 140);
            this.btnSubirImagen.Name = "btnSubirImagen";
            this.btnSubirImagen.Size = new System.Drawing.Size(414, 35);
            this.btnSubirImagen.TabIndex = 3;
            this.btnSubirImagen.Text = "📷 Subir Imagen del Producto (Opcional)";
            this.btnSubirImagen.UseVisualStyleBackColor = false;
            this.btnSubirImagen.Click += new System.EventHandler(this.btnSubirImagen_Click);
            // 
            // pnlActionsAndStatus
            // 
            this.pnlActionsAndStatus.Controls.Add(this.lblEstadoProcesamiento);
            this.pnlActionsAndStatus.Controls.Add(this.progressBar2);
            this.pnlActionsAndStatus.Controls.Add(this.btnRegresar);
            this.pnlActionsAndStatus.Controls.Add(this.btnCotizar);
            this.pnlActionsAndStatus.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlActionsAndStatus.Location = new System.Drawing.Point(0, 210);
            this.pnlActionsAndStatus.Name = "pnlActionsAndStatus";
            this.pnlActionsAndStatus.Padding = new System.Windows.Forms.Padding(10);
            this.pnlActionsAndStatus.Size = new System.Drawing.Size(460, 80);
            this.pnlActionsAndStatus.TabIndex = 1;
            // 
            // lblEstadoProcesamiento
            // 
            this.lblEstadoProcesamiento.AutoSize = true;
            this.lblEstadoProcesamiento.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEstadoProcesamiento.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblEstadoProcesamiento.Location = new System.Drawing.Point(15, 12);
            this.lblEstadoProcesamiento.Name = "lblEstadoProcesamiento";
            this.lblEstadoProcesamiento.Size = new System.Drawing.Size(41, 13);
            this.lblEstadoProcesamiento.Text = "Estado";
            this.lblEstadoProcesamiento.Visible = false;
            // 
            // progressBar2
            // 
            this.progressBar2.Location = new System.Drawing.Point(18, 30);
            this.progressBar2.MarqueeAnimationSpeed = 30;
            this.progressBar2.Name = "progressBar2";
            this.progressBar2.Size = new System.Drawing.Size(180, 15);
            this.progressBar2.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.progressBar2.TabIndex = 7; // Does not need user focus generally
            this.progressBar2.Visible = false;
            // 
            // btnRegresar
            // 
            this.btnRegresar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRegresar.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnRegresar.FlatAppearance.BorderColor = System.Drawing.Color.LightGray;
            this.btnRegresar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRegresar.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.btnRegresar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnRegresar.Location = new System.Drawing.Point(200, 25); // Adjusted position
            this.btnRegresar.Name = "btnRegresar";
            this.btnRegresar.Size = new System.Drawing.Size(120, 40);
            this.btnRegresar.TabIndex = 5;
            this.btnRegresar.Text = "⬅️ Regresar";
            this.btnRegresar.UseVisualStyleBackColor = false;
            this.btnRegresar.Click += new System.EventHandler(this.btnRegresar_Click);
            // 
            // btnCotizar
            // 
            this.btnCotizar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCotizar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.btnCotizar.FlatAppearance.BorderSize = 0;
            this.btnCotizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCotizar.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnCotizar.ForeColor = System.Drawing.Color.White;
            this.btnCotizar.Location = new System.Drawing.Point(326, 25); // Adjusted position
            this.btnCotizar.Name = "btnCotizar";
            this.btnCotizar.Size = new System.Drawing.Size(120, 40);
            this.btnCotizar.TabIndex = 4;
            this.btnCotizar.Text = "💰 Cotizar";
            this.btnCotizar.UseVisualStyleBackColor = false;
            this.btnCotizar.Click += new System.EventHandler(this.btnCotizar_Click);
            // 
            // CotizarProductoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F); // Segoe UI 9F
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(242)))), ((int)(((byte)(245)))));
            this.ClientSize = new System.Drawing.Size(460, 290); // Adjusted ClientSize
            this.Controls.Add(this.pnlMainInputArea);
            this.Controls.Add(this.pnlActionsAndStatus);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MinimumSize = new System.Drawing.Size(476, 329);
            this.Name = "CotizarProductoForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Cotizar Producto con IA";
            this.pnlMainInputArea.ResumeLayout(false);
            this.pnlMainInputArea.PerformLayout();
            this.pnlActionsAndStatus.ResumeLayout(false);
            this.pnlActionsAndStatus.PerformLayout();
            this.ResumeLayout(false);
        }
    }
}