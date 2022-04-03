using UnityEngine;
using UnityEngine.SceneManagement;

public static class GameEnd
{
    public static void GoToGameScene()
    {
        SceneManager.LoadScene("Game");
    }

    public static void GoToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public static EndGameResult GetGameResult()
    {
        return (EndGameResult)PlayerPrefs.GetInt("GameResult", 0);
    }

    public static void SaveGameRuslt(EndGameResult endGameResults)
    {
        PlayerPrefs.SetInt("GameResult", (int)endGameResults);
        PlayerPrefs.Save();
    }
}

public enum EndGameResult
{ 
    None = 0,
    Warp,
    CoreOverheat,
    PlayerDied
}
