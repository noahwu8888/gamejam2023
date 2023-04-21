using UnityEngine;

/// <summary>
/// Updated the players SpawnPoint
/// </summary>
[RequireComponent(typeof(Collider))]
public class SpawnPoint : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
            other.gameObject.GetComponent<PlayerHealth>().SpawnPoint = transform.position;
    }
}