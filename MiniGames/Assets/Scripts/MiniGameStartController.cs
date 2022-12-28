using UnityEngine;

public class MiniGameStartController : MonoBehaviour
{
    [SerializeField]
    private Transform TransformPoint;
    private GameObject MiniGame;

    public void StartMiniGame(GameObject MiniGame)
    {
        MiniGame = Instantiate(MiniGame, TransformPoint.position, TransformPoint.rotation);

        MiniGame.transform.SetParent(TransformPoint);
        MiniGame.transform.localScale = new Vector3(1, 1, 1);
        MiniGame.GetComponent<RectTransform>().offsetMin = new Vector2(0, 0);
        MiniGame.GetComponent<RectTransform>().offsetMax = new Vector2(0, 0);
    }
}
