using System;
using UnityEngine;

public abstract class MatchPhase
{
    protected MatchControllerBase _matchController;
    public Action OnRequestNextPhase;

    public MatchPhase(MatchControllerBase matchController)
    {
        _matchController = matchController;
    }

    public void StartPhase()
    {
        ExecutePhase();
    }

    public abstract void ExecutePhase();

    public void RequestPhaseEnd()
    {
        EndPhase();
    }

    public void EndPhase()
    {
        OnRequestNextPhase?.Invoke();
    }
}