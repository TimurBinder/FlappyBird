using System;
using UnityEngine;

[RequireComponent(typeof(BirdMover))]
[RequireComponent(typeof(BirdCollisionHandler))]
public class Bird : MonoBehaviour
{
    [SerializeField] private ScoreCounter _scoreCounter;

    private BirdMover _birdMover;
    private BirdCollisionHandler _birdCollisionHandler;

    public event Action GameOver;

    private void Awake()
    {
        _birdMover = GetComponent<BirdMover>();
        _birdCollisionHandler = GetComponent<BirdCollisionHandler>();
    }

    private void OnEnable()
    {
        _birdCollisionHandler.CollisionDetected += ProcessCollision;
    }

    private void OnDisable()
    {
        _birdCollisionHandler.CollisionDetected -= ProcessCollision;
    }  

    public void Reset()
    {
        _scoreCounter.Reset();
        _birdMover.Reset();
    }

    public void Play()
    {
        _birdMover.Play();
    }

    public void Pause()
    {
        _birdMover.Pause();
    }

    private void ProcessCollision(IInteractable interactable)
    {
        if (interactable is Obstacle)
            GameOver?.Invoke();
        else if (interactable is ScoreZone)
            _scoreCounter.Add();
    }
}
