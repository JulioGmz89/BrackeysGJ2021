using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Elements;

public class Bullet : MonoBehaviour
{
    public GameObject hitEffect;
    ElementInteractions elementInteractions;
    [SerializeField]
    private Element bulletElement;
    void OnTriggerEnter(Collider collision)
    {
        Debug.Log(collision.name);
        if (collision.gameObject.tag == "Player")
        {
            Physics.IgnoreCollision(GameObject.FindGameObjectWithTag("Player").GetComponent<Collider>(), gameObject.GetComponent<Collider>());
        }
        else if (collision.gameObject.tag == "Enemy")
        {
            elementInteractions.CheckElementInteraction(bulletElement, collision.GetComponent<EnemyManager>().myElement);
        }
        else
        {
            
            GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.Euler(90, 0, 0));
            Destroy(effect, 0.5f);
            Destroy(gameObject);
        }

    }

}
