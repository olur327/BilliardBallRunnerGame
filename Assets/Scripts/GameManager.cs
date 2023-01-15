using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Text tapToStart;
    public movement mv;

    void Start()
    {
        Time.timeScale = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0)) { 
            Time.timeScale = 1;
            tapToStart.text = "";
        }
        if (mv.endGame)
        {
            tapToStart.text = "Tap to Restart";
            if(Input.GetMouseButtonDown(0))
            { 
                SceneManager.LoadScene(SceneManager.GetActiveScene().name); 
            }
                
        }
        if (mv.isWin)
        {
            tapToStart.text = "WIN";
        }
    }

}
