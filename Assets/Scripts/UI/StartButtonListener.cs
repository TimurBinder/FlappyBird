using System;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class StartButtonListener : MonoBehaviour
{
    private Button _button;

    public event Action Clicked;

    private void Awake()
    {
        _button = GetComponent<Button>();
    }

    private void OnEnable()
    {
        _button.onClick.AddListener(OnClick);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(OnClick);
    }

    public void Show()
    {
        _button.interactable = true;
    }

    private void OnClick()
    {
        Clicked?.Invoke();
        _button.interactable = false;
    }
}
