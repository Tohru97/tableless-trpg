using System.Collections.Generic;
using System.Threading.Tasks;
using Cysharp.Threading.Tasks;
using UnityEngine;

public abstract class MatchControllerBase : MonoBehaviour
{
    private bool _isMatchOver = false;
    public MatchPhase _currentPhase;
    protected List<MatchPhase> _matchPhaseList = new List<MatchPhase>();

    public List<CardBase> _playerDeck = new List<CardBase>();
    public List<CardBase> _opponentDeck = new List<CardBase>();

    public abstract void SetMatchPhases();

    public void StartMatch()
    {
        _isMatchOver = false;

        SetMatchPhases();
        StartMatchPhaseLoop().Forget();
    }

    private async UniTask StartMatchPhaseLoop()
    {
        while (!_isMatchOver)
        {
            foreach (MatchPhase phase in _matchPhaseList)
            {
                _currentPhase = phase;
                _currentPhase.StartPhase();

                await UniTask.WaitUntil(() => _currentPhase._isPhaseActive == false);

                if (_isMatchOver)
                {
                    EndMatch();

                    break;
                }
            }
        }
    }
    
    private void OnRequestMatchEnd()
    {
        _isMatchOver = true;
    }
    
    public void EndMatch()
    {

    }
}