using System;
using UnityEngine;

public class MaxScore : ScoreCounter
{
    [SerializeField] private ScoreCounter _counter;

    private void OnEnable()
    {
        _counter.Changed += SetValue;
    }

    private void OnDisable()
    {
        _counter.Changed -= SetValue;
    }

    private void SetValue(int value)
    {
        if (value > Value)
            Value = value;
    }
}
