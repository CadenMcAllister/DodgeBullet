using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1Controller : MonoBehaviour
{
    public GameObject enemy1;

    public GameObject player;
    public Rigidbody2D rb;

    public Vector3 offset;
    private bool canShoot = true;
    public GameObject target;
    public Transform bulletSpawnPoint;
    public GameObject projectilePrefab;
    public float projectileForce = 500f;
    public AnimationClip upDown;

    // Start is called before the first frame update
    void Start()
    {
        rb = enemy1.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = player.transform.position + offset;

        float distance = Vector2.Distance(transform.position, target.transform.position);
        if (distance < 10f)
        {
            // Fire the projectile
            Fire();

        }
    }

    void Fire()
    {
        if (canShoot)
        {
            // Create a new instance of the projectile prefab at the bulletSpawnPoint position
            GameObject newProjectile = Instantiate(projectilePrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
            Rigidbody2D rb = newProjectile.GetComponent<Rigidbody2D>();

            // Calculate the direction to the player
            Vector2 directionToTarget = (target.transform.position - bulletSpawnPoint.position).normalized;

            rb.AddForce(directionToTarget * projectileForce, ForceMode2D.Impulse);

            // Set canShoot to false and start the cooldown timer
            canShoot = false;
            Invoke(nameof(ResetCooldown), 2f);
        }
    }

    void ResetCooldown()
    {
        canShoot = true;        
    }
}
