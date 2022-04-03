using UnityEngine;

public class Menu : MonoBehaviour
{
    [SerializeField] private Animator _mainMenuAnimtator;
    [SerializeField] private GameObject _settings;
    [SerializeField] private GameObject _mainMenu;

    public void Play()
    {
        _mainMenuAnimtator.SetTrigger("StartGame");
    }

    public void Settings()
    {
        _settings.SetActive(true);
        _mainMenu.SetActive(false);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
