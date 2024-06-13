using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Text scoretxt;
    public Text livetxt;
    public GameObject gameoverPanel;
    PlayerHealth ph;

    private void Start()
    {
        ph = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
    }
    public void SetScoretxt(string txt)
    {
        if (scoretxt)
        {
            scoretxt.text = txt;
        }
    }
    public void SetLivetxt()
    {
        if (livetxt&&ph)
        {
            livetxt.text = ph.GetCurrentLives().ToString(); ;
        }
    }
    public void SetGameoverPanel(bool isShow)
    {
        gameoverPanel.SetActive(isShow);
    }
}
