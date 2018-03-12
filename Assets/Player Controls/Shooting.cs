using UnityEngine;


public class Shooting : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform bulletSpawn;

    void Update()
    {
        
        if (Input.GetMouseButtonDown(0))
        {
            Fire();
        }
    }


    public void Fire()
    {
        // Create the Bullet from the Bullet Prefab
        var bullet = (GameObject)Instantiate(
            bulletPrefab,
            bulletSpawn.position,
            bulletSpawn.rotation);

        // Add velocity to the bullet
        bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * 30;

        // Destroy the bullet after 2 seconds
        Destroy(bullet, 2.0f);
    }

   
}