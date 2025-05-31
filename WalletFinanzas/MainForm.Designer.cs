namespace WalletFinanzas
{
    partial class MainForm
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title chartTitle1 = new System.Windows.Forms.DataVisualization.Charting.Title();

            // --- Controles Originales (Nombres sin cambios) ---
            this.lblBalance = new System.Windows.Forms.Label();
            this.chartEstadísticas = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.btnIngresarDatos = new System.Windows.Forms.Button();
            this.btnCotizarProducto = new System.Windows.Forms.Button();
            this.btnVerHistorial = new System.Windows.Forms.Button();
            this.btnRecomendaciones = new System.Windows.Forms.Button();
            this.rbGastosPorCategoria = new System.Windows.Forms.RadioButton();
            this.rbIngresosPorCategoria = new System.Windows.Forms.RadioButton();
            this.rbGastosVsIngresos = new System.Windows.Forms.RadioButton();

            // --- Nuevos Controles Estructurales ---
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.pnlActionButtons = new System.Windows.Forms.Panel();
            this.pnlClientArea = new System.Windows.Forms.Panel();
            this.gbTipoGrafico = new System.Windows.Forms.GroupBox();

            ((System.ComponentModel.ISupportInitialize)(this.chartEstadísticas)).BeginInit();
            this.pnlHeader.SuspendLayout();
            this.pnlActionButtons.SuspendLayout();
            this.pnlClientArea.SuspendLayout();
            this.gbTipoGrafico.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.Controls.Add(this.lblBalance);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(800, 70);
            this.pnlHeader.TabIndex = 0;
            // 
            // lblBalance
            // 
            this.lblBalance.AutoSize = true;
            this.lblBalance.Font = new System.Drawing.Font("Segoe UI Semibold", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBalance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(100)))), ((int)(((byte)(0))))); // Dark Green
            this.lblBalance.Location = new System.Drawing.Point(20, 18);
            this.lblBalance.Name = "lblBalance";
            this.lblBalance.Size = new System.Drawing.Size(255, 32); // Approx size based on text
            this.lblBalance.TabIndex = 0;
            this.lblBalance.Text = "Balance actual: Q0.00";
            // 
            // pnlActionButtons
            // 
            this.pnlActionButtons.Controls.Add(this.btnIngresarDatos);
            this.pnlActionButtons.Controls.Add(this.btnCotizarProducto);
            this.pnlActionButtons.Controls.Add(this.btnVerHistorial);
            this.pnlActionButtons.Controls.Add(this.btnRecomendaciones);
            this.pnlActionButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlActionButtons.Location = new System.Drawing.Point(0, 540); // Adjusted Y for ClientSize 600
            this.pnlActionButtons.Name = "pnlActionButtons";
            this.pnlActionButtons.Size = new System.Drawing.Size(800, 60);
            this.pnlActionButtons.TabIndex = 2;
            // 
            // btnIngresarDatos
            // 
            this.btnIngresarDatos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.btnIngresarDatos.FlatAppearance.BorderSize = 0;
            this.btnIngresarDatos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnIngresarDatos.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnIngresarDatos.ForeColor = System.Drawing.Color.White;
            this.btnIngresarDatos.Location = new System.Drawing.Point(60, 12); // Adjusted for centering
            this.btnIngresarDatos.Name = "btnIngresarDatos";
            this.btnIngresarDatos.Size = new System.Drawing.Size(160, 35);
            this.btnIngresarDatos.TabIndex = 3; // Updated TabIndex
            this.btnIngresarDatos.Text = "➕ Ingresar Datos";
            this.btnIngresarDatos.UseVisualStyleBackColor = false;
            this.btnIngresarDatos.Click += new System.EventHandler(this.btnIngresarDatos_Click);
            // 
            // btnCotizarProducto
            // 
            this.btnCotizarProducto.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnCotizarProducto.FlatAppearance.BorderColor = System.Drawing.Color.LightGray;
            this.btnCotizarProducto.FlatAppearance.BorderSize = 1;
            this.btnCotizarProducto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCotizarProducto.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnCotizarProducto.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnCotizarProducto.Location = new System.Drawing.Point(235, 12); // Adjusted for centering
            this.btnCotizarProducto.Name = "btnCotizarProducto";
            this.btnCotizarProducto.Size = new System.Drawing.Size(160, 35);
            this.btnCotizarProducto.TabIndex = 4; // Updated TabIndex
            this.btnCotizarProducto.Text = "🛒 Cotizar";
            this.btnCotizarProducto.UseVisualStyleBackColor = false;
            this.btnCotizarProducto.Click += new System.EventHandler(this.btnCotizarProducto_Click);
            // 
            // btnVerHistorial
            // 
            this.btnVerHistorial.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnVerHistorial.FlatAppearance.BorderColor = System.Drawing.Color.LightGray;
            this.btnVerHistorial.FlatAppearance.BorderSize = 1;
            this.btnVerHistorial.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVerHistorial.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnVerHistorial.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnVerHistorial.Location = new System.Drawing.Point(410, 12); // Adjusted for centering
            this.btnVerHistorial.Name = "btnVerHistorial";
            this.btnVerHistorial.Size = new System.Drawing.Size(160, 35);
            this.btnVerHistorial.TabIndex = 5; // Updated TabIndex
            this.btnVerHistorial.Text = "📜 Ver Historial";
            this.btnVerHistorial.UseVisualStyleBackColor = false;
            this.btnVerHistorial.Click += new System.EventHandler(this.btnVerHistorial_Click);
            // 
            // btnRecomendaciones
            // 
            this.btnRecomendaciones.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnRecomendaciones.FlatAppearance.BorderColor = System.Drawing.Color.LightGray;
            this.btnRecomendaciones.FlatAppearance.BorderSize = 1;
            this.btnRecomendaciones.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRecomendaciones.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnRecomendaciones.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnRecomendaciones.Location = new System.Drawing.Point(585, 12); // Adjusted for centering
            this.btnRecomendaciones.Name = "btnRecomendaciones";
            this.btnRecomendaciones.Size = new System.Drawing.Size(160, 35);
            this.btnRecomendaciones.TabIndex = 6; // Updated TabIndex
            this.btnRecomendaciones.Text = "💡 Recomendaciones";
            this.btnRecomendaciones.UseVisualStyleBackColor = false;
            this.btnRecomendaciones.Click += new System.EventHandler(this.btnRecomendaciones_Click);
            // 
            // pnlClientArea
            // 
            this.pnlClientArea.Controls.Add(this.gbTipoGrafico);
            this.pnlClientArea.Controls.Add(this.chartEstadísticas);
            this.pnlClientArea.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlClientArea.Location = new System.Drawing.Point(0, 70);
            this.pnlClientArea.Name = "pnlClientArea";
            this.pnlClientArea.Padding = new System.Windows.Forms.Padding(20, 15, 20, 20);
            this.pnlClientArea.Size = new System.Drawing.Size(800, 470); // 600 - 70 - 60
            this.pnlClientArea.TabIndex = 1;
            // 
            // gbTipoGrafico
            // 
            this.gbTipoGrafico.Controls.Add(this.rbGastosPorCategoria);
            this.gbTipoGrafico.Controls.Add(this.rbIngresosPorCategoria);
            this.gbTipoGrafico.Controls.Add(this.rbGastosVsIngresos);
            this.gbTipoGrafico.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbTipoGrafico.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbTipoGrafico.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.gbTipoGrafico.Location = new System.Drawing.Point(20, 15);
            this.gbTipoGrafico.Name = "gbTipoGrafico";
            this.gbTipoGrafico.Size = new System.Drawing.Size(760, 60);
            this.gbTipoGrafico.TabIndex = 0; // Main group for radio buttons
            this.gbTipoGrafico.TabStop = false;
            this.gbTipoGrafico.Text = "Ver Gráfico De:";
            // 
            // rbGastosPorCategoria
            // 
            this.rbGastosPorCategoria.AutoSize = true;
            this.rbGastosPorCategoria.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.rbGastosPorCategoria.Location = new System.Drawing.Point(20, 25);
            this.rbGastosPorCategoria.Name = "rbGastosPorCategoria";
            this.rbGastosPorCategoria.Size = new System.Drawing.Size(135, 19);
            this.rbGastosPorCategoria.TabIndex = 0; // TabIndex within group
            this.rbGastosPorCategoria.TabStop = true;
            this.rbGastosPorCategoria.Text = "Gastos por semana";
            this.rbGastosPorCategoria.UseVisualStyleBackColor = true;
            this.rbGastosPorCategoria.CheckedChanged += new System.EventHandler(this.Estadistica_CheckedChanged);
            // 
            // rbIngresosPorCategoria
            // 
            this.rbIngresosPorCategoria.AutoSize = true;
            this.rbIngresosPorCategoria.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.rbIngresosPorCategoria.Location = new System.Drawing.Point(185, 25); // Adjusted X
            this.rbIngresosPorCategoria.Name = "rbIngresosPorCategoria";
            this.rbIngresosPorCategoria.Size = new System.Drawing.Size(140, 19);
            this.rbIngresosPorCategoria.TabIndex = 1; // TabIndex within group
            this.rbIngresosPorCategoria.TabStop = true;
            this.rbIngresosPorCategoria.Text = "Ingresos por Categoría";
            this.rbIngresosPorCategoria.UseVisualStyleBackColor = true;
            this.rbIngresosPorCategoria.CheckedChanged += new System.EventHandler(this.Estadistica_CheckedChanged);
            // 
            // rbGastosVsIngresos
            // 
            this.rbGastosVsIngresos.AutoSize = true;
            this.rbGastosVsIngresos.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.rbGastosVsIngresos.Location = new System.Drawing.Point(355, 25); // Adjusted X
            this.rbGastosVsIngresos.Name = "rbGastosVsIngresos";
            this.rbGastosVsIngresos.Size = new System.Drawing.Size(126, 19);
            this.rbGastosVsIngresos.TabIndex = 2; // TabIndex within group
            this.rbGastosVsIngresos.TabStop = true;
            this.rbGastosVsIngresos.Text = "Gastos vs. Ingresos";
            this.rbGastosVsIngresos.UseVisualStyleBackColor = true;
            this.rbGastosVsIngresos.CheckedChanged += new System.EventHandler(this.Estadistica_CheckedChanged);
            // 
            // chartEstadísticas
            // 
            chartArea1.AxisX.LabelStyle.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            chartArea1.AxisX.LineColor = System.Drawing.Color.LightGray;
            chartArea1.AxisX.MajorGrid.LineColor = System.Drawing.Color.Gainsboro;
            chartArea1.AxisX.TitleFont = new System.Drawing.Font("Segoe UI", 9F);
            chartArea1.AxisY.LabelStyle.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            chartArea1.AxisY.LineColor = System.Drawing.Color.LightGray;
            chartArea1.AxisY.MajorGrid.LineColor = System.Drawing.Color.Gainsboro;
            chartArea1.AxisY.TitleFont = new System.Drawing.Font("Segoe UI", 9F);
            chartArea1.BackColor = System.Drawing.Color.White;
            chartArea1.Name = "ChartArea1";
            this.chartEstadísticas.ChartAreas.Add(chartArea1);
            this.chartEstadísticas.Dock = System.Windows.Forms.DockStyle.Bottom; // Fills below radio buttons
            legend1.Font = new System.Drawing.Font("Segoe UI", 9F);
            legend1.IsTextAutoFit = false;
            legend1.Name = "Legend1";
            this.chartEstadísticas.Legends.Add(legend1);
            this.chartEstadísticas.Location = new System.Drawing.Point(20, 90); // Y = gb.Bottom + 15 (approx)
            this.chartEstadísticas.Name = "chartEstadísticas";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chartEstadísticas.Series.Add(series1);
            this.chartEstadísticas.Size = new System.Drawing.Size(760, 360); // H = pnlClient.H - gb.H - padding
            this.chartEstadísticas.TabIndex = 1; // After radio buttons group
            this.chartEstadísticas.Text = "chart1";
            chartTitle1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            chartTitle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            chartTitle1.Name = "TitleMain";
            chartTitle1.Text = "Resumen Financiero";
            this.chartEstadísticas.Titles.Add(chartTitle1);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F); // For Segoe UI 9F
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(242)))), ((int)(((byte)(245)))));
            this.ClientSize = new System.Drawing.Size(800, 600); // Adjusted ClientSize
            this.Controls.Add(this.pnlClientArea);
            this.Controls.Add(this.pnlActionButtons);
            this.Controls.Add(this.pnlHeader);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "WalletFinanzas - Dashboard Principal";
            ((System.ComponentModel.ISupportInitialize)(this.chartEstadísticas)).EndInit();
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlActionButtons.ResumeLayout(false);
            this.pnlClientArea.ResumeLayout(false);
            this.gbTipoGrafico.ResumeLayout(false);
            this.gbTipoGrafico.PerformLayout();
            this.ResumeLayout(false);
        }

        #endregion

        // --- Controles Originales (Nombres sin cambios) ---
        private System.Windows.Forms.Label lblBalance;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartEstadísticas;
        private System.Windows.Forms.Button btnIngresarDatos;
        private System.Windows.Forms.Button btnCotizarProducto;
        private System.Windows.Forms.Button btnVerHistorial;
        private System.Windows.Forms.Button btnRecomendaciones;
        private System.Windows.Forms.RadioButton rbGastosPorCategoria;
        private System.Windows.Forms.RadioButton rbIngresosPorCategoria;
        private System.Windows.Forms.RadioButton rbGastosVsIngresos;

        // --- Nuevos Controles Estructurales ---
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Panel pnlActionButtons;
        private System.Windows.Forms.Panel pnlClientArea;
        private System.Windows.Forms.GroupBox gbTipoGrafico;
    }
}