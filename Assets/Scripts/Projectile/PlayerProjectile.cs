using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProjectile : MonoBehaviour
{
    private Rigidbody rb;
    [SerializeField] private float projectileSpeed;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.velocity *= projectileSpeed;
    }
    void OnCollisionEnter(Collision co)
    {
        if (co.gameObject.tag != "Bullet" && co.gameObject.tag != "Player")
        {
            Destroy(gameObject);
        }
    }
}
