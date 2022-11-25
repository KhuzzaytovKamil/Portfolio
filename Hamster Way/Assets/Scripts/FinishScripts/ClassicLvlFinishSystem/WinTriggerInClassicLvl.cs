using UnityEngine;
using UnityEngine.UI;
using Creature;
using ClassicLvlGenerator;
using UnityEngine.SceneManagement;
using Finish.WinSystem;

namespace Finish.ClassicLvlFinishSystem
{
    public class WinTriggerInClassicLvl : MonoBehaviour
    {
        [SerializeField]
        CreatureMoveAnimController LastAnim;
        [SerializeField]
        WinManager WinManager;
        [SerializeField]
        bool Education;
        bool ChackAnim = false;
        [SerializeField]
        GameObject SkipAnimInPipelineButton;
        public void SetWinManager(WinManager OutWinManager) => WinManager = OutWinManager;
        
        void Start()
        {
            PipelineInspector.StartChack += ReadyToChackWin;
            StopAllCoroutines();
        }

        void OnEnable() => PipelineInspector.StartChack += ReadyToChackWin;

        void OnDisable() => PipelineInspector.StartChack -= ReadyToChackWin;
        
        void OnDestroy() => PipelineInspector.StartChack -= ReadyToChackWin;
        
        void Update()
        {
            if (ChackAnim && LastAnim.StartAnimInNextPipe)
            {
                if (Education)
                {
                    SceneManager.LoadScene("LvlPullMenu");
                    Education = false;
                }
                else
                {
                    WinManager.WinGame();
                    Destroy(SkipAnimInPipelineButton);
                    ChackAnim = false;
                }
            }
        }
        void ReadyToChackWin() => ChackAnim = true;
        
        public void SkipAnim()
        {
            WinManager.WinGame();
            Destroy(SkipAnimInPipelineButton);
        }
#if UNITY_EDITOR
        public void SetLastAnim(PipelineCreateManager CreateManager) => 
            LastAnim = CreateManager.LastCreatedPipe.GetComponent<AnimStarter>().ThisAnim.GetComponent<CreatureMoveAnimController>();
        
        public void DestroyButton() => 
            Destroy(gameObject.GetComponent<Button>());
        
#endif
    }
}
