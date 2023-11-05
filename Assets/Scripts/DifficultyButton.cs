using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DifficultyButton : MonoBehaviour
{
    public int difficulty;
    private Button button;
    private GameManager gameManager;
    
    void Start()
    {
        button= GetComponent<Button> ();
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        button.onClick.AddListener(SetDifficulty);
       
        
    }

   
    void Update()
    {
        
    }

    void SetDifficulty()
    {
        //Debug.Log(button.gameObject.name + " was clicked ");
        gameManager.StartGame(difficulty);
    }

}
