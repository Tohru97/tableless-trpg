using System.Collections.Generic;
using System.Linq;
using Cysharp.Threading.Tasks;
using UnityEngine;

public abstract class MatchControllerBase : MonoBehaviour
{
    public MatchPhaseBase _currentPhase;
    protected List<MatchPhaseBase> _matchPhaseList = new List<MatchPhaseBase>();

    [Header("Character Data")]
    public List<CharacterBase> characterPrefabs;

    private bool _localPlayerTurnEnded;
    private bool _remotePlayerTurnEnded;

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

        _localPlayerTurnEnded = false;
        _remotePlayerTurnEnded = false;
    }

    public void OnPlayerTurnEnded(bool isLocalPlayer, bool isTurnEnded)
    {
        if(isLocalPlayer)
        {
            _localPlayerTurnEnded = isTurnEnded;
        }
        else
        {
            _remotePlayerTurnEnded = isTurnEnded;
        }

        if (_localPlayerTurnEnded && _remotePlayerTurnEnded)
        {
            _currentPhase.RequestPhaseEnd();
        }
    }

    public void SelectCharacter(bool isLocalPlayer, int characterId)
    {
        _currentPhase.OnCharacterSelected(isLocalPlayer, characterId);
    }

    public void EndMatch()
    {
        Debug.Log("===== Match END =====");
    }
}