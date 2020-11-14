using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSet : MonoBehaviour
{
    public GameObject bullet, bulletSpawn;
    public float ammo, alturaSpawn;
    public string commandShoot;
    public bool teledirigido = false;
    Vector3 mousePosInWorld;
    Vector3 mouseWorldPosition;
    Vector3 mousePosition;

    public void Update()
    {
        mousePosition = Input.mousePosition;
        mousePosition.z = 100;
        mouseWorldPosition = Camera.main.ScreenToWorldPoint(mousePosition);
        mouseWorldPosition.z = 0;
    }

    public void Shoot(float shootForce)
    {
        if(ammo >= 1)
        {
            GameObject newBullet = GameObject.Instantiate(bullet);
            if (newBullet.GetComponent<bulletSet>() != null)
            {
                bulletSet bulls = newBullet.GetComponent<bulletSet>();
                newBullet.transform.position = bulletSpawn.transform.position;
                newBullet.transform.up = this.transform.up;
                bulls.shootForce = shootForce;
                ammo--;
            } 
            else if (newBullet.GetComponent<granada>() != null)
            {
                granada bulls = newBullet.GetComponent<granada>();
                newBullet.transform.position = bulletSpawn.transform.position;
                newBullet.transform.up = this.transform.up;
                bulls.shootForce = shootForce;
                ammo--;
            }

            Camera.main.GetComponent<CameraFollowScript>().SetFollow(newBullet);
        }
    }
}
