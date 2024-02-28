using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace EdgeRunner
{
    public class EventController 
    {
        public event Action baseEvent;

        public void InvokeEvent() => baseEvent?.Invoke();

        public void Addlistener(Action listener) => baseEvent += listener;

        public void RemoveListener(Action listener) => baseEvent -= listener;
    }
}