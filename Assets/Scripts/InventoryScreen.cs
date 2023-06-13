using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class InventoryScreen : MonoBehaviour
{
    public Text foodCountText;
    public Text ammoCountText;
    public Button healButton;
    public Button FireButton;
    private bool finish;

    // Start is called before the first frame update
    void Start()
    {
        FireButton.interactable = false;
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


    public void OnButtonTouchStart()
    {
        PlayerController.instance.canMove = false;
    }

    public void OnButtonTouchEnd()
    {
        PlayerController.instance.canMove = true;
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
        Invoke(nameof(OnButtonTouchStart), 2f);
        Invoke(nameof(OnButtonTouchEnd), 2f);
    }

    void ActivateButton()
    {
        healButton.interactable = true;
        FireButton.interactable = true;

    }

    public void OnFireButtonClick()
    {
        int ammoCount = PlayerInventory.instance.GetItemCount("ammo");

        if (ammoCount > 0)
        {
            Fire.instance.FireProjectile();
            UpdateItemCountUI();
        }
    }

    public void OnHealButtonClick()
    {
        int foodCount = PlayerInventory.instance.GetItemCount("food");
        int currentHealth = PlayerHealth.instance.currentHealth;
        int startingHealth = PlayerHealth.instance.startingHealth;

        if (currentHealth < startingHealth && foodCount > 0)
        {
            PlayerHealth.instance.Heal(10);
            PlayerInventory.instance.RemoveItem("food", 1);
            UpdateItemCountUI();
        }
    }

}
