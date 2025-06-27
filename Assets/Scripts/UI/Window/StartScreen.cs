using UnityEngine;

public class StartScreen : Window
{
    [SerializeField] private StartButtonListener _button;

    private void OnEnable()
    {
        _button.Clicked += Hide;
    }

    private void OnDisable()
    {
        _button.Clicked -= Hide;
    }

    public override void Show()
    {
        base.Show();
        _button.Show();
    }
}
