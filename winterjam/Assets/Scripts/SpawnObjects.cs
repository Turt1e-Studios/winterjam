using UnityEngine;

public class SpawnObjects : MonoBehaviour
{
    [SerializeField] private GameObject spawnObj;
    [SerializeField] private float bounds;
    [SerializeField] private float numberObjects;
    [SerializeField] private float heightRange;
    [SerializeField] private bool isOnGround;
    [SerializeField] private bool isRotated;
    private MeshRenderer _renderer;
    private float _size;

    // Start is called before the first frame update
    void Start()
    {
        _renderer = spawnObj.GetComponent<MeshRenderer>();
        _size = _renderer.bounds.size.y / 2;
        for (int i = 0; i < numberObjects; i++)
        {
            if (isOnGround && isRotated)
            {
                Instantiate(spawnObj, new Vector3(Random.Range(-bounds, bounds), 0, Random.Range(-bounds, bounds)), spawnObj.transform.rotation);
            }
            else if (isOnGround)
            {
                Instantiate(spawnObj, new Vector3(Random.Range(-bounds, bounds), _size, Random.Range(-bounds, bounds)), spawnObj.transform.rotation);
            }
            else
            {
                Instantiate(spawnObj, new Vector3(Random.Range(-bounds, bounds), Random.Range(-heightRange, heightRange), Random.Range(-bounds, bounds)), spawnObj.transform.rotation);
            }
            
        }
    }
}
