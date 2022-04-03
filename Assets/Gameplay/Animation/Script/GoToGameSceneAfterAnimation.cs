using UnityEngine;

public class GoToGameSceneAfterAnimation : StateMachineBehaviour
{
    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        GameEnd.GoToGameScene();
    }
}
