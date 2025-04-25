using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moveables : MonoBehaviour
{
    public float moveDistance = 3f; 
    public float speed = 2f;

    private Vector3 startPoint;
    private Vector3 endPoint;
    private Vector3 target;

    void Start()
    {
        startPoint = transform.position;
        endPoint = startPoint + new Vector3(moveDistance, 0f, 0f); 
        target = endPoint;
    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);

        if (Vector3.Distance(transform.position, target) < 0.1f)
        {
            target = target == endPoint ? startPoint : endPoint;
        }
    }
}
