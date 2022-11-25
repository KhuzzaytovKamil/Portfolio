using UnityEngine;

namespace LvlIconInClassicMenu
{
    public class StarInMenuController : MonoBehaviour
    {
        [SerializeField]
        MainIconController MainIconController;
        [SerializeField]
        GameObject TheFirstStar;
        [SerializeField]
        GameObject TheSecondStar;
        [SerializeField]
        GameObject TheThirdStar;
        void Start()
        {
            if (PlayerPrefs.GetInt("StarsInLvl" + MainIconController.ClassicLvlNumber) == 3)
            {
                TheThirdStar.SetActive(true);
                TheSecondStar.SetActive(true);
                TheFirstStar.SetActive(true);
            }
            else if (PlayerPrefs.GetInt("StarsInLvl" + MainIconController.ClassicLvlNumber) == 2)
            {
                TheSecondStar.SetActive(true);
                TheFirstStar.SetActive(true);
            }
            else if (PlayerPrefs.GetInt("StarsInLvl" + MainIconController.ClassicLvlNumber) == 1)
                TheFirstStar.SetActive(true);
        }
    }
}
