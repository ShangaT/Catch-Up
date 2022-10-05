using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dogs : MonoBehaviour
{
    float x, y;
    float s1, s2, s3, s4;
    float min, max;

    //public GameObject Panel;
    void Start()
    {
        min = 2f;
        max = 6f;

        x = Random.Range(-3.5f, 3.5f);
        y = Random.Range(-5.75f, 5.75f);

        s1 = Random.Range(min, max);
        s2 = Random.Range(min, max);
        s3 = Random.Range(min, max);
        s4 = Random.Range(min, max);
    }

    void Update()
    {
        if (this.tag == "Hight")
        {                   
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(x, -5.75f, 0), s1 * Time.deltaTime);
            if (this.transform.position.y == -5.75f) 
                Destroy(gameObject);            
        }

        if (this.tag == "Low")
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(x, 5.75f, 0), s2 * Time.deltaTime);
            if (this.transform.position.y == 5.75f) 
                Destroy(gameObject);            
        }

        if (this.tag == "Right")
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(3.5f, y, 0), s3 * Time.deltaTime);
            if (this.transform.position.x == 3.5f) 
                Destroy(gameObject);            
        }

        if (this.tag == "Left")
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(-3.5f, y, 0), s4 * Time.deltaTime);
            if (this.transform.position.x == -3.5f) 
                Destroy(gameObject);           
        }        
    }
}
