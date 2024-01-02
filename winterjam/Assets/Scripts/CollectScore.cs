using UnityEngine;

public class CollectScore : MonoBehaviour
{
    private Score _score;
    // Start is called before the first frame update
    void Start()
    {
        _score = GameObject.Find("Score").GetComponent<Score>();
        _score.ChangeScore(1);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("House"))
        {
            _score.ChangeScore(1);
            Destroy(gameObject);
        }
    }
}
