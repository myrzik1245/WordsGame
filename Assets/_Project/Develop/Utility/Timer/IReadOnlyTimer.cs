using System;

namespace Assets._Project.Develop.Utility.Timer
{
    public interface IReadOnlyTimer
    {
        event Action TimeEnded;
        float TimeValue { get; }
    }
}