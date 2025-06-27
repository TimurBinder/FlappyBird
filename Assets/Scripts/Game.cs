using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField] private Bird _bird;
    [SerializeField] private PipeGenerator _pipeGenerator;
    [SerializeField] private PlatformGenerator _platformGenerator;
    [SerializeField] private StartScreen _startScreen;
    [SerializeField] private EndScreen _endScreen;

    private void Start()
    {
        _startScreen.gameObject.SetActive(true);
        _startScreen.Show();
        Pause();
    }

    private void OnEnable()
    {
        _bird.GameOver += OnGameOver;
        _startScreen.Hiden += Play;
        _endScreen.Hiden += Replay;
    }

    private void OnDisable()
    {
        _bird.GameOver -= OnGameOver;
        _startScreen.Hiden -= Play;
        _endScreen.Hiden -= Replay;
    }

    private void OnGameOver()
    {
        Pause();
        _endScreen.gameObject.SetActive(true);
        _endScreen.Show();
    }

    private void Reset()
    {
        _bird.Reset();
        _pipeGenerator.Reset();
        _platformGenerator.Reset();
        Play();
    }

    private void Replay()
    {
        Reset();
        Play();
    }

    private void Play()
    {
        _bird.Play();
        _pipeGenerator.Play();
        _platformGenerator.Play();
    }

    private void Pause()
    {
        _bird.Pause();
        _pipeGenerator.Pause();
    }
}
