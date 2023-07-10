using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;

public class PlayerMovement : Singleton<PlayerMovement>
{
    public float speed = 25f;  

    private Rigidbody rb;


    public float attackRadius = 1f;
    public float attackCooldown = 0.25f;

    private float lastAttackTime;

    public GameObject terremoto;

    public string enemyTag;

    float terremotoSpeed = 0;

    float normalSpeed;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        terremoto.SetActive(false);
        normalSpeed = speed;
        
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && Time.time >= lastAttackTime + attackCooldown)
        {
            terremoto.SetActive(true);
            speed = terremotoSpeed;
            PerformMeleeAttack();
            lastAttackTime = Time.time;
            
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            terremoto.SetActive(false);
            speed = normalSpeed;
        }
       
    }

    private void PerformMeleeAttack()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, attackRadius);
        foreach (Collider collider in hitColliders)
        {
            if (collider.CompareTag(enemyTag))
            {
                Destroy(collider.gameObject);
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        // Dibujar un gizmo visual para representar el radio de ataque en el editor
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRadius);
    }



    private void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0f, moveVertical);
        rb.velocity = movement * speed;

        //if (movement != Vector3.zero)
        //{
        //    Quaternion newRotation = Quaternion.LookRotation(movement);
        //    rb.rotation = Quaternion.Slerp(rb.rotation, newRotation, Time.deltaTime * 10f);
        //}
    }

  
}

