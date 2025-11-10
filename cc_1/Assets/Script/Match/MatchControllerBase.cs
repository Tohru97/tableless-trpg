using System.Collections.Generic;
using System.Threading.Tasks;
using Cysharp.Threading.Tasks;
using UnityEngine;

public abstract class MatchControllerBase : MonoBehaviour
{
    public MatchPhase _currentPhase;
    protected List<MatchPhase> _matchPhaseList = new List<MatchPhase>();

    public Deck _localPlayerDeck { get; private set; }
    public Deck _remotePlayerDeck { get; private set; }

    public abstract void SetMatchPhases();

    public void StartMatch()
    {
        SetMatchPhases();
        _currentPhase.StartPhase();
    }
    
    public void EndMatch()
    {

    }
}