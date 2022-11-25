using UnityEngine;
using ClassicLvlGenerator;

namespace Finish.ClassicLvlFinishSystem
{
    public class LoseTrigger : MonoBehaviour
    {
        public GameObject LastPipe;
        [SerializeField]
        bool ThereIsContact = false;
        void Start() => PipelineInspector.StartChack += SetContact;
        
        void OnEnable() => PipelineInspector.StartChack += SetContact;

        void OnDisable() => PipelineInspector.StartChack -= SetContact;

        void OnDestroy() => PipelineInspector.StartChack -= SetContact;

        void OnCollisionEnter(Collision other)
        {
            if (LastPipe == other.gameObject)
                ThereIsContact = true;
        }
        void OnCollisionExit(Collision other)
        {
            if (LastPipe == other.gameObject)
                ThereIsContact = false;
        }
        void SetContact()
        {
            if (ThereIsContact == false)
            {
                PlayerPrefs.SetString("cause", "FalsePipeline");
                PlayerPrefs.SetInt("Pipeline", 0);
            }
        }
        #if UNITY_EDITOR
        public void SetLastPipe(PipelineCreateManager CreateManager) => LastPipe = CreateManager.LastCreatedPipe;
        
        #endif
    }
}
