using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopKeeper : MonoBehaviour
{

    public GameObject ShopKeeperPanel;

    public int currentSelectItem;
    public int currentItemCost;

    private PlayerController player;


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            player = other.GetComponent<PlayerController>();
            ShopKeeperPanel.SetActive(true);
            if (player != null)
            {
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


    public void BuyItem(){

        if (player.gemsOwn>=currentItemCost)
        {
            player.gemsOwn -= currentItemCost;
            if (currentSelectItem==2)
            {
                GameManager.Instance.HasKeyToCastle = true;
            }

            ShopKeeperPanel.SetActive(false);

        }else
        {
            ShopKeeperPanel.SetActive(false);
        }
    }

}
