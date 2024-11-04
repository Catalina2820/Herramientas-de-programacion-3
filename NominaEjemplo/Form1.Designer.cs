namespace NominaEjemplo
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
            lbl_Nombre = new Label();
            lbl_Valor = new Label();
            lbl_Cargo = new Label();
            lbl_Cant = new Label();
            txt_Nombre = new TextBox();
            txt_Cantidad = new TextBox();
            txt_Valor = new TextBox();
            btn_Save = new Button();
            btn_Calcular = new Button();
            btn_Salir = new Button();
            txt_Total = new TextBox();
            lbl_Total = new Label();
            cbx_Cargo = new ComboBox();
            SuspendLayout();
            // 
            // lbl_Nombre
            // 
            lbl_Nombre.AutoSize = true;
            lbl_Nombre.Location = new Point(19, 19);
            lbl_Nombre.Name = "lbl_Nombre";
            lbl_Nombre.Size = new Size(67, 20);
            lbl_Nombre.TabIndex = 0;
            lbl_Nombre.Text = "Nombre:";
            lbl_Nombre.Click += label1_Click;
            // 
            // lbl_Valor
            // 
            lbl_Valor.AutoSize = true;
            lbl_Valor.Location = new Point(19, 96);
            lbl_Valor.Name = "lbl_Valor";
            lbl_Valor.Size = new Size(83, 20);
            lbl_Valor.TabIndex = 1;
            lbl_Valor.Text = "Valor Hora:";
            lbl_Valor.Click += lbl_Valor_Click;
            // 
            // lbl_Cargo
            // 
            lbl_Cargo.AutoSize = true;
            lbl_Cargo.Location = new Point(19, 55);
            lbl_Cargo.Name = "lbl_Cargo";
            lbl_Cargo.Size = new Size(52, 20);
            lbl_Cargo.TabIndex = 2;
            lbl_Cargo.Text = "Cargo:";
            // 
            // lbl_Cant
            // 
            lbl_Cant.AutoSize = true;
            lbl_Cant.Location = new Point(19, 145);
            lbl_Cant.Name = "lbl_Cant";
            lbl_Cant.Size = new Size(79, 20);
            lbl_Cant.TabIndex = 3;
            lbl_Cant.Text = "Cant Hora:";
            // 
            // txt_Nombre
            // 
            txt_Nombre.Location = new Point(123, 12);
            txt_Nombre.Name = "txt_Nombre";
            txt_Nombre.Size = new Size(170, 27);
            txt_Nombre.TabIndex = 4;
            // 
            // txt_Cantidad
            // 
            txt_Cantidad.Location = new Point(123, 138);
            txt_Cantidad.Name = "txt_Cantidad";
            txt_Cantidad.Size = new Size(170, 27);
            txt_Cantidad.TabIndex = 5;
            // 
            // txt_Valor
            // 
            txt_Valor.Location = new Point(123, 96);
            txt_Valor.Name = "txt_Valor";
            txt_Valor.Size = new Size(170, 27);
            txt_Valor.TabIndex = 6;
            // 
            // btn_Save
            // 
            btn_Save.Location = new Point(28, 233);
            btn_Save.Name = "btn_Save";
            btn_Save.Size = new Size(94, 29);
            btn_Save.TabIndex = 8;
            btn_Save.Text = "Guardar";
            btn_Save.UseVisualStyleBackColor = true;
            btn_Save.Click += btn_Save_Click;
            // 
            // btn_Calcular
            // 
            btn_Calcular.Location = new Point(155, 233);
            btn_Calcular.Name = "btn_Calcular";
            btn_Calcular.Size = new Size(94, 29);
            btn_Calcular.TabIndex = 9;
            btn_Calcular.Text = "Calcular";
            btn_Calcular.UseVisualStyleBackColor = true;
            btn_Calcular.Click += btn_Calcular_Click;
            // 
            // btn_Salir
            // 
            btn_Salir.Location = new Point(96, 281);
            btn_Salir.Name = "btn_Salir";
            btn_Salir.Size = new Size(94, 29);
            btn_Salir.TabIndex = 10;
            btn_Salir.Text = "Salir";
            btn_Salir.UseVisualStyleBackColor = true;
            btn_Salir.Click += btn_Salir_Click;
            // 
            // txt_Total
            // 
            txt_Total.Location = new Point(123, 181);
            txt_Total.Name = "txt_Total";
            txt_Total.Size = new Size(170, 27);
            txt_Total.TabIndex = 12;
            // 
            // lbl_Total
            // 
            lbl_Total.AutoSize = true;
            lbl_Total.Location = new Point(19, 188);
            lbl_Total.Name = "lbl_Total";
            lbl_Total.Size = new Size(102, 20);
            lbl_Total.TabIndex = 11;
            lbl_Total.Text = "Total Nómina:";
            // 
            // cbx_Cargo
            // 
            cbx_Cargo.FormattingEnabled = true;
            cbx_Cargo.Items.AddRange(new object[] { "Auxiliar", "Coordinador", "Gerente" });
            cbx_Cargo.Location = new Point(123, 55);
            cbx_Cargo.Name = "cbx_Cargo";
            cbx_Cargo.Size = new Size(170, 28);
            cbx_Cargo.TabIndex = 13;
            cbx_Cargo.SelectedIndexChanged += cbx_Cargo_SelectedIndexChanged;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(341, 330);
            Controls.Add(cbx_Cargo);
            Controls.Add(txt_Total);
            Controls.Add(lbl_Total);
            Controls.Add(btn_Salir);
            Controls.Add(btn_Calcular);
            Controls.Add(btn_Save);
            Controls.Add(txt_Valor);
            Controls.Add(txt_Cantidad);
            Controls.Add(txt_Nombre);
            Controls.Add(lbl_Cant);
            Controls.Add(lbl_Cargo);
            Controls.Add(lbl_Valor);
            Controls.Add(lbl_Nombre);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lbl_Nombre;
        private Label lbl_Valor;
        private Label lbl_Cargo;
        private Label lbl_Cant;
        private TextBox txt_Nombre;
        private TextBox txt_Cantidad;
        private TextBox txt_Valor;
        private Button btn_Save;
        private Button btn_Calcular;
        private Button btn_Salir;
        private TextBox txt_Total;
        private Label lbl_Total;
        private ComboBox cbx_Cargo;
    }
}