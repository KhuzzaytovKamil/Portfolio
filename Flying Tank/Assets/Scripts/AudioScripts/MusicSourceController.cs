using UnityEngine;

namespace Audio
{
    public class MusicSourceController : MonoBehaviour
    {
        void Start()
        {
            if (PlayerPrefs.HasKey("MUSIC") == false)
                PlayerPrefs.SetInt("MUSIC", 1);
            OnOffMusic();
            MusicOffOn.MusicTypeIsSwiched += OnOffMusic;
        }

        void OnEnable() => MusicOffOn.MusicTypeIsSwiched += OnOffMusic;

        void OnDisable() => MusicOffOn.MusicTypeIsSwiched -= OnOffMusic;

        void OnDestroy() => MusicOffOn.MusicTypeIsSwiched -= OnOffMusic;

        void OnOffMusic()
        {
            if(PlayerPrefs.GetInt("MUSIC") == 1)
            {
                gameObject.GetComponent<AudioSource>().volume = 1;
            }
            else
            {
                gameObject.GetComponent<AudioSource>().volume = 0;
            } 
        }
    }
}

