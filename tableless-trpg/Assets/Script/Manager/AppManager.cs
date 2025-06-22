using Cysharp.Threading.Tasks;
using UnityEngine;

public class AppManager : SingletonMono<AppManager>
{
    public async UniTask Init()
    {
        await CreateManager();
    }

    private UniTask CreateManager()
    {
        Debug.Log("CreateManager");

        return UniTask.CompletedTask;
    }
}