using UnityEngine;
using UnityEngine.UI;
using Finish.LoseSystem;
using Goods;
using ScriptableObjects.LvlsManager;
using Finish.WinSystem;
using ScriptableObjects.Economy;

namespace Finish.MatchingCardsLvlFinishSystem
{
    public class LastsOpeningController : MonoBehaviour
    {
        [SerializeField]
        MatchingCardsLvlsManager LvlManager;
        [SerializeField]
        LoseManager Lose;
        public float OpeningBeforeLose;
        float AllOpening;
        [SerializeField]
        Image ProgressBar;
        [SerializeField]
        GameObject RightPoint;
        [SerializeField]
        GameObject LeftPoint;
        float ProgressBarWide;
        [SerializeField]
        Text LastsOpeningNumberText;
        [Header("HeartsPack:")]
        int ForTreeHeartsPack;
        int ForTwoHeartsPack;
        int ForOneHeartsPack;
        [SerializeField]
        GameObject TheFirstHeartsPack;
        [SerializeField]
        GameObject TheSecondHeartsPack;
        [SerializeField]
        GameObject TheThirdHeartsPack;
        [SerializeField]
        GoodsInfoBank GoodsInfoBank;
        void Start()
        {
            PlayerPrefs.SetInt("Stars", 0);
            OpeningBeforeLose = Mathf.RoundToInt(LvlManager.OpeningForLvl[PlayerPrefs.GetInt("MatchingCardsLvlNumber")] * PlayerPrefs.GetFloat("FactorForOpening"));
            ForOneHeartsPack = Mathf.RoundToInt(OpeningBeforeLose * LvlManager.FactorForOneHeartsPack);
            ForTwoHeartsPack = Mathf.RoundToInt(OpeningBeforeLose * LvlManager.FactorForTwoHeartsPacks);
            ForTreeHeartsPack = Mathf.RoundToInt(OpeningBeforeLose * LvlManager.FactorForTreeHeartsPacks);
            AllOpening = OpeningBeforeLose;
            ProgressBarWide = RightPoint.transform.position.x - LeftPoint.transform.position.x;
            TheFirstHeartsPack.transform.position = new Vector3(LeftPoint.transform.position.x + ((ForOneHeartsPack / AllOpening) * ProgressBarWide), TheFirstHeartsPack.transform.position.y, TheFirstHeartsPack.transform.position.z);
            TheSecondHeartsPack.transform.position = new Vector3(LeftPoint.transform.position.x + ((ForTwoHeartsPack / AllOpening) * ProgressBarWide), TheSecondHeartsPack.transform.position.y, TheSecondHeartsPack.transform.position.z);
            TheThirdHeartsPack.transform.position = new Vector3(LeftPoint.transform.position.x + ((ForTreeHeartsPack / AllOpening) * ProgressBarWide), TheThirdHeartsPack.transform.position.y, TheThirdHeartsPack.transform.position.z);
            TheFirstHeartsPack.GetComponentInChildren<Text>().text = Mathf.RoundToInt(LvlManager.HeartsForTheFirstHeartsPack[PlayerPrefs.GetInt("MatchingCardsLvlNumber")] * PlayerPrefs.GetFloat("FactorForPrize")).ToString();
            TheSecondHeartsPack.GetComponentInChildren<Text>().text = Mathf.RoundToInt(LvlManager.HeartsForTheSecondHeartsPack[PlayerPrefs.GetInt("MatchingCardsLvlNumber")] * PlayerPrefs.GetFloat("FactorForPrize")).ToString();
            TheThirdHeartsPack.GetComponentInChildren<Text>().text = Mathf.RoundToInt(LvlManager.HeartsForTheThirdHeartsPack[PlayerPrefs.GetInt("MatchingCardsLvlNumber")] * PlayerPrefs.GetFloat("FactorForPrize")).ToString();
            GetMoreOpeningController.UsedOpening += SetStarsAgin;
            WinManager.Win += WinOpening;
        }
        void OnEnable()
        {
            GetMoreOpeningController.UsedOpening += GetMoreOpening;
            GetMoreOpeningController.UsedOpening += SetStarsAgin;
            WinManager.Win += WinOpening;
        }
        void OnDisable()
        {
            GetMoreOpeningController.UsedOpening -= GetMoreOpening;
            GetMoreOpeningController.UsedOpening -= SetStarsAgin;
            WinManager.Win -= WinOpening;
        }
        void OnDestroy()
        {
            GetMoreOpeningController.UsedOpening -= GetMoreOpening;
            GetMoreOpeningController.UsedOpening -= SetStarsAgin;
            WinManager.Win -= WinOpening;
        }
        void Update()
        {
            if (OpeningBeforeLose == 0 || OpeningBeforeLose < 0)
                Lose.LoseGame();
            if (OpeningBeforeLose < ForOneHeartsPack)
                TheFirstHeartsPack.SetActive(false);
            else if (OpeningBeforeLose < ForTwoHeartsPack)
                TheSecondHeartsPack.SetActive(false);
            else if (OpeningBeforeLose < ForTreeHeartsPack)
                TheThirdHeartsPack.SetActive(false);
            ProgressBar.fillAmount = OpeningBeforeLose / AllOpening;
            LastsOpeningNumberText.text = OpeningBeforeLose.ToString();
        }
        void WinOpening()
        {
            if (OpeningBeforeLose >= ForTreeHeartsPack)
                PlayerPrefs.SetInt("Stars", 3);
            else if (OpeningBeforeLose >= ForTwoHeartsPack)
                PlayerPrefs.SetInt("Stars", 2);
            else if (OpeningBeforeLose >= ForOneHeartsPack)
                PlayerPrefs.SetInt("Stars", 1);
        }
        void GetMoreOpening()
        {
            if (OpeningBeforeLose + GoodsInfoBank.OpeningNumber < AllOpening)
                OpeningBeforeLose = OpeningBeforeLose + GoodsInfoBank.OpeningNumber;
            else
                OpeningBeforeLose = AllOpening;
            Debug.Log(gameObject.name);
        }
        void SetStarsAgin()
        {
            if (OpeningBeforeLose >= ForTreeHeartsPack)
                TheFirstHeartsPack.SetActive(true);
            if (OpeningBeforeLose >= ForTwoHeartsPack)
                TheSecondHeartsPack.SetActive(true);
            if (OpeningBeforeLose >= ForOneHeartsPack)
                TheThirdHeartsPack.SetActive(true);
        }
    }
}
