using Cysharp.Threading.Tasks;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.UI;

public class LobbyScene : BaseScene
{
    [SerializeField]
    private Button _hostButton, _joinButton, _testButton;
    private bool isTurnEnd = true;

    public override eScene GetCurrentSceneType()
    {
        return eScene.LobbyScene;
    }

    public override UniTask LoadAsync()
    {
        return UniTask.CompletedTask;
    }

    public void Start()
    {
        MatchManager.Instance.StartMatch(true);

        _hostButton.onClick.AddListener(() =>
        {
            NetworkController.Instance.StartHost();
        });

        _joinButton.onClick.AddListener(() =>
        {
            NetworkController.Instance.JoinMatch();
        });

        _testButton.onClick.AddListener(() =>
        {
            NetworkController.Instance._localPlayer.TestServerRpc();

            MatchManager.Instance._matchController.RequestTurnEnded(isTurnEnd);

            isTurnEnd = !isTurnEnd;
        });
    }
}