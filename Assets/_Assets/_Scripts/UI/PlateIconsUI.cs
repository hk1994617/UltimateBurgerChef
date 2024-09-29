using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateIconsUI : MonoBehaviour
{
    [SerializeField] private PlateKitchenObject plateKitchenObject; // Объект тарелки, на которой отображаются ингредиенты
    [SerializeField] private Transform iconTemplate; // Шаблон иконки

    private void Start()
    {
        // Подписка на событие добавления ингредиентов на тарелку
        plateKitchenObject.OnIngredientAdded += PlateKitchenObject_OnIngredientAdded;
    }

    private void Awake()
    {
        // Шаблон иконки изначально скрыт
        iconTemplate.gameObject.SetActive(false);
    }

    // Метод вызывается при добавлении ингредиента на тарелку
    private void PlateKitchenObject_OnIngredientAdded(object sender, PlateKitchenObject.OnIngredientAddedEventArgs e)
    {
        UpdateVisual();
    }

    // Метод обновления отображения иконок ингредиентов
    private void UpdateVisual()
    {
        // Удаляем все инстанцированные иконки, оставляя шаблон нетронутым
        foreach (Transform child in transform)
        {
            if (child == iconTemplate) continue; // Пропускаем сам шаблон
            Destroy(child.gameObject); // Удаляем только инстанцированные объекты
        }

        // Проходим по списку ингредиентов и создаем иконки на основе шаблона
        foreach (KitchenObjectSO kitchenObjectSO in plateKitchenObject.GetKitchenObjectSOList())
        {
            // Инстанцируем новый объект на основе шаблона
            Transform iconTransform = Instantiate(iconTemplate, transform);
            iconTransform.gameObject.SetActive(true); // Активируем только инстанцированную иконку

            // Устанавливаем соответствующий ингредиент в иконке
            iconTransform.GetComponent<PlateIconSinglesUI>().SetKitchenObjectSO(kitchenObjectSO);
        }
    }
}
