using UnityEngine;
using UnityEngine.UI;

namespace Audio
{
    public class SoundOffOn : MonoBehaviour
    {
        [SerializeField]
        Sprite SoundOn;
        [SerializeField]
        Sprite SoundOff;
        void Start()
        {
            if (PlayerPrefs.HasKey("SOUND") == false)
                PlayerPrefs.SetInt("SOUND", 0);
            if(PlayerPrefs.GetInt("SOUND") == 0)
                GetComponent<Image>().sprite = SoundOff;
            else
                GetComponent<Image>().sprite = SoundOn;
        }
        public void CHANGE_TYPE()
        {
            if(PlayerPrefs.GetInt("SOUND") == 1)
            {
                PlayerPrefs.SetInt("SOUND", 0);
                GetComponent<Image>().sprite = SoundOff;
            }
                
            else
            {
                PlayerPrefs.SetInt("SOUND", 1);
                GetComponent<Image>().sprite = SoundOn;
            }    
        }
    }
}
