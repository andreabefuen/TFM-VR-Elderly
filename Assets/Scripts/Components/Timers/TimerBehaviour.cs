using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Utils
{
    [Serializable]
    public class TimerBehaviour : MonoBehaviour
    {
        [SerializeField] private float duration = 1f;
        [SerializeField] private UnityEvent onTimerEnd = null;
        [SerializeField] private UnityEvent<float> onTimerUpdate = null;        

        private Timer timer;

        void Start()
        {
            timer = new Timer(duration);

            timer.OnTimerEnd += HandleTimerEnd;
            timer.OnTimerUpdate += HandleTimerUpdate;
        }

        private void HandleTimerEnd()
        {
            onTimerEnd.Invoke();
            Destroy(this);
        }

        private void HandleTimerUpdate(float remainingTime)
        {
            onTimerUpdate.Invoke(remainingTime);
        }

        void Update()
        {
            timer.Tick(Time.deltaTime);
        }
    }

}
