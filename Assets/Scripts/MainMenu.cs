using System;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using TMPro;

public class MainMenu : MonoBehaviour
{
    public int gameCount = 0;

    public GameObject griid;
    public GameObject coll;
    private slot sloot;
    private DragAndDrop dad;
    private AdsManager ads;

    public int lan = 1;
    public float xFactor;

    public GameObject gr1;
    public GameObject gr2;
    public GameObject gr3;
    public GameObject gr4;
    public GameObject tl1;
    public GameObject tl2;
    public GameObject tl3;
    public GameObject tl4;
    public GameObject tl5;
    public GameObject tl6;

    public GameObject l1;
    public GameObject l2;

    public GameObject col;
    public GameObject colll;

    public Vector2 dragScale = new Vector2(0.25f, 0.25f);
    public Vector2 gridSizee = new Vector2(4f, 4f);
    public Vector3 grd = new Vector3(0, 1, 99);

    private const string SAVE_SEPERATOR = "#-SAVE-#";

    public GameObject o1; //start
    public GameObject o2; //options
    public GameObject o3; //credits
    public GameObject o4; //exit
    public GameObject o5; //optionsmenu
    public GameObject o6; //selectgridsize
    public GameObject o7; //selecttilesize
    public GameObject o8; //selectlanguage
    public GameObject o9; //sleectp1color
    public GameObject o10; //selectp2color
    public GameObject o11; //optionsback
    public GameObject o12; //creditsmenu
    public GameObject o13; //creditsback
    public GameObject o14; //rolldice
    public GameObject o15; //skip
    public GameObject o16; //gameendback
    public GameObject o17; //menuSure
    public GameObject o18; //continue

    private TextMeshProUGUI txt1;
    private TextMeshProUGUI txt2;
    private TextMeshProUGUI txt3;
    private TextMeshProUGUI txt4;
    private TextMeshProUGUI txt5;
    private TextMeshProUGUI txt6;
    private TextMeshProUGUI txt7;
    private TextMeshProUGUI txt8;
    private TextMeshProUGUI txt9;
    private TextMeshProUGUI txt10;
    private TextMeshProUGUI txt11;
    private TextMeshProUGUI txt12;
    private TextMeshProUGUI txt13;
    private Text txt14;
    private Text txt15;
    private TextMeshProUGUI txt16;
    private TextMeshProUGUI txt17;
    private TextMeshProUGUI txt18;

    void Start()
    {
        Screen.SetResolution(720, 1280, true);

        sloot = GameObject.FindObjectOfType<slot>();
        dad = GameObject.FindObjectOfType<DragAndDrop>();
        ads = GameObject.FindObjectOfType<AdsManager>();

        txt1 = o1.GetComponent<TextMeshProUGUI>();
        txt2 = o2.GetComponent<TextMeshProUGUI>();
        txt3 = o3.GetComponent<TextMeshProUGUI>();
        txt4 = o4.GetComponent<TextMeshProUGUI>();
        txt5 = o5.GetComponent<TextMeshProUGUI>();
        txt6 = o6.GetComponent<TextMeshProUGUI>();
        txt7 = o7.GetComponent<TextMeshProUGUI>();
        txt8 = o8.GetComponent<TextMeshProUGUI>();
        txt9 = o9.GetComponent<TextMeshProUGUI>();
        txt10 = o10.GetComponent<TextMeshProUGUI>();
        txt11 = o11.GetComponent<TextMeshProUGUI>();
        txt12 = o12.GetComponent<TextMeshProUGUI>();
        txt13 = o13.GetComponent<TextMeshProUGUI>();
        txt14 = o14.GetComponent<Text>();
        txt15 = o15.GetComponent<Text>();
        txt16 = o16.GetComponent<TextMeshProUGUI>();
        txt17 = o17.GetComponent<TextMeshProUGUI>();
        txt18 = o18.GetComponent<TextMeshProUGUI>();

        griid.SetActive(false);

        Load();
    }

    void Update()
    {
        if (gameCount == 4)
        {
            gameCount = 0;
            Save();
            ads.interstitialGosterilecek = true;
        }
    }

    public void Play()
    {
        griid.transform.position = grd;
        griid.SetActive(true);
        float sizeX = griid.GetComponent<Grid>().gridSize.x;
        float sizeY = griid.GetComponent<Grid>().gridSize.y;
        float gs = griid.GetComponent<Grid>().gs;
        if (gs == 1) { colll.transform.position = new Vector2(-1.5f, 3.5f); xFactor = 1; } else if (gs == 2 && sizeX == 4) { colll.transform.position = new Vector2(-1.75f, 3.75f); xFactor = 0.5f; } else if (gs == 2 && sizeX == 5) { colll.transform.position = new Vector2(-2.25f, 3.75f); xFactor = 0.5f; } else if (gs == 4) { colll.transform.position = new Vector2(-2.375f, 3.875f); xFactor = 0.25f; }

        for (int x = 0; x < (sizeX * gs); x++)
        {
            for (int y = 0; y < (sizeY * gs); y++)
            {
                GameObject colObj = Instantiate(col);
                colObj.transform.parent = colll.transform;
                colObj.transform.localPosition = new Vector2(x * xFactor, -y * xFactor);
                //colObj.transform.position = new Vector2((-(0.25f * (sizeX * gs / 2 - 0.5f)) + x*0.25f), ((0.25f * (sizeY * gs / 2 - 0.5f)) + (2 * gs * 0.25f) - y*0.25f - sizeX + 4)) * 4/gs;
            }
        }
    }

    public void Credits()
    {
        soundmanager.PlaySound("menuclick");
    }

    public void Language()
    {
        soundmanager.PlaySound("menuclick");
        var go = EventSystem.current.currentSelectedGameObject;

        if (go.tag == "l1")
        {
            lan = 1;
            l1.GetComponent<Button>().interactable = false;
            l2.GetComponent<Button>().interactable = true;

            txt1.SetText("Play");
            txt2.SetText("Options");
            txt3.SetText("Credits");
            txt4.SetText("Quit");
            txt5.SetText("OPTIONS");
            txt6.SetText("Grid Size");
            txt7.SetText("Max Tile Size");
            txt8.SetText("Language");
            txt9.SetText("P1 Block Color");
            txt10.SetText("P2 Block Color");
            txt11.SetText("Back");
            txt12.SetText("CREDITS");
            txt13.SetText("Back");
            txt14.text = "Roll Dice";
            txt15.text = "Skip";
            txt16.SetText("Back");
            txt17.SetText("Do you want to go back to menu?");
            txt18.SetText("Continue");
            griid.GetComponent<Grid>().lang = 1;
        }
        else if (go.tag == "l2")
        {
            lan = 2;
            l1.GetComponent<Button>().interactable = true;
            l2.GetComponent<Button>().interactable = false;

            txt1.SetText("Oyna");
            txt2.SetText("Ayarlar");
            txt3.SetText("Emekçiler");
            txt4.SetText("Çık");
            txt5.SetText("AYARLAR");
            txt6.SetText("Oyun Tahtası");
            txt7.SetText("Parça Büyüklüğü");
            txt8.SetText("Oyun Dili");
            txt9.SetText("1. Oyuncu Blok Rengi");
            txt10.SetText("2. Oyuncu Blok Rengi");
            txt11.SetText("Geri");
            txt12.SetText("EMEKÇİLER");
            txt13.SetText("Geri");
            txt14.text = "Zar At";
            txt15.text = "Pas Geç";
            txt16.SetText("Geri");
            txt17.SetText("Menüye dönmek istiyor musun?");
            txt18.SetText("Devam Et");
            griid.GetComponent<Grid>().lang = 2;
        }
    }

    public void Back()
    {
        GameObject[] dest;

        dest = GameObject.FindGameObjectsWithTag("Destroyable");

        foreach (var i in dest)
            Destroy(i);
        
        Save();

        SceneManager.LoadScene("game");
    }

    public void QuitGame()
    {
        soundmanager.PlaySound("menuclick");
        Application.Quit();
    }

    public void GrSize()
    {
        var go = EventSystem.current.currentSelectedGameObject;
        soundmanager.PlaySound("menuclick");

        if (go.tag == "gs1")
        {   
            grd = new Vector3(0, 2, 99);
            griid.GetComponent<Grid>().gridSize = new Vector2(4, 4);
            griid.GetComponent<Grid>().gs = 1;
            sloot.ts = 1;
            sloot.n1 = 2;
            sloot.n2 = 2;
            gr1.GetComponent<Button>().interactable = false;
            gr2.GetComponent<Button>().interactable = true;
            gr3.GetComponent<Button>().interactable = true;
            gr4.GetComponent<Button>().interactable = true;
            tl1.GetComponent<Button>().interactable = false;
            tl2.GetComponent<Button>().interactable = true;
            tl3.GetComponent<Button>().interactable = true;
            tl4.GetComponent<Button>().interactable = true;
            tl5.GetComponent<Button>().interactable = true;
            tl6.GetComponent<Button>().interactable = true;
            tl4.SetActive(false);
            tl5.SetActive(false);
            tl6.SetActive(false);
} else if (go.tag == "gs2")
        {
            grd = new Vector3(0, 2, 99);
            griid.GetComponent<Grid>().gridSize = new Vector2(4, 4);
            griid.GetComponent<Grid>().gs = 2;
            sloot.ts = 2;
            sloot.n1 = 2;
            sloot.n2 = 2;
            gr2.GetComponent<Button>().interactable = false;
            gr1.GetComponent<Button>().interactable = true;
            gr3.GetComponent<Button>().interactable = true;
            gr4.GetComponent<Button>().interactable = true;
            tl1.GetComponent<Button>().interactable = false;
            tl2.GetComponent<Button>().interactable = true;
            tl3.GetComponent<Button>().interactable = true;
            tl4.GetComponent<Button>().interactable = true;
            tl5.GetComponent<Button>().interactable = true;
            tl6.GetComponent<Button>().interactable = true;
            tl4.SetActive(true);
            tl5.SetActive(true);
            tl6.SetActive(false);
        } else if (go.tag == "gs3")
            {
            grd = new Vector3(0, 1, 99);
            griid.GetComponent<Grid>().gridSize = new Vector2(5, 6);
            griid.GetComponent<Grid>().gs = 2;
            sloot.ts = 3;
            sloot.n1 = 2;
            sloot.n2 = 2;
            gr3.GetComponent<Button>().interactable = false;
            gr2.GetComponent<Button>().interactable = true;
            gr1.GetComponent<Button>().interactable = true;
            gr4.GetComponent<Button>().interactable = true;
            tl1.GetComponent<Button>().interactable = false;
            tl2.GetComponent<Button>().interactable = true;
            tl3.GetComponent<Button>().interactable = true;
            tl4.GetComponent<Button>().interactable = true;
            tl5.GetComponent<Button>().interactable = true;
            tl6.GetComponent<Button>().interactable = true;
            tl4.SetActive(true);
            tl5.SetActive(true);
            tl6.SetActive(false);
        } else if (go.tag == "gs4")
            {
            grd = new Vector3(0, 1, 99);
            griid.GetComponent<Grid>().gridSize = new Vector2(5, 6);
            griid.GetComponent<Grid>().gs = 4;
            sloot.ts = 4;
            sloot.n1 = 2;
            sloot.n2 = 2;
            gr4.GetComponent<Button>().interactable = false;
            gr2.GetComponent<Button>().interactable = true;
            gr3.GetComponent<Button>().interactable = true;
            gr1.GetComponent<Button>().interactable = true;
            tl1.GetComponent<Button>().interactable = false;
            tl2.GetComponent<Button>().interactable = true;
            tl3.GetComponent<Button>().interactable = true;
            tl4.GetComponent<Button>().interactable = true;
            tl5.GetComponent<Button>().interactable = true;
            tl6.GetComponent<Button>().interactable = true;
            tl4.SetActive(true);
            tl5.SetActive(true);
            tl6.SetActive(true);
        }   
    }

    public void TiSize()
    {
        var go = EventSystem.current.currentSelectedGameObject;
        soundmanager.PlaySound("menuclick");

        if (go.tag == "ts1")
        {
            sloot.n1 = 2;
            sloot.n2 = 2;
            tl1.GetComponent<Button>().interactable = false;
            tl2.GetComponent<Button>().interactable = true;
            tl3.GetComponent<Button>().interactable = true;
            tl4.GetComponent<Button>().interactable = true;
            tl5.GetComponent<Button>().interactable = true;
            tl6.GetComponent<Button>().interactable = true;
        } else if (go.tag == "ts2")
            {
                sloot.n1 = 3;
                sloot.n2 = 3;
                tl1.GetComponent<Button>().interactable = true;
                tl2.GetComponent<Button>().interactable = false;
                tl3.GetComponent<Button>().interactable = true;
                tl4.GetComponent<Button>().interactable = true;
                tl5.GetComponent<Button>().interactable = true;
                tl6.GetComponent<Button>().interactable = true;
            } else if (go.tag == "ts3")
                {
                    sloot.n1 = 4;
                    sloot.n2 = 4;
                    tl1.GetComponent<Button>().interactable = true;
                    tl2.GetComponent<Button>().interactable = true;
                    tl3.GetComponent<Button>().interactable = false;
                    tl4.GetComponent<Button>().interactable = true;
                    tl5.GetComponent<Button>().interactable = true;
                    tl6.GetComponent<Button>().interactable = true;
                } else if (go.tag == "ts4")
                    {
                        sloot.n1 = 5;
                        sloot.n2 = 5;
                        tl1.GetComponent<Button>().interactable = true;
                        tl2.GetComponent<Button>().interactable = true;
                        tl3.GetComponent<Button>().interactable = true;
                        tl4.GetComponent<Button>().interactable = false;
                        tl5.GetComponent<Button>().interactable = true;
                        tl6.GetComponent<Button>().interactable = true;
                    } else if (go.tag == "ts5")
                        {
                            sloot.n1 = 6;
                            sloot.n2 = 6;
                            tl1.GetComponent<Button>().interactable = true;
                            tl2.GetComponent<Button>().interactable = true;
                            tl3.GetComponent<Button>().interactable = true;
                            tl4.GetComponent<Button>().interactable = true;
                            tl5.GetComponent<Button>().interactable = false;
                            tl6.GetComponent<Button>().interactable = true;
                    } else if (go.tag == "ts6")
                            {
                                sloot.n1 = 7;
                                sloot.n2 = 7;
                                tl1.GetComponent<Button>().interactable = true;
                                tl2.GetComponent<Button>().interactable = true;
                                tl3.GetComponent<Button>().interactable = true;
                                tl4.GetComponent<Button>().interactable = true;
                                tl5.GetComponent<Button>().interactable = true;
                                tl6.GetComponent<Button>().interactable = false;
                        }
    }

    public void Save()
    {
        string[] contents = new string[] {
            ""+sloot.n1,
            ""+sloot.n2,
            ""+sloot.ts,
            ""+griid.GetComponent<Grid>().gs,
            ""+griid.GetComponent<Grid>().gridSize.x,
            ""+griid.GetComponent<Grid>().gridSize.y,
            ""+grd.x,
            ""+grd.y,
            ""+lan,
            ""+gameCount,
            ""+coll.GetComponent<ColorChange>().i1,
            ""+coll.GetComponent<ColorChange>().i2
        };
        string saveString = string.Join(SAVE_SEPERATOR, contents);
        File.WriteAllText(Application.persistentDataPath + "/save.sav", saveString);
    }

    public void Load()
    {
        if (File.Exists(Application.persistentDataPath + "/save.sav"))
        {
            string saveString = File.ReadAllText(Application.persistentDataPath + "/save.sav");

            string[] contents = saveString.Split(new[] { SAVE_SEPERATOR }, System.StringSplitOptions.None);

            int n1 = int.Parse(contents[0]);
            int n2 = int.Parse(contents[1]);
            int ts = int.Parse(contents[2]);
            int gs = int.Parse(contents[3]);
            float gsX = float.Parse(contents[4]);
            float gsY = float.Parse(contents[5]);
            float grdX = float.Parse(contents[6]);
            float grdY = float.Parse(contents[7]);
            int langu = int.Parse(contents[8]);
            int gameC = int.Parse(contents[9]);
            int i1 = int.Parse(contents[10]);
            int i2 = int.Parse(contents[11]);

            sloot.n1 = n1;
            sloot.n2 = n2;
            sloot.ts = ts;
            griid.GetComponent<Grid>().gs = gs;
            griid.GetComponent<Grid>().gridSize.x = gsX;
            griid.GetComponent<Grid>().gridSize.y = gsY;
            grd.x = grdX;
            grd.y = grdY;
            lan = langu;
            gameCount = gameC + 1;
            coll.GetComponent<ColorChange>().i1 = i1;
            coll.GetComponent<ColorChange>().i2 = i2;

            coll.GetComponent<ColorChange>().Load();

            if (gs == 1)
            {
                tl4.SetActive(false);
                tl5.SetActive(false);
                tl6.SetActive(false);
            }
            else if (gs == 2)
            {
                tl6.SetActive(false);
            }

            if (lan == 1)
            {
                l1.GetComponent<Button>().interactable = false;
                l2.GetComponent<Button>().interactable = true;

                txt1.SetText("Play");
                txt2.SetText("Options");
                txt3.SetText("Credits");
                txt4.SetText("Quit");
                txt5.SetText("OPTIONS");
                txt6.SetText("Grid Size");
                txt7.SetText("Max Tile Size");
                txt8.SetText("Language");
                txt9.SetText("P1 Block Color");
                txt10.SetText("P2 Block Color");
                txt11.SetText("Back");
                txt12.SetText("CREDITS");
                txt13.SetText("Back");
                txt14.text = "Roll Dice";
                txt15.text = "Skip";
                txt16.SetText("Back");
                txt17.SetText("Do you want to go back to menu?");
                txt18.SetText("Continue");
                griid.GetComponent<Grid>().lang = 1;
            }
            else if (lan == 2)
            {
                l1.GetComponent<Button>().interactable = true;
                l2.GetComponent<Button>().interactable = false;

                txt1.SetText("Oyna");
                txt2.SetText("Ayarlar");
                txt3.SetText("Emekçiler");
                txt4.SetText("Çık");
                txt5.SetText("AYARLAR");
                txt6.SetText("Oyun Tahtası");
                txt7.SetText("Parça Büyüklüğü");
                txt8.SetText("Oyun Dili");
                txt9.SetText("1. Oyuncu Blok Rengi");
                txt10.SetText("2. Oyuncu Blok Rengi");
                txt11.SetText("Geri");
                txt12.SetText("EMEKÇİLER");
                txt13.SetText("Geri");
                txt14.text = "Zar At";
                txt15.text = "Pas Geç";
                txt16.SetText("Geri");
                txt17.SetText("Menüye dönmek istiyor musun?");
                txt18.SetText("Devam Et");
                griid.GetComponent<Grid>().lang = 2;
            }
        } else
        {
            string[] contents = new string[] { "2", "2", "1", "1", "4", "4", "0", "2", "1", "0", "5", "3" };
            string saveString = string.Join(SAVE_SEPERATOR, contents);
            File.WriteAllText(Application.persistentDataPath + "/save.sav", saveString);
        }
    }

    public void Opt()
    {
        if (sloot.ts == 1) {
            gr1.GetComponent<Button>().interactable = false;
            gr2.GetComponent<Button>().interactable = true;
            gr3.GetComponent<Button>().interactable = true;
            gr4.GetComponent<Button>().interactable = true;
        } else if (sloot.ts == 2) {
            gr1.GetComponent<Button>().interactable = true;
            gr2.GetComponent<Button>().interactable = false;
            gr3.GetComponent<Button>().interactable = true;
            gr4.GetComponent<Button>().interactable = true;
        } else if (sloot.ts == 3) {
            gr1.GetComponent<Button>().interactable = true;
            gr2.GetComponent<Button>().interactable = true;
            gr3.GetComponent<Button>().interactable = false;
            gr4.GetComponent<Button>().interactable = true;
        } else if (sloot.ts == 4) {
            gr1.GetComponent<Button>().interactable = true;
            gr2.GetComponent<Button>().interactable = true;
            gr3.GetComponent<Button>().interactable = true;
            gr4.GetComponent<Button>().interactable = false;
        }

        if (sloot.n1 == 2) {
            tl1.GetComponent<Button>().interactable = false;
            tl2.GetComponent<Button>().interactable = true;
            tl3.GetComponent<Button>().interactable = true;
            tl4.GetComponent<Button>().interactable = true;
            tl5.GetComponent<Button>().interactable = true;
            tl6.GetComponent<Button>().interactable = true;
        } else if (sloot.n1 == 3) {
            tl1.GetComponent<Button>().interactable = true;
            tl2.GetComponent<Button>().interactable = false;
            tl3.GetComponent<Button>().interactable = true;
            tl4.GetComponent<Button>().interactable = true;
            tl5.GetComponent<Button>().interactable = true;
            tl6.GetComponent<Button>().interactable = true;
        } else if (sloot.n1 == 4) {
            tl1.GetComponent<Button>().interactable = true;
            tl2.GetComponent<Button>().interactable = true;
            tl3.GetComponent<Button>().interactable = false;
            tl4.GetComponent<Button>().interactable = true;
            tl5.GetComponent<Button>().interactable = true;
            tl6.GetComponent<Button>().interactable = true;
        } else if (sloot.n1 == 5) {
            tl1.GetComponent<Button>().interactable = true;
            tl2.GetComponent<Button>().interactable = true;
            tl3.GetComponent<Button>().interactable = true;
            tl4.GetComponent<Button>().interactable = false;
            tl5.GetComponent<Button>().interactable = true;
            tl6.GetComponent<Button>().interactable = true;
        } else if (sloot.n1 == 6) {
            tl1.GetComponent<Button>().interactable = true;
            tl2.GetComponent<Button>().interactable = true;
            tl3.GetComponent<Button>().interactable = true;
            tl4.GetComponent<Button>().interactable = true;
            tl5.GetComponent<Button>().interactable = false;
            tl6.GetComponent<Button>().interactable = true;
        } else if (sloot.n1 == 7) {
            tl1.GetComponent<Button>().interactable = true;
            tl2.GetComponent<Button>().interactable = true;
            tl3.GetComponent<Button>().interactable = true;
            tl4.GetComponent<Button>().interactable = true;
            tl5.GetComponent<Button>().interactable = true;
            tl6.GetComponent<Button>().interactable = false;
        }
    }

    public void Igram()
    {
        Application.OpenURL("https://www.instagram.com/afugames/");
    }
}
