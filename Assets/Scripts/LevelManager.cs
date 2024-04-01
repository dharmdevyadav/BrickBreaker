using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
  public GameObject[] buttons;
  public GameObject[] Locks;
  private void Awake()
  {
    if (PlayerPrefs.GetInt("UnlockLevel") == 0)
    {
      PlayerPrefs.SetInt("UnlockLevel", 1);
      PlayerPrefs.Save();
        }
    
  }
  void Update()
    {
      for (int i = 0; i < buttons.Length; i++)
      {
        buttons[i].GetComponent<Button>().interactable = false;
        Locks[i].SetActive(true);
      }

      for (int i = 0; i < PlayerPrefs.GetInt("UnlockLevel"); i++)
      {
        buttons[i].GetComponent<Button>().interactable = true;
        Locks[i].SetActive(false);
      }
      
    }
  public void LoadScene(int index)
  {
    SceneManager.LoadScene(index);
  }

}
