using UnityEngine;
using System;
using System.Collections;


namespace Main
{
    public class RareUpdateManager : MonoBehaviour
    {
        [SerializeField]
        float TimeBetweenUpdate;

        void Start() => StartCoroutine(RareUpdate());

        IEnumerator RareUpdate()
        {
            yield return new WaitForSeconds(TimeBetweenUpdate);

            PlayerPrefs.SetFloat("MoneyFactorTimeBalance", PlayerPrefs.GetFloat("MoneyFactorTimeBalance") - ((int)(DateTime.UtcNow - new DateTime(2020, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalSeconds - PlayerPrefs.GetInt("LastRareUpdateTime")));
            PlayerPrefs.SetFloat("HeartsFactorTimeBalance", PlayerPrefs.GetFloat("HeartsFactorTimeBalance") - ((int)(DateTime.UtcNow - new DateTime(2020, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalSeconds - PlayerPrefs.GetInt("LastRareUpdateTime")));
            PlayerPrefs.SetFloat("EliteMoneyFactorTimeBalance", PlayerPrefs.GetFloat("EliteMoneyFactorTimeBalance") - ((int)(DateTime.UtcNow - new DateTime(2020, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalSeconds - PlayerPrefs.GetInt("LastRareUpdateTime")));

            if (PlayerPrefs.GetFloat("MoneyFactorTimeBalance") < 0)
                PlayerPrefs.SetFloat("MoneyFactor", 0);

            if (PlayerPrefs.GetFloat("HeartsFactorTimeBalance") < 0)
                PlayerPrefs.SetFloat("HeartsFactor", 0);

            if (PlayerPrefs.GetFloat("EliteMoneyFactorTimeBalance") < 0)
                PlayerPrefs.SetFloat("EliteMoneyFactor", 0);

            PlayerPrefs.SetInt("LastRareUpdateTime", (int)(DateTime.UtcNow - new DateTime(2020, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalSeconds);

            StartCoroutine(RareUpdate());
        }
    }
}
