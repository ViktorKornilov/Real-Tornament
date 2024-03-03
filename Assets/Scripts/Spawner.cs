using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Spawner : MonoBehaviour
{
	public GameObject prefab;
	public List<Transform> spawnPoints;
	public List<int> waveEnemyCounts;
	public int enemiesLeft;
	public int currentWave = 0;

	[Range(0, 10)]
	public float waveDelay = 5f;
	[Range(0,5)]
	public float spawnInterval = 2f;

	public UnityEvent onWaveStarted;
	public UnityEvent onWaveEnded;

	void Spawn()
	{
		var spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Count)];
		Instantiate(prefab, spawnPoint.position, spawnPoint.rotation);
	}

	async void Start()
	{
		// loop waves
		foreach(var wave in waveEnemyCounts)
		{
			await new WaitForSeconds(waveDelay);
			onWaveStarted.Invoke();
			enemiesLeft = waveEnemyCounts[currentWave];

			// loop enemies in wave
			while (enemiesLeft > 0)
			{
				Spawn();
				enemiesLeft--;
				await new WaitForSeconds(spawnInterval);
			}
			onWaveEnded.Invoke();
		}
	}
}