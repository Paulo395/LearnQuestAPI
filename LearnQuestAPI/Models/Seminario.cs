﻿namespace LearnQuestAPI.Models
{
    public class Seminario
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public string LinkVideo { get; set; }
        public int? TurmaId { get; set; }

    }
}
