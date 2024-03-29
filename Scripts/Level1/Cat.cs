using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cat : MonoBehaviour
{
    bool mouse;

    private void Start()
    {        
        StartCoroutine(SlowScale());
    }

    private void OnMouseDown()
    {
        mouse = true;
    }
    private void OnMouseUp()
    {
        mouse = false;
    }

    void Update()
    {
        if (mouse == true)
        {
            Vector3 MousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 2f);
            this.transform.position = Camera.main.ScreenToWorldPoint(MousePosition);
        }
    }

    IEnumerator SlowScale() //�������� ��������� ����� �� �����
    {
        for (float q = 0f; q < 0.45f; q += 0.01f) 
        {
            transform.localScale = new Vector3(q, q, q);
            yield return new WaitForSeconds(0.01f);
        }
    }

    void OnCollisionEnter2D(Collision2D coll) // ��������������� � ������ ����������
    {
        if (coll.gameObject.tag == "Hight" || coll.gameObject.tag == "Low" || coll.gameObject.tag == "Right" || coll.gameObject.tag == "Left")
        {
            Destroy(gameObject);
            Play.play = false;
        }
            
        if (coll.gameObject.tag == "Star")
        {
            if (PlayerPrefs.GetString("Music") == "yes")
                GameObject.Find("MusicStars").GetComponent<AudioSource>().Play();
            Destroy(coll.gameObject);
            Play.score_stars++;
            PlayerPrefs.SetInt("Stars", Play.score_stars);
        }
    }
}
