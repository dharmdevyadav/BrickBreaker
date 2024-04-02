using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelMenuHandler : MonoBehaviour
{
    public GameObject BackgroundMenu;
    public GameObject LevelMenu;
    public static bool wasLevelMenuOpened = false;

    private void Start()
    {
        if (wasLevelMenuOpened == true)
        {
            BackgroundMenu.SetActive(false);
            LevelMenu.SetActive(true);
        }
    }

    public void showStartMenu()
    {
        LevelMenu.SetActive(false);
        BackgroundMenu.SetActive(true);
    }
}
