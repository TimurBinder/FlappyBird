using System;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public abstract class ObstacleRemover<T> : MonoBehaviour where T : Obstacle
{
    [SerializeField] private ObstacleGenerator<T> _generator;

    public event Action Removed;

    private void OnValidate()
    {
        GetComponent<Collider2D>().isTrigger = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out T obj))
        {
            _generator.PutObject(obj);
            Removed?.Invoke();
        }
    }
}
