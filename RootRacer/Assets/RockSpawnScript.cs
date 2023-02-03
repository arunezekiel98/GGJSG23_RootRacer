using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockSpawnScript : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject rock;
    private float timer = 0;
    public float spawnRate = 2;
    public float topOffset = 10;
    public float bottomOffset = 90;
    public float leftScreen = 50;
    public float rightScreen = 50;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if( timer < spawnRate)
        {
            timer += Time.deltaTime;
        }
        else
        {
            SpawnRock();
            timer = 0;
        }
        
    }

    void SpawnRock()
    {
        float highestPoint = transform.position.y - topOffset;
        float lowestPoint = transform.position.y - bottomOffset;
        Instantiate(rock, new Vector3(Random.Range(transform.position.x - leftScreen, transform.position.x + rightScreen),Random.Range(highestPoint,lowestPoint)), transform.rotation);
    }
}
