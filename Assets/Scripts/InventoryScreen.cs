using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryScreen : MonoBehaviour
{
    public Text foodCountText;
    public Text ammoCountText;
    public Button healButton;
    private bool finish;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        finish = FınıshLine.instance.isFinished;
        if (finish)
        {
            Aktif();
        }

        UpdateItemCountUI();
    }

    void UpdateItemCountUI()
    {
        int foodCount = PlayerInventory.instance.GetItemCount("food");
        int ammoCount = PlayerInventory.instance.GetItemCount("ammo");

        foodCountText.text = $"X {foodCount}";
        ammoCountText.text = $"X {ammoCount}";
    }

    void Aktif()
    {
        Invoke(nameof(ActivateButton), 2f);
    }

    void ActivateButton()
    {
        healButton.interactable = true;
    }


    public void OnHealButtonClick()
    {
        int foodCount = PlayerInventory.instance.GetItemCount("food");

        if (foodCount > 0)
        {
            PlayerHealth.instance.Heal(10);
            PlayerInventory.instance.RemoveItem("food", 1);
            UpdateItemCountUI();
        }
    }
}
