using UnityEngine;
using ClassicLvlGenerator;

namespace Creature
{
    public class SetTrueCreatureAnimController : MonoBehaviour
    {
#if UNITY_EDITOR
        public PipelineCreateManager PipelineCreateManager;
        [SerializeField]
        CreatureMoveAnimController CreatureMoveAnimController;
        bool CheckLastPipe = false;
        [SerializeField]
        public GameObject LastPipe;
        void Start()
        {
            if (PipelineCreateManager != null)
                PipelineCreateManager.SetTruePipeline += CheckLastPipePosition;
        }
        void OnEnable()
        {
            if (PipelineCreateManager != null)
                PipelineCreateManager.SetTruePipeline += CheckLastPipePosition;
        }
        void OnDisable()
        {
            if (PipelineCreateManager != null)
                PipelineCreateManager.SetTruePipeline -= CheckLastPipePosition;
        }
        void OnDestroy()
        {
            if (PipelineCreateManager != null)
                PipelineCreateManager.SetTruePipeline -= CheckLastPipePosition;
        }
        void OnCollisionStay(Collision other)
        {
            if (LastPipe == other.gameObject && CheckLastPipe && PipelineCreateManager != null)
            {
                CreatureMoveAnimController.UseOtherAnim = true;
                CheckLastPipe = false;
            }   
        }
        void CheckLastPipePosition() => CheckLastPipe = true;
        
#endif
    }
}

