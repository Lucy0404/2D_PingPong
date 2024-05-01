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

    // ����������, ����� ������ �������� ������
    public void StartCountdown() 
    {
        // ��������� �������� ������ ��������� �������
        animator.SetTrigger("StartCountdown");
    }

    public void StartGame() 
    {
        // �������� ����� StartGame � GameController ��� ������ ����
        gameController.StartGame();
    }
}
