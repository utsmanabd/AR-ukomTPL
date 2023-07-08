using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arButton : MonoBehaviour
{
    public string mainMenu;

    public void goToMainMenu()
    {
        Application.LoadLevel(mainMenu);
    }
}
