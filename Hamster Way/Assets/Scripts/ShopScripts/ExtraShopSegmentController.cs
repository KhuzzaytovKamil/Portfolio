using UnityEngine;
using UnityEngine.UI;

namespace Shop
{
    public class ExtraShopSegmentController : MonoBehaviour
    {
        [SerializeField]
        GameObject CenterScreen;
        [Header("Content:")]
        [SerializeField]
        GameObject PlatesContent;
        [SerializeField]
        GameObject HousesContent;
        [SerializeField]
        GameObject FoodsContent;
        [SerializeField]
        GameObject FoodNumberInfoBlock;
        [Header("ContentsPoints:")]
        [SerializeField]
        Image PlatesPoint;
        [SerializeField]
        Image HousesPoint;
        [SerializeField]
        Image FoodsPoint;
        Vector3 ScreenStartPosition;

        void Start() => ScreenStartPosition = CenterScreen.transform.position;

        public void OpenPlateContent()
        {
            CenterScreen.transform.position = ScreenStartPosition;

            PlatesContent.SetActive(true);
            HousesContent.SetActive(false);
            FoodsContent.SetActive(false);
            FoodNumberInfoBlock.SetActive(false);

            PlatesPoint.color = new Color(1, 1, 1, 1);
            HousesPoint.color = new Color(1, 1, 1, 0.6f);
            FoodsPoint.color = new Color(1, 1, 1, 0.6f);
        }

        public void OpenHouseContent()
        {
            CenterScreen.transform.position = ScreenStartPosition;

            PlatesContent.SetActive(false);
            HousesContent.SetActive(true);
            FoodsContent.SetActive(false);
            FoodNumberInfoBlock.SetActive(false);

            PlatesPoint.color = new Color(1, 1, 1, 0.6f);
            HousesPoint.color = new Color(1, 1, 1, 1);
            FoodsPoint.color = new Color(1, 1, 1, 0.6f);
        }

        public void OpenFoodContent()
        {
            CenterScreen.transform.position = ScreenStartPosition;

            PlatesContent.SetActive(false);
            HousesContent.SetActive(false);
            FoodsContent.SetActive(true);
            FoodNumberInfoBlock.SetActive(true);

            PlatesPoint.color = new Color(1, 1, 1, 0.6f);
            HousesPoint.color = new Color(1, 1, 1, 0.6f);
            FoodsPoint.color = new Color(1, 1, 1, 1);
        }
    }
}
