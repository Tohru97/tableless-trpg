using System.Collections.Generic;
using System.Threading.Tasks;
using Cysharp.Threading.Tasks;
using UnityEngine;

public abstract class MatchControllerBase : MonoBehaviour
{
    public MatchPhaseBase _currentPhase;
    protected List<MatchPhaseBase> _matchPhaseList = new List<MatchPhaseBase>();

    public Deck _localPlayerDeck { get; private set; }
    public Deck _remotePlayerDeck { get; private set; }

    public abstract void SetMatchPhases();
    public abstract void RequestTurnEnd();

    public void StartMatch()
    {
        SetMatchPhases();
        _currentPhase.StartPhase();
    }
    
    public void EndMatch()
    {

    }
}