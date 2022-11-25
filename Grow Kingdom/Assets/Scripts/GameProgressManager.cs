using UnityEngine;
using UnityEngine.SceneManagement;

public class GameProgressManager : MonoBehaviour
{
    [SerializeField]
    private GameObject TheFirstLvlButton;
    [SerializeField]
    private GameObject TheSecondLvlButton;
    [SerializeField]
    private GameObject TheThirdLvlButton;
    [SerializeField]
    private GameObject TheFourthLvlButton;
    /*[SerializeField]
    private GameObject TheFifthLvlButton;
    [SerializeField]
    private GameObject TheSixthLvlButton;
    [SerializeField]
    private GameObject TheSeventhLvlButton;
    [SerializeField]
    private GameObject TheEighthLvlButton;*/

    private void Start()
    {
        if (PlayerPrefs.GetInt("TheFirstGameOpen") == 0)
        {
            PlayerPrefs.SetInt("TheFirstGameOpen", 1);
            SceneManager.LoadScene("Education");
        }

        if (PlayerPrefs.GetInt("LastCompletedLvl") == 0)
            TheFirstLvlButton.SetActive(true);
        else if (PlayerPrefs.GetInt("LastCompletedLvl") == 1)
            TheSecondLvlButton.SetActive(true);
        else if (PlayerPrefs.GetInt("LastCompletedLvl") == 2)
            TheThirdLvlButton.SetActive(true);
        else if (PlayerPrefs.GetInt("LastCompletedLvl") == 3)
            TheFourthLvlButton.SetActive(true);
        /*else if (PlayerPrefs.GetInt("LastCompletedLvl") == 4)
            TheFifthLvlButton.SetActive(true);
        else if (PlayerPrefs.GetInt("LastCompletedLvl") == 5)
            TheSixthLvlButton.SetActive(true);
        else if (PlayerPrefs.GetInt("LastCompletedLvl") == 6)
            TheSeventhLvlButton.SetActive(true);
        else if (PlayerPrefs.GetInt("LastCompletedLvl") == 7)
            TheEighthLvlButton.SetActive(true);*/
    }
}
