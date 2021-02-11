using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using Vuforia;

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

    public VuforiaBehaviour vuforiaBehaviour;

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

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
