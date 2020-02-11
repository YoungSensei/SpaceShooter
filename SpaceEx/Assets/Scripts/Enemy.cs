using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    [SerializeField] float health = 100;
    [SerializeField] float shotCounter;
    [SerializeField] float minTimeBtwShots = 0.5f;
    [SerializeField] float maxTimeBtwShots = 3f;
    [SerializeField] GameObject enemyLaser;
    [SerializeField] float projectileSpeed = 10f;


    void Start()
    {
        shotCounter = Random.Range(minTimeBtwShots, maxTimeBtwShots);
    }


    void Update()
    {
        ManageEnemyShootFreq();
    }

    private void ManageEnemyShootFreq()
    {
        shotCounter -= Time.deltaTime;
        if(shotCounter <= 0)
        {
            Fire();
            shotCounter = Random.Range(minTimeBtwShots, maxTimeBtwShots);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        DamageDealer damageDealer = collision.gameObject.GetComponent<DamageDealer>();
        ProcessHit(damageDealer);
    }

    private void ProcessHit(DamageDealer damageDealer)
    {
        health -= damageDealer.GetDamage();
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void Fire()
    {
        GameObject laser = Instantiate(enemyLaser, transform.position, Quaternion.identity) as GameObject;
        laser.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -projectileSpeed);
    }
}

