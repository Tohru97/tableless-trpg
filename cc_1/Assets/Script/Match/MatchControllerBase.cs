using System.Collections.Generic;
using System.Threading.Tasks;
using Cysharp.Threading.Tasks;
using UnityEngine;

public abstract class MatchControllerBase : MonoBehaviour
{
    public MatchPhase _currentPhase;
    protected List<MatchPhase> _matchPhaseList = new List<MatchPhase>();

    public Deck _playerDeck { get; private set; }
    public Deck _opponentDeck { get; private set; }

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