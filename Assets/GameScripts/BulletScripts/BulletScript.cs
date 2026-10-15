using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{

    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject bulletPrefab;



    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        // Checks if right mouse button was clicked
        if (Input.GetMouseButtonDown(0) && Time.timeScale != 0)
        {
            ShootBullet(); // Makes copy and sends it to ShootBullet()
        }
    }


    private void ShootBullet()
    {
        GameObject newBullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation) as GameObject;
        newBullet.SetActive(true);
    }

}
