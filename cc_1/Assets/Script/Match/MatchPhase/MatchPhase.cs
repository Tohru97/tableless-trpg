using System;
using UnityEngine;

public abstract class MatchPhase
{
    protected MatchControllerBase _matchController;
    public bool _isPhaseActive { get; private set; }

    public event Action OnRequestMatchEnd;

    public MatchPhase(MatchControllerBase matchController)
    {
        _matchController = matchController;
    }

    public void StartPhase()
    {
        _isPhaseActive = true;

        ExecutePhase();
    }

    public abstract void ExecutePhase();

    public void EndPhase()
    {
        _isPhaseActive = false;
    }
}