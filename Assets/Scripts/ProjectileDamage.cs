using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileDamage : MonoBehaviour
{
    
    public PlayerHealth playerHealth;

    [SerializeField]
    GameObject gameObjectt;

    

   

    // Start is called before the first frame update
     void Start()
    {
        playerHealth = GetComponent<PlayerHealth>();
    }

    // Update is called once per frame
    void Update()
    {
  


    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("Collision");

        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("ph "+playerHealth);
            playerHealth.TakeDamage(20);
            Debug.Log("Damage");
            Destroy(gameObject);
        }


        Destroy(gameObject);
    }

   
}
