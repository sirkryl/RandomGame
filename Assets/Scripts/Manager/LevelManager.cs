using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
public class LevelManager : MonoBehaviour
{

    
    public static LevelManager instance = null;

    private int level = 1;
    private List<Enemy> enemies;
    private bool doingSetup;

    void Awake()
    {
        
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);

        MainComponentManager.CreateInstance();
        DontDestroyOnLoad(gameObject);
        enemies = new List<Enemy>();
        InitGame();
    }

    private void OnLevelWasLoaded(int index)
    {
        level++;
        InitGame();
    }

    void InitGame()
    {
        doingSetup = true;

        enemies.Clear();
    }


    public void GameOver()
    {
        enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (doingSetup)
            return;

        //StartCoroutine(MoveEnemies());
    }

    public void AddEnemyToList(Enemy script)
    {
        enemies.Add(script);
    }


    //IEnumerator MoveEnemies()
    //{
    //    //enemiesMoving = true;
    //    //yield return new WaitForSeconds(turnDelay);
    //    //if (enemies.Count == 0)
    //    //{
    //    //    yield return new WaitForSeconds(turnDelay);
    //    //}

    //    //for (int i = 0; i < enemies.Count; i++)
    //    //{
    //    //    enemies[i].MoveEnemy();
    //    //    yield return new WaitForSeconds(enemies[i].moveTime);
    //    //}

    //    //playersTurn = true;
    //    //enemiesMoving = false;
    //}
}
