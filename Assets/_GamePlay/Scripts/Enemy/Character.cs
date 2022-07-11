using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    protected float hp;
    protected float damage;
    protected bool isDie => hp <= 0;

    public virtual void OnInit()
    {

    }


    public virtual void OnDespawn()
    {
       
    }

    public void OnHit(int damage)
    {
        if (!isDie)
        {
            hp -= damage;

            if (isDie)
            {
                OnDeath();
            }
        }
    }

    private void OnDeath()
    {
        OnDespawn();
    }
}
