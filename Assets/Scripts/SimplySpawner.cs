using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimplySpawner : MonoBehaviour
{
    [SerializeField] float maxTime = 1;
    float timer;
    [Space]

    [SerializeField] GameObject[] obstacles = new GameObject[2];
    [Space]

    [SerializeField] GameObject wall;
    [SerializeField] float upWall;
    [SerializeField] float downWall;
    [Space]

    [SerializeField] float minUpHeight;
    [SerializeField] float maxUpHeight;
    [Space]

    [SerializeField] float midHeight;
    [Space]

    [SerializeField] float minDownHeight;
    [SerializeField] float maxDownHeight;

    IEnumerator coroutine;

    private void Start()
    {
        //roof wall
        GameObject cloneWall = Instantiate(wall, transform.position, Quaternion.Euler(180, 0, 0));
        cloneWall.transform.position = transform.position + new Vector3(0, upWall, 0);

        //floor wall
        GameObject cloneFloor = Instantiate(wall);
        cloneFloor.transform.position = transform.position + new Vector3(0, downWall, 0);

        coroutine = InstantiateObstacles(2f);
        StartCoroutine(coroutine);
    }

    //void Update()
    //{
    //    if (timer > maxTime)
    //    {
    //        GameObject cloneObstacle = Instantiate(obstacle);
    //        cloneObstacle.transform.position = transform.position + new Vector3(0, Random.Range(-height, height), 0);

    //        Destroy(cloneObstacle, 15);
    //        timer = 0;
    //    }
    //    timer += Time.deltaTime;
    //}


    private void Update()
    {
        
    }

    private void FixedUpdate()
    {
        InstantiateWalls();
        //StartCoroutine(InstantiateObstacles());
    }

    private void InstantiateWalls()
    {
        if (timer > maxTime)
        {
            //roof
            GameObject cloneWall = Instantiate(wall,transform.position,Quaternion.Euler(180,0,0));
            cloneWall.transform.position = transform.position + new Vector3(0, upWall, 0);

            //floor
            GameObject cloneFloor = Instantiate(wall);
            cloneFloor.transform.position = transform.position + new Vector3(0, downWall, 0);

            Destroy(cloneWall, 15);
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
            GameObject cloneObstacle2 = Instantiate(obstacles[0]);
            float up = Random.Range(minUpHeight, maxUpHeight);
            cloneObstacle2.transform.position = transform.position + new Vector3(50, up, 0);
            yield return new WaitForSeconds(Random.Range(0, 2));

            //mid obstacle
            GameObject cloneObstacle = Instantiate(obstacles[1]);
            cloneObstacle.transform.position = transform.position + new Vector3(50, Random.Range(-midHeight, midHeight), 0);
            yield return new WaitForSeconds(Random.Range(1, 2));

            //lover obstacle
            GameObject cloneObstacle3 = Instantiate(obstacles[2]);
            float down = Random.Range(minDownHeight, maxDownHeight);
            cloneObstacle3.transform.position = transform.position + new Vector3(50, down, 0);
            yield return new WaitForSeconds(Random.Range(0, 2));

            //Destroy (cloneObstacle, 15);   
        }
    }
}