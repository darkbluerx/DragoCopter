using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    [SerializeField] float speed;

    void Update()
    {
        float speedFactor = 2f;
        speed += speedFactor * Time.deltaTime;
    
        transform.position += Vector3.left* speed * Time.deltaTime;
    }
}
