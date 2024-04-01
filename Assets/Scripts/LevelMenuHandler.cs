using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelMenuHandler : MonoBehaviour
{
    public GameObject BackgroundMenu;
    public GameObject LevelMenu;
    public bool wasLevelMenuOpened;

    private void Start()
    {
        wasLevelMenuOpened = false;
    }
    private void Update()
    {
        if (wasLevelMenuOpened == true)
        {
            BackgroundMenu.SetActive(false);
            LevelMenu.SetActive(true);
        }
    }
}
