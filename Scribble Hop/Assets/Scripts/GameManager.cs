using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject platformPrefab;

    public int platformCount = 300;
    public float minDistance = 1.5f; 

    private List<Vector2> spawnPositions = new List<Vector2>();

    
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
                Instantiate(platformPrefab, spawnPosition, Quaternion.identity);
            }
        }
    }
}
