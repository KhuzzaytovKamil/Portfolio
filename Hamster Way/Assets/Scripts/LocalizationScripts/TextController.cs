using UnityEngine;
using UnityEngine.UI;

namespace Localization
{
	[RequireComponent(typeof(Text))]
    public class TextController : MonoBehaviour
    {
		[SerializeField]
		string EnglishText;
		[SerializeField]
		string RussianText;
		[SerializeField]
		string FrenchText;
		[SerializeField]
		string ItalianText;
		[SerializeField]
		string KoreanText;
		[SerializeField]
		string PortugueseText;
		[SerializeField]
		string GermanText;
		[SerializeField]
		string SpanishText;
		[SerializeField]
		string TurkishText;
		[SerializeField]
		string DutchText;
		[SerializeField]
		string JapaneseText;
		[SerializeField]
		string SimplifiedChineseText;
		[SerializeField]
		string CzechText;
		[SerializeField]
		string ThaiText;
		[SerializeField]
		string PolishText;
		void OnDisable() => LocalizationChangerManager.LocalizationChanged -= ChangeText;
        
		void OnDestroy() => LocalizationChangerManager.LocalizationChanged -= ChangeText;
        
        void OnEnable() => LocalizationChangerManager.LocalizationChanged += ChangeText;
        
		void Start()
		{
			ChangeText();
			LocalizationChangerManager.LocalizationChanged += ChangeText;
		}

		void ChangeText()
		{
			if (PlayerPrefs.GetString("Language") == "English")
			{
				GetComponent<Text>().text = EnglishText;
			}
			else if (PlayerPrefs.GetString("Language") == "Russian")
			{
				GetComponent<Text>().text = RussianText;
			}
			else if (PlayerPrefs.GetString("Language") == "French")
			{
				GetComponent<Text>().text = FrenchText;
			}
			else if (PlayerPrefs.GetString("Language") == "Italian")
			{
				GetComponent<Text>().text = ItalianText;
			}
			else if (PlayerPrefs.GetString("Language") == "Korean")
			{
				GetComponent<Text>().text = KoreanText;
			}
			else if (PlayerPrefs.GetString("Language") == "Portuguese")
			{
				GetComponent<Text>().text = PortugueseText;
			}
			else if (PlayerPrefs.GetString("Language") == "German")
			{
				GetComponent<Text>().text = GermanText;
			}
			else if (PlayerPrefs.GetString("Language") == "Spanish")
			{
				GetComponent<Text>().text = SpanishText;
			}
			else if (PlayerPrefs.GetString("Language") == "Turkish")
			{
				GetComponent<Text>().text = TurkishText;
			}
			else if (PlayerPrefs.GetString("Language") == "Dutch")
			{
				GetComponent<Text>().text = DutchText;
			}
			else if (PlayerPrefs.GetString("Language") == "Japanese")
			{
				GetComponent<Text>().text = JapaneseText;
			}
			else if (PlayerPrefs.GetString("Language") == "SimplifiedChinese")
			{
				GetComponent<Text>().text = SimplifiedChineseText;
			}
			else if (PlayerPrefs.GetString("Language") == "Czech")
			{
				GetComponent<Text>().text = CzechText;
			}
			else if (PlayerPrefs.GetString("Language") == "Thai")
			{
				GetComponent<Text>().text = ThaiText;
			}
			else if (PlayerPrefs.GetString("Language") == "Polish")
			{
				GetComponent<Text>().text = PolishText;
			}
		}
    }
}
