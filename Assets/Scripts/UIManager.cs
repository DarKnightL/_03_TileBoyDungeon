using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Text playerGemsCount;
    public Image selectImage;




    private static UIManager _instance;

    public static UIManager Instance
    {
        get
        {
            if (_instance == null)
            {
                Debug.Log("Instance doesnot exist");
            }

            return _instance;
        }
    }


    private void Awake()
    {
        _instance = this;
    }


    public void OpenShop(int gemCounts){

        playerGemsCount.text = gemCounts+" G";
    }


    public void SelectItemUpdate(int yPos){

        selectImage.rectTransform.anchoredPosition = new Vector2(selectImage.rectTransform.anchoredPosition.x, yPos);
    }

}
