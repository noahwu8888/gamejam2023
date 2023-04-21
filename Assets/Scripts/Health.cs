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

    //reference to the healthbar
    [SerializeField] private Healthbar _healthbar;

    private void Start()
    {
        HealthValue = _maxHealth;
        _healthbar.UpdateHealthBar(_maxHealth, HealthValue);
    }

    /// <summary>
    /// Make the object take <paramref name="damage"/> damage.
    /// </summary>
    public void TakeDamage(float damage)
    {
        if (damage < 0) return;
        HealthValue -= damage;
        _healthbar.UpdateHealthBar(_maxHealth, HealthValue);

        if (HealthValue <= 0)
            Die();
        //Debug.Log(HealthValue);
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
        _healthbar.UpdateHealthBar(_maxHealth, HealthValue);
    }

    /// <summary>
    /// Kill the object once health is non-positive.
    /// </summary>
    protected virtual void Die()
    {
        Destroy(gameObject);
    }
}
