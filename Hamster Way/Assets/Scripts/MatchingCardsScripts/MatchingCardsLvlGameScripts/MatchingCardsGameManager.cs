using UnityEngine;
using UnityEngine.UI;
using Finish.WinSystem;
using Finish.MatchingCardsLvlFinishSystem;

namespace MatchingCardsLvlGame
{
    public class MatchingCardsGameManager : MonoBehaviour
    {
        public LastsOpeningController LastsOpeningController;
        int TheFirstTypeNumber;
        GameObject TheFirstOpenedCard;
        int FoundPairs;
        [SerializeField]
        int PairsNumberInLvl;
        public WinManager WinManager;
        public void CardIsOpened(GameObject Card, int ThingTypeNumber)
        {
            if (TheFirstOpenedCard != Card)
            {
                if (TheFirstOpenedCard == null)
                {
                    TheFirstTypeNumber = ThingTypeNumber;
                    TheFirstOpenedCard = Card;
                }
                else if (TheFirstTypeNumber == ThingTypeNumber)
                {
                    Destroy(TheFirstOpenedCard.GetComponent<Button>());
                    Destroy(Card.GetComponent<Button>());
                    FoundPairs++;
                    if (PairsNumberInLvl == FoundPairs)
                        WinManager.WinGame();
                    else
                        TheFirstOpenedCard = null;
                }
                else
                {
                    TheFirstOpenedCard.GetComponent<MatchingCardsCardController>().CloseCard();
                    Card.GetComponent<MatchingCardsCardController>().CloseCard();
                    TheFirstOpenedCard = null;
                }
            }
            else
                LastsOpeningController.OpeningBeforeLose++;
        }
        
        public void DestroyOneOpening() => LastsOpeningController.OpeningBeforeLose--;
    }
}

