using UnityEngine;

namespace LvlIconInMenu
{
    public class LvlBlock : MonoBehaviour
    {
        [SerializeField]
        MainIconController MainIconController;
        [SerializeField]
        GameObject BlockImage;
        [SerializeField]
        Animator Plate;
        void Start()
        {
            if (PlayerPrefs.GetInt("FalseNextBlockInLvl" + (MainIconController.LvlNumber - 1)) == 1 && BlockImage != null)
                BlockImage.SetActive(false);
            if (PlayerPrefs.GetInt("FalseNextBlockInLvl" + MainIconController.LvlNumber) == 1)
                Plate.SetBool("LvlIsPassed", true);
        }
    }
}
