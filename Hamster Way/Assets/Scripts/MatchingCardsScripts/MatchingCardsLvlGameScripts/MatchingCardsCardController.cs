using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using ScriptableObjects.LvlsManager;

namespace MatchingCardsLvlGame
{
    public class MatchingCardsCardController : MonoBehaviour
    {
        [SerializeField]
        MatchingCardsGameManager MatchingCardsGameManager;
        [SerializeField]
        Animator CardAnim;
        public int ThingTypeNumber;
        [SerializeField]
        MatchingCardsThingsTypeManager MatchingCardsThingsTypeManager;
        [SerializeField]
        Image ThingImage;
        void Start() => StartCoroutine(SetThingImage());
        
        public void OpenCard()
        {
            CardAnim.SetBool("OpenCard", true);
            CardAnim.SetBool("CloseCard", false);
            MatchingCardsGameManager.DestroyOneOpening();
            StartCoroutine(OpenAnimIsFinished());

        }
        public void CloseCard()
        {
            CardAnim.SetBool("OpenCard", false);
            CardAnim.SetBool("CloseCard", true);
        }
        IEnumerator OpenAnimIsFinished()
        {
            yield return new WaitForSeconds(0.3f);
            MatchingCardsGameManager.CardIsOpened(gameObject, ThingTypeNumber);
        }
        IEnumerator SetThingImage()
        {
            yield return new WaitForSeconds(0.1f);
            ThingImage.sprite = MatchingCardsThingsTypeManager.ThingSprite[ThingTypeNumber];
        }
    }
}

