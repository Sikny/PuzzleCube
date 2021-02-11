using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManagerScript : MonoBehaviour
{
    [SerializeField] private Transform cube;
    
    [SerializeField]
    Chrono chrono;
    
    [SerializeField]
    GameObject ball;

    [SerializeField]
    GameObject endgameUI;

    TextMeshProUGUI text;

    Rigidbody rb;
    BallTrigger trigger;

    private void Start()
    {
        text = endgameUI.GetComponent<TextMeshProUGUI>();
        rb = ball.GetComponent<Rigidbody>();
        trigger = ball.GetComponent<BallTrigger>();
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
        //Debug.Log(ball.transform.position);
    }

    void GameOver()
    {
        rb.isKinematic = true;
        text.SetText("Game Over");
    }
    
    void Win()
    {
        text.SetText("Win");
    }

    void nextLvl()
    {
        chrono.ResetCountdown();
        trigger.EndLvl = false;
    }
}
