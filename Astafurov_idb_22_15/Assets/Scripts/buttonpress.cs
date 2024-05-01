using UnityEngine;

public class RobotController : MonoBehaviour
{
    public Animator robotAnimator;

    public void OnButtonPress()
    {
        bool isActivated = robotAnimator.GetBool("Activated");

        robotAnimator.SetBool("Activated", !isActivated);
    }
}
