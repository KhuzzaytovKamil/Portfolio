using UnityEngine;
using ScriptableObjects.LvlsManager;
using UnityEngine.SceneManagement;

namespace MatchingCardsMenu
{
    public class MatchingCardsLvlScreenInMenuController : MonoBehaviour
    {
        [SerializeField]
        int LevelNumber;
        [SerializeField]
        MatchingCardsLvlsManager MatchingCardsLvlsManager;
        [SerializeField]
        GameObject TheFirstStarInLvlScreen;
        [SerializeField]
        GameObject TheSecondStarInLvlScreen;
        [SerializeField]
        GameObject TheThirdStarInLvlScreen;
        [SerializeField]
        GameObject AllLvlBlock;

        void Start()
        {
            if (PlayerPrefs.GetInt("StarsInMatchingCardsLvl" + (LevelNumber - 1)) > 0)
                AllLvlBlock.SetActive(false);
            if (PlayerPrefs.GetInt("StarsInMatchingCardsLvl" + LevelNumber) > 0)
                TheFirstStarInLvlScreen.SetActive(true);
            if (PlayerPrefs.GetInt("StarsInMatchingCardsLvl" + LevelNumber) > 1)
                TheSecondStarInLvlScreen.SetActive(true);
            if (PlayerPrefs.GetInt("StarsInMatchingCardsLvl" + LevelNumber) > 2)
                TheThirdStarInLvlScreen.SetActive(true);
        }

        public void OpenLvlData()
        {
            if (PlayerPrefs.GetInt("StarsInMatchingCardsLvl" + LevelNumber) > 1)
            {
                PlayerPrefs.SetFloat("FactorForOpening", MatchingCardsLvlsManager.HardFactorForOpening);
                PlayerPrefs.SetFloat("FactorForPrize", MatchingCardsLvlsManager.HardFactorForPrize);
            }
            else if (PlayerPrefs.GetInt("StarsInMatchingCardsLvl" + LevelNumber) > 0)
            {
                PlayerPrefs.SetFloat("FactorForOpening", MatchingCardsLvlsManager.MiddleFactorForOpening);
                PlayerPrefs.SetFloat("FactorForPrize", MatchingCardsLvlsManager.MiddleFactorForPrize);
            }
            else
            {
                PlayerPrefs.SetFloat("FactorForOpening", MatchingCardsLvlsManager.EasyFactorForOpening);
                PlayerPrefs.SetFloat("FactorForPrize", MatchingCardsLvlsManager.EasyFactorForPrize);
            }

            PlayerPrefs.SetInt("MatchingCardsLvlNumber", LevelNumber);
            SceneManager.LoadScene("MatchingCardsLvl");
        }
    }
}
