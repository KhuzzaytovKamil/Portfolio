using UnityEngine;
using UnityEditor;
using Finish.ClassicLvlFinishSystem;
using Creature;
using Pipe;
using ScriptableObjects.LvlsManager;
using System;
using Main;
using TeleportationSystem;
using UnityEngine.SceneManagement;

namespace ClassicLvlGenerator
{
    public class PipelineCreateManager : MonoBehaviour
    {
#if UNITY_EDITOR
        [SerializeField]
        GameObject TransformPoint;
        [SerializeField]
        GameObject NormPipe;
        [SerializeField]
        GameObject RotationPipe;
        [SerializeField]
        GameObject TeleportationSystem;
        [SerializeField]
        GameObject UslessNormPipe;
        [SerializeField]
        GameObject UslessRotationPipe;
        [SerializeField]
        GameObject UslessTeleportationSystem;
        GameObject CurrentTeleportationSystem;
        [SerializeField]
        CreatedTypeObject CurrentCreatedTypeObject;
        [SerializeField]
        GameObject MainParent;
        public GameObject LastCreatedPipe;
        LoseTrigger ThisLoseTrigger;
        AnimStarter ThisAnimStarter;
        GameObject ThisPipe;
        AllPipeTurnController ThisPipeController;
        [SerializeField]
        GameObject TruePipeline;
        [SerializeField]
        GameObject Pipeline;
        GameObject RotationPipeParent;
        public static event Action SetTruePipeline;
        public static event Action StartLvlRefactoring;
        [SerializeField]
        GameObject ChangeFirstPipeTypeButton;
        [SerializeField]
        GameObject UpperTextureParent;
        [Header("SaveLevelSettings")]
        [SerializeField]
        string FolderNameForSaveLvl;
        [SerializeField]
        int LvlNumber;
        [SerializeField]
        ClassicLvlsManager ClassicLvlsManager;
        string LastCreatedPipeType;
        enum CreatedTypeObject { NormPipe, RotationPipe, UslessNormPipe, UslessRotationPipe, TeleportationSystem, UslessTeleportationSystem }
        [ContextMenu("CreatePipe")]
        public void CreateObject()
        {
            Destroy(ChangeFirstPipeTypeButton);
            if (CurrentCreatedTypeObject == CreatedTypeObject.UslessNormPipe)
            {
                ThisPipe = Instantiate(UslessNormPipe, TransformPoint.transform.position, NormPipe.transform.rotation);
                ThisPipe.transform.SetParent(MainParent.transform);
                ThisPipe.transform.localScale = new Vector3(1, 1, 1);
            }
            else if (CurrentCreatedTypeObject == CreatedTypeObject.UslessRotationPipe)
            {
                ThisPipe = Instantiate(UslessRotationPipe, TransformPoint.transform.position, RotationPipe.transform.rotation);
                ThisPipe.transform.SetParent(MainParent.transform);
                ThisPipe.transform.localScale = new Vector3(1, 1, 1);
            }
            else if(CurrentCreatedTypeObject == CreatedTypeObject.NormPipe)
            {
                ThisPipe = Instantiate(NormPipe, TransformPoint.transform.position, NormPipe.transform.rotation);
                ThisPipe.transform.SetParent(MainParent.transform);
                ThisPipe.transform.localScale = new Vector3(1, 1, 1);
                ThisPipe.GetComponent<ObjectsBank>().Objects[0].GetComponent<UpperTextureController>().UpperTextureParent = UpperTextureParent;
                ThisPipe.GetComponent<ObjectsBank>().Objects[1].GetComponent<SetTrueCreatureAnimController>().PipelineCreateManager = gameObject.GetComponent<PipelineCreateManager>();
                ThisPipe.GetComponent<ObjectsBank>().Objects[1].GetComponent<SetTrueCreatureAnimController>().LastPipe = LastCreatedPipe;
                ThisPipeController = ThisPipe.GetComponent<AllPipeTurnController>();
                LastCreatedPipeType = "NormPipe";
            }
            else if (CurrentCreatedTypeObject == CreatedTypeObject.RotationPipe)
            {
                RotationPipeParent = Instantiate(RotationPipe, TransformPoint.transform.position, RotationPipe.transform.rotation);
                RotationPipeParent.transform.SetParent(MainParent.transform);
                RotationPipeParent.transform.localScale = new Vector3(1, 1, 1);
                ThisPipe = RotationPipeParent.GetComponent<ObjectsBank>().Objects[0];
                RotationPipeParent.GetComponent<ObjectsBank>().Objects[2].GetComponent<UpperTextureController>().UpperTextureParent = UpperTextureParent;
                RotationPipeParent.GetComponent<ObjectsBank>().Objects[1].GetComponent<SetTrueCreatureAnimController>().PipelineCreateManager = gameObject.GetComponent<PipelineCreateManager>();
                RotationPipeParent.GetComponent<ObjectsBank>().Objects[1].GetComponent<SetTrueCreatureAnimController>().LastPipe = LastCreatedPipe;
                ThisPipeController = RotationPipeParent.GetComponent<AllPipeTurnController>();
                LastCreatedPipeType = "RotationPipe";
            }
            else if (CurrentCreatedTypeObject == CreatedTypeObject.TeleportationSystem)
            {
                CurrentTeleportationSystem = Instantiate(TeleportationSystem, TransformPoint.transform.position, TeleportationSystem.transform.rotation);
                CurrentTeleportationSystem.transform.SetParent(MainParent.transform);
                CurrentTeleportationSystem.transform.localScale = new Vector3(1, 1, 1);
                CurrentTeleportationSystem.GetComponent<MainTeleportationSystemController>().LastAnim = LastCreatedPipe.GetComponent<AnimStarter>().ThisAnim.GetComponent<CreatureMoveAnimController>();
                CurrentTeleportationSystem.GetComponent<MainTeleportationSystemController>().TeleportationFinishingStation.GetComponent<AnimStarter>().ThisAnim = LastCreatedPipe.GetComponent<AnimStarter>().ThisAnim;
                CurrentTeleportationSystem.GetComponent<MainTeleportationSystemController>().LastPipe = LastCreatedPipe;
                if (LastCreatedPipeType == "NormPipe")
                    LastCreatedPipe.GetComponent<ObjectsBank>().Objects[1].GetComponent<SetTrueCreatureAnimController>().LastPipe = CurrentTeleportationSystem.GetComponent<MainTeleportationSystemController>().TeleportationFinishingStation;
                if (LastCreatedPipeType == "RotationPipe")
                    RotationPipeParent.GetComponent<ObjectsBank>().Objects[1].GetComponent<SetTrueCreatureAnimController>().LastPipe = CurrentTeleportationSystem.GetComponent<MainTeleportationSystemController>().TeleportationFinishingStation;
                LastCreatedPipe = CurrentTeleportationSystem.GetComponent<MainTeleportationSystemController>().TeleportationFinishingStation;
            }
            else if (CurrentCreatedTypeObject == CreatedTypeObject.UslessTeleportationSystem)
            {
                CurrentTeleportationSystem = Instantiate(UslessTeleportationSystem, TransformPoint.transform.position, TeleportationSystem.transform.rotation);
                CurrentTeleportationSystem.transform.SetParent(MainParent.transform);
                CurrentTeleportationSystem.transform.localScale = new Vector3(1, 1, 1);
            }
            if (CurrentCreatedTypeObject == CreatedTypeObject.NormPipe || CurrentCreatedTypeObject == CreatedTypeObject.RotationPipe)
            {
                ThisLoseTrigger = ThisPipe.GetComponent<LoseTrigger>();
                ThisAnimStarter = ThisPipe.GetComponent<AnimStarter>();
                ThisLoseTrigger.LastPipe = LastCreatedPipe;
                ThisPipeController.TruePipeline = TruePipeline;
                ThisAnimStarter.LastAnim = LastCreatedPipe.GetComponent<AnimStarter>().ThisAnim.GetComponent<CreatureMoveAnimController>();
                LastCreatedPipe = ThisPipe;
            }
        }
        [ContextMenu("SaveLevel")]
        public void SaveLevel()
        {
            if (ClassicLvlsManager.Pipeline[LvlNumber] != null)
                Debug.Log("Please delete last prefab, before new create");
            else if (LvlNumber == 0)
                Debug.Log("Please set LvlNumber");
            else
            {
                if (LvlNumber < 21)
                    ClassicLvlsManager.Pipeline[LvlNumber] = PrefabUtility.SaveAsPrefabAsset(Pipeline, FolderNameForSaveLvl + "1 - 20/" + "ClassicPipelineForLvl_" + LvlNumber + ".prefab");
                else if (LvlNumber < 41)
                    ClassicLvlsManager.Pipeline[LvlNumber] = PrefabUtility.SaveAsPrefabAsset(Pipeline, FolderNameForSaveLvl + "21 - 40/" + "ClassicPipelineForLvl_" + LvlNumber + ".prefab");
                else if (LvlNumber < 61)
                    ClassicLvlsManager.Pipeline[LvlNumber] = PrefabUtility.SaveAsPrefabAsset(Pipeline, FolderNameForSaveLvl + "41 - 60/" + "ClassicPipelineForLvl_" + LvlNumber + ".prefab");
                else if (LvlNumber < 81)
                    ClassicLvlsManager.Pipeline[LvlNumber] = PrefabUtility.SaveAsPrefabAsset(Pipeline, FolderNameForSaveLvl + "61 - 80/" + "ClassicPipelineForLvl_" + LvlNumber + ".prefab");
                else if (LvlNumber < 101)
                    ClassicLvlsManager.Pipeline[LvlNumber] = PrefabUtility.SaveAsPrefabAsset(Pipeline, FolderNameForSaveLvl + "81 - 100/" + "ClassicPipelineForLvl_" + LvlNumber + ".prefab");
                SceneManager.LoadScene("ClassicLvl");
                PlayerPrefs.SetInt("ClassicLvlNumber", LvlNumber);
                ClassicLvlsManager.TimeForLvl[LvlNumber] = 3600;
            }
        }
        public void SetTruePipelineVoid() => SetTruePipeline.Invoke();
        
        void Start() => StartLvlRefactoring.Invoke();
        
        public void CancelLastCreate()
        {

        }
#endif
    }
}
