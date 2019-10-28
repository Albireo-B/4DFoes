using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testButton : MonoBehaviour
{
public void testButtonChangement(string scene){
    Application.LoadLevel(scene);
}


public void quitApp(){
    Application.Quit();
}


}
