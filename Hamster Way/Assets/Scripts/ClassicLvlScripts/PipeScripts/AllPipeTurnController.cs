using UnityEngine;
using ClassicLvlGenerator;
using Audio;

namespace Pipe
{
    public class AllPipeTurnController : MonoBehaviour
    {
        [SerializeField]
        Animator PipeAnim;
        [SerializeField]
        bool FirstHorizontal;
        [SerializeField]
        bool SecondVertical;
        [SerializeField]
        bool SecondHorizontal;
        [SerializeField]
        bool FirstVertical;
        [SerializeField]
        GameObject TruePositionObject;
        public GameObject TruePipeline;
        [SerializeField]
        AudioSource PipeTurnAudio;
        void Start()
        {
            if (FirstHorizontal == true)
                PipeAnim.SetBool("FirstHorizontal", true);
            else if (SecondVertical == true)
                PipeAnim.SetBool("SecondVertical", true);
            else if (SecondHorizontal == true)
                PipeAnim.SetBool("SecondHorizontal", true);
            else if (FirstVertical == true)
                PipeAnim.SetBool("FirstVertical", true);
            #if UNITY_EDITOR
            PipelineCreateManager.SetTruePipeline += SetTruePipePosition;
            #endif
        }
        #if UNITY_EDITOR
        void OnDisable()
        {
            PipelineCreateManager.SetTruePipeline -= SetTruePipePosition;
            PipelineCreateManager.SetTruePipeline -= SetTruePipePosition;
        }
		void OnDestroy() => PipelineCreateManager.SetTruePipeline -= SetTruePipePosition;
        
        void OnEnable() => PipelineCreateManager.SetTruePipeline += SetTruePipePosition;
        
        void SetTruePipePosition()
        {
            if (TruePipeline != null && TruePositionObject != null)
            {
                TruePositionObject.SetActive(true);
                TruePositionObject.transform.SetParent(TruePipeline.transform);
            }
        }
        #endif
        public void Turn()
        {
            SoundController.PLAY_THIS_SOUND(PipeTurnAudio);
            PipeAnim.SetBool("Turn", true);
            if (FirstHorizontal == true)
            {
                SecondVertical = true;
                FirstHorizontal = false;
            }
            else if (SecondVertical == true)
            {
                SecondHorizontal = true;
                SecondVertical = false;
            }
            else if (SecondHorizontal == true)
            {
                FirstVertical = true;
                SecondHorizontal = false;
            }
            else if (FirstVertical == true)
            {
                FirstHorizontal = true;
                FirstVertical = false;
            }
        }
        public void StartAnim() => PipeAnim.SetBool("Turn", false);
        
    }
}

