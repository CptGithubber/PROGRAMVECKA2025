using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camarefolowing : MonoBehaviour
{

    public GameObject prefab;
    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.transform.position = prefab.transform.position;
    }
}
