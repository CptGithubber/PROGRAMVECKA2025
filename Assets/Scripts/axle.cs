using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class axle : MonoBehaviour
{
    public void change(bool fullScreen)
    {
        Screen.fullScreen = fullScreen;
        print("Fullscreen ändrade");
    }
   
}

