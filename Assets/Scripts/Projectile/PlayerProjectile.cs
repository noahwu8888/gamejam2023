using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProjectile : MonoBehaviour
{

    public bool isTPGun = false;
    public bool isMelee = false;
    public float damage = 1;
    private Rigidbody rb;
    [SerializeField] private float projectileSpeed;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.velocity *= projectileSpeed;
    }

    private void Update()
    {
        if (isMelee){
            Destroy(gameObject, .1f);
            
        }
    }
    void OnCollisionEnter(Collision co)
    {
        if (isTPGun)
        {
            TeleportGunManager.Singleton.AddEnemy(co.gameObject);
        }
        if (co.gameObject.tag != "Player" && co.gameObject.tag != "EnemyBullet")
            Destroy(gameObject);
    }
}
