using System.Globalization;

namespace ReservaSala
{
    public partial class frmReserva : Form
    {
        // O documento informa explicitamente capacidade 10 para a sala Osasco,
        // mas não fornece as capacidades das demais salas. Para não inventar
        // capacidades diferentes das especificadas, todas ficam com capacidade 10.
        private readonly Dictionary<string, int> capacidadesSalas = new()
        {
            ["Osasco"] = 10,
            ["Jundiaí"] = 10,
            ["Iguatu"] = 10,
            ["Campos do Jordão"] = 10,
            ["São Caetano"] = 10,
            ["Santo André"] = 10,
            ["São Bernardo do Campo"] = 10
        };

        private string CaminhoArquivoReservas => Path.Combine(AppContext.BaseDirectory, "reservas.txt");

        public frmReserva()
        {
            InitializeComponent();
            ConfigurarTela();
        }

        private void ConfigurarTela()
        {
            dtpData.MinDate = DateTime.Today;
            dtpData.MaxDate = new DateTime(2099, 12, 31);
            dtpData.Value = DateTime.Today;

            cmbHorario.SelectedIndex = -1;
            cmbHorarioFinal.SelectedIndex = -1;
            cmbSala.SelectedIndex = -1;
            cmbHorarioFinal.SelectedIndexChanged += cmbHorarioFinal_SelectedIndexChanged;
            cmbSala.SelectedIndexChanged += cmbSala_SelectedIndexChanged;

            AtualizarInformacoesSala();
        }

        private void btnReservar_Click(object sender, EventArgs e)
        {
            var camposFaltantes = new List<string>();

            if (string.IsNullOrWhiteSpace(txtNome.Text))
                camposFaltantes.Add("Responsável");

            if (cmbSala.SelectedIndex < 0)
                camposFaltantes.Add("Sala");

            if (dtpData.Value.Date < DateTime.Today)
                camposFaltantes.Add("Data válida");

            if (cmbHorario.SelectedIndex < 0)
                camposFaltantes.Add("Horário inicial");

            if (cmbHorarioFinal.SelectedIndex < 0)
                camposFaltantes.Add("Horário final");

            if (numParticipantes.Value < 1)
                camposFaltantes.Add("Quantidade de participantes");

            if (camposFaltantes.Count > 0)
            {
                MessageBox.Show(
                    "Preencha os seguintes campos obrigatórios:\n- " +
                    string.Join("\n- ", camposFaltantes),
                    "Campos obrigatórios",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            if (!ValidarLetras(txtNome.Text.Trim()))
            {
                MessageBox.Show(
                    "Não é permitido digitar números ou caracteres especiais no campo responsável.",
                    "Responsável inválido",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            TimeSpan horarioInicial = TimeSpan.Parse(cmbHorario.Text);
            TimeSpan horarioFinal = TimeSpan.Parse(cmbHorarioFinal.Text);

            // CA04: o horário inicial precisa ser anterior ao horário final.
            if (horarioInicial >= horarioFinal)
            {
                MessageBox.Show(
                    "O horário inicial deve ser anterior ao horário final.",
                    "Horário inválido",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            TimeSpan duracao = horarioFinal - horarioInicial;

            // CA08: máximo de 4 horas, sendo exatamente 4h permitido.
            if (duracao > TimeSpan.FromHours(4))
            {
                MessageBox.Show(
                    "A duração da reserva não pode ser superior a 4 horas.",
                    "Duração inválida",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            // CA03: para hoje, início precisa estar pelo menos 1 hora à frente.
            if (dtpData.Value.Date == DateTime.Today &&
                horarioInicial < DateTime.Now.TimeOfDay.Add(TimeSpan.FromHours(1)))
            {
                MessageBox.Show(
                    "Para reservas na data de hoje, o horário inicial deve ser pelo menos 1 hora posterior ao momento da solicitação.",
                    "Antecedência insuficiente",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            int participantes = (int)numParticipantes.Value;
            int capacidade = capacidadesSalas[cmbSala.Text];

            // CA05: participantes não podem ultrapassar a capacidade da sala.
            if (participantes > capacidade)
            {
                MessageBox.Show(
                    $"A sala {cmbSala.Text} comporta no máximo {capacidade} participantes.",
                    "Capacidade excedida",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            string equipamentos = ObterEquipamentosSelecionados();

            Reserva reserva = new Reserva(
                txtNome.Text.Trim(),
                cmbSala.Text,
                dtpData.Value.Date,
                horarioInicial,
                horarioFinal,
                participantes,
                equipamentos);

            // CA06 e CA07: verifica conflito permitindo início exatamente
            // no horário de término da reserva anterior.
            if (VerificarConflito(reserva))
            {
                MessageBox.Show(
                    "A sala já está reservada neste período. Escolha outro horário.",
                    "Conflito de horário",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            SalvarReserva(reserva);
            MessageBox.Show(
                "Reserva realizada com sucesso!",
                "Reserva",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            MostrarReservasNaTela();
        }

        private Reserva CriarReserva()
        {
            TimeSpan horarioInicial = TimeSpan.Parse(cmbHorario.Text);
            TimeSpan horarioFinal = TimeSpan.Parse(cmbHorarioFinal.Text);

            return new Reserva(
                txtNome.Text.Trim(),
                cmbSala.Text,
                dtpData.Value.Date,
                horarioInicial,
                horarioFinal,
                (int)numParticipantes.Value,
                ObterEquipamentosSelecionados());
        }

        private void SalvarReserva(Reserva reserva)
        {
            string linha = string.Join(";", new[]
            {
                reserva.Responsavel,
                reserva.Sala,
                reserva.Data.ToString("dd/MM/yyyy"),
                reserva.HorarioInicial.ToString(@"hh\:mm"),
                reserva.HorarioFinal.ToString(@"hh\:mm"),
                reserva.Participantes.ToString(CultureInfo.InvariantCulture),
                reserva.Equipamentos
            });

            File.AppendAllText(CaminhoArquivoReservas, linha + Environment.NewLine);
        }

        private List<Reserva> CarregarReservas()
        {
            var reservas = new List<Reserva>();

            if (!File.Exists(CaminhoArquivoReservas))
                return reservas;

            foreach (var linha in File.ReadAllLines(CaminhoArquivoReservas))
            {
                if (string.IsNullOrWhiteSpace(linha))
                    continue;

                var dados = linha.Split(';');

                if (dados.Length < 5)
                    continue;

                if (!DateTime.TryParseExact(
                        dados[2].Trim(),
                        "dd/MM/yyyy",
                        CultureInfo.InvariantCulture,
                        DateTimeStyles.None,
                        out DateTime data))
                    continue;

                if (!TimeSpan.TryParse(dados[3].Trim(), out TimeSpan horarioInicial))
                    continue;

                // Novo formato: horário inicial + horário final + participantes + equipamentos.
                if (dados.Length >= 7 && TimeSpan.TryParse(dados[4].Trim(), out TimeSpan horarioFinal))
                {
                    int participantes = 0;
                    int.TryParse(dados[5].Trim(), NumberStyles.Integer,
                        CultureInfo.InvariantCulture, out participantes);

                    string equipamentos = string.IsNullOrWhiteSpace(dados[6])
                        ? "Nenhum"
                        : dados[6].Trim();

                    reservas.Add(new Reserva(
                        dados[0].Trim(),
                        dados[1].Trim(),
                        data,
                        horarioInicial,
                        horarioFinal,
                        participantes,
                        equipamentos));

                    continue;
                }

                // Formato antigo: o quinto campo era a duração.
                if (TimeSpan.TryParse(dados[4].Trim(), out TimeSpan duracao))
                {
                    reservas.Add(new Reserva(
                        dados[0].Trim(),
                        dados[1].Trim(),
                        data,
                        horarioInicial,
                        duracao));
                }
            }

            return reservas;
        }

        private bool VerificarConflito(Reserva novaReserva)
        {
            List<Reserva> reservas = CarregarReservas();

            foreach (Reserva reserva in reservas)
            {
                if (!string.Equals(reserva.Sala, novaReserva.Sala, StringComparison.OrdinalIgnoreCase) ||
                    reserva.Data.Date != novaReserva.Data.Date)
                    continue;

                // Dois intervalos entram em conflito somente quando um começa
                // antes do término do outro e termina depois do início do outro.
                // Assim, 14:00-16:00 e 16:00-18:00 são permitidos (CA07).
                if (novaReserva.HorarioInicial < reserva.HorarioFinal &&
                    reserva.HorarioInicial < novaReserva.HorarioFinal)
                {
                    return true;
                }
            }

            return false;
        }

        private void btnMostrar_Click(object sender, EventArgs e)
        {
            MostrarReservasNaTela();
        }

        private void MostrarReservasNaTela()
        {
            var reservas = CarregarReservas()
                .OrderBy(r => r.Data)
                .ThenBy(r => r.HorarioInicial)
                .ToList();

            if (reservas.Count == 0)
            {
                txtReservas.Text = "Nenhuma reserva cadastrada.";
                return;
            }

            var texto = new System.Text.StringBuilder();
            texto.AppendLine($"RESERVAS CADASTRADAS: {reservas.Count}");
            texto.AppendLine(new string('-', 65));

            for (int i = 0; i < reservas.Count; i++)
            {
                Reserva r = reservas[i];
                TimeSpan duracao = r.HorarioFinal - r.HorarioInicial;

                texto.AppendLine($"Reserva {i + 1}");
                texto.AppendLine($"Responsável: {r.Responsavel}");
                texto.AppendLine($"Sala: {r.Sala}");
                texto.AppendLine($"Data: {r.Data:dd/MM/yyyy}");
                texto.AppendLine($"Horário: {r.HorarioInicial:hh\\:mm} às {r.HorarioFinal:hh\\:mm}");
                texto.AppendLine($"Duração: {duracao:hh\\:mm}");
                texto.AppendLine($"Participantes: {(r.Participantes > 0 ? r.Participantes.ToString() : "Não informado (reserva antiga)")}");
                texto.AppendLine($"Equipamentos: {r.Equipamentos}");
                texto.AppendLine(new string('-', 65));
            }

            txtReservas.Text = texto.ToString();
            txtReservas.SelectionStart = 0;
            txtReservas.SelectionLength = 0;
        }

        private string ObterEquipamentosSelecionados()
        {
            if (ClbItens.CheckedItems.Count == 0)
                return "Nenhum";

            return string.Join(", ", ClbItens.CheckedItems.Cast<object>());
        }

        private void cmbSala_SelectedIndexChanged(object? sender, EventArgs e)
        {
            AtualizarInformacoesSala();
        }

        private void AtualizarInformacoesSala()
        {
            if (cmbSala.SelectedIndex < 0)
            {
                lblInfoSala.Text = "Selecione uma sala para ver a capacidade.";
                return;
            }

            int capacidade = capacidadesSalas[cmbSala.Text];
            lblInfoSala.Text = $"Capacidade máxima: {capacidade} participantes";
        }

        private void cmbHorarioFinal_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (cmbHorario.SelectedIndex < 0 || cmbHorarioFinal.SelectedIndex < 0)
                return;

            TimeSpan inicio = TimeSpan.Parse(cmbHorario.Text);
            TimeSpan fim = TimeSpan.Parse(cmbHorarioFinal.Text);

            if (fim > inicio && fim - inicio > TimeSpan.FromHours(4))
            {
                lblAvisoHorario.Text = "A duração máxima permitida é de 4 horas.";
            }
            else
            {
                lblAvisoHorario.Text = "";
            }
        }

        private bool ValidarLetras(string input)
        {
            foreach (char c in input)
            {
                if (!char.IsLetter(c) && !char.IsWhiteSpace(c))
                    return false;
            }

            return input.Length > 0;
        }
    }
}
