using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Popup : MonoBehaviour
{

    private Animator animator;

    int condition = 0;

    // Start is called before the first frame update
    void Start()
    {
        // Gets component.
        animator = GetComponent<Animator>();
       
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T) && condition == 0)
        {
            // Plays the animation once,if the key is pressed and hasn't been pressed before. 
            animator.Play("Popup");
            animator.SetBool("Bool", true);
            condition += 1;
        }
    }
}
