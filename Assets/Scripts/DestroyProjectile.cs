using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyProjectile : MonoBehaviour
{
    // Int for the lifetime of the projectile in seconds, which in this case is 3 seconds. 
    int Lifetime = 3;

    public void Start()
    {
        // Starts WaitThenDie.
        StartCoroutine(WaitThenDie());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator WaitThenDie()
    {
        // Destroys the object after 3 seconds of spawning.
        yield return new WaitForSeconds(Lifetime);
        Destroy(gameObject);
    }
}
