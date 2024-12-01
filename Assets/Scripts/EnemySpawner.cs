using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] [Tooltip("The minimum time for the enemy to appear")]
    private float minimumSpawnTime = 0f;
    [SerializeField] [Tooltip("The maximum time for the enemy to appear")]
    private float maximumSpawnTime = 2f;

    private float timeUntilSpwan;

    void Start()
    {
        SetTimeSpwan();
    }

    void Update()
    {
        // Spawner enemy
        timeUntilSpwan -= Time.deltaTime;
        if (timeUntilSpwan <= 0)
        {
            Instantiate(enemyPrefab, transform.position, Quaternion.identity);
            SetTimeSpwan();
        }
    }

    private void SetTimeSpwan()
    {
        timeUntilSpwan = Random.Range(minimumSpawnTime, maximumSpawnTime);
    }
}
