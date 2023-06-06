using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class HelicopterController : MonoBehaviour
{

    Rigidbody2D rb;

    [SerializeField] float velocity = 10f;


    private void Awake()
    {
       rb = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        //laita painalluksella ja pyyhk‰isyll‰

        if(Input.GetMouseButtonDown(0)) 
        {
            //rb.AddForce(transform.up * speed, ForceMode2D.Impulse);
            rb.velocity = Vector2.up * velocity;
            Debug.Log("Lent‰‰");
        }
    }


}
