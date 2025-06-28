using UnityEngine;

[RequireComponent(typeof(Animator))]
public class UIAnimator : MonoBehaviour
{
    public static readonly int Show = Animator.StringToHash(nameof(Show));

    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public virtual void RunShowTrigger()
    {
        _animator.SetTrigger(Show);
    }
}
