using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ToolSlot : MonoBehaviour
{
    public TextMeshProUGUI toolQuantityText;
    public TextMeshProUGUI PriceText;
    public int quantity=1;
    public int price;
    int quantityPrice=0;
    private void Start()
    {
        quantityPrice = price;
        PriceText.text = "$"+price.ToString();
    }
    public void AddToolQuantity()
    {
        
        quantity++;
        quantityPrice = price * quantity;
        
        toolQuantityText.text = quantity.ToString();
        PriceText.text = "$"+quantityPrice.ToString();
    }
    public void RemoveToolQuantity()
    {
        if (quantity > 1)
        {
           
            quantity--;
            quantityPrice = price * quantity;
            toolQuantityText.text = quantity.ToString();
            PriceText.text = "$"+quantityPrice.ToString();
        }
    }
    public void BuyTool(Item item)
    {
       
        if (ShopSystem.instance.totalMoney >= quantityPrice)
        {
            print("buy");
            ShopSystem.instance.totalMoney -= quantityPrice;
            Inventory.instance.Add(item);
            item.count += quantity - 1;

            quantity = 1;
            toolQuantityText.text = quantity.ToString();
            quantityPrice = price;
            PriceText.text = "$" + quantityPrice.ToString();
        }
        
    }
}
