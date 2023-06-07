using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimplySpawner : MonoBehaviour
{
    [Header("Height and time adjustments")]
    [SerializeField] SpawnerVariables variables;

    [Header("Obstacles")]
    [SerializeField] GameObject[] obstacles = new GameObject[3];
    [Space]

    [Header("Delay between obstacles")]
    [SerializeField] float minDelayTimer = 0f;
    [SerializeField] float maxDelayTimer = 3f;
    IEnumerator coroutine;

    private void Start()
    {
        //obstacles
        coroutine = InstantiateObstacles();
        StartCoroutine(coroutine);
    }

    private IEnumerator InstantiateObstacles()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(minDelayTimer, maxDelayTimer));

            //upper obstacle
            GameObject cloneObstacle1 = Instantiate(obstacles[0]);
            float up = Random.Range(variables.minUpperHeight, variables.maxUpperHeight);
            cloneObstacle1.transform.position = transform.position + new Vector3(50, up, 0);
            yield return new WaitForSeconds(Random.Range(minDelayTimer, maxDelayTimer));

            //mid obstacle
            GameObject cloneObstacle2 = Instantiate(obstacles[1]);
            cloneObstacle2.transform.position = transform.position + new Vector3(50, Random.Range(-variables.midHeight, variables.midHeight), 0);
            yield return new WaitForSeconds(Random.Range(minDelayTimer, maxDelayTimer));

            //lower obstacle
            GameObject cloneObstacle3 = Instantiate(obstacles[2]);
            float down = Random.Range(variables.minLowerHeight, variables.maxLowerHeight);
            cloneObstacle3.transform.position = transform.position + new Vector3(50, down, 0);
            yield return new WaitForSeconds(Random.Range(minDelayTimer, maxDelayTimer));

            Destroy(cloneObstacle1, 15);
            Destroy(cloneObstacle2, 15);
            Destroy(cloneObstacle3, 15);
        }
    }
}