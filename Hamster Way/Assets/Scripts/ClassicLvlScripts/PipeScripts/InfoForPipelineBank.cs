using UnityEngine;
using Finish.LoseSystem;
using Finish.ClassicLvlFinishSystem;
using System.Collections;
using Finish.WinSystem;

namespace Pipe
{
    public class InfoForPipelineBank : MonoBehaviour
    {
        [SerializeField]
        PipelineInspector PipelineInspector;
        [SerializeField]
        WinTriggerInClassicLvl WinTrigger;
        [SerializeField]
        public LoseManager LoseScript;
        [SerializeField]
        public WinManager WinManager;
        public GameObject TruePipeline;
        void Start()
        {
            if (LoseScript != null && WinManager != null)
                StartCoroutine(LateStart());
        }
        IEnumerator LateStart()
        {
            yield return new WaitForSeconds(0.1f);
            PipelineInspector.SetLoseManager(LoseScript);
            WinTrigger.SetWinManager(WinManager);
        }
    }
}