using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatesCounter : BaseCounter
{
    public event EventHandler OnPlateSpawned;
    public event EventHandler OnPlaterRemoved;

    [SerializeField] private KitchenObjectSO  plateKitchenObjectSo;
    private float spawnPlateTime;
    private float spawnPlateTimeMax = 4f;
    private int platesSpawnedAmout;
    private int platesSpawnedAmoutMax = 4;

    private void Update()
    {
        spawnPlateTime += Time.deltaTime;
        if (spawnPlateTime > spawnPlateTimeMax)
        {
            spawnPlateTime = 0f;
            if (platesSpawnedAmout < platesSpawnedAmoutMax) 
            {
                platesSpawnedAmout++;


                OnPlateSpawned?.Invoke(this, EventArgs.Empty);

            }

        }
    }

    public override void Interact(Player player)
    {
        if (!player.HasKitchenObject())
        {
            //Plaer is Empaty handed
            if(platesSpawnedAmout > 0)
            {
                //There's at least one plate here
                platesSpawnedAmout--;

                KitchenObject.SpawnKitchenObject(plateKitchenObjectSo, player);


                OnPlaterRemoved?.Invoke(this, EventArgs.Empty);
            }
        }
    }
}
