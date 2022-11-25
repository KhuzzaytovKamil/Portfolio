using UnityEngine;
using Finish.ClassicLvlFinishSystem;
using Creature;

namespace TeleportationSystem
{
    public class MainTeleportationSystemController : MonoBehaviour
    {
        public CreatureMoveAnimController LastAnim;
        public bool BackContact = false;
        public GameObject LastPipe;
        public GameObject TeleportationFinishingStation;
        void Start() => PipelineInspector.StartChack += SetContact;
        
        void OnDisable() => PipelineInspector.StartChack -= SetContact;
        
        void OnDestroy() => PipelineInspector.StartChack -= SetContact;
        
        void OnEnable() => PipelineInspector.StartChack += SetContact;
        
        void SetContact()
        {
            if (BackContact == false)
            {
                PlayerPrefs.SetInt("Pipeline", 0);
            }
        }
    }
}