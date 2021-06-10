using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class slot : MonoBehaviour
{
    public GameObject obj1;
    public GameObject obj2;
    private GameObject obj;
    private MainMenu mm;
    public GameObject turnText;

    public Sprite[] diceSides;
    public GameObject zar1;
    public GameObject zar2;

    public Vector3 locm = new Vector3(0, -2.9f, -3);
    public Vector3 locl = new Vector3(-1.3f, -2.9f, -3);
    public Vector3 locr = new Vector3(1.3f, -2.9f, -3);

    public GameObject rollBtn, skipBtn;

    public int numb1, numb2, p1, p2, oldP1, oldP2;
    public Text tp1, tp2;

    public int coll = 0;
    public int turn = 2;
    public int doneTurn = 1;
    public int n1 = 1;
    public int n2 = 1;
    public int ts = 1;
    public string t1 = null;
    public string t2 = null;


    void Start()
    {
        p1 = 0;
        p2 = 0;
        oldP1 = 0;
        oldP2 = 0;
        t1 = null;
        t2 = null;

        mm = GameObject.FindObjectOfType<MainMenu>();
        diceSides = Resources.LoadAll<Sprite>("Dice/");
        zar1.GetComponent<SpriteRenderer>().sprite = diceSides[5];
    }
    void Update()
    {
        if (turn == 1)
        {
            obj = obj1;
            if (mm.lan == 1)
            {
                turnText.GetComponent<Text>().text = "Turn\nP1"; 
            } else if (mm.lan == 2)
                {
                    turnText.GetComponent<Text>().text = "Sıra\nP1";
                }

        } else if (turn == 2)
            {
                obj = obj2;
            if (mm.lan == 1)
            {
                turnText.GetComponent<Text>().text = "Turn\nP2";
            } else if (mm.lan == 2)
                {
                    turnText.GetComponent<Text>().text = "Sıra\nP2";
                }
        }
    }
    public void RandomGenerate ()
    {
        if (doneTurn == 1)
        {
            soundmanager.PlaySound("gameclick");
            doneTurn = 0;
            rollBtn.SetActive(false);
            StartCoroutine("RollDice");
        }
    }
    
    IEnumerator RollDice()
    {
        for (int i = 0; i <= 19; i++)
        {
            int sideS1 = Random.Range(1, 7);
            int sideS2 = Random.Range(1, 7);
            zar1.GetComponent<SpriteRenderer>().sprite = diceSides[sideS1-1];
            zar2.GetComponent<SpriteRenderer>().sprite = diceSides[sideS2-1];
            yield return new WaitForSeconds(0.05f);
        }
            numb1 = Random.Range(1, n1);
            numb2 = Random.Range(1, n2);
            zar1.GetComponent<SpriteRenderer>().sprite = diceSides[numb1-1];
            zar2.GetComponent<SpriteRenderer>().sprite = diceSides[numb2-1];
            createObj();
            skipBtn.SetActive(true);
    }

    public void Skip()
    {
        rollBtn.SetActive(true);
        skipBtn.SetActive(false);
    }

    public void Skipp()
    {
        if (t1 != null) { Destroy(GameObject.FindGameObjectsWithTag(t1)[0]); }
        if (t2 != null) { Destroy(GameObject.FindGameObjectsWithTag(t2)[0]); }
        t1 = null;
        t2 = null;
        if (turn == 1) { turn = 2; } else if (turn == 2) { turn = 1; }
        doneTurn = 1;
        p1 = oldP1;
        p2 = oldP2;
        soundmanager.PlaySound("gameclick");
        Skip();
    }

    public void createObj()
    {
        oldP1 = p1;
        oldP2 = p2;
        if (numb1 == 1 && numb2 == 1)
        {
            GameObject p11 = Instantiate(obj, locm, Quaternion.identity) as GameObject;
            p11.transform.GetChild(0).localScale = new Vector3(0.25f, 0.25f, 1);
            p11.tag = "p11";
            if (turn == 1) { p1 += 1; } else if (turn == 2) { p2 += 1; }
            t1 = "p11";
        }
        if (numb1 == 1 && numb2 == 2 || numb1 == 2 && numb2 == 1)
        {
            GameObject p12 = Instantiate(obj, locl, Quaternion.identity) as GameObject;
            p12.transform.GetChild(0).localScale = new Vector3(0.25f, 0.5f, 1);
            p12.tag = "p12";
            GameObject p21 = Instantiate(obj, locr, Quaternion.identity) as GameObject;
            p21.transform.GetChild(0).localScale = new Vector3(0.5f, 0.25f, 1);
            p21.tag = "p21";
            if (turn == 1) { p1 += 2; } else if (turn == 2) { p2 += 2; }
            t1 = "p12";
            t2 = "p21";
        }
        if (numb1 == 1 && numb2 == 3 || numb1 == 3 && numb2 == 1)
        {
            GameObject p13 = Instantiate(obj, locl, Quaternion.identity) as GameObject;
            p13.transform.GetChild(0).localScale = new Vector3(0.25f, 0.75f, 1);
            p13.tag = "p13";
            GameObject p31 = Instantiate(obj, locr, Quaternion.identity) as GameObject;
            p31.transform.GetChild(0).localScale = new Vector3(0.75f, 0.25f, 1);
            p31.tag = "p31";
            if (turn == 1) { p1 += 3; } else if (turn == 2) { p2 += 3; }
            t1 = "p13";
            t2 = "p31";
        }
        if (numb1 == 1 && numb2 == 4 || numb1 == 4 && numb2 == 1)
        {
            GameObject p14 = Instantiate(obj, locl, Quaternion.identity) as GameObject;
            p14.transform.GetChild(0).localScale = new Vector3(0.25f, 1f, 1);
            p14.tag = "p14";
            GameObject p41 = Instantiate(obj, locr, Quaternion.identity) as GameObject;
            p41.transform.GetChild(0).localScale = new Vector3(1f, 0.25f, 1);
            p41.tag = "p41";
            if (turn == 1) { p1 += 4; } else if (turn == 2) { p2 += 4; }
            t1 = "p14";
            t2 = "p41";
        }
        if (numb1 == 1 && numb2 == 5 || numb1 == 5 && numb2 == 1)
        {
            GameObject p15 = Instantiate(obj, locl, Quaternion.identity) as GameObject;
            p15.transform.GetChild(0).localScale = new Vector3(0.25f, 1.25f, 1);
            p15.tag = "p15";
            GameObject p51 = Instantiate(obj, locr, Quaternion.identity) as GameObject;
            p51.transform.GetChild(0).localScale = new Vector3(1.25f, 0.25f, 1);
            p51.tag = "p51";
            if (turn == 1) { p1 += 5; } else if (turn == 2) { p2 += 5; }
            t1 = "p15";
            t2 = "p51";
        }
        if (numb1 == 1 && numb2 == 6 || numb1 == 6 && numb2 == 1)
        {
            GameObject p16 = Instantiate(obj, locl, Quaternion.identity) as GameObject;
            p16.transform.GetChild(0).localScale = new Vector3(0.25f, 1.5f, 1);
            p16.tag = "p16";
            GameObject p61 = Instantiate(obj, locr, Quaternion.identity) as GameObject;
            p61.transform.GetChild(0).localScale = new Vector3(1.5f, 0.25f, 1);
            p61.tag = "p61";
            if (turn == 1) { p1 += 6; } else if (turn == 2) { p2 += 6; }
            t1 = "p16";
            t2 = "p61";
        }

        if (numb1 == 2 && numb2 == 2)
        {
            GameObject p22 = Instantiate(obj, locm, Quaternion.identity) as GameObject;
            p22.transform.GetChild(0).localScale = new Vector3(0.5f, 0.5f, 1);
            p22.tag = "p22";
            if (turn == 1) { p1 += 4; } else if (turn == 2) { p2 += 4; }
            t1 = "p22";
        }
        if (numb1 == 2 && numb2 == 3 || numb1 == 3 && numb2 == 2)
        {
            GameObject p23 = Instantiate(obj, locl, Quaternion.identity) as GameObject;
            p23.transform.GetChild(0).localScale = new Vector3(0.5f, 0.75f, 1);
            p23.tag = "p23";
            GameObject p32 = Instantiate(obj, locr, Quaternion.identity) as GameObject;
            p32.transform.GetChild(0).localScale = new Vector3(0.75f, 0.5f, 1);
            p32.tag = "p32";
            if (turn == 1) { p1 += 6; } else if (turn == 2) { p2 += 6; }
            t1 = "p23";
            t2 = "p32";
        }
        if (numb1 == 2 && numb2 == 4 || numb1 == 4 && numb2 == 2)
        {
            GameObject p24 = Instantiate(obj, locl, Quaternion.identity) as GameObject;
            p24.transform.GetChild(0).localScale = new Vector3(0.5f, 1f, 1);
            p24.tag = "p24";
            GameObject p42 = Instantiate(obj, locr, Quaternion.identity) as GameObject;
            p42.transform.GetChild(0).localScale = new Vector3(1f, 0.5f, 1);
            p42.tag = "p42";
            if (turn == 1) { p1 += 8; } else if (turn == 2) { p2 += 8; }
            t1 = "p24";
            t2 = "p42";
        }
        if (numb1 == 2 && numb2 == 5 || numb1 == 5 && numb2 == 2)
        {
            GameObject p25 = Instantiate(obj, locl, Quaternion.identity) as GameObject;
            p25.transform.GetChild(0).localScale = new Vector3(0.5f, 1.25f, 1);
            p25.tag = "p25";
            GameObject p52 = Instantiate(obj, locr, Quaternion.identity) as GameObject;
            p52.transform.GetChild(0).localScale = new Vector3(1.25f, 0.5f, 1);
            p52.tag = "p52";
            if (turn == 1) { p1 += 10; } else if (turn == 2) { p2 += 10; }
            t1 = "p25";
            t2 = "p52";
        }
        if (numb1 == 2 && numb2 == 6 || numb1 == 6 && numb2 == 2)
        {
            GameObject p26 = Instantiate(obj, locl, Quaternion.identity) as GameObject;
            p26.transform.GetChild(0).localScale = new Vector3(0.5f, 1.5f, 1);
            p26.tag = "p26";
            GameObject p62 = Instantiate(obj, locr, Quaternion.identity) as GameObject;
            p62.transform.GetChild(0).localScale = new Vector3(1.5f, 0.5f, 1);
            p62.tag = "p62";
            if (turn == 1) { p1 += 12; } else if (turn == 2) { p2 += 12; }
            t1 = "p26";
            t2 = "p62";
        }

        if (numb1 == 3 && numb2 == 3)
        {
            GameObject p33 = Instantiate(obj, locm, Quaternion.identity) as GameObject;
            p33.transform.GetChild(0).localScale = new Vector3(0.75f, 0.75f, 1);
            p33.tag = "p33";
            if (turn == 1) { p1 += 9; } else if (turn == 2) { p2 += 9; }
            t1 = "p33";
        }
        if (numb1 == 3 && numb2 == 4 || numb1 == 4 && numb2 == 3)
        {
            GameObject p34 = Instantiate(obj, locl, Quaternion.identity) as GameObject;
            p34.transform.GetChild(0).localScale = new Vector3(0.75f, 1f, 1);
            p34.tag = "p34";
            GameObject p43 = Instantiate(obj, locr, Quaternion.identity) as GameObject;
            p43.transform.GetChild(0).localScale = new Vector3(1f, 0.75f, 1);
            p43.tag = "p43";
            if (turn == 1) { p1 += 12; } else if (turn == 2) { p2 += 12; }
            t1 = "p34";
            t2 = "p43";
        }
        if (numb1 == 3 && numb2 == 5 || numb1 == 5 && numb2 == 3)
        {
            GameObject p35 = Instantiate(obj, locl, Quaternion.identity) as GameObject;
            p35.transform.GetChild(0).localScale = new Vector3(0.75f, 1.25f, 1);
            p35.tag = "p35";
            GameObject p53 = Instantiate(obj, locr, Quaternion.identity) as GameObject;
            p53.transform.GetChild(0).localScale = new Vector3(1.25f, 0.75f, 1);
            p53.tag = "p53";
            if (turn == 1) { p1 += 15; } else if (turn == 2) { p2 += 15; }
            t1 = "p35";
            t2 = "p53";
        }
        if (numb1 == 3 && numb2 == 6 || numb1 == 6 && numb2 == 3)
        {
            GameObject p36 = Instantiate(obj, locl, Quaternion.identity) as GameObject;
            p36.transform.GetChild(0).localScale = new Vector3(0.75f, 1.5f, 1);
            p36.tag = "p36";
            GameObject p63 = Instantiate(obj, locr, Quaternion.identity) as GameObject;
            p63.transform.GetChild(0).localScale = new Vector3(1.5f, 0.75f, 1);
            p63.tag = "p63";
            if (turn == 1) { p1 += 18; } else if (turn == 2) { p2 += 18; }
            t1 = "p36";
            t2 = "p63";
        }

        if (numb1 == 4 && numb2 == 4)
        {
            GameObject p44 = Instantiate(obj, locm, Quaternion.identity) as GameObject;
            p44.transform.GetChild(0).localScale = new Vector3(1f, 1f, 1);
            p44.tag = "p44";
            if (turn == 1) { p1 += 16; } else if (turn == 2) { p2 += 16; }
            t1 = "p44";
        }
        if (numb1 == 4 && numb2 == 5 || numb1 == 5 && numb2 == 4)
        {
            GameObject p45 = Instantiate(obj, locl, Quaternion.identity) as GameObject;
            p45.transform.GetChild(0).localScale = new Vector3(1f, 1.25f, 1);
            p45.tag = "p45";
            GameObject p54 = Instantiate(obj, locr, Quaternion.identity) as GameObject;
            p54.transform.GetChild(0).localScale = new Vector3(1.25f, 1f, 1);
            p54.tag = "p54";
            if (turn == 1) { p1 += 20; } else if (turn == 2) { p2 += 20; }
            t1 = "p45";
            t2 = "p54";
        }
        if (numb1 == 4 && numb2 == 6 || numb1 == 6 && numb2 == 4)
        {
            GameObject p46 = Instantiate(obj, locl, Quaternion.identity) as GameObject;
            p46.transform.GetChild(0).localScale = new Vector3(1f, 1.5f, 1);
            p46.tag = "p46";
            GameObject p64 = Instantiate(obj, locr, Quaternion.identity) as GameObject;
            p64.transform.GetChild(0).localScale = new Vector3(1.5f, 1f, 1);
            p64.tag = "p64";
            if (turn == 1) { p1 += 24; } else if (turn == 2) { p2 += 24; }
            t1 = "p46";
            t2 = "p64";
        }

        if (numb1 == 5 && numb2 == 5)
        {
            GameObject p55 = Instantiate(obj, locm, Quaternion.identity) as GameObject;
            p55.transform.GetChild(0).localScale = new Vector3(1.25f, 1.25f, 1);
            p55.tag = "p55";
            if (turn == 1) { p1 += 25; } else if (turn == 2) { p2 += 25; }
            t1 = "p55";
        }
        if (numb1 == 5 && numb2 == 6 || numb1 == 6 && numb2 == 5)
        {
            GameObject p56 = Instantiate(obj, locl, Quaternion.identity) as GameObject;
            p56.transform.GetChild(0).localScale = new Vector3(1.25f, 1.5f, 1);
            p56.tag = "p56";
            GameObject p65 = Instantiate(obj, locr, Quaternion.identity) as GameObject;
            p65.transform.GetChild(0).localScale = new Vector3(1.5f, 1.25f, 1);
            p65.tag = "p65";
            if (turn == 1) { p1 += 30; } else if (turn == 2) { p2 += 30; }
            t1 = "p56";
            t2 = "p65";
        }

        if (numb1 == 6 && numb2 == 6)
        {
            GameObject p66 = Instantiate(obj, locm, Quaternion.identity) as GameObject;
            p66.transform.GetChild(0).localScale = new Vector3(1.5f, 1.5f, 1);
            p66.tag = "p66";
            if (turn == 1) { p1 += 36; } else if (turn == 2) { p2 += 36; }
            t1 = "p66";
        }
    }

    public void Point()
    {
        if (turn == 1)
            {
                tp1.text = "P1: " + p1.ToString();
            }
        else if (turn == 2)
        {
            tp2.text = "P2: " + p2.ToString();
        }
    }
}