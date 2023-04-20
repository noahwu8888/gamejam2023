using UnityEngine;

/// <summary>
/// Enum for the different enemies.
/// </summary>
// TODO: Add actual enemies
public enum EnemyType
{
    Default
}

/* VERY IMPORTANT: Please keep the number of enemies accurate to the enum.
 * The game WILL BREAK if this is not kept updated.
 */
public partial class EnemyManager { public const int NUMBER_OF_ENEMIES = 1;  }

/// <summary>
/// Stores information about enemies.
/// </summary>
public class Enemy : Health
{
    [SerializeField] 
    private EnemyType _enemyType;

    /// <summary>
    /// The type of enemy this script represents.
    /// </summary>
    public EnemyType EnemyType => _enemyType;
}