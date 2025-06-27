using System;
using UnityEngine;

public class ScoreCounter : MonoBehaviour
{
    public virtual event Action<int> Changed;

    public int Value { get; protected set; }

    public void Reset()
    {
        Value = 0;
        Changed?.Invoke(Value);
    }

    public void Add()
    {
        Changed?.Invoke(++Value);
    }
}
