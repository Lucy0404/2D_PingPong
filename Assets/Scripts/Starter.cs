using UnityEngine;

public class Starter : MonoBehaviour
{
    private GameController gameController;
    private Animator animator;

    
    void Start()
    {
        gameController = FindObjectOfType<GameController>();
        animator = GetComponent<Animator>();
    }

    // Вызывается, чтобы начать обратный отсчет
    public void StartCountdown() 
    {
        // Запускаем анимацию начала обратного отсчета
        animator.SetTrigger("StartCountdown");
    }

    public void StartGame() 
    {
        // Вызываем метод StartGame у GameController для начала игры
        gameController.StartGame();
    }
}
