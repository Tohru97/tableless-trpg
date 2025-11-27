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

    public Dictionary<int, CharacterBase> _localCharacterDic { get; private set; } = new Dictionary<int, CharacterBase>();
    public Dictionary<int, CharacterBase> _remoteCharacterDic { get; private set; } = new Dictionary<int, CharacterBase>();

    public Deck _localPlayerDeck { get; private set; }
    public Deck _remotePlayerDeck { get; private set; }

    private int _timerID = 0;

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

        _localCharacterDic.Clear();
        _remoteCharacterDic.Clear();

        _localPlayerDeck = new Deck();
        _remotePlayerDeck = new Deck();

        _localPlayerTurnEnded = false;
        _remotePlayerTurnEnded = false;
    }

    public void StartTurnEndTimer(float duration)
    {
        _timerID = TimeManager.Instance.SetTimer(duration, OnDoneTurnEndTimer);
    }

    private void OnDoneTurnEndTimer()
    {
        // Set Local Player Active Block

        TimeManager.Instance.RemoveTimer(_timerID);
    }

    #region Server Communication Methods

    public void RequestTurnEnded(bool isTurnEnded)
    {
        // Request local player turn end
        NetworkController.Instance._localPlayer.RequestTurnEndedServerRpc(isTurnEnded);
    }

    public void ResponseTurnEnded(bool isLocalPlayer, bool isTurnEnded)
    {
        if(isLocalPlayer)
        {
            _localPlayerTurnEnded = isTurnEnded;

            // Local Turn End UI Change
        }
        else
        {
            _remotePlayerTurnEnded = isTurnEnded;
        }

        if (_localPlayerTurnEnded && _remotePlayerTurnEnded)
        {
            OnDoneTurnEndTimer();

            _localPlayerTurnEnded = false;
            _remotePlayerTurnEnded = false;

            _currentPhase.RequestPhaseEnd();
        }
    }

    #endregion

    public bool IsLocalPlayerCanAct()
    {
        // Check Local Player Do Anything Possible

        return !_localPlayerTurnEnded;
    }

    #region Match Phase Control Methods

    public void SelectCharacter(bool isLocalPlayer, int characterId)
    {
        _currentPhase.OnCharacterSelected(isLocalPlayer, characterId);
    }

    #endregion

    public void EndMatch()
    {
        Debug.Log("===== Match END =====");
    }
}