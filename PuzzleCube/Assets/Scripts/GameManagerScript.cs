using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManagerScript : MonoBehaviour
{
    [SerializeField]
    Chrono chrono;
    
    [SerializeField]
    GameObject ball;

    [SerializeField]
    GameObject endgameUI;

    TextMeshPro text;

    Rigidbody rb;
    BallTrigger trigger;

    private void Start()
    {
        text = endgameUI.GetComponent<TextMeshPro>();
        rb = ball.GetComponent<Rigidbody>();
        trigger.EndLvl = false;
        trigger.EndStage = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (chrono.Stop())
        {
            GameOver();
        }
        if (trigger.LvlChecked())
        {
            nextLvl();
        }
        if (trigger.PuzzleCleared())
        {
            Win();
        }
    }

    void GameOver()
    {
        rb.isKinematic = false;
        text.text = "Game Over";
    }
    
    void Win()
    {
        rb.isKinematic = false;
        text.text = "Win";
    }

    void nextLvl()
    {
        if (trigger.LvlChecked())
        {
            chrono.ResetCountdown();
        }
    }
}
