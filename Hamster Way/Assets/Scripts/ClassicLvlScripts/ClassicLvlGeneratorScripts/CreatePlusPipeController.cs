using UnityEngine;
using UnityEngine.UI;
using Pipe;

namespace ClassicLvlGenerator
{
    public class CreatePlusPipeController : MonoBehaviour
    {
#if UNITY_EDITOR
        [SerializeField]
        bool SetPlusPipe = false;
        void OnCollisionStay(Collision other)
        {
            if (SetPlusPipe)
            {
                SetPlusPipe = false;

                Destroy(gameObject.GetComponent<AllPipeTurnController>());
                Destroy(gameObject.GetComponent<Animator>());
                Destroy(gameObject.GetComponent<Button>());
                Destroy(gameObject.GetComponent<AudioSource>());

                Destroy(other.gameObject.GetComponent<AllPipeTurnController>());
                Destroy(other.gameObject.GetComponent<Animator>());
                Destroy(other.gameObject.GetComponent<Button>());
                Destroy(other.gameObject.GetComponent<AudioSource>());
            }
        }
#endif
    }
}

