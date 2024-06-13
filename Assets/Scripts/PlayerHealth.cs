using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxLives = 5; 
    int currentLives;
    Animator anim;
    public AudioSource aus;
    public AudioClip dead;
    GameController gc;
    UIManager um;
    // Start is called before the first frame update
    void Start()
    {
        currentLives = maxLives;
        anim = GetComponent<Animator>();
        gc= FindObjectOfType<GameController>();
        um = FindObjectOfType<UIManager>();
    }
   
    public void LoseLife(int damage)
    {
        currentLives -= damage; 
        if (currentLives <= 0)
        {
            Die();
        }
        um.SetLivetxt();
    }
    public void AddLife(int amount)
    {
        currentLives += amount;
        currentLives = Mathf.Min(currentLives, maxLives);
    }
    void Die()
    {
        anim.SetTrigger("Dead");
        Time.timeScale = 0;
        gc.SetgameOver(true);
        aus.PlayOneShot(dead);
    }
    public int GetCurrentLives()
    {
        return currentLives;
    }
}
