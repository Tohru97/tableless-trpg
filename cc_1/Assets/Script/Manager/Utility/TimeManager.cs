using System;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class TimeManager : SingletonMono<TimeManager>, IInitializable
{
    public class Timer
    {
        public int timerID;
        public float duration;
        public float currentTime;
        public Action onTimerEnd;
        public bool isFinished; // Add a flag to indicate if the timer is finished

        public Timer(int id, float duration, Action onEnd)
        {
            timerID = id;
            this.duration = duration;
            currentTime = 0f;
            onTimerEnd = onEnd;
            isFinished = false; // Initialize to false
        }

        public bool UpdateTime()
        {
            if (isFinished)
                return true;

            currentTime += Time.deltaTime;

            if (currentTime >= duration)
            {
                onTimerEnd?.Invoke();
                isFinished = true;
                return true;
            }

            return false;
        }
    }

    private Dictionary<int, Timer> _timerTable = new Dictionary<int, Timer>();
    private List<int> _endTimerList = new List<int>();
    private int _timerIndex = 0;

    public UniTask InitializeAsync()
    {
        Debug.Log("TimeManager initialization started.");

        // Simulate some asynchronous initialization work
        return UniTask.CompletedTask;
    }

    public int SetTimer(float duration, Action onTimerEnd)
    {
        if(_timerIndex >= int.MaxValue)
            _timerIndex = 0;

        _timerIndex++;

        _timerTable.Add(_timerIndex, new Timer(_timerIndex, duration, onTimerEnd));

        return _timerIndex;
    }

    public void RemoveTimer(int timerID)
    {
        if (_timerTable.ContainsKey(timerID))
        {
            _endTimerList.Add(timerID);
        }
    }

    public void LateUpdate()
    {
        foreach(KeyValuePair<int, Timer> pair in _timerTable)
        {
            if (!_endTimerList.Contains(pair.Key) && pair.Value.UpdateTime())
            {
                _endTimerList.Add(pair.Key);
            }
        }

        if(_endTimerList.Count > 0)
        {
            foreach (int timerID in _endTimerList)
            {
                _timerTable.Remove(timerID);
            }

            _endTimerList.Clear();   
        }
    }
}
