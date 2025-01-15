using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileDamage : MonoBehaviour
{

    PlayerHealth playerHealth;

    [SerializeField]
    GameObject gameObjectt;

    

   

    // Start is called before the first frame update
     void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
  


    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collision");

        if (collision.gameObject.CompareTag("Player"))
        {
            playerHealth.TakeDamage(20);

            Debug.Log("20 damage");
            Destroy(gameObject);
        }


        Destroy(gameObject);
    }

   
}
