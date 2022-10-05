using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonsPanel : MonoBehaviour
{
    public GameObject[] Hero;
    public GameObject Panel;
    public static int index;
    public int k;    

    private void Start()
    {
        index = 0;
        Hero[0].SetActive(true);
        Hero[1].SetActive(false);
        Hero[2].SetActive(false);
    }

    private void Update()
    {
        //if (Panel.transform.position.y == -1f) Buttons.k = 0;
        if (k == 1 && Panel.transform.position.y > -9f) 
        {
            Panel.transform.Translate(Vector3.down * Time.deltaTime * 20f, Space.World);
            if (Panel.transform.position.y <= -9f)
            {
                Panel.SetActive(false);
                k = 0;
            }
                
        }        
    }

    public void Right()
    {
        if (PlayerPrefs.GetString("Music") == "yes")
            GameObject.Find("Tap").GetComponent<AudioSource>().Play();

        if (index != 2)
        {
            index++;
            Hero[index-1].SetActive(false);
            Hero[index].SetActive(true);
        }
        else if (index == 2)
        {
            index = 0;
            Hero[0].SetActive(true);
            Hero[1].SetActive(false);
            Hero[2].SetActive(false);
        }              
    }

    public void Left()
    {
        if (PlayerPrefs.GetString("Music") == "yes")
            GameObject.Find("Tap").GetComponent<AudioSource>().Play();

        if (index != 0)
        {
            index--;
            Hero[index + 1].SetActive(false);
            Hero[index].SetActive(true);
        }
        else if (index == 0)
        {
            index = 2;
            Hero[0].SetActive(false);
            Hero[1].SetActive(false);
            Hero[2].SetActive(true);
        }
    }

    public void Close()
    {
        if (PlayerPrefs.GetString("Music") == "yes")
            GameObject.Find("Tap").GetComponent<AudioSource>().Play();

        k = 1;        
    }
}
