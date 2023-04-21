using UnityEngine;

/// <summary>
/// Updated the players SpawnPoint.
/// As of right now, functions as a one-use health refill.
/// </summary>
[RequireComponent(typeof(Collider))]
public class SpawnPoint : MonoBehaviour
{
    [SerializeField]
    private bool _disableGun;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            print("ahhahha");
            //other.gameObject.GetComponent<PlayerHealth>().SpawnPoint = transform.position;
            other.gameObject.GetComponent<PlayerHealth>().Heal(float.MaxValue);
            if (_disableGun)
            {
                other.gameObject.GetComponent<ShootScript>().IsTPDisabled = true;
                StartCoroutine(TextManager.Singleton.DisableGun());
            }
            Destroy(gameObject);
        }
    }
}