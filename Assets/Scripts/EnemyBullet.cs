using UnityEngine;
using UnityEngine.UI;

public class EnemyBullet : MonoBehaviour
{
    private int playerScore;
    public Text scoreText;

    private bool passed;

    void Start()
    {
        scoreText = GameObject.FindGameObjectWithTag("ScoreText").GetComponent<Text>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Hit");
        addScore(1);
    }

    private void addScore(int scoreToAdd)
    {
        if (!passed){
           playerScore += scoreToAdd;
           scoreText.text = playerScore.ToString();
        }
           passed = true;
           Invoke("resetPassed", 5);
    }

    void resetPassed(){
        passed = false;
    }
}
