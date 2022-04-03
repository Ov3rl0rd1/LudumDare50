using UnityEngine;

public class GoToMainMenuAfterAnimation : StateMachineBehaviour
{
    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        GameEnd.GoToMainMenu();
    }
}
