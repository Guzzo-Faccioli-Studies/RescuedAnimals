﻿namespace RescuedAnimals.Model
{
    public class ApplicationResult<T> : ApplicationResult
    {
        public T? Result { get; set; }
    }

    public class ApplicationResult
    {
        public List<string> Errors { get; set; } = new();

        public bool IsError => Errors.Any();

        public bool IsSuccess => !IsError;
    }
}