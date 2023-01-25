using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    PlayerController playerControllerScript;
    public GameObject Player;
    public GameObject[] ObstaclePrefabs;
    //public GameObject LiczeniePrefab;
    public Vector3 spawnPos = new Vector3(40, 0, 0);
    float startDelay = 2;
    float repeateRate = 2;
    float leftBoundary = -10;
    void Start()
    {
        playerControllerScript = Player.GetComponent<PlayerController>();
        InvokeRepeating("SpawnObstacle", startDelay, repeateRate);
    }

    // Update is called once per frame
    void Update()
    {
  
    }

    void SpawnObstacle()
    {
        if (!playerControllerScript.gameOver)
        {
            int obstacleIndex = Random.Range(0, ObstaclePrefabs.Length);
            Instantiate(ObstaclePrefabs[obstacleIndex], spawnPos, ObstaclePrefabs[obstacleIndex].transform.rotation);
            //Instantiate(LiczeniePrefab, spawnPos, LiczeniePrefab.transform.rotation);

        }
    }
}
