using UnityEngine;
using UnityEditor;
using UnityEngine.SceneManagement;
using ScriptableObjects.LvlsManager;

namespace LvlGenerator
{
    public class PlatformGeneratorManager : MonoBehaviour
    {
        [SerializeField]
        bool ItIsStart;
        [SerializeField]
        GameObject AllLvlPlatforms;
        [SerializeField]
        int PlatformsNumber;
        [SerializeField]
        GameObject MajorMatchingPlatforms;
        [SerializeField]
        GameObject WinPlatform;
        Vector3 GenerationPosition;
        float PlatformTypeIndex;
        float PlatformNextPositionTypeIndex;
        int CustomPlatformsCreated;
        GameObject LastCreatedPlatform;
        [Header("PlatformsPrefabs:")]
        [SerializeField]
        GameObject StandardPlatformPrefab;
        [SerializeField]
        GameObject MajorMatchingPlatformPrefab;
        [SerializeField]
        GameObject WeakPlatformPrefab;
        [SerializeField]
        GameObject MovePlatformPrefab;
        [Header("What types of platforms will be created:")]
        [SerializeField]
        bool MajorMatching;
        [SerializeField]
        bool WeakPlatform;
        [SerializeField]
        bool MovePlatform;
        [Header("Time:")]
        public int TimeForLvl;
        public int TimeForOneStar;
        public int TimeForTwoStars;
        public int TimeForTreeStars;
        [Header("Prizes:")]
        public int MoneyForTheFirstStar;
        public int MoneyForTheSecondStar;
        public int MoneyForTheThirdStar;
        public int EliteMoneyForTheThirdStar;
        [Header("SaveLevelSettings")]
        [SerializeField]
        string FolderNameForSaveLvl;
        public int LvlNumber;
        [SerializeField]
        LvlsManager LvlsManager;
#if UNITY_EDITOR
        void Start()
        {
            if (ItIsStart)
                CreateLvl();
        }
        [ContextMenu("CreateLvl")]
        void CreateLvl()
        {
            SetNewPositionForNextPlatform();
            for (int PlatformsCreated = 0; PlatformsCreated <= PlatformsNumber - 2; PlatformsCreated++)
            {
                if (PlatformsCreated == PlatformsNumber - 2)
                    WinPlatform.transform.position = GenerationPosition;
                else
                {
                    if (CustomPlatformsCreated == 2)
                    {
                        LastCreatedPlatform = Instantiate(StandardPlatformPrefab, GenerationPosition, Quaternion.identity);
                        LastCreatedPlatform.gameObject.transform.SetParent(AllLvlPlatforms.transform);
                        SetNewPositionForNextPlatform();
                        CustomPlatformsCreated = 0;
                    }
                    else
                    {
                        CreateCustomPlatform();
                        CustomPlatformsCreated++;
                    }
                }
            }
            SaveLevel();
        }
        void SetNewPositionForNextPlatform()
        {
            PlatformNextPositionTypeIndex = Mathf.Round(Random.Range(0, 3));
            if (PlatformNextPositionTypeIndex == 0)
                GenerationPosition += new Vector3(13, 0, 0);
            if (PlatformNextPositionTypeIndex == 1)
                GenerationPosition += new Vector3(13, 5, 0);
            if (PlatformNextPositionTypeIndex == 2)
                GenerationPosition += new Vector3(13, -2, 0);
        }
        void CreateCustomPlatform()
        {
            if (MajorMatching == false && WeakPlatform == false && MovePlatform == false)
            {
                LastCreatedPlatform = Instantiate(StandardPlatformPrefab, GenerationPosition, Quaternion.identity);
                LastCreatedPlatform.gameObject.transform.SetParent(AllLvlPlatforms.transform);
                SetNewPositionForNextPlatform();
                return;
            }
            PlatformTypeIndex = Mathf.Round(Random.Range(1, 4));
            if (PlatformTypeIndex == 1)
            {
                if (MajorMatching)
                {
                    LastCreatedPlatform = Instantiate(MajorMatchingPlatformPrefab, GenerationPosition, Quaternion.identity);
                    SetNewPositionForNextPlatform();
                    LastCreatedPlatform.gameObject.transform.SetParent(MajorMatchingPlatforms.transform);
                }
                else
                {
                    CreateCustomPlatform();
                    return;
                }
            }
            else if (PlatformTypeIndex == 2)
            {
                if (WeakPlatform)
                {
                    LastCreatedPlatform = Instantiate(WeakPlatformPrefab, GenerationPosition, Quaternion.identity);
                    LastCreatedPlatform.gameObject.transform.SetParent(AllLvlPlatforms.transform);
                    SetNewPositionForNextPlatform();
                }
                else
                {
                    CreateCustomPlatform();
                    return;
                }
            }
            else if (PlatformTypeIndex == 3 && CustomPlatformsCreated == 0)
            {
                if (MovePlatform)
                {
                    GenerationPosition += new Vector3(-2, 0, 0);
                    LastCreatedPlatform = Instantiate(MovePlatformPrefab, GenerationPosition, Quaternion.identity);
                    LastCreatedPlatform.gameObject.transform.SetParent(AllLvlPlatforms.transform);
                    GenerationPosition += new Vector3(8, 0, 0);
                    SetNewPositionForNextPlatform();
                    CustomPlatformsCreated = 1;
                }
                else
                {
                    CreateCustomPlatform();
                    return;
                }
            }
            else if (Random.Range(0, 2) == 0)
                CreateCustomPlatform();
            else
            {
                LastCreatedPlatform = Instantiate(StandardPlatformPrefab, GenerationPosition, Quaternion.identity);
                LastCreatedPlatform.gameObject.transform.SetParent(AllLvlPlatforms.transform);
                SetNewPositionForNextPlatform();
            }

        }
        [ContextMenu("SaveLvl")]
        void SaveLevel()
        {
            ItIsStart = false;
            LvlsManager.Lvls[LvlNumber] = PrefabUtility.SaveAsPrefabAsset(gameObject, FolderNameForSaveLvl + LvlNumber + ".prefab");
            PlayerPrefs.SetInt("LvlNumber", LvlNumber);
            SceneManager.LoadScene("Lvl");
        }
#endif
    }
}
