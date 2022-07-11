using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private const float TIME_ALIVE = 1.5f;

    public Rigidbody rigidbody;
    private float speed = 20f;
    private float time;

    

   
    public void Update()
    {
        
        time += Time.deltaTime;
        if(time >= TIME_ALIVE)
        {
            OnDespawn();
            time = 0;
        }

        
    }

    private void OnEnable()
    {
        OnInit();
        time = 0;
    }

    public void OnInit()
    {
        rigidbody.velocity = transform.forward * speed;
        LevelManager.Ins.BulletRegister(this);

    }

    public void OnDespawn()
    {
        LevelManager.Ins.BulletUnRegister(this);
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Zombie")
        {
            Zombie zombie = other.GetComponent<Zombie>();

            if(zombie != null)
            {
                zombie.OnHit(1);
                OnDespawn();
            }
        }
    }
}
