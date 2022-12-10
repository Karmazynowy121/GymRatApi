using GymRatApi.ContractModules;
using GymRatApi.Entieties;

namespace GymRatApi.Utilis
{
    public static class Extentions
    {
        public static List<TrainingPart> ToTrainigPartList(this List<CreateTrainingPartContract> trainingParts, int trainingId)
        => trainingParts.Select(trainingPart => new TrainingPart()
        {
            TrainingId = trainingId,
            ExerciseId = trainingPart.ExerciseId,
            BodyWeight = trainingPart.BodyWeight,
            AmountSeries = trainingPart.AmountSeries,
            BreakBetweenSeries = trainingPart.BreakBetweenSeries,
            Reps = trainingPart.Reps
        }).ToList();
    }
}
