using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    Animator anim;
    GameObject player;
    public GameObject respawnpoint;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player");
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("Player"))
        {
            // Set the respawnpoint to this checkpoint's position
            respawnpoint.transform.position = this.gameObject.transform.position;

            // Telst the animator that the isInUse bool is true
            anim.SetBool("isInUse", true);

            player.GetComponent<PlayerHealth>().respawnpoint = this.gameObject;
            if (player.GetComponent<PlayerHealth>().respawnpoint != null)
            {
                player.GetComponent<PlayerHealth>().respawnpoint = this.gameObject;
            }
        }
    }
}
