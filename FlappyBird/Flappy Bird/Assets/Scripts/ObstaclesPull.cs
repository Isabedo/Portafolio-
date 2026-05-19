using UnityEngine;

public class ObstaclesPull : MonoBehaviour
{
    [SerializeField] private GameObject obstaclePrefab;
    [SerializeField] private int poolSize = 5;
    [SerializeField] private float spawnInterval = 2.5f;
    [SerializeField] private float xSpawnPosition = 10f;
    [SerializeField] private float minYPosition = -1.6f;
    [SerializeField] private float maxYPosition = 2.8f;

    private float timeElapsed;
    private int obstacleCount = 0;
    private GameObject[] obstacles;
    void Start()
    {
        obstacles = new GameObject[poolSize];
        for (int i = 0; i < poolSize; i++)
        {
            obstacles[i] = Instantiate(obstaclePrefab);
            obstacles[i].SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        timeElapsed += Time.deltaTime;
        if (timeElapsed > spawnInterval && !GameManager.Instance.isGameOver)
        {
            SpawnObstacle();
        }

    }

    private void SpawnObstacle()
    {
        timeElapsed = 0f;

        float yPosition = Random.Range(minYPosition, maxYPosition);
        Vector2 spawnPosition = new Vector2(xSpawnPosition, yPosition);
        obstacles[obstacleCount].transform.position = spawnPosition;

        if (!obstacles[obstacleCount].activeSelf)
        {
            obstacles[obstacleCount].SetActive(true);
        }

        obstacleCount++;

        if(obstacleCount == poolSize)
        {
            obstacleCount = 0;
        }
    }
}
