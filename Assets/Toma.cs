using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Toma : MonoBehaviour
{
    private GameObject player;
    public GameObject balita;
    public float minInterval = 3f;
    public float maxI = 5f;
    public float bulletSpeed;
    private float nextShootTime;

    private void Start()
    {

        SetNextShootTime();
        player = GameObject.FindWithTag("Player");
    }

    private void Update()
    {

        if (Time.time >= nextShootTime)
        {
            Shoot();
            SetNextShootTime();
        }
    }

    private void SetNextShootTime()
    {

        nextShootTime = Time.time + Random.Range(minInterval, maxI);
    }

    private void Shoot()
    {

        GameObject bullet = Instantiate(balita, transform.position, Quaternion.identity);
        Vector3 direction = (player.transform.position - transform.position).normalized;
        bullet.GetComponent<Rigidbody>().velocity = direction * bulletSpeed;
    }
}

