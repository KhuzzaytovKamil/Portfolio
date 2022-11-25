using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class ShowStarsController : MonoBehaviour
    {
        int LvlNumber;
        int UsersStars;
        void Start()
        {
            for (LvlNumber = (PlayerPrefs.GetInt("LastCompletedLvlNumber")); LvlNumber > 0; LvlNumber--)
            {
                UsersStars = UsersStars + PlayerPrefs.GetInt("StarsInLvl" + LvlNumber);
            }
            gameObject.GetComponent<Text>().text = UsersStars.ToString();
        }
    }
}

