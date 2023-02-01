using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private GameObject rootPrefab;
    [SerializeField] private Vector3 playerDirection = new Vector3(0, 1, 0);
    [SerializeField] private GameObject currentPlayerObject;

    [SerializeField] private float timeToSpawn = 0.5f; // Time it takes to spawn new player circle
    private float currTimeToSpawn; // Tracked time between spawns, when value reaches 0 reset to timeToSpawn

    // Start is called before the first frame update
    void Start()
    {
        currTimeToSpawn = timeToSpawn;
    }

    // Update is called once per frame
    void Update()
    {
        currTimeToSpawn -= Time.deltaTime;
        if (currTimeToSpawn <= 0f)
        {
            currTimeToSpawn += timeToSpawn;

            GameObject newRoot = Instantiate(rootPrefab);
            newRoot.transform.position = currentPlayerObject.transform.position;
            newRoot.transform.parent = this.transform;

        }

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            playerDirection.x = -1f;
        }
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            playerDirection.x = 1f;
        }
        else
        {
            playerDirection.x = 0f;
        }

        currentPlayerObject.transform.position = currentPlayerObject.transform.position + playerDirection * Time.deltaTime;
    }
}
