using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;
using ScriptableObjects.Economy;
using UnityEngine.SceneManagement;
using Scroll;

namespace Creature.Skins
{
    public class CreatureSkinInShopController : MonoBehaviour
    {
        public static event Action ChangeColor;
        public Sprite CreatureStandard;
        public Sprite CreatureClosingEye;
        float TimeBeforeNextAnimSwitch;
        [SerializeField]
        PlayerSkinsManager PlayerSkinsManager;
        int AnimNumber = 1;
        [SerializeField]
        GameObject SkinBuyWindow;
        public int BuySkinNumber;
        public Image CreatureSkinInBuyWindow;
        [SerializeField]
        OpenSamePlaceInScroll OpenSamePlaceInScrollController;
        void Start() => StartCoroutine(SetCretureAnim());

        public void ChangeColorEvent() => ChangeColor.Invoke();
        
        IEnumerator SetCretureAnim()
        {
            yield return new WaitForSeconds(TimeBeforeNextAnimSwitch);
            if (AnimNumber == 1)
            {
                AnimNumber = 2;
                TimeBeforeNextAnimSwitch = PlayerSkinsManager.StandardAnimationTimeBetweenFramesInSecond;
                gameObject.GetComponent<Image>().sprite = CreatureStandard;
            }
            else if (AnimNumber == 2)
            {
                AnimNumber = 1;
                TimeBeforeNextAnimSwitch = PlayerSkinsManager.StandardAnimationTimeBetweenFramesInSecond / 3;
                gameObject.GetComponent<Image>().sprite = CreatureClosingEye;
            }
            StartCoroutine(SetCretureAnim());
        }
        public void BuyColor()
        {
            if (PlayerPrefs.GetInt("money") >= PlayerSkinsManager.SkinPrice[BuySkinNumber])
            {
                PlayerPrefs.SetInt("SkinBuyed" + BuySkinNumber, 1);
                PlayerPrefs.SetInt("money", PlayerPrefs.GetInt("money") - PlayerSkinsManager.SkinPrice[BuySkinNumber]);
                PlayerPrefs.SetInt("ActiveSkinNumber", BuySkinNumber);
                SkinBuyWindow.SetActive(false);
                ChangeColor.Invoke();
            }
            else
            {
                SceneManager.LoadScene("CurrencyShop");
                OpenSamePlaceInScrollController.SwitchScrollContentPosition();
            }
                
        }
    }
}
