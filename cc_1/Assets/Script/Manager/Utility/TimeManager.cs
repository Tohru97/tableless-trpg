using System;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using UnityEngine;

public class TimeManager : Singleton<TimeManager>, IInitializable
{
    public class Timer
    {
        public int timerID;
        public float duration;
        public float currentTime;
        public Action onTimerEnd;

        public Timer(int id, float duration, Action onEnd)
        {
            timerID = id;
            this.duration = duration;
            currentTime = 0f;
            onTimerEnd = onEnd;
        }

        public void UpdateTime()
        {
            currentTime += Time.deltaTime;
            if (currentTime >= duration)
            {
                onTimerEnd?.Invoke();
            }
        }
    }

    private Dictionary<int, Timer> _timerTable = new Dictionary<int, Timer>();
    private int _timerIndex = 0;

    public UniTask InitializeAsync()
    {
        Debug.Log("TimeManager initialization started.");

        // Simulate some asynchronous initialization work
        return UniTask.CompletedTask;
    }

    public int SetTimer(float duration, Action onTimerEnd)
    {
        _timerIndex++;

        _timerTable.Add(_timerIndex, new Timer(_timerIndex, duration, onTimerEnd));

        return _timerIndex;
    }

    public void Update()
    {
        foreach(KeyValuePair<int, Timer> pair in _timerTable)
        {
            pair.Value.UpdateTime();
        }
    }
}
