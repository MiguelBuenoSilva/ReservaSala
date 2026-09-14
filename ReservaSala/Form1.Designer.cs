namespace ReservaSala
{
    partial class frmReserva
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            lblNome = new Label();
            lblSala = new Label();
            lblData = new Label();
            lblHorario = new Label();
            lblHorarioFinal = new Label();
            btnReservar = new Button();
            txtNome = new TextBox();
            dtpData = new DateTimePicker();
            cmbSala = new ComboBox();
            cmbHorario = new ComboBox();
            cmbHorarioFinal = new ComboBox();
            btnMostrar = new Button();
            txtReservas = new TextBox();
            numParticipantes = new NumericUpDown();
            LblParticipantes = new Label();
            ClbItens = new CheckedListBox();
            LblItens = new Label();
            lblInfoSala = new Label();
            lblAvisoHorario = new Label();
            ((System.ComponentModel.ISupportInitialize)numParticipantes).BeginInit();
            SuspendLayout();
            // 
            // lblNome
            // 
            lblNome.AutoSize = true;
            lblNome.Location = new Point(30, 18);
            lblNome.Name = "lblNome";
            lblNome.Size = new Size(75, 15);
            lblNome.TabIndex = 18;
            lblNome.Text = "Responsável:";
            // 
            // lblSala
            // 
            lblSala.AutoSize = true;
            lblSala.Location = new Point(58, 59);
            lblSala.Name = "lblSala";
            lblSala.Size = new Size(31, 15);
            lblSala.TabIndex = 17;
            lblSala.Text = "Sala:";
            // 
            // lblData
            // 
            lblData.AutoSize = true;
            lblData.Location = new Point(57, 106);
            lblData.Name = "lblData";
            lblData.Size = new Size(34, 15);
            lblData.TabIndex = 16;
            lblData.Text = "Data:";
            // 
            // lblHorario
            // 
            lblHorario.AutoSize = true;
            lblHorario.Location = new Point(18, 152);
            lblHorario.Name = "lblHorario";
            lblHorario.Size = new Size(84, 15);
            lblHorario.TabIndex = 15;
            lblHorario.Text = "Horário inicial:";
            // 
            // lblHorarioFinal
            // 
            lblHorarioFinal.AutoSize = true;
            lblHorarioFinal.Location = new Point(18, 200);
            lblHorarioFinal.Name = "lblHorarioFinal";
            lblHorarioFinal.Size = new Size(76, 15);
            lblHorarioFinal.TabIndex = 14;
            lblHorarioFinal.Text = "Horário final:";
            // 
            // btnReservar
            // 
            btnReservar.Location = new Point(101, 402);
            btnReservar.Name = "btnReservar";
            btnReservar.Size = new Size(200, 30);
            btnReservar.TabIndex = 7;
            btnReservar.Text = "Reservar";
            btnReservar.UseVisualStyleBackColor = true;
            btnReservar.Click += btnReservar_Click;
            // 
            // txtNome
            // 
            txtNome.Location = new Point(101, 15);
            txtNome.Name = "txtNome";
            txtNome.Size = new Size(200, 23);
            txtNome.TabIndex = 0;
            // 
            // dtpData
            // 
            dtpData.Format = DateTimePickerFormat.Short;
            dtpData.Location = new Point(101, 103);
            dtpData.Name = "dtpData";
            dtpData.Size = new Size(200, 23);
            dtpData.TabIndex = 2;
            // 
            // cmbSala
            // 
            cmbSala.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbSala.FormattingEnabled = true;
            cmbSala.Items.AddRange(new object[] { "Osasco", "Jundiaí", "Iguatu", "Campos do Jordão", "São Caetano", "Santo André", "São Bernardo do Campo" });
            cmbSala.Location = new Point(101, 56);
            cmbSala.Name = "cmbSala";
            cmbSala.Size = new Size(200, 23);
            cmbSala.TabIndex = 1;
            // 
            // cmbHorario
            // 
            cmbHorario.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbHorario.FormattingEnabled = true;
            cmbHorario.Items.AddRange(new object[] { "00:00", "00:30", "01:00", "01:30", "02:00", "02:30", "03:00", "03:30", "04:00", "04:30", "05:00", "05:30", "06:00", "06:30", "07:00", "07:30", "08:00", "08:30", "09:00", "09:30", "10:00", "10:30", "11:00", "11:30", "12:00", "12:30", "13:00", "13:30", "14:00", "14:30", "15:00", "15:30", "16:00", "16:30", "17:00", "17:30", "18:00", "18:30", "19:00", "19:30", "20:00", "20:30", "21:00", "21:30", "22:00", "22:30", "23:00", "23:30" });
            cmbHorario.Location = new Point(101, 149);
            cmbHorario.Name = "cmbHorario";
            cmbHorario.Size = new Size(200, 23);
            cmbHorario.TabIndex = 3;
            // 
            // cmbHorarioFinal
            // 
            cmbHorarioFinal.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbHorarioFinal.FormattingEnabled = true;
            cmbHorarioFinal.Items.AddRange(new object[] { "00:00", "00:30", "01:00", "01:30", "02:00", "02:30", "03:00", "03:30", "04:00", "04:30", "05:00", "05:30", "06:00", "06:30", "07:00", "07:30", "08:00", "08:30", "09:00", "09:30", "10:00", "10:30", "11:00", "11:30", "12:00", "12:30", "13:00", "13:30", "14:00", "14:30", "15:00", "15:30", "16:00", "16:30", "17:00", "17:30", "18:00", "18:30", "19:00", "19:30", "20:00", "20:30", "21:00", "21:30", "22:00", "22:30", "23:00", "23:30" });
            cmbHorarioFinal.Location = new Point(101, 197);
            cmbHorarioFinal.Name = "cmbHorarioFinal";
            cmbHorarioFinal.Size = new Size(200, 23);
            cmbHorarioFinal.TabIndex = 4;
            // 
            // btnMostrar
            // 
            btnMostrar.Location = new Point(101, 438);
            btnMostrar.Name = "btnMostrar";
            btnMostrar.Size = new Size(200, 30);
            btnMostrar.TabIndex = 8;
            btnMostrar.Text = "Mostrar reservas";
            btnMostrar.UseVisualStyleBackColor = true;
            btnMostrar.Click += btnMostrar_Click;
            // 
            // txtReservas
            // 
            txtReservas.BackColor = SystemColors.Window;
            txtReservas.Location = new Point(350, 15);
            txtReservas.Multiline = true;
            txtReservas.Name = "txtReservas";
            txtReservas.ReadOnly = true;
            txtReservas.ScrollBars = ScrollBars.Vertical;
            txtReservas.Size = new Size(620, 453);
            txtReservas.TabIndex = 9;
            // 
            // numParticipantes
            // 
            numParticipantes.Location = new Point(111, 247);
            numParticipantes.Maximum = new decimal(new int[] { 10, 0, 0, 0 });
            numParticipantes.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numParticipantes.Name = "numParticipantes";
            numParticipantes.ReadOnly = true;
            numParticipantes.Size = new Size(190, 23);
            numParticipantes.TabIndex = 5;
            numParticipantes.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // LblParticipantes
            // 
            LblParticipantes.AutoSize = true;
            LblParticipantes.Location = new Point(18, 250);
            LblParticipantes.Name = "LblParticipantes";
            LblParticipantes.Size = new Size(78, 15);
            LblParticipantes.TabIndex = 11;
            LblParticipantes.Text = "Participantes:";
            // 
            // ClbItens
            // 
            ClbItens.FormattingEnabled = true;
            ClbItens.Items.AddRange(new object[] { "Controle Ar-Condicionado", "Cadeiras ergonômicas", "Internet Wi-Fi", "Quadro branco", "Passador de Slide", "Projetor", "Papelaria", "Mesa de Escritório 10 Lugares", "Móvel de apoio", "Notebook", "", "", "" });
            ClbItens.Location = new Point(101, 287);
            ClbItens.Name = "ClbItens";
            ClbItens.Size = new Size(200, 94);
            ClbItens.TabIndex = 6;
            // 
            // LblItens
            // 
            LblItens.AutoSize = true;
            LblItens.Location = new Point(34, 290);
            LblItens.Name = "LblItens";
            LblItens.Size = new Size(35, 15);
            LblItens.TabIndex = 10;
            LblItens.Text = "Itens:";
            // 
            // lblInfoSala
            // 
            lblInfoSala.AutoSize = true;
            lblInfoSala.Location = new Point(101, 82);
            lblInfoSala.Name = "lblInfoSala";
            lblInfoSala.Size = new Size(227, 15);
            lblInfoSala.TabIndex = 13;
            lblInfoSala.Text = "Selecione uma sala para ver a capacidade.";
            // 
            // lblAvisoHorario
            // 
            lblAvisoHorario.AutoSize = true;
            lblAvisoHorario.Location = new Point(101, 223);
            lblAvisoHorario.Name = "lblAvisoHorario";
            lblAvisoHorario.Size = new Size(0, 15);
            lblAvisoHorario.TabIndex = 12;
            // 
            // frmReserva
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1000, 500);
            Controls.Add(txtReservas);
            Controls.Add(btnMostrar);
            Controls.Add(btnReservar);
            Controls.Add(ClbItens);
            Controls.Add(LblItens);
            Controls.Add(numParticipantes);
            Controls.Add(LblParticipantes);
            Controls.Add(lblAvisoHorario);
            Controls.Add(cmbHorarioFinal);
            Controls.Add(cmbHorario);
            Controls.Add(dtpData);
            Controls.Add(lblInfoSala);
            Controls.Add(cmbSala);
            Controls.Add(txtNome);
            Controls.Add(lblHorarioFinal);
            Controls.Add(lblHorario);
            Controls.Add(lblData);
            Controls.Add(lblSala);
            Controls.Add(lblNome);
            Name = "frmReserva";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Reserva de Sala";
            ((System.ComponentModel.ISupportInitialize)numParticipantes).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private static object[] GerarHorarios()
        {
            var horarios = new List<string>();
            for (int hora = 0; hora < 24; hora++)
            {
                horarios.Add($"{hora:00}:00");
                horarios.Add($"{hora:00}:30");
            }
            return horarios.ToArray();
        }

        #endregion

        private Label lblNome;
        private Label lblSala;
        private Label lblData;
        private Label lblHorario;
        private Label lblHorarioFinal;
        private Button btnReservar;
        private TextBox txtNome;
        private DateTimePicker dtpData;
        private ComboBox cmbSala;
        private ComboBox cmbHorario;
        private ComboBox cmbHorarioFinal;
        private Button btnMostrar;
        private TextBox txtReservas;
        private NumericUpDown numParticipantes;
        private Label LblParticipantes;
        private CheckedListBox ClbItens;
        private Label LblItens;
        private Label lblInfoSala;
        private Label lblAvisoHorario;
    }
}
