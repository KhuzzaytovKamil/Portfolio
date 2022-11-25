using UnityEngine;
using Finish.ClassicLvlFinishSystem;

namespace Creature
{
    public class AnimStarter : MonoBehaviour
    {
        public CreatureMoveAnimController LastAnim;
        public GameObject ThisAnim;
        bool ChackAnim = false;
        void Start()
        {
            PipelineInspector.StartChack += ReadyToChackWin;
            StopAllCoroutines();
        }
        void OnDisable() => PipelineInspector.StartChack -= ReadyToChackWin;
        
        void OnDestroy() => PipelineInspector.StartChack -= ReadyToChackWin;
        
        void OnEnable() => PipelineInspector.StartChack += ReadyToChackWin;
        
        void Update()
        {
            if (LastAnim != null)
            {
                if (ChackAnim && LastAnim.StartAnimInNextPipe)
                {
                    ThisAnim.SetActive(true);
                    ChackAnim = false;
                }
            }
        }
        void ReadyToChackWin() => ChackAnim = true;
        
    }
}

