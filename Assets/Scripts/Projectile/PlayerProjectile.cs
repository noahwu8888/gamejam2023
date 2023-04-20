using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProjectile : MonoBehaviour
{

    public bool isTPGun = false;
    private Rigidbody rb;
    [SerializeField] private float projectileSpeed;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.velocity *= projectileSpeed;
    }
    void OnCollisionEnter(Collision co)
    {
        if(isTPGun){
            TeleportGunManager.Singleton.AddEnemy(co.gameObject);
        }
        Destroy(gameObject);
    }
}
