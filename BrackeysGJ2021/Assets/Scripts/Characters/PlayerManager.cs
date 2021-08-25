using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Elements;

public class PlayerManager : MonoBehaviour
{
    public int maxHealth = 3;
    public int currentHealth;
    public float movementSpeed = 5f;

    public Rigidbody rb;

    public HealthBar healthBar;

    Vector3 movement;

    private bool airMode, fireMode, electricityMode, gumMode, iceMode;
    private bool isHoldingOrb = false;
    private Element currentOrb;
    [SerializeField]
    private GameObject[] orbPrefabs;

    public bool isDead;

    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        isDead = false;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            TakeDamage(1);
        }

        movement.x = Input.GetAxisRaw("Horizontal");
        movement.z = Input.GetAxisRaw("Vertical");


        if (currentHealth == 0)
        {
            Die();
        }

        if (Input.GetKeyDown(KeyCode.R) && isDead)
        {
            Revive();
        }

    }

    void FixedUpdate()
    {
        if (!isDead)
        {
            rb.MovePosition(rb.position + movement * movementSpeed * Time.deltaTime);
        }
    }

    void TakeDamage(int damage)
    {
        currentHealth -= damage;

        healthBar.SetHealth(currentHealth);
    }

    void Die()
    {
        isDead = true;
        gameObject.GetComponent<Renderer>().material.color = Color.red;

    }

    void Revive()
    {
        currentHealth = 1;
        healthBar.SetHealth(currentHealth);
        gameObject.GetComponent<Renderer>().material.color = Color.white;
        isDead = false;
    }

    private void AirSet()
    {

    }

    private void FireSet()
    {

    }

    private void ElectricitySet()
    {

    }

    private void GumSet()
    {

    }

    private void IceSet()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("orb"))
        {
            if (Input.GetKey(KeyCode.E) && other.gameObject.layer.Equals("Air") && isHoldingOrb == false)
            {
                currentOrb = Element.Air;
                isHoldingOrb = true;
            }
            if (Input.GetKey(KeyCode.E) && other.gameObject.layer.Equals("Fire") && isHoldingOrb == false)
            {
                currentOrb = Element.Fire;
                isHoldingOrb = true;
            }
            if (Input.GetKey(KeyCode.E) && other.gameObject.layer.Equals("Electricity") && isHoldingOrb == false)
            {

                currentOrb = Element.Electricity;
                isHoldingOrb = true;
            }
            if (Input.GetKey(KeyCode.E) && other.gameObject.layer.Equals("Gum") && isHoldingOrb == false)
            {

                currentOrb = Element.Gum;
                isHoldingOrb = true;
            }
            if (Input.GetKey(KeyCode.E) && other.gameObject.layer.Equals("Ice") && isHoldingOrb == false)
            {

                currentOrb = Element.Ice;
                isHoldingOrb = true;
            }
        }
    }
}
