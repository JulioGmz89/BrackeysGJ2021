using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class firePointRotation : MonoBehaviour
{
    public Rigidbody rb;

    void start()
    {
        rb = GetComponent<Rigidbody>();
    }
    void Update()
    {

        Ray cameraRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        Plane groundPlane = new Plane(Vector3.up, Vector3.zero);
        float rayLenght;

        if (groundPlane.Raycast(cameraRay, out rayLenght))
        {
            Vector3 pointToLook = cameraRay.GetPoint(rayLenght);
            Debug.DrawLine(cameraRay.origin, pointToLook, Color.blue);


            Vector2 direction = new Vector2(pointToLook.x, pointToLook.z) - new Vector2(rb.position.x, rb.position.z);
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;
            transform.rotation = Quaternion.Euler(90, 0, angle);
        }
    }
}
