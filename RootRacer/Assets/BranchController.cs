using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BranchController : MonoBehaviour
{

    [SerializeField] private GameObject BranchPrefab;
    [SerializeField] private float timeToSpawn = 0.5f; // Time it takes to spawn new player circle
    private float currTimeToSpawn; // Tracked time between spawns, when value reaches 0 reset to timeToSpawn
    private Vector3 currentBranchPosition;

    void Start()// Start is called before the first frame update
    {
        currentBranchPosition = this.transform.position;
        currTimeToSpawn = timeToSpawn;
    }

    // Update is called once per frame
    void Update()
    {
        currTimeToSpawn -= Time.deltaTime;
        if (currTimeToSpawn <= 0f)
        {
            currTimeToSpawn += timeToSpawn;

            currentBranchPosition = currentBranchPosition + new Vector3(0.2f, 0, 0);

            GameObject branchNew = Instantiate(BranchPrefab);//create new object
            branchNew.transform.position = currentBranchPosition;
            branchNew.transform.parent = this.transform;
        }
    }
}
