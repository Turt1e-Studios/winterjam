using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    private int _score;

    private void Start()
    {
        ChangeScore(0);
    }

    public void ChangeScore(int score)
    {
        _score += score;
        scoreText.text = "Score: " + _score;
    }
}
