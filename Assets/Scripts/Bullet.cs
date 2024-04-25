using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    private AudioSource bulletSound;

    void Start()
    {
        bulletSound = GetComponent<AudioSource>();
    }
    void Update()
    {
        bool keyShoot = Input.GetKeyDown(KeyCode.P);
        if (keyShoot) 
        {
            Shoot();
            bulletSound.PlayOneShot(bulletSound.clip);
        }
    }

    void Shoot()
    {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }
}
