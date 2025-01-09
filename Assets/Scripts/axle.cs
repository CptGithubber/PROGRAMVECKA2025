using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class axle : MonoBehaviour
{
    public void change()
    {
        Screen.fullScreen = !Screen.fullScreen;
        print("Fullscreen ändrade");
    }
}

