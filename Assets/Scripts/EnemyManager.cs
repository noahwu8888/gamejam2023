using UnityEngine;

/// <summary>
/// Manages spawwning enemies.
/// </summary>
public partial class EnemyManager : MonoBehaviour
{
    // Singleton pattern
    private static EnemyManager s_singleton;
    /// <summary>
    /// The singleton refernce for <cref>EnemyManager</cref>.
    /// </summary>
    public static EnemyManager Singleton
    {
        get => s_singleton;
        private set
        {
            if (s_singleton is null)
                s_singleton = value;
            else if (s_singleton != value)
                Destroy(value);
        }
    }

    [SerializeField]
    [Tooltip("The prefabs for the enemies, in the order found in the EnemyType enum.")]
    private GameObject[] _prefabList;

    private void Awake()
    {
        Singleton = this;
        DontDestroyOnLoad(this);
    }

    /// <summary>
    /// Spawns an enemy of type <paramref name="enemyType"/>
    /// </summary>
    /// <returns>The GameObject that is the enemy.</returns>
    public GameObject SpawnEnemy(EnemyType enemyType)
    {
        return Instantiate(_prefabList[(int)enemyType]);
    }
}