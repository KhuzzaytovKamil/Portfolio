using UnityEngine;
using System;
using System.Collections;
using Finish.LoseSystem;
using Creature.Skins;
using ClassicLvlGenerator;

namespace Finish.ClassicLvlFinishSystem
{
    public class PipelineInspector : MonoBehaviour
    {
        [SerializeField]
        GameObject ClickBlock;
        [SerializeField]
        LoseManager MainLoseScript;
        [SerializeField]
        GameObject TheFirstCreatureAnim;
        public static event Action StartChack;
        [SerializeField]
        CreatureSkinInHouseController HouseSkinController;
        bool FirstIsNormPipe = false;
        [SerializeField]
        GameObject FirstNormPipe;
        [SerializeField]
        GameObject FirstRotationPipe;
        [SerializeField]
        GameObject FirstRotationPipeObject;
        [SerializeField]
        GameObject FirstNormPipeAnim;
        [SerializeField]
        GameObject FirstRotationPipeAnim;
        [SerializeField]
        PipelineCreateManager PipelineCreateManager;
        [SerializeField]
        GameObject SkipAnimInPipelineButton;

#if UNITY_EDITOR
        public void ChangeFirstPipeType()
        {
            if (FirstIsNormPipe)
            {
                FirstIsNormPipe = false;
                FirstNormPipe.SetActive(true);
                FirstRotationPipe.SetActive(false);
                PipelineCreateManager.LastCreatedPipe = FirstNormPipe;
                TheFirstCreatureAnim = FirstNormPipeAnim;
            }
            else
            {
                FirstIsNormPipe = true;
                FirstNormPipe.SetActive(false);
                FirstRotationPipe.SetActive(true);
                PipelineCreateManager.LastCreatedPipe = FirstRotationPipeObject;
                TheFirstCreatureAnim = FirstRotationPipeAnim; 
            }      
        }
#endif
        void Start() => PlayerPrefs.SetInt("Pipeline", 1);
        
        public void SetLoseManager(LoseManager LoseManager) => MainLoseScript = LoseManager;
        
        public void Chack()
        {
            if (StartChack != null)
                StartChack.Invoke();
            StartCoroutine(CreateCreature());
        }
        IEnumerator CreateCreature()
        {
            yield return new WaitForSeconds(0.1f);
            if (PlayerPrefs.GetInt("Pipeline") == 1)
            {
                TheFirstCreatureAnim.SetActive(true);
                HouseSkinController.SetEmptyAnim();
                ClickBlock.SetActive(true);
                SkipAnimInPipelineButton.SetActive(true);
            }
            else
                MainLoseScript.LoseGame();
        }
    }
}
