using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Elements;
using UnityEngine.UI;

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
    [SerializeField] GameObject[] staffPrefabs;

    public bool isDead;


    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        FireSet();
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

        Debug.Log(currentOrb);
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

    private void FireAbility(Element element)
    {
        int orbIndex = (int)element;
        Instantiate(staffPrefabs[orbIndex], gameObject.transform);
    }

    

    private void OnTriggerStay(Collider other)
    {
        if (other.tag.Equals("Staff"))
        {
            Debug.Log("Tocando Staff");
            
            if (Input.GetKey(KeyCode.E) && other.gameObject.layer.Equals(14) && !isHoldingOrb)
            {
                Debug.Log("Tomar Aire");
                currentOrb = Element.Air;
                isHoldingOrb = true;
                Instantiate(staffPrefabs[0], gameObject.transform);
                Destroy(other.gameObject);
            }
            if (Input.GetKey(KeyCode.E) && other.gameObject.layer.Equals(11) && !isHoldingOrb)
            {
                currentOrb = Element.Fire;
                isHoldingOrb = true;
                Instantiate(staffPrefabs[1], gameObject.transform);
                Destroy(other.gameObject);
            }
            if (Input.GetKey(KeyCode.E) && other.gameObject.layer.Equals(10) && !isHoldingOrb)
            {
                
                currentOrb = Element.Electricity;
                isHoldingOrb = true;
                Instantiate(staffPrefabs[2], gameObject.transform);
                Destroy(other.gameObject);
            }
            if (Input.GetKey(KeyCode.E) && other.gameObject.layer.Equals(12) && !isHoldingOrb)
            {
                
                currentOrb = Element.Gum;
                isHoldingOrb = true;
                Instantiate(staffPrefabs[3], gameObject.transform);
                Destroy(other.gameObject);
            }
            if (Input.GetKey(KeyCode.E) && other.gameObject.layer.Equals(13) && !isHoldingOrb)
            {
                
                currentOrb = Element.Ice;
                isHoldingOrb = true;
                Instantiate(staffPrefabs[4], gameObject.transform);
                Destroy(other.gameObject);
            }

        }
    }
}
