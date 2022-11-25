using UnityEngine;
using ScriptableObjects.Economy;
using UnityEngine.UI;

namespace HouseSkin
{
    public class SetHouseInLvlController : MonoBehaviour
    {
        [SerializeField]
        HouseSkinManager SkinDataManager;
        [SerializeField]
        Image BG;
        [SerializeField]
        Image FG;
        
        void Start()
        {
            BG.color = SkinDataManager.ColorForBG[PlayerPrefs.GetInt("UsedHouseSkinNumber")];
            FG.sprite = SkinDataManager.SpriteForFG[PlayerPrefs.GetInt("UsedHouseSkinNumber")];
        }
    }
}
