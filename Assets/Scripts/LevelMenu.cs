using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelMenu : MonoBehaviour
{

  public GameObject BackgroundPanel;
  public GameObject LevelMenuPanel;
  public bool ismainmenuLoad=false;
  public void HideObject()
  {
    if (ismainmenuLoad == true)
    {
      BackgroundPanel.SetActive(false);
      LevelMenuPanel.SetActive(true);
    }
  }
   
}
