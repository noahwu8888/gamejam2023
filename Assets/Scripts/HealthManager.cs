using UnityEngine;
using UnityEngine.Rendering.Universal;

/// <summary>
/// Handles health.
/// </summary>
public class HealthManager : MonoBehaviour
{
    [SerializeField]
    private float _maxHealth;

    /// <summary>
    /// The current health.
    /// </summary>
    public float Health { get; private set; }

    private void Start()
    {
        Health = _maxHealth;
    }

    /// <summary>
    /// Make the object take <paramref name="damage"/> damage.
    /// </summary>
    public void TakeDamage(float damage)
    {
        if (damage < 0) return;
        Health -= damage;
        if (Health <= 0)
            Die();
        Debug.Log(Health);
    }

    /// <summary>
    /// Heal the object for <paramref name="health"/> health.
    /// </summary>
    public void Heal(float health)
    {
        if (health < 0) return;
        Health += health;
        if (Health > _maxHealth)
            Health = _maxHealth;
    }

    /// <summary>
    /// Kill the object once health is non-positive.
    /// </summary>
    protected virtual void Die()
    {
        Destroy(this);
    }
}
