using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class homeButton : MonoBehaviour
{
    public string sampleScene;
    public string howTo;
    
    public void goToSampleScene(){
        Application.LoadLevel(sampleScene);
    }
    public void goToHowTo(){
        Application.LoadLevel(howTo);
    }
    public void exitApplication(){
        Application.Quit();
    }
}