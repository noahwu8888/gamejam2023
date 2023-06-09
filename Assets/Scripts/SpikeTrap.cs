﻿using UnityEngine;

/// <summary>
/// A basic spike trap that deals damage every frame the player is on it.
/// </summary>
[RequireComponent (typeof(Collider))]
public class SpikeTrap : MonoBehaviour
{
    [SerializeField]
    private float _damageDealt;

    private void OnCollisionStay(Collision col)
    {
        if (col.gameObject.tag == "Player")
        {
            Health health = col.gameObject.GetComponent<Health>();
            health.TakeDamage(_damageDealt);
        }
    }
}