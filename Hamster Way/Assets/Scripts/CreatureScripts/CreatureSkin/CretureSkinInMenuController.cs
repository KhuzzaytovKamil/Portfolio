using UnityEngine;
using UnityEngine.UI;
using ScriptableObjects.Economy;
using System;
using System.Collections;

namespace Creature.Skins
{
    public class CretureSkinInMenuController : MonoBehaviour
    {
        [SerializeField]
        PlayerSkinsManager PlayerSkinsManager;
        float TimeBeforeNextAnimSwitch;
        int MoodAnimNumber = 1;
        public string AnimType = "ChooseAnim";
        int AnimTypeNumber;
        int RepeatsNumber;
        [SerializeField]
        PrizeManager PrizeManager;
        [SerializeField]
        GameObject Hands;
        [SerializeField]
        Image Food;
        [SerializeField]
        GameObject FoodMaxYPositionPoint;
        float FoodMinYPosition;
        bool AnimStarted = false;

        void Start()
        {
            gameObject.GetComponent<Image>().sprite = PlayerSkinsManager.SkinStandard[PlayerPrefs.GetInt("ActiveSkinNumber")];
            UpdateData();
            SetRightAnim();
            StartCoroutine(SetCretureAnim());
            FoodMinYPosition = gameObject.transform.position.y;
        }
        IEnumerator SetCretureAnim()
        {
            yield return new WaitForSeconds(TimeBeforeNextAnimSwitch);
            SetRightAnim();
            StartCoroutine(SetCretureAnim());
        }
        void SetRightAnim()
        {
            UpdateData();
            
            if (AnimType == "Eat")
            {
                TimeBeforeNextAnimSwitch = PlayerSkinsManager.LunchAnimationTimeBetweenFramesInSecond;
                SetEatImage();
                if (AnimStarted == false)
                    MoodAnimNumber = 1;
            }  
            else if (AnimType == "Hand")
            {
                TimeBeforeNextAnimSwitch = PlayerSkinsManager.HandAnimationTimeBetweenFramesInSecond;
                SetHandImage();
                if (AnimStarted == false)
                    MoodAnimNumber = 1;
            }
            else if (PlayerPrefs.GetFloat("CurrentHungry") >= PlayerSkinsManager.HungerForAngryStatus)
            {
                if (AnimType == "Angry")
                {
                    TimeBeforeNextAnimSwitch = PlayerSkinsManager.AngryAnimationTimeBetweenFramesInSecond;
                    SetAngryImage();
                    RepeatsNumber = UnityEngine.Random.Range(0, 3);
                }
                else if (AnimType == "Depressed")
                {
                    TimeBeforeNextAnimSwitch = PlayerSkinsManager.DepressedAnimationTimeBetweenFramesInSecond;
                    SetDepressedImage();
                    RepeatsNumber = UnityEngine.Random.Range(0, 3);
                }
                else
                {
                    MoodAnimNumber = 1;
                    AnimTypeNumber = UnityEngine.Random.Range(1, 3);
                    if (AnimTypeNumber == 1)
                        AnimType = "Angry";
                    else
                        AnimType = "Depressed";
                }
            }
            else if (PlayerPrefs.GetFloat("CurrentHungry") >= PlayerSkinsManager.HungerForSadStatus)
            {
                if (AnimType == "Sad")
                {
                    TimeBeforeNextAnimSwitch = PlayerSkinsManager.SadAnimationTimeBetweenFramesInSecond;
                    SetSadImage();
                    RepeatsNumber = UnityEngine.Random.Range(0, 3);
                }
                else if (AnimType == "Cry")
                {
                    TimeBeforeNextAnimSwitch = PlayerSkinsManager.CryAnimationTimeBetweenFramesInSecond;
                    SetCryImage();
                    RepeatsNumber = UnityEngine.Random.Range(0, 3);
                }
                else
                {
                    MoodAnimNumber = 1;
                    AnimTypeNumber = UnityEngine.Random.Range(1, 3);
                    if (AnimTypeNumber == 1)
                        AnimType = "Sad";
                    else if (AnimTypeNumber == 2)
                        AnimType = "Cry";
                }
            }
            else if (PlayerPrefs.GetFloat("CurrentHungry") >= PlayerSkinsManager.HungerForMiddleStatus)
            {
                if (AnimType == "Middle")
                {
                    TimeBeforeNextAnimSwitch = PlayerSkinsManager.MiddleAnimationTimeBetweenFramesInSecond;
                    SetMiddleImage();
                    RepeatsNumber = UnityEngine.Random.Range(0, 3);
                }
                else if (AnimType == "Sleep")
                {
                    TimeBeforeNextAnimSwitch = PlayerSkinsManager.SleepAnimationTimeBetweenFramesInSecond;
                    SetHandImage();
                    RepeatsNumber = UnityEngine.Random.Range(0, 3);
                }
                else if (AnimType == "Wait")
                {
                    TimeBeforeNextAnimSwitch = PlayerSkinsManager.StandardAnimationTimeBetweenFramesInSecond;
                    SetWaitImage();
                    RepeatsNumber = UnityEngine.Random.Range(0, 5);
                }
                else
                {
                    MoodAnimNumber = 1;
                    AnimTypeNumber = UnityEngine.Random.Range(1, 4);
                    if (AnimTypeNumber == 1)
                        AnimType = "Sleep";
                    else if (AnimTypeNumber == 2)
                        AnimType = "Middle";
                    else if (AnimTypeNumber == 3)
                        AnimType = "Wait";
                }
            }
            else
            {
                if (AnimType == "Fun")
                {
                    TimeBeforeNextAnimSwitch = PlayerSkinsManager.FunAnimationTimeBetweenFramesInSecond;
                    SetFunImage();
                    RepeatsNumber = UnityEngine.Random.Range(0, 3);
                }
                else if (AnimType == "Middle")
                {
                    TimeBeforeNextAnimSwitch = PlayerSkinsManager.MiddleAnimationTimeBetweenFramesInSecond;
                    SetMiddleImage();
                    RepeatsNumber = UnityEngine.Random.Range(0, 3);
                }
                else if (AnimType == "Sleep")
                {
                    TimeBeforeNextAnimSwitch = PlayerSkinsManager.SleepAnimationTimeBetweenFramesInSecond;
                    SetSleepImage();
                    RepeatsNumber = UnityEngine.Random.Range(0, 7);
                }
                else if (AnimType == "Wait")
                {
                    TimeBeforeNextAnimSwitch = PlayerSkinsManager.StandardAnimationTimeBetweenFramesInSecond;
                    SetWaitImage();
                    RepeatsNumber = UnityEngine.Random.Range(0, 5);
                }
                else
                {
                    MoodAnimNumber = 1;
                    AnimTypeNumber = UnityEngine.Random.Range(1, 5);
                    if (AnimTypeNumber == 1)
                        AnimType = "Fun";
                    else if (AnimTypeNumber == 2)
                        AnimType = "Middle";
                    else if (AnimTypeNumber == 3)
                        AnimType = "Sleep";
                    else if (AnimTypeNumber == 4)
                        AnimType = "Wait";
                }
            }
        }
        void SetSadImage()
        {
            if (MoodAnimNumber == 1)
                gameObject.GetComponent<Image>().sprite = PlayerSkinsManager.SkinSad_1[PlayerPrefs.GetInt("ActiveSkinNumber")];
            else if (MoodAnimNumber == 2)
                gameObject.GetComponent<Image>().sprite = PlayerSkinsManager.SkinSad_2[PlayerPrefs.GetInt("ActiveSkinNumber")];
            else if (MoodAnimNumber == 3)
                gameObject.GetComponent<Image>().sprite = PlayerSkinsManager.SkinSad_3[PlayerPrefs.GetInt("ActiveSkinNumber")];
            else if (MoodAnimNumber == 4)
                gameObject.GetComponent<Image>().sprite = PlayerSkinsManager.SkinSad_4[PlayerPrefs.GetInt("ActiveSkinNumber")];
            else if (MoodAnimNumber == 5)
                gameObject.GetComponent<Image>().sprite = PlayerSkinsManager.SkinSad_5[PlayerPrefs.GetInt("ActiveSkinNumber")];
            if (MoodAnimNumber < 5)
                MoodAnimNumber++;
            else if (RepeatsNumber > 0)
            {
                MoodAnimNumber = 1;
                RepeatsNumber--;
            }
            else
                AnimType = "ChooseAnim";
        }
        void SetMiddleImage()
        {
            if (MoodAnimNumber == 1)
                gameObject.GetComponent<Image>().sprite = PlayerSkinsManager.SkinMiddle_1[PlayerPrefs.GetInt("ActiveSkinNumber")];
            else if (MoodAnimNumber == 2)
                gameObject.GetComponent<Image>().sprite = PlayerSkinsManager.SkinMiddle_2[PlayerPrefs.GetInt("ActiveSkinNumber")];
            else if (MoodAnimNumber == 3)
                gameObject.GetComponent<Image>().sprite = PlayerSkinsManager.SkinMiddle_3[PlayerPrefs.GetInt("ActiveSkinNumber")];
            else if (MoodAnimNumber == 4)
                gameObject.GetComponent<Image>().sprite = PlayerSkinsManager.SkinMiddle_4[PlayerPrefs.GetInt("ActiveSkinNumber")];
            else if (MoodAnimNumber == 5)
                gameObject.GetComponent<Image>().sprite = PlayerSkinsManager.SkinMiddle_5[PlayerPrefs.GetInt("ActiveSkinNumber")];
            if (MoodAnimNumber < 5)
                MoodAnimNumber++;
            else if (RepeatsNumber > 0)
            {
                MoodAnimNumber = 1;
                RepeatsNumber--;
            }
            else
                AnimType = "ChooseAnim";
        }
        void SetFunImage()
        {
            if (MoodAnimNumber == 1)
                gameObject.GetComponent<Image>().sprite = PlayerSkinsManager.SkinFun_1[PlayerPrefs.GetInt("ActiveSkinNumber")];
            else if (MoodAnimNumber == 2)
                gameObject.GetComponent<Image>().sprite = PlayerSkinsManager.SkinFun_2[PlayerPrefs.GetInt("ActiveSkinNumber")];
            else if (MoodAnimNumber == 3)
                gameObject.GetComponent<Image>().sprite = PlayerSkinsManager.SkinFun_3[PlayerPrefs.GetInt("ActiveSkinNumber")];
            else if (MoodAnimNumber == 4)
                gameObject.GetComponent<Image>().sprite = PlayerSkinsManager.SkinFun_4[PlayerPrefs.GetInt("ActiveSkinNumber")];
            else if (MoodAnimNumber == 5)
                gameObject.GetComponent<Image>().sprite = PlayerSkinsManager.SkinFun_5[PlayerPrefs.GetInt("ActiveSkinNumber")];
            if (MoodAnimNumber < 5)
                MoodAnimNumber++;
            else if (RepeatsNumber > 0)
            {
                MoodAnimNumber = 1;
                RepeatsNumber--;
            }
            else
                AnimType = "ChooseAnim";
        }
        void SetHandImage()
        {
            if (MoodAnimNumber == 1)
            {
                AnimStarted = true;
                gameObject.GetComponent<Image>().sprite = PlayerSkinsManager.SkinHand_1[PlayerPrefs.GetInt("ActiveSkinNumber")];
            }
            else if (MoodAnimNumber == 2)
                gameObject.GetComponent<Image>().sprite = PlayerSkinsManager.SkinHand_2[PlayerPrefs.GetInt("ActiveSkinNumber")];
            if (MoodAnimNumber < 2)
                MoodAnimNumber++;
            else if (RepeatsNumber > 0)
            {
                MoodAnimNumber = 1;
                RepeatsNumber--;
            }
            else
            {
                AnimStarted = false;
                AnimType = "ChooseAnim";
            }
        }
        void SetDepressedImage()
        {
            if (MoodAnimNumber == 1)
                gameObject.GetComponent<Image>().sprite = PlayerSkinsManager.SkinDepressed_1[PlayerPrefs.GetInt("ActiveSkinNumber")];
            else if (MoodAnimNumber == 2)
                gameObject.GetComponent<Image>().sprite = PlayerSkinsManager.SkinDepressed_2[PlayerPrefs.GetInt("ActiveSkinNumber")];
            if (MoodAnimNumber < 2)
                MoodAnimNumber++;
            else if (RepeatsNumber > 0)
            {
                MoodAnimNumber = 1;
                RepeatsNumber--;
            }
            else
                AnimType = "ChooseAnim";
        }
        void SetCryImage()
        {
            if (MoodAnimNumber == 1)
                gameObject.GetComponent<Image>().sprite = PlayerSkinsManager.SkinCry_1[PlayerPrefs.GetInt("ActiveSkinNumber")];
            else if (MoodAnimNumber == 2)
                gameObject.GetComponent<Image>().sprite = PlayerSkinsManager.SkinCry_2[PlayerPrefs.GetInt("ActiveSkinNumber")];
            else if (MoodAnimNumber == 3)
                gameObject.GetComponent<Image>().sprite = PlayerSkinsManager.SkinCry_3[PlayerPrefs.GetInt("ActiveSkinNumber")];
            if (MoodAnimNumber < 3)
                MoodAnimNumber++;
            else if (RepeatsNumber > 0)
            {
                MoodAnimNumber = 1;
                RepeatsNumber--;
            }
            else
                AnimType = "ChooseAnim";
        }
        void SetSleepImage()
        {
            if (MoodAnimNumber == 1)
                gameObject.GetComponent<Image>().sprite = PlayerSkinsManager.SkinSleep_1[PlayerPrefs.GetInt("ActiveSkinNumber")];
            else if (MoodAnimNumber == 2)
                gameObject.GetComponent<Image>().sprite = PlayerSkinsManager.SkinSleep_2[PlayerPrefs.GetInt("ActiveSkinNumber")];
            else if (MoodAnimNumber == 3)
                gameObject.GetComponent<Image>().sprite = PlayerSkinsManager.SkinSleep_3[PlayerPrefs.GetInt("ActiveSkinNumber")];
            if (MoodAnimNumber < 3)
                MoodAnimNumber++;
            else if (RepeatsNumber > 0)
            {
                MoodAnimNumber = 1;
                RepeatsNumber--;
            }
            else
                AnimType = "ChooseAnim";
        }
        void SetAngryImage()
        {
            if (MoodAnimNumber == 1)
                gameObject.GetComponent<Image>().sprite = PlayerSkinsManager.SkinAngry_1[PlayerPrefs.GetInt("ActiveSkinNumber")];
            else if (MoodAnimNumber == 2)
                gameObject.GetComponent<Image>().sprite = PlayerSkinsManager.SkinAngry_2[PlayerPrefs.GetInt("ActiveSkinNumber")];
            else if (MoodAnimNumber == 3)
                gameObject.GetComponent<Image>().sprite = PlayerSkinsManager.SkinAngry_3[PlayerPrefs.GetInt("ActiveSkinNumber")];
            if (MoodAnimNumber < 3)
                MoodAnimNumber++;
            else if (RepeatsNumber > 0)
            {
                MoodAnimNumber = 1;
                RepeatsNumber--;
            }
            else
                AnimType = "ChooseAnim";
        }
        void SetWaitImage()
        {
            if (MoodAnimNumber == 1)
                gameObject.GetComponent<Image>().sprite = PlayerSkinsManager.SkinStandard[PlayerPrefs.GetInt("ActiveSkinNumber")];
            else
            {
                gameObject.GetComponent<Image>().sprite = PlayerSkinsManager.SkinClosingEye[PlayerPrefs.GetInt("ActiveSkinNumber")];
                TimeBeforeNextAnimSwitch = TimeBeforeNextAnimSwitch / 3;
            }
            if (MoodAnimNumber < 2)
                MoodAnimNumber++;
            else if (RepeatsNumber > 0)
            {
                MoodAnimNumber = 1;
                RepeatsNumber--;
            }
            else
                AnimType = "ChooseAnim";
        }

        public void SetEatImage()
        {
            if (MoodAnimNumber == 1)
            {
                gameObject.GetComponent<Image>().sprite = PlayerSkinsManager.SkinLunch_1[PlayerPrefs.GetInt("ActiveSkinNumber")];
                Hands.gameObject.SetActive(true);
                AnimStarted = true;
                Hands.SetActive(true);
            }
            else if (MoodAnimNumber == 2)
            {
                gameObject.GetComponent<Image>().sprite = PlayerSkinsManager.SkinLunch_2[PlayerPrefs.GetInt("ActiveSkinNumber")];
                Hands.transform.position -= new Vector3(0, (FoodMaxYPositionPoint.transform.position.y - FoodMinYPosition) / 2, 0);
            }
            else if (MoodAnimNumber == 3)
            {
                gameObject.GetComponent<Image>().sprite = PlayerSkinsManager.SkinLunch_3[PlayerPrefs.GetInt("ActiveSkinNumber")];
                Hands.transform.position -= new Vector3(0, (FoodMaxYPositionPoint.transform.position.y - FoodMinYPosition) / 2, 0);
            }
            else if (MoodAnimNumber == 4)
            {
                gameObject.GetComponent<Image>().sprite = PlayerSkinsManager.SkinLunch_4[PlayerPrefs.GetInt("ActiveSkinNumber")];
            }
            else if (MoodAnimNumber == 5)
            {
                gameObject.GetComponent<Image>().sprite = PlayerSkinsManager.SkinLunch_5[PlayerPrefs.GetInt("ActiveSkinNumber")];
                Food.fillAmount = 0.6f;
            }
            else if (MoodAnimNumber == 6)
                gameObject.GetComponent<Image>().sprite = PlayerSkinsManager.SkinLunch_6[PlayerPrefs.GetInt("ActiveSkinNumber")];
            else if (MoodAnimNumber == 7)
                gameObject.GetComponent<Image>().sprite = PlayerSkinsManager.SkinLunch_3[PlayerPrefs.GetInt("ActiveSkinNumber")];
            else if (MoodAnimNumber == 8)
                gameObject.GetComponent<Image>().sprite = PlayerSkinsManager.SkinLunch_4[PlayerPrefs.GetInt("ActiveSkinNumber")];
            else if (MoodAnimNumber == 9)
            {
                gameObject.GetComponent<Image>().sprite = PlayerSkinsManager.SkinLunch_5[PlayerPrefs.GetInt("ActiveSkinNumber")];
                Food.fillAmount = 0;
            }
            else if (MoodAnimNumber == 10)
            {
                Food.fillAmount = 1;
                Hands.gameObject.SetActive(false);
                gameObject.GetComponent<Image>().sprite = PlayerSkinsManager.SkinLunch_7[PlayerPrefs.GetInt("ActiveSkinNumber")];
                Hands.transform.position += new Vector3(0, FoodMaxYPositionPoint.transform.position.y - FoodMinYPosition, 0);
            }
            if (MoodAnimNumber < 10)
                MoodAnimNumber++;
            else
            {
                AnimStarted = false;
                AnimType = "ChooseAnim";
            }
        }

        void UpdateData()
        {
            PlayerPrefs.SetFloat("CurrentHungry", PlayerPrefs.GetFloat("CurrentHungry") + ((int)(DateTime.UtcNow - new DateTime(2020, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalSeconds - PlayerPrefs.GetInt("LastLoginTime")) * PlayerSkinsManager.ExtraHungerInSecond);
            PlayerPrefs.SetFloat("HappinessPoint", PlayerPrefs.GetFloat("HappinessPoint") + ((int)(DateTime.UtcNow - new DateTime(2020, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalSeconds - PlayerPrefs.GetInt("LastLoginTime")) * PrizeManager.ExtraHappinessPointInSecond * (1 - PlayerPrefs.GetFloat("CurrentHungry")));
            PlayerPrefs.SetInt("LastLoginTime", (int)(DateTime.UtcNow - new DateTime(2020, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalSeconds);

            if (PlayerPrefs.GetFloat("HappinessPoint") > PrizeManager.MaxHappinessPoint)
                PlayerPrefs.SetFloat("HappinessPoint", PrizeManager.MaxHappinessPoint);

            if (PlayerPrefs.GetFloat("CurrentHungry") > 1)
                PlayerPrefs.SetFloat("CurrentHungry", 1);
        }

        public void HamsterContact() => AnimType = "Hand";
    }
}
