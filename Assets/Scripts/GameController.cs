using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public GameObject Medal;
    public GameObject Trap;
    public GameObject Enemy;
    public GameObject Item;
    public float spawnTime;
    float spawn;

    int score;
    bool gameOver;
    public Button pauseButton;
    private bool isPaused = false;
    UIManager manager;

    GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        manager=FindObjectOfType<UIManager>();
        spawn = 0;
        player = GameObject.FindGameObjectWithTag("Player");
        pauseButton.onClick.AddListener(Pause);
    }

    // Update is called once per frame
    void Update()
    {
        if (gameOver)
        {
            manager.SetGameoverPanel(true);
        }
        spawn -= Time.deltaTime;
        if (spawn <= 0)
        {
            SpawnMedal();
            SpawnEnemy();
            SpawnTrap();
            SpawnItem();
            spawn = spawnTime;
        }
    }
    public void SpawnMedal()
    {
        Vector2 playerPos = player.transform.position;
        Vector2 spwanPos = new Vector2(Random.Range(playerPos.x, playerPos.x + 7), -1.5f);
        if (Medal)
        {
           Instantiate(Medal,spwanPos, Quaternion.identity);
        }
    }
    public void SpawnTrap()
    {
        Vector2 playerPos = player.transform.position;
        Vector2 spwanPos = new Vector2(Random.Range(playerPos.x, playerPos.x + 7), -2.054792f);
        if (Trap)
        {
            Instantiate(Trap, spwanPos, Quaternion.identity);
        }
    }
    public void SpawnEnemy()
    {
        Vector2 playerPos = player.transform.position;
        Vector2 spwanPos = new Vector2(Random.Range(playerPos.x, playerPos.x + 7), -1.86f);
        if (Enemy)
        {
            Instantiate(Enemy, spwanPos, Quaternion.identity);
        }
    }
    public void SpawnItem()
    {
        Vector2 playerPos = player.transform.position;
        Vector2 spwanPos = new Vector2(Random.Range(playerPos.x, playerPos.x + 7), -1.5f);
        if (Item)
        {
            Instantiate(Item, spwanPos, Quaternion.identity);
        }
    }
    public void Setscore(int value)
    {
        score = value;
    }
    public int Getscore()
    { 
        return score;
    }
    public void point()
    {
        score++;
        manager.SetScoretxt("Point: " + score);
    }
    public void SetgameOver(bool isgo)
    {
        gameOver = isgo;
    }
    public bool GetgameOver()
    {
        return gameOver;
    }
    void Pause()
    {
        isPaused = !isPaused;
        if (isPaused)
        {
            Time.timeScale = 0f;
            AudioListener.pause = true;
        }
        else
        {
            Time.timeScale = 1f;
            AudioListener.pause = false;
        }
    }
}
