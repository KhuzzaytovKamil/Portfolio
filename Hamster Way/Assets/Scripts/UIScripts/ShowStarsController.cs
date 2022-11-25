using UnityEngine;
using UnityEngine.UI;
using ScriptableObjects.LvlsManager;

namespace UI
{
    public class ShowStarsController : MonoBehaviour
    {
        [SerializeField]
        ClassicLvlsManager ClassicLvlsManager;
        int clasicLvlNumber;
        int UsersStars;
        void Start()
        {
            for (clasicLvlNumber = ClassicLvlsManager.LvlNumber; clasicLvlNumber > 0; clasicLvlNumber--)
            {
                UsersStars = UsersStars + PlayerPrefs.GetInt("StarsInLvl" + clasicLvlNumber);
            }
            gameObject.GetComponent<Text>().text = UsersStars.ToString();
        }
    }
}

