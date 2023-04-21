using UnityEngine;

/// <summary>
/// Updated the players SpawnPoint.
/// As of right now, functions as a one-use health refill.
/// </summary>
[RequireComponent(typeof(Collider))]
public class SpawnPoint : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            //other.gameObject.GetComponent<PlayerHealth>().SpawnPoint = transform.position;
            other.gameObject.GetComponent<PlayerHealth>().Heal(float.MaxValue);
            Destroy(gameObject);
        }
    }
}