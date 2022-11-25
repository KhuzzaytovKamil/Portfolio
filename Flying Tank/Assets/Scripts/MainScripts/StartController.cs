using UnityEngine;

namespace Main
{
    public class StartController : MonoBehaviour
    {
        [SerializeField]
        int WinWithoutAdsNumber;
        void Start()
        {
            if (PlayerPrefs.GetInt("IsNotStart") == 1)
                Destroy(gameObject); 
            else
            {
                PlayerPrefs.SetString("Language", "Russian");
                PlayerPrefs.SetInt("SkinBuyed0", 1);
                PlayerPrefs.SetInt("SOUND", 1);
                PlayerPrefs.SetInt("CurrentDay", 1);
                PlayerPrefs.SetInt("LastGotEverydayPrize", 0);
                PlayerPrefs.SetInt("WinningWereAfterLastAd", 2 - WinWithoutAdsNumber);
            }
            PlayerPrefs.SetInt("IsNotStart", 1);
        }
    }
}
