using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Play2 : MonoBehaviour
{
    public GameObject[] Villains;
    private GameObject villain1, villain2, villain3, villain4;
    public GameObject star;
    private GameObject Stars;
    private GameObject hero;
    public GameObject[] Heros;

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
    }

    private void Update()
    {
        text_score.text = score.ToString(); //����������� �����
        text_record.text = PlayerPrefs.GetInt("Record2").ToString(); //����������� �������
        text_score_stars.text = PlayerPrefs.GetInt("Stars").ToString(); //����������� ����� �����

        if (score > PlayerPrefs.GetInt("Record2")) PlayerPrefs.SetInt("Record2", score); // ���������� �������

        if (play == false)
        {
            Destroy(hero);
            Panel.SetActive(true);
            if (Panel.transform.position.y < 0 && m == 0) Panel.transform.Translate(Vector3.up * Time.deltaTime * 20, Space.World); //����� ������ ���������
            if (k == 0) //��������, ����� ������ ����������� ������ ���� ���
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
                SceneManager.LoadScene("Level2");
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

    IEnumerator CrateHero() // �������� �������
    {
        yield return new WaitForSeconds(1.5f);

        while (play == true)
        {
            villain1 = Instantiate(Villains[Random.Range(0, Villains.Length)], new Vector3(Random.Range(-2.8f, 2.8f), 5f, -2f), Quaternion.identity) as GameObject; // �������� �����
            villain1.tag = "Hight"; // ���������� ����            
            yield return new WaitForSeconds(Random.Range(0.1f, 1f));

            villain2 = Instantiate(Villains[Random.Range(0, Villains.Length)], new Vector3(Random.Range(-2.8f, 2.8f), -5f, -3f), Quaternion.identity) as GameObject; // �������� �����
            villain2.tag = "Low";            
            yield return new WaitForSeconds(Random.Range(0.1f, 1f));

            villain3 = Instantiate(Villains[Random.Range(0, Villains.Length)], new Vector3(-2.8f, Random.Range(-5f, 5f), -4f), Quaternion.identity) as GameObject; // �������� �����
            villain3.tag = "Right";           
            yield return new WaitForSeconds(Random.Range(0.1f, 1f));

            villain4 = Instantiate(Villains[Random.Range(0, Villains.Length)], new Vector3(2.8f, Random.Range(-5f, 5f), -5f), Quaternion.identity) as GameObject; // �������� �����
            villain4.tag = "Left";            
            yield return new WaitForSeconds(Random.Range(0.1f, 1f));
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

    IEnumerator Delay()
    {
        yield return new WaitForSeconds(3f);
        txt.SetActive(false);
    }
}
