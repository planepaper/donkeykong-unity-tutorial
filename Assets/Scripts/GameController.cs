using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    private int level;
    private int lives;
    private int score;

    private void Start()
    {
        DontDestroyOnLoad(gameObject);
        NewGame();

        LoadLevel(1);
    }

    private void LoadLevel(int index)
    {
        level = index;

        Camera camera = Camera.main;

        if (camera != null)
        {
            camera.cullingMask = 0;
        }

        Invoke(nameof(LoadScene), 1f);
    }

    private void LoadScene()
    {
        SceneManager.LoadScene(level);
    }

    private void NewGame()
    {
        lives = 3;
        score = 0;
    }

    public void LevelComplete()
    {
        score += 100;

        int nextLevel = level + 1;

        if (nextLevel < SceneManager.sceneCountInBuildSettings)
        {
            LoadLevel(nextLevel);
        }
        else
        {
            LoadLevel(1);
        }

        LoadLevel(nextLevel);
    }

    public void LevelFailed()
    {
        lives--;

        if (lives <= 0)
        {
            NewGame();
        }
        else
        {
            LoadLevel(level);
        }
    }
}
