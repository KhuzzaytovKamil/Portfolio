using UnityEngine;

namespace Creature
{
    public class CreatureMoveAnimController : MonoBehaviour
    {
        
        [Header("AnimBool:")]
        [SerializeField]
        bool IsNorm;
        [SerializeField]
        bool IsRotation;
        [Header("Other:")]
        [SerializeField]
        Animator CreatureAnimator;
        public bool StartAnimInNextPipe = false;
        public bool UseOtherAnim = false;
        void Start()
        {
            if (IsNorm)
            {
                if (UseOtherAnim)
                    CreatureAnimator.SetBool("TheSecondInNorm", true);                    
                else
                    CreatureAnimator.SetBool("TheFirstInNorm", true);
            }
            else if (IsRotation)
            {
                if (UseOtherAnim)
                    CreatureAnimator.SetBool("TheSecondInRotation", true);
                else
                    CreatureAnimator.SetBool("TheFirstInRotation", true);
            }
        }
        public void StartNextAnim() => StartAnimInNextPipe = true;
        
    }
}
