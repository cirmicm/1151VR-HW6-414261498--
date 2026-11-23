using UnityEngine;

public class FallingItemSpawner : MonoBehaviour
{
    [SerializeField] private FallingItemFactory itemFactory;
    [SerializeField] private float spawnInterval = 1.0f;
    [Range(0f, 1f)]
    [SerializeField] private float bombChance = 0.25f;

    [Header("Spawn Bounds (World X)")]
    [SerializeField] private float minX = 0f;
    [SerializeField] private float maxX = 3f;
    [SerializeField] private float minZ = 0f;

    [SerializeField] private float maxZ = 3f;
    [SerializeField] private float spawnY = 10f;

    private float _timer;

    private void Update()
    {
        _timer += Time.deltaTime;
        if (_timer >= spawnInterval)
        {
            _timer = 0f;
            SpawnRandomItem();
        }
    }

    private void SpawnRandomItem()
    {
        if (itemFactory == null) return;

        FallingItemType itemType = Random.value < bombChance
            ? FallingItemType.Bomb
            : FallingItemType.Apple;

        float randomX = Random.Range(minX, maxX);
        float randomZ = Random.Range(minZ, maxZ);
        Vector3 spawnPos = new Vector3(randomX, spawnY, randomZ);

        itemFactory.Create(itemType, spawnPos, Quaternion.identity);
    }
}