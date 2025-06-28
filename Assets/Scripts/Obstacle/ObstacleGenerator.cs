using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public abstract class ObstacleGenerator<T> : MonoBehaviour where T : Obstacle
{
    [SerializeField] private T _prefab;
    [SerializeField] private int _defaultCapacity;
    [SerializeField] private int _maxSize;
    [SerializeField] protected Transform Container;

    protected ObjectPool<T> Pool;
    private List<T> _gettedObjects;

    private void Awake()
    {
        _gettedObjects = new List<T>();
        Pool = new ObjectPool<T>(
            createFunc: () => OnActionCreate(),
            actionOnGet: (obj) => OnActionGet(obj),
            actionOnRelease: (obj) => OnActionRelease(obj),
            actionOnDestroy: (obj) => OnActionDestroy(obj),
            maxSize: _maxSize,
            defaultCapacity: _defaultCapacity
        );
    }

    public void PutObject(T obj)
    {
        Pool.Release(obj);
    }

    public virtual void Reset()
    {
        T[] tempArray = _gettedObjects.ToArray();

        foreach (T obj in tempArray)
            Pool.Release(obj);
    }

    private T OnActionCreate()
    {
        return Instantiate(_prefab);
    }

    private void OnActionGet(T obj)
    {
        obj.transform.parent = Container;
        obj.gameObject.SetActive(true);
        _gettedObjects.Add(obj);
    }

    private void OnActionRelease(T obj)
    {
        obj.gameObject.SetActive(false);
        _gettedObjects.Remove(obj);
    }

    private void OnActionDestroy(T obj) 
    {
        Destroy(obj);
    }
}
