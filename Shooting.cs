using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Shooting : MonoBehaviour
{
    public int MaxAmmo = 6;
    public int currentAmmo;
    private bool canShoot = true;

    public Transform firePoint;
    public GameObject bulletPrefab;

    public float bulletForce = 20f;
    // Update is called once per frame

    public Text AmmoText;
    private int peluru;

    void Start()
    {
        currentAmmo = MaxAmmo;
        //peluru = GetComponent<Shooting>().currentAmmo;
        AmmoText = GameObject.Find("Bullet").GetComponent<Text>();
    }

    void Update()
    {
        //AmmoText.text = currentAmmo.ToString();
        AmmoText.text = currentAmmo.ToString();
        if (currentAmmo > 0)
        {
            canShoot = true;
        }
        else
        {
            canShoot = false;
        }

            if(Input.GetButtonDown("Fire2") && canShoot == true)
            {
            Shoot();
            }

            if(Input.GetKeyDown(KeyCode.Space))
            {
                Reload();
                return;
            }

        
    }

    void Shoot()
    {
        currentAmmo--;
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb =  bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
    }

    public void Reload()
    {
        Debug.Log("Reloading...");
        currentAmmo = MaxAmmo;
    }
}
