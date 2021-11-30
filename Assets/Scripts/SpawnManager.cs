using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    // Main game objects
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject platform;

    // Spawn pozitions and ranges
    private float platformSpawnPosXMin = 20.0f;
    private float platformSpawnPosXMax = 50.0f;
    private float platformSpawnRangeZ = 40.0f;
    private float platformSpawnPosY = 0.6f;

    private Vector3 platformSpawnPos;

    private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        SpawnPlatformAndPlayer();
    }

    // Spawn the platform in a limited area
    void SpawnPlatformAndPlayer()
    {
        platformSpawnPos = new Vector3(Random.Range(platformSpawnPosXMin, platformSpawnPosXMax), platformSpawnPosY,
        Random.Range(-platformSpawnRangeZ, platformSpawnRangeZ));

        Instantiate(platform, platformSpawnPos, platform.transform.rotation);

        SpawnPlayer();
    }

    // Spawn player in the player spawn position
    void SpawnPlayer()
    {
        Vector3 playerSpawnPos = new Vector3(platformSpawnPos.x + 25, platformSpawnPos.y,
         platformSpawnPos.z);

        Instantiate(player, playerSpawnPos, player.transform.rotation);

    }
}
