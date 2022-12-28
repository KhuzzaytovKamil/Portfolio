using UnityEngine;
using UnityEngine.UI;

public class MiniGameCameraImprovementManager : MonoBehaviour
{
    [SerializeField]
    private GameObject ConfettiRain;
    [SerializeField]
    private GameObject CameraModel;

    [Header("FinishMiniGameScreen")]
    [SerializeField]
    private string LoseMessage;
    [SerializeField]
    private string WinMessage;
    [SerializeField]
    private Text FinishText;
    [SerializeField]
    private GameObject FinishMiniGameScreen;

    public void VictoryAction()
    {
        FinishMiniGameScreen.SetActive(true);
        FinishText.text = WinMessage;

        ConfettiRain.SetActive(true);
    }

    public void LoseAction()
    {
        FinishMiniGameScreen.SetActive(true);
        FinishText.text = LoseMessage;

        CameraModel.GetComponent<Rigidbody>().useGravity = true;
    }
}
