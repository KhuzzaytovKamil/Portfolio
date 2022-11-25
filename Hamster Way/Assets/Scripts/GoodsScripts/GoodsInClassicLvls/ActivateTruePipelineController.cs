using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using Pipe;
using ScriptableObjects.Economy;
using ClassicLvlGenerator;

namespace Goods
{
    public class ActivateTruePipelineController : MonoBehaviour
    {
        [SerializeField]
        GameObject TruePipeline;
        [SerializeField]
        GoodsInfoBank GoodsInfoBank;
        [SerializeField]
        Text Price;
        [SerializeField]
        ClassicLvlSettingsManager LvlManager;
        InfoForPipelineBank InfoForPipelineBank;
        int CurrentPrice;
        public void SetInfoForPipelineBank(InfoForPipelineBank InfoForPipeline) => InfoForPipelineBank = InfoForPipeline;
        
        void Start()
        {
            if (LvlManager.LvlNumber < 101)
                CurrentPrice = GoodsInfoBank.TruePipelinePrice[0];
            else if (LvlManager.LvlNumber < 111)
                CurrentPrice = GoodsInfoBank.TruePipelinePrice[1];
            else if (LvlManager.LvlNumber < 121)
                CurrentPrice = GoodsInfoBank.TruePipelinePrice[2];
            else if (LvlManager.LvlNumber < 131)
                CurrentPrice = GoodsInfoBank.TruePipelinePrice[3];
            else if (LvlManager.LvlNumber < 141)
                CurrentPrice = GoodsInfoBank.TruePipelinePrice[4];
            else if (LvlManager.LvlNumber < 151)
                CurrentPrice = GoodsInfoBank.TruePipelinePrice[5];
            else if (LvlManager.LvlNumber < 161)
                CurrentPrice = GoodsInfoBank.TruePipelinePrice[6];
            else if (LvlManager.LvlNumber < 171)
                CurrentPrice = GoodsInfoBank.TruePipelinePrice[7];
            else if (LvlManager.LvlNumber < 181)
                CurrentPrice = GoodsInfoBank.TruePipelinePrice[8];
            else
                CurrentPrice = GoodsInfoBank.TruePipelinePrice[9];

            Price.text = CurrentPrice.ToString();
            TruePipeline = InfoForPipelineBank.TruePipeline;

        }
        public void ActivateHelper()
        {
            if (PlayerPrefs.GetInt("money") >= CurrentPrice)
            {
                PlayerPrefs.SetInt("money", PlayerPrefs.GetInt("money") - CurrentPrice);
                TruePipeline.SetActive(true);
                StartCoroutine(HideTruePipeline());
            }
        }
        IEnumerator HideTruePipeline()
        {
            yield return new WaitForSeconds(GoodsInfoBank.TruePipelineOnSeconds);
            TruePipeline.SetActive(false);
        }
    }    
}

