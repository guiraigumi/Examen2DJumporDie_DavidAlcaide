using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public int coins = 0;
    public Text coinsText;
    public Image[] lives; 
    public int livesRemaining;
    
    
    void Awake()
    {
        if (Instance != null & Instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Instance = this;
        }
    }
    public void LoseLife()
    {
        if (livesRemaining == 0)
            return;
        livesRemaining--;
        lives[livesRemaining].enabled = false;
        if (livesRemaining == 0)
        {
            Destroy(GameObject.FindWithTag("Player"));
        }
    }
    public void LoadLevel(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }

    public void AddCoin(GameObject Coin)
    {      
        coins++;
        coinsText.text = coins.ToString();
        Destroy(Coin);
    }

}
