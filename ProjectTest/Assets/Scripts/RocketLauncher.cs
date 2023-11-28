using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketLauncher : MonoBehaviour
{
    // Weapons variables
    private int price = 8;
    private float fireRate = 0.5f;
    public int localMoney;

    // DataManager
    private DataManager dataManager;
    // Player controller
    public PlayerController playerController;

    void Start()
    {
        // Get the datamanager
        playerController = FindObjectOfType<PlayerController>();
        // Get the dataManager
        dataManager = FindObjectOfType<DataManager>();
    }

    
    void Update()
    {
        // Get the players money
        localMoney = dataManager.coinsCollected;
    }

    private void OnTriggerEnter(Collider other)
    {
        // Buying item
        if (localMoney >= price)
        {
            // Change price
            localMoney -= price;
            // Set the datamanger price
            dataManager.coinsCollected = localMoney;
            Destroy(gameObject);
            Destroy(other.gameObject);

            // Update datamanager for weapon
            dataManager.initialAmmunition = 3;
            dataManager.initialMagazine = 3;
            dataManager.ammunition = 3;
            dataManager.fireRate = fireRate;
            playerController.playerWeapon = "rocketlauncher";
            dataManager.playerWeapon = "rocketlauncher";
        }
    }
}
