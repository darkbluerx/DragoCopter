using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField] float maxTime = 1;
    float timer;
    [SerializeField] List<GameObject> obstacleList = new List<GameObject>();
    [SerializeField] float height;

    void Start()
    {
        foreach (GameObject obstacle in obstacleList) 
        {
            int n = Random.Range(0, obstacleList.Count);
            Instantiate(obstacleList[n]);
            obstacle.transform.position = transform.position + new Vector3(0, Random.Range(-height, height), 0);
        }  
    }

    void Update()
    {
        if (timer > maxTime + Random.Range(3, 5))
        {
            //GameObject cloneObstacle = Instantiate(obstacle[Random.RandomRange(0, 2)]);
            //cloneObstacle.transform.position = transform.position + new Vector3(0, Random.Range(-height, height), 0);
            foreach (GameObject obstacle in obstacleList)
            {
                int n = Random.Range(0, obstacleList.Count);
                Instantiate(obstacleList[n]);
                obstacle.transform.position = transform.position + new Vector3(0, Random.Range(-height, height), 0);
                //Destroy(obstacle,15);
            }
            timer = 0;
        }
        timer += Time.deltaTime;
    }
}
