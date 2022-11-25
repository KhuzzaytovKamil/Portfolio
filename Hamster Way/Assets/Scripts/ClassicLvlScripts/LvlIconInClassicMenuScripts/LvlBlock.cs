using UnityEngine;
using UnityEngine.UI;
using ScriptableObjects.Economy;

namespace LvlIconInClassicMenu
{
    public class LvlBlock : MonoBehaviour
    {
        [SerializeField]
        MainIconController MainIconController;
        [SerializeField]
        GameObject BlockImage;
        [SerializeField]
        Image Plate;
        [SerializeField]
        PlateSkinManager SkinDataManager;
        void Start()
        {
            if (PlayerPrefs.GetInt("FalseNextBlockInLvl" + (MainIconController.ClassicLvlNumber - 1)) == 1 && BlockImage != null)
                BlockImage.SetActive(false);
            if (PlayerPrefs.GetInt("FalseNextBlockInLvl" + MainIconController.ClassicLvlNumber) == 1)
                Plate.sprite = SkinDataManager.StandardPlateSprite[PlayerPrefs.GetInt("UsedPlateSkinNumber")];
            else
                Plate.sprite = SkinDataManager.EmptyPlateSprite[PlayerPrefs.GetInt("UsedPlateSkinNumber")];
        }
    }
}
