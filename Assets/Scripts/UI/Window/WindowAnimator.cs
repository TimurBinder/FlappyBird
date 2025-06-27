using UnityEngine;

public class WindowAnimator : MonoBehaviour
{
    [SerializeField] private UIAnimator[] _animatorsUI;

    public virtual void Show()
    {
        foreach (var animator in _animatorsUI)
            animator.RunShowTrigger();
    }
}
