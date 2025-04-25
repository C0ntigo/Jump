using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager1 : MonoBehaviour
{
    public GameObject normalPlatformPrefab;
    public GameObject advancedPlatformPrefab; 

    public Transform player; 

    public int platformCount = 300;
    public float minDistance = 1.5f;

    private List<Vector2> spawnPositions = new List<Vector2>();
    private List<GameObject> platforms = new List<GameObject>();

    void Start()
    {
        Vector2 spawnPosition = new Vector2();

        for (int i = 0; i < platformCount; i++)
        {
            int attempts = 0;
            bool validPosition = false;

            while (!validPosition && attempts < 100)
            {
                spawnPosition.y += Random.Range(0.5f, 2f);
                spawnPosition.x = Random.Range(-5f, 5f);

                validPosition = true;
                foreach (Vector2 pos in spawnPositions)
                {
                    if (Vector2.Distance(spawnPosition, pos) < minDistance)
                    {
                        validPosition = false;
                        break;
                    }
                }

                attempts++;
            }

            if (validPosition)
            {
                spawnPositions.Add(spawnPosition);
                GameObject newPlatform = Instantiate(
                    normalPlatformPrefab,
                    spawnPosition,
                    Quaternion.identity
                );
                platforms.Add(newPlatform);
            }
        }
    }

    void Update()
    {
        for (int i = platforms.Count - 1; i >= 0; i--)
        {
            GameObject platform = platforms[i];
            if (platform != null && platform.transform.position.y < player.position.y - 10f)
            {
                spawnPositions.Remove((Vector2)platform.transform.position);
                Destroy(platform);
                platforms.RemoveAt(i);

                SpawnNewPlatform();
            }
        }
    }

    void SpawnNewPlatform()
    {
        Vector2 spawnPosition = new Vector2();
        int attempts = 0;
        bool validPosition = false;

        while (!validPosition && attempts < 100)
        {
            spawnPosition.y = player.position.y + Random.Range(5f, 10f); 
            spawnPosition.x = Random.Range(-5f, 5f);

            validPosition = true;
            foreach (Vector2 pos in spawnPositions)
            {
                if (Vector2.Distance(spawnPosition, pos) < minDistance)
                {
                    validPosition = false;
                    break;
                }
            }

            attempts++;
        }

        if (validPosition)
        {
            spawnPositions.Add(spawnPosition);

            GameObject prefabToUse = player.position.y >= 350f
                ? advancedPlatformPrefab
                : normalPlatformPrefab;

            GameObject newPlatform = Instantiate(prefabToUse, spawnPosition, Quaternion.identity);
            platforms.Add(newPlatform);
        }
    }
}
