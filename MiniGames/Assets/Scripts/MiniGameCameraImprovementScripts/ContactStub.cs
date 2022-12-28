using UnityEngine;

public class ContactStub : MonoBehaviour
{
    [SerializeField]
    private MiniGameCameraImprovementManager MiniGameCameraImprovementManager;

    public void VictoryAction() => MiniGameCameraImprovementManager.VictoryAction();

    public void LoseAction() => MiniGameCameraImprovementManager.LoseAction();
}
