using UnityEngine;
using UnityEngine.UI;

public class FingerprintGeneratorController : MonoBehaviour
{
    public MiniGameFingerprintsManager MiniGameFingerprintsManager;

    [Header("FingerprintGameObject")]
    [SerializeField]
    private GameObject Fingerprint0_0;
    [SerializeField]
    private GameObject Fingerprint0_1;
    private GameObject ThisFingerprint;
    [SerializeField]
    private GameObject LeftPoint;
    [SerializeField]
    private GameObject RightPoint;
    [SerializeField]
    private GameObject LowerPoint;
    [SerializeField]
    private GameObject UpperPoint;

    [Header("FingerprintImage")]
    [SerializeField]
    private Sprite[] FingerprintSprites;

    private void Start()
    {
        for (int CreatedFingerprint = 0; CreatedFingerprint < MiniGameFingerprintsManager.FinishFingerprintAmount; CreatedFingerprint++)
        {
            if (MiniGameFingerprintsManager.ThisGameMode == MiniGameFingerprintsManager.GameMode.StandardMode)
                ThisFingerprint = Instantiate(Fingerprint0_0, new Vector3(Random.Range(LeftPoint.transform.position.x, RightPoint.transform.position.x), Random.Range(LowerPoint.transform.position.y, UpperPoint.transform.position.y),
                gameObject.transform.position.z), new Quaternion(0, 0, Random.Range(0, 360), 0));
            else
                ThisFingerprint = Instantiate(Fingerprint0_1, new Vector3(Random.Range(LeftPoint.transform.position.x, RightPoint.transform.position.x), Random.Range(LowerPoint.transform.position.y, UpperPoint.transform.position.y),
                gameObject.transform.position.z), new Quaternion(0, 0, Random.Range(0, 360), 0));

            ThisFingerprint.transform.SetParent(gameObject.transform);
            ThisFingerprint.transform.localScale = new Vector3(1, 1, 1);

            if (MiniGameFingerprintsManager.ThisGameMode == MiniGameFingerprintsManager.GameMode.StandardMode)
            {
                ThisFingerprint.GetComponent<Image>().sprite = FingerprintSprites[MiniGameFingerprintsManager.FingerprintThisSpriteNumber];
                ThisFingerprint.GetComponent<FingerprintController>().MiniGameFingerprintsManager = MiniGameFingerprintsManager;
            }
            else
                ThisFingerprint.GetComponent<ObjectsBank>().Objects[0].GetComponent<Image>().sprite = FingerprintSprites[MiniGameFingerprintsManager.FingerprintThisSpriteNumber];
        }
    }
}
