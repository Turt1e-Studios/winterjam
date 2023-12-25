using UnityEngine;

public class Powerup : MonoBehaviour
{
    private PlayerController _playerController;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            _playerController = GameObject.Find("Player").GetComponent<PlayerController>();
            _playerController.IncreaseBoost();
            Destroy(gameObject);
        }
    }
}
