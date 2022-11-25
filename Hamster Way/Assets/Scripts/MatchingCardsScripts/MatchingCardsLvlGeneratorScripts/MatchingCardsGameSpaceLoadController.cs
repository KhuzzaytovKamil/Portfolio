using UnityEngine;
using Finish.WinSystem;
using Finish.MatchingCardsLvlFinishSystem;
using MatchingCardsLvlGame;
using ScriptableObjects.LvlsManager;

namespace MatchingCardsLvlGenerator
{
    public class MatchingCardsGameSpaceLoadController : MonoBehaviour
    {
        [SerializeField]
        GameObject ParentForGameSpace;
        [SerializeField]
        MatchingCardsLvlsManager MatchingCardsLvlsManager;
        [SerializeField]
        LastsOpeningController LastsOpeningController;
        [SerializeField]
        WinManager WinManager;
        void Start()
        {
            GameObject GameSpace = Instantiate(MatchingCardsLvlsManager.GameSpace[PlayerPrefs.GetInt("MatchingCardsLvlNumber")], transform.position, transform.rotation);
            GameSpace.transform.SetParent(ParentForGameSpace.transform);
            GameSpace.transform.localScale = new Vector3(1.1f, 1, 1);
            GameSpace.GetComponent<RectTransform>().offsetMin = new Vector2(0, 0);
            GameSpace.GetComponent<RectTransform>().offsetMax = new Vector2(0, 0);
            GameSpace.GetComponent<MatchingCardsGameManager>().LastsOpeningController = LastsOpeningController;
            GameSpace.GetComponent<MatchingCardsGameManager>().WinManager = WinManager;
        }
    }
}
