using UnityEngine;
using UnityEngine.UI;
using ScriptableObjects.Economy;

namespace PrizeSystem
{
    public class HappinessPointController : MonoBehaviour
    {
        [SerializeField]
        Text ProgressText;
        [SerializeField]
        PrizeManager PrizeManager;
        [SerializeField]
        GameObject ProgressOpenPrizeObject;
        void Update()
        {
            if (PlayerPrefs.GetFloat("HappinessPoint") >= PrizeManager.HappinessPointNumberForPrize)
                ProgressOpenPrizeObject.SetActive(false);
            else
                ProgressText.text = Mathf.RoundToInt(PlayerPrefs.GetFloat("HappinessPoint")).ToString() + "/" + PrizeManager.HappinessPointNumberForPrize.ToString();
        }
    }
}
