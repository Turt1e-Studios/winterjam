using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    [SerializeField] private GameObject text;
    [SerializeField] private TextMeshProUGUI timeText;

    private float _initialTime;
    // Start is called before the first frame update
    void Start()
    {
        _initialTime = Time.time;
    }

    public void FinishGame()
    {
        gameObject.SetActive(true);
        text.SetActive(false);
        double elapsedTime = Math.Round(Time.time - _initialTime, 2);
        timeText.text = "Time elapsed: " + elapsedTime + " seconds";
        GameObject.Find("Player").GetComponent<PlayerController>().enabled = false;
        GameObject.Find("Score").GetComponent<Score>().enabled = false;
    }
    
    public void RestartButton()
    {
        _initialTime = Time.time;
        SceneManager.LoadScene("Game");
    }

    public void ExitButton()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
