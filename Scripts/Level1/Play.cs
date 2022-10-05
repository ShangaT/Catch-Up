using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Play : MonoBehaviour
{  
    public GameObject[] Villains;    
    private GameObject villain1, villain2, villain3, villain4;
    public GameObject star;
    private GameObject Stars;
    public GameObject[] Heros;
    private GameObject hero;
    
    public static bool play;
    int k, m;
    public GameObject Panel;

    public Text text_score, text_score_stars, text_record;
    public GameObject txt;
    public static int score, score_stars;    
        
    void Start()
    {       
        hero = Instantiate(Heros[ButtonsPanel.index], new Vector3(0f, 0f, 0f), Quaternion.identity) as GameObject;
        play = true;
        k = 0;
        m = 0;
        score_stars = PlayerPrefs.GetInt("Stars");

        StartCoroutine(CrateHero());
        StartCoroutine(CrateStars());
        StartCoroutine(ScoreTime());
    }

    private void Update() //выполняется каждый кадр
    {
        text_score.text = score.ToString(); //отображение счета
        text_record.text = PlayerPrefs.GetInt("Record").ToString(); //отображение рекорда
        text_score_stars.text = PlayerPrefs.GetInt("Stars").ToString(); //отображение счета звезд

        if (score > PlayerPrefs.GetInt("Record")) PlayerPrefs.SetInt("Record", score); // обновление рекорда

        if (play == false)
        {
            Destroy(hero);
            Panel.SetActive(true);
            if (Panel.transform.position.y < 0 && m == 0) Panel.transform.Translate(Vector3.up * Time.deltaTime * 20, Space.World); //вылет панели проигрыша          
            
            if (k == 0) //проверка, чтобы музыка проигралась только один раз
            {
                if (PlayerPrefs.GetString("Music") == "yes")
                    GameObject.Find("MusicPanel").GetComponent<AudioSource>().Play();
                k = 1;
            }
        }
        
        if (m == 1)
        {
            if (Panel.transform.position.y > -7f) Panel.transform.Translate(Vector3.down * Time.deltaTime * 20, Space.World);
            else
            {                
                Panel.SetActive(false);                
                SceneManager.LoadScene("Level1");
            }            
        }
    }

    public void Continue()
    {
        if (PlayerPrefs.GetString("Music") == "yes")
            GameObject.Find("Tap").GetComponent<AudioSource>().Play();


        if (PlayerPrefs.GetInt("Stars") >= 100)
        {
            m = 1;
            score_stars -= 100;
            PlayerPrefs.SetInt("Stars", score_stars);
        }
        else
        {
            txt.SetActive(true);
            StartCoroutine(Delay());
        }
    }

    public void Replay()
    {
        if (PlayerPrefs.GetString("Music") == "yes") { }
            GameObject.Find("Tap").GetComponent<AudioSource>().Play();

        m = 1;
        score = 0;
    }

    public void Home()
    {
        if (PlayerPrefs.GetString("Music") == "yes")
            GameObject.Find("Tap").GetComponent<AudioSource>().Play();

        SceneManager.LoadScene("Start");
    }

    void OnGUI()
    {
        if (Input.GetKeyUp(KeyCode.Escape)) SceneManager.LoadScene("Start");
    }

    IEnumerator CrateHero() // создание злодеев
    {
        yield return new WaitForSeconds(1.5f);

        while (play == true)
        {           
            villain1 = Instantiate(Villains[Random.Range(0, Villains.Length)], new Vector3(Random.Range(-3.5f, 3.5f), 5.75f, -2f), Quaternion.identity) as GameObject; // создание героя
            villain1.tag = "Hight"; // присвоение тэга
            if (PlayerPrefs.GetString("Music") == "yes") //звук появления героя
                GameObject.Find("MusicHero").GetComponent<AudioSource>().Play();
            yield return new WaitForSeconds(Random.Range(0.1f, 2f));

            villain2 = Instantiate(Villains[Random.Range(0, Villains.Length)], new Vector3(Random.Range(-3.5f, 3.5f), -5.75f, -3f), Quaternion.identity) as GameObject; // создание героя
            villain2.tag = "Low";
            if (PlayerPrefs.GetString("Music") == "yes")
                GameObject.Find("MusicHero").GetComponent<AudioSource>().Play();
            yield return new WaitForSeconds(Random.Range(0.1f, 2f));

            villain3 = Instantiate(Villains[Random.Range(0, Villains.Length)], new Vector3(-3.5f, Random.Range(-5.75f, 5.75f), -4f), Quaternion.identity) as GameObject; // создание героя
            villain3.tag = "Right";
            if (PlayerPrefs.GetString("Music") == "yes")
                GameObject.Find("MusicHero").GetComponent<AudioSource>().Play();
            yield return new WaitForSeconds(Random.Range(0.1f, 2f));

            villain4 = Instantiate(Villains[Random.Range(0, Villains.Length)], new Vector3(3.5f, Random.Range(-5.75f, 5.75f), -5f), Quaternion.identity) as GameObject; // создание героя
            villain4.tag = "Left";
            if (PlayerPrefs.GetString("Music") == "yes")
                GameObject.Find("MusicHero").GetComponent<AudioSource>().Play();
            yield return new WaitForSeconds(Random.Range(0.1f, 2f));
        }     
    }

    IEnumerator CrateStars()
    {
        while (play == true)
        {
            yield return new WaitForSeconds(Random.Range(3f, 10f));            
            Stars = Instantiate(star, new Vector3(Random.Range(-2.35f, 2.35f), Random.Range(-4.45f, 4.45f), -1f), Quaternion.identity) as GameObject;            
            yield return new WaitForSeconds(3f);
            Destroy(Stars);
        }
    }

    IEnumerator ScoreTime()
    {
        yield return new WaitForSeconds(1.5f);
        while (play == true)
        {
            yield return new WaitForSeconds(1f);
            score++;
        }
    }
    IEnumerator Delay()
    {
        yield return new WaitForSeconds(3f);
        txt.SetActive(false);
    }
}
