using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : Health
{
    public Vector3 SpawnPoint;

    void OnCollisionEnter(Collision co)
    {
        if (co.gameObject.tag == "EnemyBullet" && !GetComponent<PlayerScript>().isRolling)
        {
            TakeDamage(co.gameObject.GetComponent<EnemyProjectile>().damage);
        }
    }
    protected override void Die()
    {
        //transform.position = SpawnPoint;
        //Heal(float.MaxValue);
        GetComponent<ShootScript>().IsTPDisabled = false;
        SceneManager.LoadScene("CaveLevel");
    }
}