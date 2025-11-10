using System;
using DG.Tweening;
using UnityEditor.PackageManager.Requests;
using UnityEngine;

public abstract class MatchPhaseBase
{
    protected MatchControllerBase _matchController;
    public Action OnRequestNextPhase;

    protected float _phaseEndTime = 30f;
    protected int _phaseTimerID = 0;

    public MatchPhaseBase(MatchControllerBase matchController)
    {
        _matchController = matchController;
    }

    public void StartPhase()
    {
        ExecutePhase();
        _phaseTimerID = TimeManager.Instance.SetTimer(_phaseEndTime, RequestPhaseEnd);
    }

    public abstract void ExecutePhase();

    public void RequestPhaseEnd()
    {
        TimeManager.Instance.RemoveTimer(_phaseTimerID);
        _phaseTimerID = 0;

        EndPhase();
    }

    public void EndPhase()
    {
        OnRequestNextPhase?.Invoke();
    }
}