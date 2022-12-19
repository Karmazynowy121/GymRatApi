﻿using GymRatApi.Entieties;

namespace GymRatApi.Commands
{
    public class TrainingPartUpdateCommand
    {
        public int Id { get; set; }
        public int AmountSeries { get; set; }
        public int Reps { get; set; }
        public int BodyWeight { get; set; }
        public int BreakBetweenSeries { get; set; } 
        public int ExerciseId { get; set; }
        public Exercise Exercise { get; set; }
        public int TrainingId { get; set; }
        public Training Training { get; set; }
    }
}