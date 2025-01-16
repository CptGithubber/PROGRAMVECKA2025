using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    Animator anim;
    public GameObject player;
    public GameObject respawnpoint;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log($"Collided with: {collision.gameObject.name}, Tag: {collision.gameObject.tag}");

        if (collision.gameObject.CompareTag("Player"))
        {
            // Set the respawnpoint to this checkpoint's position
            respawnpoint.transform.position = this.gameObject.transform.position;

            // Log the respawn point set message
            Debug.Log($"Respawn point set to: {respawnpoint.name}");

            // Set the animator to indicate that this checkpoint is in use
            anim.SetBool("isInUse", true);

            // Optionally, you can assign the player's respawn point
            player.GetComponent<PlayerHealth>().respawnpoint = this.gameObject;
        }

        // If the respawnpoint is not null, disable the previous checkpoint animation (if it exists)
        if (respawnpoint != null)
        {
            var previousCheckpointAnimator = respawnpoint.GetComponent<Animator>();
            if (previousCheckpointAnimator != null)
            {
                previousCheckpointAnimator.SetBool("isInUse", false);
            }
        }
    }
}
