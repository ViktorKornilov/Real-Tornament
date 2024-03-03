using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Spawner : MonoBehaviour
{
	public GameObject prefab;
	public List<Transform> spawnPoints;
	public List<int> enemiesPerWave;

	[Range(0f,10f)]
	public float timeBetweenWaves = 10f;
	[Range(0f,10f)]
	public float spawnInterval = 1f;
	int enemiesLeft;

	public UnityEvent onSpawn;
	public UnityEvent onWaveStart;
	public UnityEvent onWaveEnd;
	public UnityEvent onWavesCleared;

	public void Spawn()
	{
		var point = spawnPoints[Random.Range(0, spawnPoints.Count)];
		Instantiate(prefab, point.position, point.rotation);
		onSpawn.Invoke();
	}

	async void Start()
	{
		foreach (var count in enemiesPerWave)
		{
			enemiesLeft = count;
			onWaveStart.Invoke();

			// spawn enemies
			while (enemiesLeft > 0)
			{
				await new WaitForSeconds(spawnInterval);
				Spawn();
				enemiesLeft--;
			}

			onWaveEnd.Invoke();
			await new WaitForSeconds(timeBetweenWaves);
		}

		onWavesCleared.Invoke();
	}
}