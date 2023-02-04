using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RouteFollow : MonoBehaviour
{
    [SerializeField]
    private Transform[] routes;

    [SerializeField]
    private float rotationSpeed;

    private int routeToGo;

    private float tParam;

    private Vector2 objectPosition;

    private Vector3 movementDirection;

    private float speedModifier;

    private bool coroutineAllowed;

    // Start is called before the first frame update
    void Start()
    {
        routeToGo = 0;
        tParam = 0f;
        speedModifier = 0.25f;
        coroutineAllowed = true;
        rotationSpeed = 720f;
    }

    // Update is called once per frame
    void Update()
    {
        if (coroutineAllowed)
        {
            StartCoroutine(GoByTheRoute(routeToGo));
        }
        
    }

    private IEnumerator GoByTheRoute(int routeNum)
    {
        coroutineAllowed = false;

        Vector2 p0 = routes[routeNum].GetChild(0).position;
        Vector2 p1 = routes[routeNum].GetChild(1).position;
        Vector2 p2 = routes[routeNum].GetChild(2).position;
        Vector2 p3 = routes[routeNum].GetChild(3).position;

        while (tParam < 1)
        {
            tParam += Time.deltaTime * speedModifier;

            objectPosition = Mathf.Pow(1 - tParam, 3) * p0 + 3 * Mathf.Pow(1 - tParam, 2) * tParam * p1 + 3 * (1 - tParam) * Mathf.Pow(tParam, 2) * p2 + Mathf.Pow(tParam, 3) * p3;
           
            Vector3 objpos3 = objectPosition; //change to vector3
            movementDirection = objpos3 - transform.position;

            Quaternion toRotation = Quaternion.LookRotation(Vector3.forward, movementDirection);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);

            transform.position = objectPosition;
            yield return new WaitForEndOfFrame();
        }

        tParam = 0f;

        routeToGo += 1;

        if (routeToGo > routes.Length - 1)
        {
            routeToGo = 0;
        }

        coroutineAllowed = true;

        

    }
}
