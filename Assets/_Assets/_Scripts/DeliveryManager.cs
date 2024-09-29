using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeliveryManager : MonoBehaviour
{
    public event EventHandler OnRecipeSpawned;
    public event EventHandler OnRecipeCompleted;
    public event EventHandler OnRecipeSucces;
    public event EventHandler OnRecipeFailed;
    public static DeliveryManager Instance { get; private set; }
    [SerializeField] private ResipeListSO resipeListSO;
    private List<ResipeSO> waitingresipeSOList;
    private float SpawnResipeTimer;
    private float SpawnResipeTimerMax = 4f;
    private int waitingResipesMax = 4;
    private int succesfulRecipesAmount;

    private void Awake()
    {
        Instance = this;
        waitingresipeSOList = new List<ResipeSO>();
    }

    private void Update()
    {
        SpawnResipeTimer -= Time.deltaTime;

        if (SpawnResipeTimer <= 0f)
        {
            SpawnResipeTimer = SpawnResipeTimerMax;

            if (waitingresipeSOList.Count < waitingResipesMax)
            {
                ResipeSO waitingResipeSO = resipeListSO.resipeSOList[UnityEngine.Random.Range(0, resipeListSO.resipeSOList.Count)];
                Debug.Log(waitingResipeSO.resipeName);
                waitingresipeSOList.Add(waitingResipeSO);

                OnRecipeSpawned?.Invoke(this, EventArgs.Empty);
            }
        }
    }

    public void DeliveryResipe(PlateKitchenObject plateKitchenObject)
    {
        for (int i = 0; i < waitingresipeSOList.Count; ++i)
        {
            ResipeSO waitingResipeSO = waitingresipeSOList[i];

            if (waitingResipeSO.kitchenObjectSOList.Count == plateKitchenObject.GetKitchenObjectSOList().Count)
            {
                bool plateCountentsResipe = true;

                foreach (KitchenObjectSO resipeKitchenObjectSO in waitingResipeSO.kitchenObjectSOList)
                {
                    bool ingredintFound = false;
                    foreach (KitchenObjectSO plateKitchenObjectSO in plateKitchenObject.GetKitchenObjectSOList())
                    {
                        if (plateKitchenObjectSO == resipeKitchenObjectSO)
                        {
                            ingredintFound = true;
                            break;
                        }
                    }
                    if (!ingredintFound)
                    {
                        plateCountentsResipe = false;
                    }
                }

                if (plateCountentsResipe)
                {
                    succesfulRecipesAmount++;

                    waitingresipeSOList.RemoveAt(i);

                    OnRecipeCompleted?.Invoke(this, EventArgs.Empty);
                    OnRecipeSucces?.Invoke(this, EventArgs.Empty);

                    // Увеличиваем время в KitchenGameManager на 10 секунд
                    KitchenGameManager.instance.AddTimeToGame(20f);

                    return;
                }
            }
        }

        // Нет совпадений, неверный рецепт
        OnRecipeFailed?.Invoke(this, EventArgs.Empty);
    }

    public List<ResipeSO> GetWaitingRecipeSOList()
    {
        return waitingresipeSOList;
    }

    public int GetsuccesfulRecipesAmount()
    {
        return succesfulRecipesAmount;
    }
}
