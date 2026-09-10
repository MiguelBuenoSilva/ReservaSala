namespace ReservaSala
{
    class Reserva
    {
        public string Responsavel { get; set; }
        public string Sala { get; set; }
        public DateTime Data { get; set; }
        public TimeSpan HorarioInicial { get; set; }
        public TimeSpan HorarioFinal { get; set; }
        public int Participantes { get; set; }
        public string Equipamentos { get; set; }

        public Reserva(string responsavel, string sala, DateTime data,
                       TimeSpan horarioInicial, TimeSpan horarioFinal,
                       int participantes, string equipamentos)
        {
            Responsavel = responsavel;
            Sala = sala;
            Data = data;
            HorarioInicial = horarioInicial;
            HorarioFinal = horarioFinal;
            Participantes = participantes;
            Equipamentos = equipamentos;
        }

        // Mantém compatibilidade com reservas antigas salvas no formato
        // Responsável;Sala;Data;Horário;Duração.
        public Reserva(string responsavel, string sala, DateTime data,
                       TimeSpan horarioInicial, TimeSpan duracao)
            : this(responsavel, sala, data, horarioInicial,
                   horarioInicial + duracao, 0, "Não informado")
        {
        }
    }
}
