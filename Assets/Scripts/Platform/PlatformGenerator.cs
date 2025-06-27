using UnityEngine;

public class PlatformGenerator : ObstacleGenerator<Platform>
{
    [SerializeField] private PlatformRemover _remover;

    private Vector3 _currentPosition;

    private void Start()
    {
        Play();
    }

    private void OnEnable()
    {
        _remover.Removed += Spawn;
    }

    private void OnDisable()
    {
        _remover.Removed -= Spawn;
    }

    public void Play()
    {
        _currentPosition = Container.position;
        Spawn();
        Spawn();
    }

    private void Spawn()
    {
        Platform platform = Pool.Get();
        platform.transform.position = _currentPosition;
        platform.gameObject.SetActive(true);
        _currentPosition = platform.MaxBounds;
        _currentPosition.x += platform.Size.x / 2;
        _currentPosition.y = Container.position.y;
    }
}
