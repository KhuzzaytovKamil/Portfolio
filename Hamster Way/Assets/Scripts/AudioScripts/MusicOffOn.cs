using UnityEngine;
using UnityEngine.UI;
using System;

namespace Audio
{
    public class MusicOffOn : MonoBehaviour
    {
        public static event Action MusicTypeIsSwiched;
        [SerializeField]
        Sprite MusicOn;
        [SerializeField]
        Sprite MusicOff;
        void Start()
        {
            if(PlayerPrefs.GetInt("MUSIC") == 1)
                gameObject.GetComponent<Image>().sprite = MusicOn;
            else
                gameObject.GetComponent<Image>().sprite = MusicOff;
        }
        public void CHANGE_TYPE()
        {
            if(PlayerPrefs.GetInt("MUSIC") == 1)
            {
                gameObject.GetComponent<Image>().sprite = MusicOff;
                PlayerPrefs.SetInt("MUSIC", 0);
            }
            else
            {
                gameObject.GetComponent<Image>().sprite = MusicOn;
                PlayerPrefs.SetInt("MUSIC", 1);
            }  
            MusicTypeIsSwiched.Invoke();  
        }
    }
}
