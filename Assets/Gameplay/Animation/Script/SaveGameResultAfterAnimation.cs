using UnityEngine;

public class SaveGameResultAfterAnimation : StateMachineBehaviour
{
    [SerializeField] private EndGameResult _gameResult;
    [SerializeField] private bool _destroy;

    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (_destroy == true)
            Destroy(animator.gameObject);
        GameEnd.SaveGameRuslt(_gameResult);
    }
}
