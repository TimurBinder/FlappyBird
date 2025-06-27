using System;
using UnityEngine;

[RequireComponent(typeof(WindowAnimator))]
public class Window : MonoBehaviour
{
    private WindowAnimator _animator;

    public event Action Hiden;

    private void Awake()
    {
        _animator = GetComponent<WindowAnimator>();
    }

    public virtual void Show()
    {
        _animator.Show();
    }

    protected void Hide()
    {
        Hiden?.Invoke();
        gameObject.SetActive(false);
    }
}
