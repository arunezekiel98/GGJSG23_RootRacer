using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class Worm : MonoBehaviour
{
    [SerializeField] public float speed = 2.0f; //horizontal movement speed
    [SerializeField] public float frequency = 10f; //up down frequency
    [SerializeField] public float magnitude = 0.05f; //how big the sine wave is
    [SerializeField] public bool facingRight = true; //whether worm is right facing
    [SerializeField] public List<GameObject> bodyParts = new List<GameObject>();


    Vector2 pos;
    List<Transform> tail = new List<Transform>();
    //public GameObject tailPrefab;


    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < bodyParts.Count; i++)
        {
            float spacing = -0.5f;
            Vector2 pos = new Vector2(spacing * i, 0);
            GameObject temp = Instantiate(bodyParts[i], pos, Quaternion.identity);
            
            //keep track of tail objects in a list 
            tail.Insert(i, temp.transform);
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Move();
    }
    void Move()
    {
        pos = transform.position; //save current position

        //move head into new position
        transform.position += transform.right * speed * Time.deltaTime; //movement horizontally
        transform.position += transform.up * Mathf.Sin(Time.time * frequency) * magnitude; //movement up down

       
        //moving tail parts
        if(tail.Count > 0)
        {
            //value of last tail changes
            tail.Last().position = pos;

            
            tail.Insert(0,tail.Last()); //insert at front
            tail.RemoveAt(tail.Count - 1); //remove empty slot at back so length remains constant
        }
    }


    
}
    