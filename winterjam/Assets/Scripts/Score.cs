using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    [SerializeField] private GameObject gameOverScreenObject;
    [SerializeField] private TextMeshProUGUI scoreText; // UI element
    [SerializeField] private string variable; // what is being kept track of
    [SerializeField] private bool finalScore; // the actual score of the game
    private int _score;

    public void ChangeScore(int score)
    {
        _score += score;
        scoreText.text = variable + ": " + _score;
        if (finalScore && _score >= 100)
        {
            gameOverScreenObject.GetComponent<GameOver>().FinishGame();
        }
    }

    public int GetScore()
    {
        return _score;
    }
    
    private void Start()
    {
        ChangeScore(0);
    }
}
