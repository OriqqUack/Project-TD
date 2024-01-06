using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OriginFire : MonoBehaviour
{
    private float speed = 20f;
    private Rigidbody2D rb;

    void Update()
    {
        rb.velocity = transform.right * speed;
    }

}
