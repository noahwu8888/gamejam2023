using UnityEngine;

public class PlayerHealthManager : HealthManager
{
    protected override void Die()
    {
        Debug.LogWarning("Player Death is not properly implemented yet.");
        // TODO: Make the player actually able to die.
        Heal(float.MaxValue);
    }
}