using UnityEngine;
using UnityEngine.Rendering.Universal;

/// <summary>
/// Handles health.
/// </summary>
public class Health : MonoBehaviour
{
    [SerializeField]
    private float _maxHealth;

    /// <summary>
    /// The current health.
    /// </summary>
    public float HealthValue { get; private set; }

    private void Start()
    {
        HealthValue = _maxHealth;
    }

    /// <summary>
    /// Make the object take <paramref name="damage"/> damage.
    /// </summary>
    public void TakeDamage(float damage)
    {
        if (damage < 0) return;
        HealthValue -= damage;
        if (HealthValue <= 0)
            Die();
        Debug.Log(HealthValue);
    }

    /// <summary>
    /// Heal the object for <paramref name="health"/> health.
    /// </summary>
    public void Heal(float health)
    {
        if (health < 0) return;
        HealthValue += health;
        if (HealthValue > _maxHealth)
            HealthValue = _maxHealth;
    }

    /// <summary>
    /// Kill the object once health is non-positive.
    /// </summary>
    protected virtual void Die()
    {
        Destroy(this);
    }
}
