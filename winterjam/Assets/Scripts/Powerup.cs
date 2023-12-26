using UnityEngine;

public class Powerup : MonoBehaviour
{
    [SerializeField] private int numPresents = 5;
    [SerializeField] private bool isBoost;
    private PlayerController _playerController;
    private Score _presents;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (isBoost)
            {
                _playerController = GameObject.Find("Player").GetComponent<PlayerController>();
                _playerController.IncreaseBoost();
            }
            else
            {
                // todo: not sure if intersection
                _presents = GameObject.Find("Presents").GetComponent<Score>();
                _presents.ChangeScore(numPresents);
            }
            Destroy(gameObject);
        }
    }
}
