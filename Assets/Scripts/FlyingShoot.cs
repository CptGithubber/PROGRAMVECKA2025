using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FlyingShoot : MonoBehaviour
{
    [SerializeField]
    GameObject player;

    [SerializeField]
    GameObject projectile;

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
        cooldown -= Time.deltaTime;
        
        Vector2 velocity = rigidbody2D.velocity;
      
        if (velocity.x <= 0.01)
        {


           

            if (cooldown < 0)
            {
                Vector2 aim = player.transform.position - transform.position;

                GameObject projectilespawn = Instantiate(projectile, transform.position, Quaternion.identity);

                Rigidbody2D projectilerb = projectilespawn.GetComponent<Rigidbody2D>();

                projectilerb.velocity = aim.normalized *2f;

                cooldown = 3f;

               

            }

        }

    }
}
