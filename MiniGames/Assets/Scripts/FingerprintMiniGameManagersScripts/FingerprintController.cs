using UnityEngine;

public class FingerprintController : MonoBehaviour
{
    public MiniGameFingerprintsManager MiniGameFingerprintsManager;

    public void Click()
    {
        MiniGameFingerprintsManager.FindedFingerprintAmount++;
        Destroy(gameObject);
    }
}
