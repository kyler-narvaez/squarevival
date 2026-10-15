using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletMovementScript : MonoBehaviour
{
    [SerializeField] private Transform firePoint;
    private Rigidbody2D rb;
    private Vector2 myPos;
    private Vector2 target;
    private Vector2 direction;
    private Quaternion rotation;


    private float bulletSpeed;
    private int bulletDamage;

    // Start is called before the first frame update
    void Start()
    {
        // Sets bullet's begining parameters
        SetBulletSpeed(10f);
        SetBulletDamage(1);

        rb = gameObject.GetComponent<Rigidbody2D>();

        CalcShootDirection();

        ShootBullet();
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(firePoint.transform.position, gameObject.transform.position) > 10f)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            Destroy(gameObject);
        }
    }

    /*  
     * Sets speed of bullet based on paramter
     * float speed : float variable given
    */
    private void SetBulletSpeed(float speed)
    {
        bulletSpeed = speed;  // Sets bullet's speed
    }

    /*
     * Sets damage of bullet based on parameter
     * int damage : int variable given
    */
    private void SetBulletDamage(int damage)
    {
        bulletDamage = damage;   // Sets bullet's damage
    }


    /*
     * Calculates the direction the bullet goes
     * target   : Mouse position
     * myPos    : Player position
     * direction: difference between target and myPos
     * rotation : rotation of bullet
     */
    private void CalcShootDirection()
    {
        target = Camera.main.ScreenToWorldPoint(new Vector2(Input.mousePosition.x, Input.mousePosition.y)); // Mouse position
        myPos = new Vector2(transform.position.x, transform.position.y);    // FirePoint position
        direction = target - myPos;
        direction.Normalize();
        rotation = Quaternion.Euler(0, 0, Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg);
        gameObject.transform.rotation = rotation;   // Sets bullet rotation towards mouse
    }

    /*
     * Pushes Rigidbody2D towards mouse
     * direction    : Found through CalcShootDirection()
     * bulletSpeed  : Set during Start
     */
    private void ShootBullet()
    {
        rb.velocity = direction * bulletSpeed;
    }

    public int GetBulletDamage()
    {
        return bulletDamage;
    }
    
}
