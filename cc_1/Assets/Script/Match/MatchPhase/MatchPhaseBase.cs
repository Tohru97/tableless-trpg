using System;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using UnityEditor.PackageManager.Requests;
using UnityEngine;

public abstract class MatchPhaseBase
{
    protected MatchControllerBase _matchController;
    public Action OnRequestNextPhase;

    public MatchPhaseBase(MatchControllerBase matchController)
    {
        _matchController = matchController;
    }

    public void StartPhase()
    {
        ExecutePhase();
    }

    public abstract UniTaskVoid ExecutePhase();

    public void RequestPhaseEnd()
    {
        EndPhase();
    }

    public void EndPhase()
    {
        OnRequestNextPhase?.Invoke();
    }
}