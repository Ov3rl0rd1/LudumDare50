using UnityEngine;

public class BlackScreen : MonoBehaviour
{
    [SerializeField] private Animator _blackScreenAnimator;
    [SerializeField] private bool _isMain;

    private void Awake()
    {
        if(_isMain)
            _blackScreenAnimator.SetTrigger("FadeIn");
    }

    public void FadeOut()
    {
        _blackScreenAnimator.SetTrigger("FadeOut");
    }
}
