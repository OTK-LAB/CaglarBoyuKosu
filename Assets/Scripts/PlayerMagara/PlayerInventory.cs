using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public static PlayerInventory instance;

    public int ammoCount;
    public int foodCount;
    public int goldCount;

    private void Awake()
    {
        instance = this;
    }

    public int GetItemCount(string itemType)
    {
        switch (itemType)
        {
            case "ammo":
                return ammoCount;
            case "food":
                return foodCount;
            case "gold":
                return goldCount;
            default:
                return 0;
        }
    }

    public void RemoveItem(string itemType, int amount)
    {
        switch (itemType)
        {
            case "ammo":
                ammoCount -= amount;
                break;
            case "food":
                foodCount -= amount;
                break;
            case "gold":
                goldCount -= amount;
                break;
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("ammo"))
        {
            ammoCount++;
            other.gameObject.SetActive(false);
            Destroy(other.gameObject);
        }
        else if (other.CompareTag("food"))
        {
            foodCount++;
            other.gameObject.SetActive(false);
            Destroy(other.gameObject);
        }
        else if (other.CompareTag("gold"))
        {
            goldCount++;
            other.gameObject.SetActive(false);
            Destroy(other.gameObject);
        }
    }
}
