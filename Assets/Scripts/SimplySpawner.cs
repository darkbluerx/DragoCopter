using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimplySpawner : MonoBehaviour
{
    [SerializeField] SpawnerVariables variables;

    [Header("Timer for walls")]
    [SerializeField] float maxTime = 1;
    float timer;
    [Space]

    [SerializeField] GameObject wall;
    [SerializeField] float roofWallHeight;
    [SerializeField] float floorWallHeight;
    [Space]

    [Header("Obstacles")]
    [SerializeField] GameObject[] obstacles = new GameObject[3];
    [Space]

    [Header("The height of the upper barrier")]
    [SerializeField] float minUpperHeight;
    [SerializeField] float maxUpperHeight;
    [Space]

    [Header("Middle obstacle height")]
    [SerializeField] float midHeight;
    [Space]

    [Header("The height of the lower barrier")]
    [SerializeField] float minLowerHeight;
    [SerializeField] float maxLowerHeight;

    [Header("Timer for obstacles")]
    [SerializeField] float obstaclesTimer = 2f;
    IEnumerator coroutine;

    private void Start()
    {
        //variables = (SpawnerVariables)ScriptableObject.CreateInstance(typeof(SpawnerVariables));

        Debug.Log("minloverH " +variables.minLowerHeight);

        ////roof wall
        //GameObject cloneRoof = Instantiate(wall, transform.position, Quaternion.Euler(180, 0, 0));
        //cloneRoof.transform.position = transform.position + new Vector3(0, roofWallHeight, 0);

        ////floor wall
        //GameObject cloneFloor = Instantiate(wall);
        //cloneFloor.transform.position = transform.position + new Vector3(0, floorWallHeight, 0);
      
        //Destroy(cloneRoof,15);
        //Destroy(cloneFloor, 15);

        //obstacles
        coroutine = InstantiateObstacles(obstaclesTimer);
        StartCoroutine(coroutine);
    }

    private void FixedUpdate()
    {
        //InstantiateWalls();
    }

    private void InstantiateWalls()
    {
        if (timer > maxTime)
        {
            //roof
            GameObject cloneRoof = Instantiate(wall,transform.position,Quaternion.Euler(180,0,0));
            cloneRoof.transform.position = transform.position + new Vector3(10, roofWallHeight, 0);

            //floor
            GameObject cloneFloor = Instantiate(wall);
            cloneFloor.transform.position = transform.position + new Vector3(10, floorWallHeight, 0);

            Destroy(cloneRoof, 15);
            Destroy(cloneFloor, 15);
            timer = 0;  
        }
        timer += Time.deltaTime;
    }

    private IEnumerator InstantiateObstacles(float waitTime)
    {
        while (true)
        {
            //yield return new WaitForSeconds(waitTime);

            yield return new WaitForSeconds(Random.Range(0, 2));

            //upper obstacle
            GameObject cloneObstacle1 = Instantiate(obstacles[0]);
            float up = Random.Range(minUpperHeight, maxUpperHeight);
            cloneObstacle1.transform.position = transform.position + new Vector3(50, up, 0);
            yield return new WaitForSeconds(Random.Range(0, 2));

            //mid obstacle
            GameObject cloneObstacle2 = Instantiate(obstacles[1]);
            cloneObstacle2.transform.position = transform.position + new Vector3(50, Random.Range(-midHeight, midHeight), 0);
            yield return new WaitForSeconds(Random.Range(1, 2));

            //lower obstacle
            GameObject cloneObstacle3 = Instantiate(obstacles[2]);
            float down = Random.Range(minLowerHeight, maxLowerHeight);
            cloneObstacle3.transform.position = transform.position + new Vector3(50, down, 0);
            yield return new WaitForSeconds(Random.Range(0, 2));

            Destroy(cloneObstacle1, 15);
            Destroy(cloneObstacle2, 15);
            Destroy(cloneObstacle3, 15);
        }
    }
}