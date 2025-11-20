using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class LobbyScene : BaseScene
{
    [SerializeField]
    private Button _testButton;

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
        _testButton.onClick.AddListener(() =>
        {
            NetworkController.Instance.JoinMatch();
        });
    }
}
