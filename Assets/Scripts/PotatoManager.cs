using System;
using System.Buffers;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

[Serializable]
public class WaveEnemy
{
    public GameObject enemyPrefab;
    public float probability;
    public float spawnInterval;
    
    private float _spawnTimer = 0f;

    public void IncrementSpawnTimer() { _spawnTimer += Time.deltaTime; }
    public void ResetSpawnTimer() { _spawnTimer = 0f; }
    public bool SpawnTimerReached() { return _spawnTimer >= spawnInterval; }
}

[Serializable]
public class Wave
{
    public int numEnemies;
    public List<WaveEnemy> enemies;
}

public class PotatoManager : MonoBehaviour
{
    public GameObject player;
    public List<Wave> waves;
    public float waveBreakTime = 10f;

    [SerializeField] private TextMeshProUGUI waveText;

    private int _waveNumber = -1;
    private int _enemiesLeft;
    private Vector2 _bounds;
    private List<Potato> _enemies;
    private float _waveBreakTimer = 0;

    // Start is called before the first frame update
    void Start()
    {
        _bounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
        _enemies = new List<Potato>();
        StartWave();
    }

    void Update()
    {   
        if (_waveBreakTimer == 0) 
        {
            waveText.text = "Wave: " + (_waveNumber + 1);
        }
        else
        {
            waveText.text = "Time until next wave: " + (int)(waveBreakTime - _waveBreakTimer);
        }

        if (_enemiesLeft > _enemies.Count)
        {
            foreach (WaveEnemy enemy in waves[_waveNumber].enemies)
            {
                if (!enemy.SpawnTimerReached())
                {
                    enemy.IncrementSpawnTimer();
                }
                else
                {
                    enemy.ResetSpawnTimer();
                    // TODO: Probability check to determine if the enemy should be spawned
                    if (Random.value < enemy.probability)
                    {
                        SpawnEnemy(enemy.enemyPrefab);
                    }
                }
            }
        }
        else if (_enemiesLeft <= 0)
        {
            if (_waveBreakTimer >= waveBreakTime)
            {
                StartWave();
            }
            else
            {
                _waveBreakTimer += Time.deltaTime;
            }
        }
    }

    private void StartWave()
    {
        _waveBreakTimer = 0;
        _waveNumber = (_waveNumber + 1) % (waves.Count);
        _enemiesLeft = waves[_waveNumber].numEnemies;
    }

    private void SpawnEnemy(GameObject enemyType)
    {
        GameObject spawnedPotato = Instantiate(enemyType);

        int screenSide = Random.Range(0, 4);

        switch (screenSide)
        {
            case 0:
                spawnedPotato.transform.position = 
                    new Vector3(-_bounds.x - 2f, Random.Range(-_bounds.y, _bounds.y), 0);
                break;
            case 1:
                spawnedPotato.transform.position = 
                    new Vector3(Random.Range(-_bounds.x, _bounds.x), _bounds.y + 2f, 0);
                break;
            case 2:
                spawnedPotato.transform.position = 
                    new Vector3(_bounds.x + 2f, Random.Range(-_bounds.y, _bounds.y), 0);
                break;
            case 3:
                spawnedPotato.transform.position = 
                    new Vector3(Random.Range(-_bounds.x, _bounds.x), -_bounds.y - 2f, 0);
                break;
        }

        Potato potato = spawnedPotato.GetComponent<Potato>();
        potato.manager = this;
        potato.player = player;
        _enemies.Add(potato);
    }

    public void EnemyDestroyed(Potato destroyedPotato)
    {
        if (_enemies.Remove(destroyedPotato))
        {
            _enemiesLeft--;
        }
    }
}
