using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class LookAtMouse : MonoBehaviour
{  
    public float speed;
    public Camera cam;
    public Collider planeCollider;
    RaycastHit hit;
    Ray ray;

    void Update()
    {
        ray = cam.ScreenPointToRay(Input.mousePosition);

        if (Input.GetMouseButton(0) && Physics.Raycast(ray, out hit))
        {
            if (hit.collider == planeCollider)
            {
                transform.position = Vector3.MoveTowards(transform.position, hit.point, Time.deltaTime * speed);
                transform.LookAt(new Vector3(hit.point.x, transform.position.y, hit.point.z));

            }
        }
    }
}

