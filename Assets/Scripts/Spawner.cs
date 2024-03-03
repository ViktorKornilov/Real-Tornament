using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Spawner : MonoBehaviour
{
    public GameObject prefab;
    public List<Transform> spawnPoints;
    public List<int> enemyCounts;

    [Range(0.1f,5)]public float spawnInterval = 1f;
    [Range(0,10)]public float waveInterval = 10f;

    public int enemiesLeft;
    public UnityEvent onWaveStarted;
    public UnityEvent onWaveEnded;

    async void Start()
    {
        Random.seed = 5;
        foreach (var count in enemyCounts)
        {
            onWaveStarted.Invoke();

            enemiesLeft = count;
            while (enemiesLeft > 0)
            {
                await new WaitForSeconds(spawnInterval);
                Spawn();
                enemiesLeft--;
            }

            onWaveEnded.Invoke();
            await new WaitForSeconds(waveInterval);
        }
    }

    public void Spawn()
    {
        var spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Count)];
        Instantiate(prefab, spawnPoint.position, Quaternion.identity);
    }
}