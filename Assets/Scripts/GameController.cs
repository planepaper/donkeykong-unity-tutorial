using UnityEngine;

public class GameController : MonoBehaviour
{
    private int lives;
    private int score;

    private void Start()
    {
        NewGame();
    }

    private void NewGame()
    {
        lives = 3;
        score = 0;
    }

    public void LevelComplete()
    {
        score += 100;
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

        }
    }
}
