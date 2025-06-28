using UnityEngine;

public class EndScreen : StartScreen
{
    [SerializeField] private BlitzAnimator _blitz;

    public override void Show()
    {
        _blitz.RunShowTrigger();
        base.Show();
    }
}
