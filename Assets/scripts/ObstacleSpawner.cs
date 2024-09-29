
using UnityEngine;
using Random = UnityEngine.Random;

public class ObstacleSpawner : MonoBehaviour
{
    //obstacle infinite production
    public GameObject[] obstacles;
    public float obstaclesSpawnTime = 3f;
    private float nextobstacleSpawnTime;
    public float obstacleSpeed;

    //Increase obstacle speed using curveGraph
    



    private void Update()
    {

        SpawnLoop();

    }


    void SpawnLoop()
    {
        nextobstacleSpawnTime += Time.deltaTime;
        if (nextobstacleSpawnTime >= obstaclesSpawnTime)
        {
            Spawn();
            nextobstacleSpawnTime = 0f;
        }
    }
    void Spawn()

    {

        GameObject obstacleToSpawn = obstacles[Random.Range(0, obstacles.Length)];
        GameObject spawnObstacles = Instantiate(obstacleToSpawn, transform.position, Quaternion.identity);
        Rigidbody2D obstacleRB = spawnObstacles.GetComponent<Rigidbody2D>();

    }
}
    






