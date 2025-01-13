using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEngine.GraphicsBuffer;

public class Camarefolowing : MonoBehaviour
{
    Vector3 offset = new Vector3(0, 0, -10f);
    float smoothTime = 0.25f;
    Vector3 velocity = Vector2.zero;

    [SerializeField] Transform target;

    // Update is called once per frame
    void Update()
    {
        Vector3 targetPosition = target.position + offset;
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
    }
}
