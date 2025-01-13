using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FlyingShoot : MonoBehaviour
{
    // Player object draged in for target purposes
    [SerializeField]
    GameObject player;

    // projectile serialized in to be instantiated
    [SerializeField]
    GameObject projectile;

    // cooldown float so flying enemy can only shoot every 3 seconds
    float cooldown = 3f;

    Rigidbody2D rigidbody2D;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // cooldown ticks down every second
        cooldown -= Time.deltaTime;
        
        // Flying enemys velocity calculated, used as a condition that if it stops then it can shoot
        Vector2 velocity = rigidbody2D.velocity;
      
        if (velocity.x <= 0.01)
        {


           

            if (cooldown < 0)
            {
                // when the cooldown is zero then it will aim and fire a projectile 

                Vector2 aim = player.transform.position - transform.position;

                GameObject projectilespawn = Instantiate(projectile, transform.position, Quaternion.identity);

                Rigidbody2D projectilerb = projectilespawn.GetComponent<Rigidbody2D>();

                projectilerb.velocity = aim.normalized *2f;

                // sets a 3 second cooldown
                cooldown = 3f;

               

            }

        }

    }
}
