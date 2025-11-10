using System;
using DG.Tweening;
using UnityEngine;

public abstract class MatchPhase
{
    protected MatchControllerBase _matchController;
    public Action OnRequestNextPhase;

    protected float _phaseEndTime = 30f;
    protected int _phaseTimerID = 0;

    public MatchPhase(MatchControllerBase matchController)
    {
        _matchController = matchController;
    }

    public void StartPhase()
    {
        ExecutePhase();

        _phaseTimerID = TimeManager.Instance.SetTimer(_phaseEndTime, PhaseTimerEnd);
    }

    private void PhaseTimerEnd()
    {
        
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