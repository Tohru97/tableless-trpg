using System;
using Cysharp.Threading.Tasks;
using System.Threading;
using UnityEngine;

public static class UniTaskHelper
{
    public static async UniTask Delay(float seconds, Action action = null)
    {
        await UniTask.Delay(TimeSpan.FromSeconds(seconds));
        action?.Invoke();
    }

    public static async UniTask WaitUntil(Func<bool> predicate, Action onComplete = null)
    {
        await UniTask.WaitUntil(predicate);
        onComplete?.Invoke();
    }

    public static async UniTask<bool> WaitUntilWithTimeout(Func<bool> predicate, float timeoutSeconds)
    {
        var timeoutTask = UniTask.Delay(TimeSpan.FromSeconds(timeoutSeconds));
        var waitTask = UniTask.WaitUntil(predicate);

        var completedTask = await UniTask.WhenAny(timeoutTask, waitTask);
        return completedTask == 1;
    }

    public static async UniTask RepeatEvery(float intervalSeconds, Action action, int repeatCount = -1, CancellationToken cancellationToken = default)
    {
        int count = 0;
        while (!cancellationToken.IsCancellationRequested && (repeatCount < 0 || count < repeatCount))
        {
            action?.Invoke();
            count++;
            await UniTask.Delay(TimeSpan.FromSeconds(intervalSeconds), cancellationToken: cancellationToken);
        }
    }

    public static async UniTask DelayUntil(float delaySeconds, Func<bool> predicate, Action onSuccess = null, Action onFail = null, float timeoutSeconds = 5f)
    {
        await UniTask.Delay(TimeSpan.FromSeconds(delaySeconds));

        if (await WaitUntilWithTimeout(predicate, timeoutSeconds))
            onSuccess?.Invoke();
        else
            onFail?.Invoke();
    }
}
