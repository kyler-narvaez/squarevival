using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyMovement : MonoBehaviour
{

    [SerializeField] private Transform player;
    [SerializeField] private Rounds round;

    private float moveSpeed;
    private float minMoveSpeed;
    private float maxMoveSpeed;
    private float EnemyVelocity;
    private float EnemyAcceleration;
    private HealthBar healthBar;

    // increases the enemies speed based on time


    // Start is called before the first frame update
    void Start()
    {
        // Speed of enemy
        SetMinSpeed(2f);
        SetMoveSpeed(minMoveSpeed);
        SetMaxSpeed(4);
        SetVelocity(0.2f);
        SetAcceleration(2f);


        healthBar = gameObject.GetComponent<HealthBar>();

        InvokeRepeating("IncreaseEnemySpeed", 5f, EnemyAcceleration);
    }

    private void FixedUpdate()
    {
        // Goes in direction of player
        gameObject.transform.position = Vector2.MoveTowards(gameObject.transform.position, player.position, moveSpeed * Time.deltaTime);

        // Rotates towards player
        gameObject.transform.up = player.position - gameObject.transform.position;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Bullet")
        {
            int bulletDamage = collision.GetComponent<bulletMovementScript>().GetBulletDamage();
            CalcDamage(bulletDamage);    // Sends over bullet damage
        }
    }

    // Setters
    private void SetMinSpeed(float speed)
    {
        minMoveSpeed = speed;
    }

    private void SetMoveSpeed(float speed)
    {
        moveSpeed = speed;
    }

    private void SetMaxSpeed(float speed)
    {
        maxMoveSpeed = speed;
    }

    private void SetVelocity(float velocity)
    {
        // Every 3 rounds the velocity increases
        EnemyVelocity = velocity + (0.4f * (round.GetCurrentRound() % 4));
        print("Velocity: " + EnemyVelocity);
    }

    private void SetAcceleration(float acceleration)
    {
        // every 3 rounds acceleration decreases (Time)
        EnemyAcceleration = acceleration - (0.4f * (round.GetCurrentRound() % 4));
        print("Acceleration: " + EnemyAcceleration);
    }
    // End of setters


    private void IncreaseEnemySpeed()
    {
        // Checks if added velocity would be too fast
        if (moveSpeed < maxMoveSpeed)
        {
            moveSpeed += EnemyVelocity;
        }
        // if speed greater than max speed, speed = max speed
        else
        {
            moveSpeed = maxMoveSpeed;
            CancelInvoke();
        }
    }

    private void CalcDamage(int damage)
    {
        if (healthBar.IsDead(damage))
        {
            Destroy(gameObject);
        }
        else
        {
            healthBar.SubtractHealth(damage);    // Sets health to result
        }
    }

}
