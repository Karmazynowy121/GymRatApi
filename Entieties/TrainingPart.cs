﻿namespace GymRatApi.Entieties
{
    public class TrainingPart
    {
        public int Id { get; set; }
        public int AmountSeries {get; set;} 
        public int Reps { get; set;}
        public int BodyWeight {get; set;}
        public int BreakBetweenSeries { get; set; } // MS
        public int ExerciseId { get; set; }
        public Exercise Exercise { get; set; } // wyciskanie na klate 
        public int TrainingId { get; set; }
        public Training Training { get; set; }
    }
}
