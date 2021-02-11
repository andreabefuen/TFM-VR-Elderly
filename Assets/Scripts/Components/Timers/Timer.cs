using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Utils
{
    public class Timer
    {
        public float RemainingTime { get; private set; }
        public Timer(float duration)
        {
            RemainingTime = duration;
        }
        public event Action OnTimerEnd;
        public event Action<float> OnTimerUpdate;
        public void Tick(float deltaTime)
        {
            if(RemainingTime == 0f) { return; }
            RemainingTime -= deltaTime;
            CheckForTimerEnd();
            UpdateTimer();
        }

        public void UpdateTimer()
        {
            OnTimerUpdate?.Invoke(RemainingTime);
        }
        private void CheckForTimerEnd()
        {
            if(RemainingTime > 0f) { return; }
            RemainingTime = 0f;
            OnTimerEnd?.Invoke();
        }
    }

}