using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootScript : MonoBehaviour
{

    public Transform mousePos;

    private Vector3 direction;

    private int selectedWeapon = 0;
    public GameObject[] projectile;

    public float shootCooldown = .5f;
    private float shootTimer;

    public bool IsTPDisabled;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("1"))
        {
            selectedWeapon = 0;
        }
        else if (Input.GetKey("2"))
        {
            selectedWeapon = 1;
        }

        if (shootTimer >= 0)
        {
            shootTimer -= Time.deltaTime;
        }
        if (Input.GetButton("Fire1") && shootTimer <= 0)
        {
            ShootProjectile();
            shootTimer = shootCooldown;
        }
        if (Input.GetButtonDown("Fire3"))
        {
            DoMelee();
        }
    }

    void ShootProjectile()
    {
        /*if (selectedWeapon == 0 && IsTPDisabled)
            selectedWeapon = 1;*/
        var projectileObj = Instantiate(projectile[selectedWeapon], transform.position + (mousePos.position - transform.position).normalized / 10, Quaternion.identity) as GameObject;
        projectileObj.GetComponent<Rigidbody>().velocity = (mousePos.position - transform.position).normalized;

    }
    void DoMelee()
    {
        Vector3 direction = (mousePos.position - transform.position).normalized;
        Quaternion rotation = Quaternion.LookRotation(direction, Vector3.up);
        var projectileObj = Instantiate(projectile[2], transform.position + (mousePos.position - transform.position).normalized, rotation) as GameObject;
        projectileObj.GetComponent<Rigidbody>().velocity = (mousePos.position - transform.position).normalized;
    }
}
