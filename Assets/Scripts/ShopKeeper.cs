using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class ShopKeeper : MonoBehaviour
{

    public GameObject ShopKeeperPanel;

    public int currentSelectItem;
    public int currentItemCost;

    private PlayerController player;

    private void Start()
    {
        ShopKeeperPanel.SetActive(true);
        ShopKeeperPanel.SetActive(false);
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            player = other.GetComponent<PlayerController>();
            if (player != null)
            {
                ShopKeeperPanel.SetActive(true);

                UIManager.Instance.OpenShop(player.gemsOwn);
            }
        }
    }


    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            ShopKeeperPanel.SetActive(false);
        }
    }


    public void SelectItem(int itemID)
    {
        switch (itemID)
        {
            case 0:
                UIManager.Instance.SelectItemUpdate(110);
                currentSelectItem = 0;
                currentItemCost = 100;
                break;
            case 1:
                UIManager.Instance.SelectItemUpdate(0);
                currentSelectItem = 1;
                currentItemCost = 120;
                break;
            case 2:
                UIManager.Instance.SelectItemUpdate(-110);
                currentSelectItem = 2;
                currentItemCost = 80;
                break;
        }
    }


    public void BuyItem()
    {

        if (player.gemsOwn >= currentItemCost)
        {
            player.gemsOwn -= currentItemCost;
            if (currentSelectItem == 2)
            {
                GameManager.Instance.HasKeyToCastle = true;
            }

            ShopKeeperPanel.SetActive(false);

        }
        else
        {
            ShopKeeperPanel.SetActive(false);
        }
    }


    public void ShowRewardedAds() {
        if (Advertisement.IsReady("rewardedVideo"))
        {
            var options = new ShowOptions { resultCallback = HandleShowResult };
            Advertisement.Show("rewardedVideo", options);
        }
    }


    private void HandleShowResult(ShowResult result)
    {
        switch (result)
        {
            case ShowResult.Finished:
                Debug.Log("The ad was successfully shown.");
                player.gemsOwn += 500;
                break;
            case ShowResult.Skipped:
                Debug.Log("The ad was skipped before reaching the end.");
                break;
            case ShowResult.Failed:
                Debug.LogError("The ad failed to be shown.");
                break;
        }
    }
}


