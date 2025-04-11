using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moveables : MonoBehaviour
{
    public Transform Moveable;
    public Transform startPoint;
    public Transform endPoint;
    public float speed = 1.5f;

    int direction = 1;
   
    // Update is called once per frame
    private void Update()
    {
        Vector2 target = currentMovementTarget();

        Moveable.position=Vector2.Lerp(Moveable.position,target, speed * Time.deltaTime);
    }

    Vector2 currentMovementTarget()
    {
        if (direction == 1)
        {
            return startPoint.position;
        }
        else
        {
            return endPoint.position;
        }
    }

    private void OnDrawGizmos()
    {
        if(Moveable!=null && startPoint!=null && endPoint !=null)
        {
            Gizmos.DrawLine(Moveable.transform.position, startPoint.position);
            Gizmos.DrawLine(Moveable.transform.position, endPoint.position);
        }
    }
}
