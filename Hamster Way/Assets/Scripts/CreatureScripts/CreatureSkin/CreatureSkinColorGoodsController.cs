using UnityEngine;
using UnityEngine.UI;
using ScriptableObjects.Economy;


namespace Creature.Skins
{
    public class CreatureSkinColorGoodsController : MonoBehaviour
    {
        [SerializeField]
        CreatureSkinInShopController CreatureSkinInShopController;
        [SerializeField]
        int GoodsSkinNumber;
        [SerializeField]
        PlayerSkinsManager PlayerSkinsManager;
        [SerializeField]
        GameObject OutsideLineForActiveSkin;
        [SerializeField]
        GameObject GoodsNotBuyBlock;
        [SerializeField]
        GameObject SkinBuyWindow;
        [SerializeField]
        Text SkinPriceInBuyWindow;
        void Start()
        {
            SwitchColor();
            CreatureSkinInShopController.ChangeColor += SwitchColor;
        }
        void OnEnable()
        {
            CreatureSkinInShopController.ChangeColor += SwitchColor;
        }
        void OnDisable()
        {
            CreatureSkinInShopController.ChangeColor -= SwitchColor;
        }
        void OnDestroy()
        {
            CreatureSkinInShopController.ChangeColor -= SwitchColor;
        }
        void SwitchColor()
        {
            if (PlayerPrefs.GetInt("SkinBuyed" + GoodsSkinNumber) == 1)
                GoodsNotBuyBlock.SetActive(false);
            if (PlayerPrefs.GetInt("ActiveSkinNumber") == GoodsSkinNumber)
            {
                CreatureSkinInShopController.CreatureStandard = PlayerSkinsManager.SkinStandard[GoodsSkinNumber];
                CreatureSkinInShopController.CreatureClosingEye = PlayerSkinsManager.SkinClosingEye[GoodsSkinNumber];
                OutsideLineForActiveSkin.SetActive(true);
            }
            else
            {
                OutsideLineForActiveSkin.SetActive(false);
            }
        }
        public void ClickToColor()
        {
            if (PlayerPrefs.GetInt("SkinBuyed" + GoodsSkinNumber) == 0)
            {
                SkinPriceInBuyWindow.text = PlayerSkinsManager.SkinPrice[GoodsSkinNumber].ToString();
                CreatureSkinInShopController.CreatureSkinInBuyWindow.sprite = PlayerSkinsManager.SkinStandard[GoodsSkinNumber];
                SkinBuyWindow.SetActive(true);
                CreatureSkinInShopController.BuySkinNumber = GoodsSkinNumber;
            }
            else
            {
                PlayerPrefs.SetInt("ActiveSkinNumber", GoodsSkinNumber);
                CreatureSkinInShopController.ChangeColorEvent();
            }
        }
    }
}
