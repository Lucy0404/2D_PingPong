using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameController : MonoBehaviour
{
    public TextMeshProUGUI scoreTextLeft;
    public TextMeshProUGUI scoreTextRight;

    private bool started = false;
    public Starter starter;

    private int scoreLeft;
    private int scoreRight;

    private Vector3 startingPosition;

    private BallController ballController;
    public GameObject ball;

    void Start()
    {
        startingPosition = ball.transform.position;
        ballController = ball.GetComponent<BallController>(); 
    }

    
    void Update()
    {
        if (this.started)
            return;

        if (Input.GetKey(KeyCode.Space))
        {
            this.started = true;
            this.starter.StartCountdown();
        }
    }

    public void StartGame() 
    {
        this.ballController.Go();
    }

    public void ScoreGoalLeft() 
    {
        scoreRight += 1;
        UpdateUI();
        ResetBall();
    }

    public void ScoreGoalRight() 
    {
        scoreLeft += 1;
        UpdateUI();
        ResetBall();
    }


    private void UpdateUI() 
    {
        // Обновляем текст счёта
        this.scoreTextLeft.text = this.scoreLeft.ToString();
        this.scoreTextRight.text = this.scoreRight.ToString();
    }
    
    
    private void ResetBall() 
    {
        this.ballController.Stop();
        this.ball.transform.position = this.startingPosition;
        this.starter.StartCountdown();
    }
}
