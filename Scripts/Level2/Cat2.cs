using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cat2 : MonoBehaviour
{
    float x, y;
    float s1, s2, s3, s4;
    float min, max;

    //public GameObject Panel;
    void Start()
    {
        min = 1f;
        max = 8f;

        x = Random.Range(-2.8f, 2.8f);
        y = Random.Range(-5f, 5f);

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
            {
                Play2.play = false;
                Destroy(gameObject);
            }                
        }

        if (this.tag == "Low")
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(x, 5.75f, 0), s2 * Time.deltaTime);
            if (this.transform.position.y == 5.75f)
            {
                Play2.play = false;
                Destroy(gameObject);                
            }                
        }

        if (this.tag == "Right")
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(3.5f, y, 0), s3 * Time.deltaTime);
            if (this.transform.position.x == 3.5f)
            {
                Play2.play = false;
                Destroy(gameObject);
            }               
        }

        if (this.tag == "Left")
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(-3.5f, y, 0), s4 * Time.deltaTime);
            if (this.transform.position.x == -3.5f)
            {
                Play2.play = false;
                Destroy(gameObject);
            }                
        }

        //if (Play2.play == false) StartCoroutine(SlowScale());
        
            
        //IEnumerator SlowScale() //анимация появления нероя на сцене
        //{
        //    for (float q = 0.4f; q > 0f; q -= 0.01f)
        //    {
        //        transform.localScale = new Vector3(q, q, q);
        //        yield return new WaitForSeconds(0.01f);
        //    }
        //}
    }
}
