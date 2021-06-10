using UnityEngine;
using UnityEngine.Advertisements;

public class AdsManager : MonoBehaviour
{
    public string GameID = "3806253";
    public string InterstitialPlacementID = "video";
    public bool testModu = false;

    public bool interstitialGosterilecek = false;

    void Start()
    {
        // Unity Ads'i kullanıma hazır hale getir
        Advertisement.Initialize(GameID, testModu);
    }

    void Update()
    {
        if (interstitialGosterilecek)
        {
            // Interstitial reklam gösterilmeye hazır mı diye kontrol et
            if (Advertisement.IsReady(InterstitialPlacementID))
            {
                // Interstitial reklam gösterilmeye hazır, o halde reklamı göster!
                Advertisement.Show(InterstitialPlacementID);

                // Interstitial'ı gösterdik, artık bu if koşulunu kontrol etmemize gerek yok
                interstitialGosterilecek = false;
            }
        }
    }
    /*
    // Ekranda test amaçlı "Interstitial Göster" butonu göstermeye yarar, bu fonksiyonu silerseniz buton yok olur
    void OnGUI()
    {
        if (GUI.Button(new Rect(Screen.width / 2 - 300, 0, 300, 300), "Interstitial Göster"))
            InterstitialGoster();
    }

    public void InterstitialGoster()
    {
        interstitialGosterilecek = true;
    }*/
}