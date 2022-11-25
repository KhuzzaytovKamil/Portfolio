using UnityEngine;
using MatchingCardsLvlGame;

namespace MatchingCardsLvlGenerator
{
    public class MatchingCardsСardTypeManager : MonoBehaviour
    {
        [SerializeField] 
        int ThingNumber;
        [SerializeField]
        MatchingCardsCardController[] MatchingCardsCardController;
        [SerializeField]
        bool[] BusyTypes;
        [SerializeField]
        bool[] UsedCards;
        [SerializeField]
        int LastCardNumber;
        int CardNumber;
        int RandomThingTypeNumber;
        void Start()
        {
            while (true)
            {
                RandomThingTypeNumber = Random.Range(0, ThingNumber);
                if (BusyTypes[RandomThingTypeNumber] == false)
                {
                    BusyTypes[RandomThingTypeNumber] = true;
                    break;
                }
                    
            }
            SetThingTypeToCard();
            SetThingTypeToCard();
            CardNumber = LastCardNumber - 1;
            while (UsedCards[CardNumber] == true)
            {
                CardNumber--;
                if (CardNumber == -1)
                    return;
            }
            Start();
        }
        void SetThingTypeToCard()
        {
            CardNumber = Random.Range(0, LastCardNumber);
            while (UsedCards[CardNumber] == true)
            {
                CardNumber = Random.Range(0, LastCardNumber);
            }
            UsedCards[CardNumber] = true;
            MatchingCardsCardController[CardNumber].ThingTypeNumber = RandomThingTypeNumber;
        }
    }
}
