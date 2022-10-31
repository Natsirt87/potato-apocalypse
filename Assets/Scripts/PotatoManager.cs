using System.Buffers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotatoManager : MonoBehaviour
{
    public GameObject simplePotato;
    public int numPotatoes = 20;
    public float staggerTime = 2f;
    
    private Vector2 _bounds;
    private List<Potato> _potatoes;
    private float _spawnTimer = 0;

    // Start is called before the first frame update
    void Start()
    {
        _bounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
        _potatoes = new List<Potato>();
    }

    void Update()
    {
        if (_spawnTimer < staggerTime)
        {
            _spawnTimer += Time.deltaTime;
        }
        else if (_potatoes.Count < numPotatoes)
        {
            _spawnTimer = 0;
            SpawnSimplePotato();
        }
    }

    private void SpawnSimplePotato()
    {
        GameObject spawnedPotato = Instantiate(simplePotato);

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

        Potato potato = spawnedPotato.GetComponent<SimplePotato>();
        potato.manager = this;
        _potatoes.Add(potato);
    }

    public void PotatoDestroyed(Potato destroyedPotato)
    {
        _potatoes.Remove(destroyedPotato);
    }
}
