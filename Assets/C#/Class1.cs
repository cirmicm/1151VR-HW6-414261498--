using UnityEngine;

public enum FallingItemType
{
    Apple,
    Bomb
}

public class FallingItemFactory : MonoBehaviour
{
    [Header("Prefabs")]
    [SerializeField] private GameObject applePrefab;
    [SerializeField] private GameObject bombPrefab;

    [Header("Optional Parent Container")]
    [SerializeField] private Transform spawnContainer;

    public GameObject Create(FallingItemType type, Vector3 spawnPosition, Quaternion rotation)
    {
        GameObject prefabToSpawn = type switch
        {
            FallingItemType.Apple => applePrefab,
            FallingItemType.Bomb => bombPrefab,
            _ => null
        };

        if (prefabToSpawn == null)
        {
            Debug.LogWarning($"[FallingItemFactory] Missing prefab for type: {type}");
            return null;
        }

        GameObject instance = Instantiate(prefabToSpawn, spawnPosition, rotation, spawnContainer);
        return instance;
    }
}