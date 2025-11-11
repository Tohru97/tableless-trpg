using System.Collections.Generic;
using System.Threading.Tasks;
using Cysharp.Threading.Tasks;
using UnityEngine;

public abstract class MatchControllerBase : MonoBehaviour
{
    public MatchPhaseBase _currentPhase;
    protected List<MatchPhaseBase> _matchPhaseList = new List<MatchPhaseBase>();

    public Dictionary<int, CharacterBase> _localCharacterDict { get; private set; } = new Dictionary<int, CharacterBase>();
    public Dictionary<int, CharacterBase> _remoteCharacterDict { get; private set; } = new Dictionary<int, CharacterBase>();

    public Deck _localPlayerDeck { get; private set; }
    public Deck _remotePlayerDeck { get; private set; }

    public abstract void SetMatchPhases();

    public void StartMatch()
    {
        ResetInfos();

        SetMatchPhases();
        _currentPhase.StartPhase();
    }

    public void ResetInfos()
    {
        _currentPhase = null;
        _matchPhaseList.Clear();

        _localCharacterDict.Clear();
        _remoteCharacterDict.Clear();

        _localPlayerDeck = new Deck();
        _remotePlayerDeck = new Deck();
    }
    
    public void EndMatch()
    {

    }
}