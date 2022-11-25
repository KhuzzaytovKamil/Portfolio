using UnityEngine;
using ScriptableObjects.LvlsManager;
using Pipe;

namespace ClassicLvlGenerator
{
    public class ClassicLvlLoadController : MonoBehaviour
    {
        GameObject Pipeline;
        GameObject UI;
        [SerializeField]
        ClassicLvlsManager LvlsManager;
        [SerializeField]
        GameObject UITransformPoint;
        [SerializeField]
        GameObject Canvas;
        void Start()
        {
            Pipeline = Instantiate(LvlsManager.Pipeline[PlayerPrefs.GetInt("ClassicLvlNumber")], UITransformPoint.transform.position, LvlsManager.Pipeline[PlayerPrefs.GetInt("ClassicLvlNumber")].transform.rotation);
            Pipeline.transform.SetParent(Canvas.transform);
            Pipeline.transform.localScale = new Vector3(1.1f, 1, 1);
            Pipeline.GetComponent<RectTransform>().offsetMin = new Vector2(-1350, 250);
            Pipeline.GetComponent<RectTransform>().offsetMax = new Vector2(1350, 0);
            UI = Instantiate(LvlsManager.LvlReference, UITransformPoint.transform.position, LvlsManager.LvlReference.transform.rotation);
            UI.transform.SetParent(Canvas.transform);
            UI.transform.localScale = new Vector3(1, 1, 1);
            UI.GetComponent<RectTransform>().offsetMin = new Vector2(0, 0);
            UI.GetComponent<RectTransform>().offsetMax = new Vector2(0, 0);
            UI.GetComponent<ClassicLvlSettingsManager>().LvlNumber = PlayerPrefs.GetInt("ClassicLvlNumber");
            UI.GetComponent<ClassicLvlSettingsManager>().TimeForLvl = LvlsManager.TimeForLvl[PlayerPrefs.GetInt("ClassicLvlNumber")];
            UI.GetComponent<ClassicLvlSettingsManager>().ForOneStar = LvlsManager.TimeForOneStar[PlayerPrefs.GetInt("ClassicLvlNumber")];
            UI.GetComponent<ClassicLvlSettingsManager>().ForTwoStars = LvlsManager.TimeForTwoStars[PlayerPrefs.GetInt("ClassicLvlNumber")];
            UI.GetComponent<ClassicLvlSettingsManager>().ForTreeStars = LvlsManager.TimeForTreeStars[PlayerPrefs.GetInt("ClassicLvlNumber")];
            UI.GetComponent<ClassicLvlSettingsManager>().MoneyForTheFirstStar = LvlsManager.MoneyForTheFirstStar[PlayerPrefs.GetInt("ClassicLvlNumber")];
            UI.GetComponent<ClassicLvlSettingsManager>().MoneyForTheSecondStar = LvlsManager.MoneyForTheSecondStar[PlayerPrefs.GetInt("ClassicLvlNumber")];
            UI.GetComponent<ClassicLvlSettingsManager>().MoneyForTheThirdStar = LvlsManager.MoneyForTheThirdStar[PlayerPrefs.GetInt("ClassicLvlNumber")];
            UI.GetComponent<ClassicLvlSettingsManager>().EliteMoneyForTheThirdStar = LvlsManager.EliteMoneyForTheThirdStar[PlayerPrefs.GetInt("ClassicLvlNumber")];
            UI.GetComponent<ClassicLvlSettingsManager>().SetInfoForPipelineBank(Pipeline.GetComponent<InfoForPipelineBank>());
            Pipeline.GetComponent<InfoForPipelineBank>().LoseScript = UI.GetComponent<ClassicLvlSettingsManager>().LoseScript;
            Pipeline.GetComponent<InfoForPipelineBank>().WinManager = UI.GetComponent<ClassicLvlSettingsManager>().WinScript;
        }
    }    
}