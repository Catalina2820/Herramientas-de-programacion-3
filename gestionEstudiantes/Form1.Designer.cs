namespace gestionEstudiantes
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblNombre = new Label();
            lblCarrera = new Label();
            lblPromedio = new Label();
            lblMatricula = new Label();
            txtNombre = new TextBox();
            txtPromedio = new TextBox();
            txtMatricula = new TextBox();
            txtValorCredito = new TextBox();
            lblCredito = new Label();
            btnAdd = new Button();
            btnBuscar = new Button();
            btnSalir = new Button();
            cbxCarrera = new ComboBox();
            SuspendLayout();
            // 
            // lblNombre
            // 
            lblNombre.AutoSize = true;
            lblNombre.Location = new Point(59, 25);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(67, 20);
            lblNombre.TabIndex = 0;
            lblNombre.Text = "Nombre:";
            lblNombre.Click += label1_Click;
            // 
            // lblCarrera
            // 
            lblCarrera.AutoSize = true;
            lblCarrera.Location = new Point(59, 62);
            lblCarrera.Name = "lblCarrera";
            lblCarrera.Size = new Size(60, 20);
            lblCarrera.TabIndex = 1;
            lblCarrera.Text = "Carrera:";
            // 
            // lblPromedio
            // 
            lblPromedio.AutoSize = true;
            lblPromedio.Location = new Point(59, 139);
            lblPromedio.Name = "lblPromedio";
            lblPromedio.Size = new Size(77, 20);
            lblPromedio.TabIndex = 2;
            lblPromedio.Text = "Promedio:";
            // 
            // lblMatricula
            // 
            lblMatricula.AutoSize = true;
            lblMatricula.Location = new Point(59, 100);
            lblMatricula.Name = "lblMatricula";
            lblMatricula.Size = new Size(74, 20);
            lblMatricula.TabIndex = 3;
            lblMatricula.Text = "Matrícula:";
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(163, 22);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(125, 27);
            txtNombre.TabIndex = 4;
            // 
            // txtPromedio
            // 
            txtPromedio.Location = new Point(163, 138);
            txtPromedio.Name = "txtPromedio";
            txtPromedio.Size = new Size(125, 27);
            txtPromedio.TabIndex = 7;
            // 
            // txtMatricula
            // 
            txtMatricula.Location = new Point(163, 97);
            txtMatricula.Name = "txtMatricula";
            txtMatricula.Size = new Size(125, 27);
            txtMatricula.TabIndex = 6;
            // 
            // txtValorCredito
            // 
            txtValorCredito.Location = new Point(163, 180);
            txtValorCredito.Name = "txtValorCredito";
            txtValorCredito.Size = new Size(125, 27);
            txtValorCredito.TabIndex = 9;
            // 
            // lblCredito
            // 
            lblCredito.AutoSize = true;
            lblCredito.Location = new Point(59, 181);
            lblCredito.Name = "lblCredito";
            lblCredito.Size = new Size(97, 20);
            lblCredito.TabIndex = 8;
            lblCredito.Text = "Valor crédito:";
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(24, 224);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(94, 29);
            btnAdd.TabIndex = 10;
            btnAdd.Text = "Adicionar";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnBuscar
            // 
            btnBuscar.Location = new Point(135, 224);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(94, 29);
            btnBuscar.TabIndex = 11;
            btnBuscar.Text = "Buscar";
            btnBuscar.UseVisualStyleBackColor = true;
            btnBuscar.Click += btnBuscar_Click;
            // 
            // btnSalir
            // 
            btnSalir.Location = new Point(245, 224);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(94, 29);
            btnSalir.TabIndex = 12;
            btnSalir.Text = "Salir";
            btnSalir.UseVisualStyleBackColor = true;
            btnSalir.Click += btnSalir_Click;
            // 
            // cbxCarrera
            // 
            cbxCarrera.FormattingEnabled = true;
            cbxCarrera.Items.AddRange(new object[] { "Ingeniería", "Administración", "Medicina" });
            cbxCarrera.Location = new Point(163, 59);
            cbxCarrera.Name = "cbxCarrera";
            cbxCarrera.Size = new Size(125, 28);
            cbxCarrera.TabIndex = 13;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(371, 274);
            Controls.Add(cbxCarrera);
            Controls.Add(btnSalir);
            Controls.Add(btnBuscar);
            Controls.Add(btnAdd);
            Controls.Add(txtValorCredito);
            Controls.Add(lblCredito);
            Controls.Add(txtPromedio);
            Controls.Add(txtMatricula);
            Controls.Add(txtNombre);
            Controls.Add(lblMatricula);
            Controls.Add(lblPromedio);
            Controls.Add(lblCarrera);
            Controls.Add(lblNombre);
            Name = "Form1";
            Text = "Gestión de estudiantes";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblNombre;
        private Label lblCarrera;
        private Label lblPromedio;
        private Label lblMatricula;
        private TextBox txtNombre;
        private TextBox txtPromedio;
        private TextBox txtMatricula;
        private TextBox txtValorCredito;
        private Label lblCredito;
        private Button btnAdd;
        private Button btnBuscar;
        private Button btnSalir;
        private ComboBox cbxCarrera;
    }
}