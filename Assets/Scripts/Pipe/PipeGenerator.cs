using System.Collections;
using UnityEngine;

public class PipeGenerator : ObstacleGenerator<Pipe>
{
    [SerializeField] private float _delay;
    [SerializeField] private float _lowerBound;
    [SerializeField] private float _upperBound;

    private WaitForSeconds _wait;
    private IEnumerator _coroutine;
    private bool _isPlaying;

    private void Start()
    {
        _wait = new WaitForSeconds(_delay);
    }

    public void Play()
    {
        if (_isPlaying == false)
        {
            _isPlaying = true;
            _coroutine = Generate();
            StartCoroutine(_coroutine);
        }
    }

    public void Pause()
    {
        if (_isPlaying)
        {
            _isPlaying = false;
            StopCoroutine(_coroutine);
            _coroutine = null;
        }
    }

    private IEnumerator Generate()
    {
        while (enabled)
        {
            yield return _wait;
            Spawn();
        }
    }

    private void Spawn()
    {
        float spawnPositionY = Random.Range(_upperBound, _lowerBound);
        Vector3 spawnPoint = new Vector3(transform.position.x, spawnPositionY, transform.position.z);
        Pipe pipe = Pool.Get();
        pipe.transform.position = spawnPoint;
        pipe.gameObject.SetActive(true);
    }
}
