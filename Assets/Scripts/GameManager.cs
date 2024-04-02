using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
  [SerializeField] int score;
  [SerializeField] int lives;
  [SerializeField] TextMeshProUGUI scoreText;
  [SerializeField] TextMeshProUGUI scoreText2;
  [SerializeField] TextMeshProUGUI FinalScore;
  [SerializeField] TextMeshProUGUI liveText;
  [SerializeField] GameObject gameOverPanel;
  [SerializeField] GameObject LevelCompletePanel;
  public int numberOfBricks;
  public int currentLevel = 1;
  public bool gameOver;

  private void Start()
  {
    scoreText.text = "Score: " + score;
    scoreText2.text = "Your Score is " + score;
    liveText.text = "Lives: " + lives;
    numberOfBricks = GameObject.FindGameObjectsWithTag("Brick").Length;
    }
  public void UpdateLive(int live)
  {
    lives += live;
    if (lives <=0)
    {
      lives = 0;
      GameOver();
    }
    liveText.text = "Lives: " + lives;
  }

  public void UpdateScore(int points)
  {
    score += points;
    scoreText.text = "Score: " + score;
    scoreText2.text = "Your Score is " + score;
  }

  public void UpdatenumberOfBrick()
  {
    numberOfBricks--;
    if (numberOfBricks <= 0)
    {
      gameOver = true;
      LevelCompletePanel.SetActive(true);
      UnlockLevelButton();
      currentLevel++;
      Invoke("LoadNextLevel",4f);
      
    }
  }
  void UnlockLevelButton()
  {
    if (SceneManager.GetActiveScene().buildIndex >=PlayerPrefs.GetInt("UnlockLevel"))
    {
      PlayerPrefs.SetInt("UnlockLevel", SceneManager.GetActiveScene().buildIndex+1);
      PlayerPrefs.Save();
    }

  }

  public void LoadNextLevel()
  {
        SceneManager.LoadScene(currentLevel);
  }
  public void GameOver()
  {
    gameOver = true;
    scoreText.alpha = 0;
    liveText.alpha = 0;
    gameOverPanel.SetActive(true);
    
  }
  public void LoadLevelOne()
  {
    SceneManager.LoadSceneAsync("Level1");
  }

  public void PlayAgain()
  {
    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); 
  }
  public void PlayAgainExit()
  {
    LevelMenuHandler.wasLevelMenuOpened= true;
    SceneManager.LoadScene("MainMenu");
    gameOver = false;
    
  }
    
  public void ExitGame()
  {
    Application.Quit();
  }
}
