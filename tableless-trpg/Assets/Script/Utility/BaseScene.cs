using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using Cysharp.Threading.Tasks;
using System.Threading;

public abstract class BaseScene : MonoBehaviour
{
    // 씬 진입 시 초기화
    protected virtual void Awake()
    {
        InitializeScene();
    }

    protected virtual void InitializeScene() { }

    // UniTask 기반 씬 로딩 메서드
    public async UniTask LoadSceneAsync(
        string sceneName,
        LoadSceneMode mode = LoadSceneMode.Single,
        IProgress<float> progress = null,
        CancellationToken cancellationToken = default)
    {
        if (string.IsNullOrEmpty(sceneName))
        {
            Debug.LogError("Invalid scene name!");
            return;
        }

        try
        {
            var asyncOp = SceneManager.LoadSceneAsync(sceneName, mode);
            await asyncOp.ToUniTask(
                progress: progress,
                cancellationToken: cancellationToken
            );

            OnSceneEnter(sceneName);
        }
        catch (OperationCanceledException)
        {
            Debug.LogWarning("Scene loading cancelled");
        }
    }

    // 씬 전환 후 처리
    protected virtual void OnSceneEnter(string sceneName)
    {
        Debug.Log($"Entered scene: {sceneName}");
        // 여기에 씬별 초기화 코드 작성
    }

    // 씬 종료 시 처리
    protected virtual void OnSceneExit(string sceneName)
    {
        Debug.Log($"Exited scene: {sceneName}");
        // 여기에 리소스 정리 코드 작성
    }

    // 씬 리로드
    public async UniTask ReloadCurrentScene(
        IProgress<float> progress = null,
        CancellationToken cancellationToken = default)
    {
        await LoadSceneAsync(SceneManager.GetActiveScene().name, progress: progress, cancellationToken: cancellationToken);
    }
}
