using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteRock : MonoBehaviour
{
    // Start is called before the first frame update
    public float timer = 0;
    public float MaxTime = 10;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(timer < MaxTime)
        {
            timer += Time.deltaTime;
        }
        else
        {
            Destroy(gameObject);
            Debug.Log("Rock deleted");
            timer = 0;
        }
    }
}
