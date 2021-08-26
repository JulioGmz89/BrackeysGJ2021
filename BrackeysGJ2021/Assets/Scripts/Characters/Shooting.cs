using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using PlayerManager;

public class Shooting : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    public float bulletForce = 20f;

    // Update is called once per frame
    void Update()
    {
        //JoystickAim();
        if (Input.GetButton("Fire") || Input.GetMouseButtonDown(0) && !gameObject.GetComponent<PlayerManager>().isDead)
        {
            Shoot();
        }

    }

    void JoysticAim()
    {
        float HorizontalAxis = Input.GetAxis("AimHorizontal");
        float VerticalAxis = Input.GetAxis("AimVertical");
        firePoint.transform.localEulerAngles = new Vector3(0f, 0f, Mathf.Atan2(HorizontalAxis, VerticalAxis) * -180 / Mathf.PI -90f);
    }
    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        rb.AddForce(firePoint.up * bulletForce, ForceMode.Impulse);
    }
    // Start is called before the first frame update
}
