﻿using GymRatApi.Commands.TrainingCommands;
using GymRatApi.Dto;

namespace GymRatApi.Services
{
    public interface ITrainingService
    {
        Task <TrainingDto> Create(TrainingCreateCommand trainingCreateCommand);
        Task<List<TrainingDto>> GetAll();
        Task<TrainingDto> GetById(int id);
        Task Update(TrainingUpdateCommand trainingUpdateCommand);
    }
}
