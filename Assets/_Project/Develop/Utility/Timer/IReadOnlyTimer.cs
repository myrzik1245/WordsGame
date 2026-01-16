
using System;

public interface IReadOnlyTimer
{
    event Action TimeEnded;
    float TimeValue { get; }
}
