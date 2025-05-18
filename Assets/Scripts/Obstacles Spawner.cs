
using UnityEngine;

public class ObstaclesSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] obstacles;
    private bool spawned = false;
    private float spacing = 2f;
    [SerializeField] private ColliderAlert colliderAlert;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (colliderAlert.colliderAlerted)
        {
            if (!spawned)
            {
                for (int i = 0;i<obstacles.Length;i++)
                {
                    float posY = Random.Range(transform.position.y - 2f, transform.position.y + 2f);
                    float posX = transform.position.x + (i * spacing);
                    Vector3 spawnPosition = new Vector3(posX, posY, transform.position.z);
                    Instantiate(obstacles[i],spawnPosition, Quaternion.identity);
                }
                spawned = true;
            }
        }
    }
}
