using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public Bullet bullet;
    public Transform bulletPoint;

    internal void Fire()
    {
        Instantiate(bullet, bulletPoint.position, bulletPoint.rotation);
    }
}
