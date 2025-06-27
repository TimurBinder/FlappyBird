using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class Blitz : MonoBehaviour
{
    [SerializeField] private float _speed;

    private Image _image;
    private IEnumerator _coroutine;
    private bool _isCoroutineRunning;
    private float _originalAlpha;
    private float _minAlpha;

    public event Action Showed;
    public event Action Hiden;

    private void Awake()
    {
        _image = GetComponent<Image>();
        _originalAlpha = _image.color.a;
        Color newColor = _image.color;
        newColor.a = 0;
        _image.color = newColor;
        _minAlpha = 0f;
    }

    private void OnEnable()
    {
        float maxAlpha = _originalAlpha;
        _coroutine = Showing(maxAlpha);
        StartCoroutine(_coroutine);
        _isCoroutineRunning = true;
        Showed += Hide;
    }

    private void OnDisable()
    {
        if (_isCoroutineRunning)
        {
            StopAllCoroutines();
            Showed -= Hide;
        }
    }

    private void Hide()
    {
        _coroutine = Showing(_minAlpha);
        StartCoroutine(_coroutine);
        _isCoroutineRunning = true;
        Showed -= Hide;
    }

    private IEnumerator Showing(float target)
    {
        float step = 0.01f;

        while (_image.color.a != target)
        {
            Color newColor = _image.color;
            newColor.a = Mathf.MoveTowards(_image.color.a, target, step * _speed);
            _image.color = newColor;
            yield return null;
        }

        _isCoroutineRunning = false;

        if (target == _minAlpha)
            Hiden?.Invoke();
        else
            Showed?.Invoke();
    }
}