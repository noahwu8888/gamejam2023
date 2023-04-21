using UnityEngine;

public class PlayerHealth : Health
{


    void OnCollisionEnter(Collision co)
    {
        if (co.gameObject.tag == "EnemyBullet" && !GetComponent<PlayerScript>().isRolling)
        {
            TakeDamage(co.gameObject.GetComponent<EnemyProjectile>().damage);
        }
    }
    protected override void Die()
    {
        Debug.LogWarning("Player Death is not properly implemented yet.");
        // TODO: Make the player actually able to die.
        Heal(float.MaxValue);
    }
}