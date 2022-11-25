using UnityEngine;

namespace Main
{
    public class WebLinkController : MonoBehaviour
    {
        public void GoToWeb(string WebLink) => Application.OpenURL(WebLink);
    }
}
