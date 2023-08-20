using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallWallCollision : MonoBehaviour
{
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            Vector3 normal = collision.contacts[0].normal;
            Vector3 reflect = Vector3.Reflect(rb.velocity, normal);
            rb.velocity = reflect;
        }
    }
}