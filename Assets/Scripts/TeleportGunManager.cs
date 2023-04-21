using UnityEngine;

public class TeleportGunManager : MonoBehaviour
{
    // Singleton pattern
    private static TeleportGunManager s_singleton;
    /// <summary>
    /// The singleton refernce for <cref>TeleportGunManager</cref>.
    /// </summary>
    public static TeleportGunManager Singleton
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
    private Transform _teleport;

    // The amount of each enemy type that has been teleported by the gun, in order of the EnemyType gun.
    //private int[] _numberOfEnemies;

    private void Awake()
    {
        Singleton = this;
        DontDestroyOnLoad(this);
        //_numberOfEnemies = new int[EnemyManager.NUMBER_OF_ENEMIES];
    }

    /// <summary>
    /// Adds an enemy of the correct type to the array.
    /// </summary>
    /// <returns>Whether or not the operation was successful.</returns>
    public bool AddEnemy(GameObject go) 
    {
        Enemy enemy;
        if (!go.TryGetComponent<Enemy>(out enemy))
            return false;
        go.transform.position = _teleport.position;
        return true;
    }
}