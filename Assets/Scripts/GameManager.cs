using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    static public GameManager instance;

    public TMP_Text scoreText;

    private int score;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        instance = this;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }


    public void UpdateScore(int pScore)
    {
        Debug.Log("points added");
        score += pScore;
        scoreText.text = "Score: " + score;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
