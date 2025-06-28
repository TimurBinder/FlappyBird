using UnityEngine;

public class BlitzAnimator : UIAnimator
{
    public override void RunShowTrigger()
    {
        gameObject.SetActive(true);
        base.RunShowTrigger();
    }

    public void EndAnimation()
    {
        gameObject.SetActive(false);
    }
}
