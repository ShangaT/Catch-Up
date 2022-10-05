using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Buttons : MonoBehaviour
{
    public GameObject panel_cat, panel_dog;    
    int stars;
    public Sprite on, off;
    public Text record_cat, record_dog, score_stars;
    public GameObject Tap;
    public GameObject PanelQuestion;
    private int k = 0;    

    void Start()
    {
        if (record_cat != null && record_dog != null && score_stars != null)
        {
            record_cat.text = PlayerPrefs.GetInt("Record").ToString();
            record_dog.text = PlayerPrefs.GetInt("Record2").ToString();
            score_stars.text = PlayerPrefs.GetInt("Stars").ToString();
        }        

        if (PlayerPrefs.GetString("Music") == null) GameObject.Find("Music").GetComponent<Image>().sprite = on;

        if (on != null && off != null)
        {
            if (PlayerPrefs.GetString("Music") == "yes") GameObject.Find("Music").GetComponent<Image>().sprite = on;
            else if (PlayerPrefs.GetString("Music") == "no") GameObject.Find("Music").GetComponent<Image>().sprite = off;
        }

        if (Tap != null) DontDestroyOnLoad(Tap);
    }

    private void Update()
    {
        if (panel_cat != null && panel_dog != null && PanelQuestion != null)
        if (k == 1)
        {
            if (panel_cat.transform.position.y < -1f) panel_cat.transform.Translate(Vector3.up * Time.deltaTime * 20, Space.World);
            else k = 0;
        }
        if (k == 2)
        {
            if (panel_dog.transform.position.y < -1f) panel_dog.transform.Translate(Vector3.up * Time.deltaTime * 20, Space.World);
            else k = 0;
        }
        if (k == 3)
        {
            if (PanelQuestion.transform.position.y < -1f) PanelQuestion.transform.Translate(Vector3.up * Time.deltaTime * 20, Space.World);
            else k = 0;
        }                
        if (k == 4 && PanelQuestion.transform.position.y > -9f)
        {
            PanelQuestion.transform.Translate(Vector3.down * Time.deltaTime * 20, Space.World);
            if (PanelQuestion.transform.position.y <= -9f) PanelQuestion.SetActive(false);
        }        
    }    

    public void Ads()
    {
        if (PlayerPrefs.GetString("Music") == "yes")
            GameObject.Find("Tap").GetComponent<AudioSource>().Play();

        stars = PlayerPrefs.GetInt("Stars");
        stars += 5;
        PlayerPrefs.SetInt("Stars", stars);
        score_stars.text = PlayerPrefs.GetInt("Stars").ToString();
    }

    public void PanelCats()
    {
        if (PlayerPrefs.GetString("Music") == "yes")
            GameObject.Find("Tap").GetComponent<AudioSource>().Play();

        panel_cat.SetActive(true);
        k = 1;
    }

    public void PanelDogs()
    {
        if (PlayerPrefs.GetString("Music") == "yes")
            GameObject.Find("Tap").GetComponent<AudioSource>().Play();

        panel_dog.SetActive(true);
        k = 2;
    }    

    public void Replay()
    {
        if (PlayerPrefs.GetString("Music") == "yes")
            GameObject.Find("Tap").GetComponent<AudioSource>().Play();

        Play.score = 0;
        SceneManager.LoadScene("Level1");
    }    

    public void Replay2()
    {
        if (PlayerPrefs.GetString("Music") == "yes")
            GameObject.Find("Tap").GetComponent<AudioSource>().Play();

        Play2.score = 0;
        SceneManager.LoadScene("Level2");
    }    
    
    public void Music()
    {
        if (PlayerPrefs.GetString("Music") == "yes")
        {
            PlayerPrefs.SetString("Music", "no");
            GameObject.Find("Music").GetComponent<Image>().sprite = off;
        }
        else
        {          
            PlayerPrefs.SetString("Music", "yes");
            GameObject.Find("Music").GetComponent<Image>().sprite = on;

            if (PlayerPrefs.GetString("Music") == "yes")
                GameObject.Find("Tap").GetComponent<AudioSource>().Play();
        }
    }

    public void Question()
    {
        if (PlayerPrefs.GetString("Music") == "yes")
            GameObject.Find("Tap").GetComponent<AudioSource>().Play();

        PanelQuestion.SetActive(true);
        k = 3;
    }

    public void QuestionClose()
    {
        if (PlayerPrefs.GetString("Music") == "yes")
            GameObject.Find("Tap").GetComponent<AudioSource>().Play();
        k = 4;        
    }

    void OnGUI()
    {
        if (Input.GetKeyUp(KeyCode.Escape)) Application.Quit();
    }
}
