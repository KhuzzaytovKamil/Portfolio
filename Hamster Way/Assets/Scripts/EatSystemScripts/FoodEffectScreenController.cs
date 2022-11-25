using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;

namespace EatSystem
{
    public class FoodEffectScreenController : MonoBehaviour
    {
        [Header("MoneyEffect:")]
        [SerializeField]
        GameObject MoneyEffect;
        [SerializeField]
        Text FactorMoneyEffectText;
        [SerializeField]
        Text BalanceMoneyEffectTimeText;

        [Header("HeartsEffect:")]
        [SerializeField]
        GameObject HeartsEffect;
        [SerializeField]
        Text FactorHeartsEffectText;
        [SerializeField]
        Text BalanceHeartsEffectTimeText;

        [Header("EliteMoneyEffect:")]
        [SerializeField]
        GameObject EliteMoneyEffect;
        [SerializeField]
        Text FactorEliteMoneyEffectText;
        [SerializeField]
        Text BalanceEliteMoneyEffectTimeText;

        int Minutes;

        void Start() => StartCoroutine(OftenUpdate());

        IEnumerator OftenUpdate()
        {
            yield return new WaitForSeconds(1);

            PlayerPrefs.SetFloat("MoneyFactorTimeBalance", PlayerPrefs.GetFloat("MoneyFactorTimeBalance") - ((int)(DateTime.UtcNow - new DateTime(2020, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalSeconds - PlayerPrefs.GetInt("LastRareUpdateTime")));
            PlayerPrefs.SetFloat("HeartsFactorTimeBalance", PlayerPrefs.GetFloat("HeartsFactorTimeBalance") - ((int)(DateTime.UtcNow - new DateTime(2020, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalSeconds - PlayerPrefs.GetInt("LastRareUpdateTime")));
            PlayerPrefs.SetFloat("EliteMoneyFactorTimeBalance", PlayerPrefs.GetFloat("EliteMoneyFactorTimeBalance") - ((int)(DateTime.UtcNow - new DateTime(2020, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalSeconds - PlayerPrefs.GetInt("LastRareUpdateTime")));

            SetEffectData();

            PlayerPrefs.SetInt("LastRareUpdateTime", (int)(DateTime.UtcNow - new DateTime(2020, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalSeconds);

            StartCoroutine(OftenUpdate());
        }

        public void SetEffectData()
        {
            Minutes = Mathf.FloorToInt(PlayerPrefs.GetFloat("MoneyFactorTimeBalance") / 60);
            if (Mathf.Round(PlayerPrefs.GetFloat("MoneyFactorTimeBalance") - Minutes * 60) > 9)
                BalanceMoneyEffectTimeText.text = Minutes.ToString() + ":" + Mathf.Round(PlayerPrefs.GetFloat("MoneyFactorTimeBalance") - Minutes * 60).ToString();
            else
                BalanceMoneyEffectTimeText.text = Minutes.ToString() + ":0" + Mathf.Round(PlayerPrefs.GetFloat("MoneyFactorTimeBalance") - Minutes * 60).ToString();
            Minutes = Mathf.FloorToInt(PlayerPrefs.GetFloat("HeartsFactorTimeBalance") / 60);
            if (Mathf.Round(PlayerPrefs.GetFloat("HeartsFactorTimeBalance") - Minutes * 60) > 9)
                BalanceHeartsEffectTimeText.text = Minutes.ToString() + ":" + Mathf.Round(PlayerPrefs.GetFloat("HeartsFactorTimeBalance") - Minutes * 60).ToString();
            else
                BalanceHeartsEffectTimeText.text = Minutes.ToString() + ":0" + Mathf.Round(PlayerPrefs.GetFloat("HeartsFactorTimeBalance") - Minutes * 60).ToString();
            Minutes = Mathf.FloorToInt(PlayerPrefs.GetFloat("EliteMoneyFactorTimeBalance") / 60);
            if (Mathf.Round(PlayerPrefs.GetFloat("EliteMoneyFactorTimeBalance") - Minutes * 60) > 9)
                BalanceEliteMoneyEffectTimeText.text = Minutes.ToString() + ":" + Mathf.Round(PlayerPrefs.GetFloat("EliteMoneyFactorTimeBalance") - Minutes * 60).ToString();
            else
                BalanceEliteMoneyEffectTimeText.text = Minutes.ToString() + ":0" + Mathf.Round(PlayerPrefs.GetFloat("EliteMoneyFactorTimeBalance") - Minutes * 60).ToString();

            if (PlayerPrefs.GetFloat("MoneyFactorTimeBalance") > 0)
            {
                MoneyEffect.SetActive(true);
                FactorMoneyEffectText.text = (PlayerPrefs.GetFloat("MoneyFactor") * 100).ToString() + "%";
            }
            else
                MoneyEffect.SetActive(false);

            if (PlayerPrefs.GetFloat("HeartsFactorTimeBalance") > 0)
            {
                HeartsEffect.SetActive(true);
                FactorHeartsEffectText.text = (PlayerPrefs.GetFloat("HeartsFactor") * 100).ToString() + "%";
            }
            else
                HeartsEffect.SetActive(false);

            if (PlayerPrefs.GetFloat("EliteMoneyFactorTimeBalance") > 0)
            {
                EliteMoneyEffect.SetActive(true);
                FactorEliteMoneyEffectText.text = (PlayerPrefs.GetFloat("EliteMoneyFactor") * 100).ToString() + "%";
            }
            else
                EliteMoneyEffect.SetActive(false);
        }
    }
}
