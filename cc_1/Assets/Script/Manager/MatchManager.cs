using Cysharp.Threading.Tasks;
using UnityEngine;

public class MatchManager : Singleton<MatchManager>, IInitializable
{
    public MatchControllerBase _matchController { get; private set; } = null;

    public UniTask InitializeAsync()
    {
        Debug.Log("MatchManager Initialized.");
        return UniTask.CompletedTask;
    }

    public void StartMatch(bool isPVE)
    {
        if (isPVE)
            _matchController = new PveMatchController();
        else
            _matchController = new PvpMatchController();

        _matchController.StartMatch();
    }

    public void EndMatch()
    {
        
    }
}
