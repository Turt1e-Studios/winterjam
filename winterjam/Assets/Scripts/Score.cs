using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private string variable;
    private int _score;

    public void ChangeScore(int score)
    {
        _score += score;
        scoreText.text = variable + ": " + _score;
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
