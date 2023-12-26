using UnityEngine;

public class Powerup : MonoBehaviour
{
    [SerializeField] private int numPresents = 5;
    [SerializeField] private int changeScore = 5;
    [SerializeField] private bool isBoost;
    [SerializeField] private bool isScore;
    private PlayerController _playerController;
    private Score _presents;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            // star boost
            if (isBoost)
            {
                _playerController = GameObject.Find("Player").GetComponent<PlayerController>();
                _playerController.IncreaseBoost();
            }
            else if (isScore) // from snowman
            {
                _presents = GameObject.Find("Score").GetComponent<Score>();
                _presents.ChangeScore(changeScore);
            }
            else // add presents
            {
                _presents = GameObject.Find("PresentsScore").GetComponent<Score>();
                _presents.ChangeScore(numPresents);
            }
            Destroy(gameObject);
        }
    }
}
