using UnityEngine;

namespace ScriptableObjects.Economy
{
    [CreateAssetMenu(menuName = "Economy/Skins/PlayerSkinsManager")]
    public class PlayerSkinsManager : ScriptableObject
    {
        [Header("ChangeStatusTimeTriggers:")]
        public float HungerForMiddleStatus;
        public float HungerForSadStatus;
        public float HungerForAngryStatus;
        public float ExtraHungerInSecond;
        [Header("AnimTime:")]
        public float StandardAnimationTimeBetweenFramesInSecond;
        public float FunAnimationTimeBetweenFramesInSecond;
        public float MiddleAnimationTimeBetweenFramesInSecond;
        public float SadAnimationTimeBetweenFramesInSecond;
        public float AngryAnimationTimeBetweenFramesInSecond;
        public float CryAnimationTimeBetweenFramesInSecond;
        public float DepressedAnimationTimeBetweenFramesInSecond;
        public float HandAnimationTimeBetweenFramesInSecond;
        public float SleepAnimationTimeBetweenFramesInSecond;
        public float LunchAnimationTimeBetweenFramesInSecond;
        [Header("GeneralData:")]
        public int SkinNumber;
        public int[] SkinPrice;
        [Header("GeneralArtsLists:")]
        public Sprite[] SkinInPipe;
        public Sprite[] SkinStandard;
        public Sprite[] SkinClosingEye;
        [Header("FunArtsLists:")]
        public Sprite[] SkinFun_1;
        public Sprite[] SkinFun_2;
        public Sprite[] SkinFun_3;
        public Sprite[] SkinFun_4;
        public Sprite[] SkinFun_5;
        [Header("MiddleArtsLists:")]
        public Sprite[] SkinMiddle_1;
        public Sprite[] SkinMiddle_2;
        public Sprite[] SkinMiddle_3;
        public Sprite[] SkinMiddle_4;
        public Sprite[] SkinMiddle_5;
        [Header("SadArtsLists:")]
        public Sprite[] SkinSad_1;
        public Sprite[] SkinSad_2;
        public Sprite[] SkinSad_3;
        public Sprite[] SkinSad_4;
        public Sprite[] SkinSad_5;
        [Header("AngryArtsLists:")]
        public Sprite[] SkinAngry_1;
        public Sprite[] SkinAngry_2;
        public Sprite[] SkinAngry_3;
        [Header("CryArtsLists:")]
        public Sprite[] SkinCry_1;
        public Sprite[] SkinCry_2;
        public Sprite[] SkinCry_3;
        [Header("DepressedArtsLists:")]
        public Sprite[] SkinDepressed_1;
        public Sprite[] SkinDepressed_2;
        [Header("HandArtsLists:")]
        public Sprite[] SkinHand_1;
        public Sprite[] SkinHand_2;
        [Header("SleepArtsLists:")]
        public Sprite[] SkinSleep_1;
        public Sprite[] SkinSleep_2;
        public Sprite[] SkinSleep_3;
        [Header("LunchArtsLists:")]
        public Sprite[] SkinLunch_1;
        public Sprite[] SkinLunch_2;
        public Sprite[] SkinLunch_3;
        public Sprite[] SkinLunch_4;
        public Sprite[] SkinLunch_5;
        public Sprite[] SkinLunch_6;
        public Sprite[] SkinLunch_7;
        [Header("HandsArts:")]
        public Sprite[] HandsSkin;
    }
}
