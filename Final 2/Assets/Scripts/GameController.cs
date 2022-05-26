using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController instance;
    public bool gameOver = false;
    public GameObject gameOverText;
    // Start is called before the first frame update
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    public void PlayerDied()
    {
        gameOverText.SetActive(true);
        gameOver = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
