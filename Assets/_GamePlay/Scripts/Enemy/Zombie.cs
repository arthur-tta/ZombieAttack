using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : Character
{
    private const float TIME_ATTACK = 2f;

    public ParticleSystem vfxZombieDeath;


    private float speed;
    private float timeAttack;
    private bool isInRangeAttack => Vector3.Distance(transform.position, LevelManager.Ins.PlayerPoint) <= 1f;


    // Update is called once per frame
    void Update()
    {
        if (!isInRangeAttack)
        {
            transform.position = Vector3.MoveTowards(transform.position, LevelManager.Ins.PlayerPoint, Time.deltaTime * speed);
            transform.LookAt(LevelManager.Ins.PlayerPoint);
        } else
        {
            timeAttack += Time.deltaTime;
            if (timeAttack >= TIME_ATTACK)
            {
                LevelManager.Ins.Player.OnHit(1);
                timeAttack = 0;
            }
        }
    }

    public override void OnInit()
    {
        base.OnInit();
        timeAttack = 0;
        damage = Random.Range(1, 3);
        speed = Random.Range(1.5f, 4f);
        LevelManager.Ins.ZombieRegister(this);
    }

    public override void OnDespawn()
    {
        base.OnDespawn();
        LevelManager.Ins.ZombieUnRegister(this);

        // TODO: pooling
        Instantiate(vfxZombieDeath, transform.position, Quaternion.identity);
        LevelManager.Ins.ZombiaDeath();
        Destroy(gameObject);
    }

    public void SetHp(float hp)
    {
        this.hp = hp;
    }

}
