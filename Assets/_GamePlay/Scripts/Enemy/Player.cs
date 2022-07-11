using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{
    public LayerMask layerGround;
    public Gun gun;

    private int score;

    private void Start()
    {
        OnInit();
        
    }


    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if(Physics.Raycast(ray, out hit, 100, layerGround))
        {
            transform.LookAt(hit.point);
        }

        if (Input.GetButtonDown("Fire1"))
        {
            gun.Fire();
        }
         
    }

    

    public override void OnInit()
    {
        base.OnInit();
        hp = 5f;
        score = 0;
    }

    public override void OnDespawn()
    {
        base.OnDespawn();
        gameObject.SetActive(false);
        LevelManager.Ins.Lose();
    }

    public void IncreScore()
    {
        score++;
    }

    public int GetScore()
    {
        return score;
    }
    public float GetHP()
    {
        return hp;
    }
}
