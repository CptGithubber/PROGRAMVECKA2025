using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyProjectile : MonoBehaviour
{
    int Lifetime = 3;

    public void Start()
    {
        StartCoroutine(WaitThenDie());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator WaitThenDie()
    {
        yield return new WaitForSeconds(Lifetime);
        Destroy(gameObject);
    }
}
