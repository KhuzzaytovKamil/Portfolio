using UnityEngine;
#if UNITY_EDITOR
using ClassicLvlGenerator;
#endif
using Finish.ClassicLvlFinishSystem;

namespace Creature
{
    public class UpperTextureController : MonoBehaviour
    {
#if UNITY_EDITOR
        [SerializeField]
        GameObject PipeParent;
#endif
        public GameObject UpperTextureParent;
        void Start()
        {
#if UNITY_EDITOR
            PipelineCreateManager.StartLvlRefactoring += SetPipeParent;
#endif
            PipelineInspector.StartChack += SetOverPipelineParent;
        }
        void OnEnable()
        {
#if UNITY_EDITOR
            PipelineCreateManager.StartLvlRefactoring += SetPipeParent;
#endif
            PipelineInspector.StartChack -= SetOverPipelineParent;
        }
        void OnDisable()
        {
#if UNITY_EDITOR
            PipelineCreateManager.StartLvlRefactoring -= SetPipeParent;
#endif
            PipelineInspector.StartChack -= SetOverPipelineParent;
        }
        void OnDestroy()
        {
#if UNITY_EDITOR
            PipelineCreateManager.StartLvlRefactoring -= SetPipeParent;
#endif
            PipelineInspector.StartChack -= SetOverPipelineParent;
        }
#if UNITY_EDITOR
        void SetPipeParent() => gameObject.transform.SetParent(PipeParent.transform);
        
#endif
        void SetOverPipelineParent() => gameObject.transform.SetParent(UpperTextureParent.transform);
        
    }
}