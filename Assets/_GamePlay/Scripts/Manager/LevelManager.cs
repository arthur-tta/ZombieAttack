using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : Singleton<LevelManager>
{
    // Data
    public LevelData levelData;
    private LevelData[] levelDatas;

    // Player
    public Player player;
    public Vector3 PlayerPoint => player.transform.position;
    public Player Player => player;

    // Zombie
    public Zombie zombieFrefab;
    private int countZombieDeath;

    // List
    private List<Zombie> zombies = new List<Zombie>();
    private List<Bullet> bullets = new List<Bullet>();

    // Level

    private int level;
    private int max_level;

    //UI
    public UI m_ui;



    private void Start()
    {
        
        LoadNewLevel();
        m_ui.SetScoreText("Score: " + Player.GetScore());
        m_ui.SetHealthText("Health: " + Player.GetHP());
    }

    private void Update()
    {
        m_ui.SetScoreText("Score: " + Player.GetScore());
        m_ui.SetHealthText("Health: " + Player.GetHP());
    }

    public void OnInit()
    {
        countZombieDeath = 0;
        StartCoroutine(IESpawnZombie());
    }


    public void OnReset()
    {
        // despawn toan bo zombie

        for(int i = 0; i < zombies.Count; i++)
        {
            Destroy(zombies[i]);
        }

        // despawnn toan bo dan
        for (int i = 0; i < bullets.Count; i++)
        {
            Destroy(bullets[i]);
        }
        // clear data

        zombies.Clear();
        bullets.Clear();

        // init lai player
        player.OnInit();


    }

    public void LoadNewLevel()
    {
        m_ui.ShowGameOverPanel(false);
        OnReset();

        LoadLevelData();

        OnInit();
    }

    public void LoadLevelData()
    {
        
    }

    public void ZombiaDeath()
    {
        countZombieDeath++;
        Player.IncreScore();
        if(countZombieDeath >= levelData.zombieAmount)
        {

            
            Win();
            

        }
    }
    private IEnumerator IESpawnZombie()
    {
        for(int i = 0; i < levelData.zombieAmount; i++)
        {
            Vector2 randomPoint = Random.insideUnitCircle.normalized * 15f;
            Vector3 zombiePoit = new Vector3(randomPoint.x, 1, randomPoint.y);
            Zombie zombie =  Instantiate(zombieFrefab, zombiePoit, Quaternion.identity);

            zombie.SetHp(Random.Range(levelData.hpRange.x, levelData.hpRange.y));

            zombie.OnInit();

            yield return new WaitForSeconds(1.5f);

        }
    }

    public void ZombieRegister(Zombie zombie)
    {
        zombies.Add(zombie);
    }
    public void ZombieUnRegister(Zombie zombie)
    {
        zombies.Remove(zombie);
    }
    public void BulletRegister(Bullet bullet)
    {
        bullets.Add(bullet);
    }
    public void BulletUnRegister(Bullet bullet)
    {
        bullets.Remove(bullet);
    }

    public void NextLevel()
    {
        // TODO: next level
        Debug.Log("Tinh nang dang phat trien");
    }

    public void Lose()
    {
        Debug.Log("Lose!");
        OnReset();
        m_ui.ShowGameOverPanel(true);
    }
    public void Win()
    {
        Debug.Log("Win!");
        
    }
}
