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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        cooldown -= Time.deltaTime;
        
        if (cooldown < 0)
        {
            Vector2 aim = player.transform.position - transform.position;

            GameObject projectilespawn = Instantiate(projectile, transform.position, Quaternion.identity);

            Rigidbody2D projectilerb = projectilespawn.GetComponent<Rigidbody2D>();

            projectilerb.velocity = aim.normalized * 10f;

            cooldown = 3f;

        }

    }
}
