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

        // If projectile collides with the player then it will do 20 damage and then disappear. 
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("ph "+playerHealth);
            playerHealth.TakeDamage(20);
            Debug.Log("Damage");
            Destroy(gameObject);
        }

        // If projectile collides with any solid object it gets destroyed.
        Destroy(gameObject);
    }

   
}
