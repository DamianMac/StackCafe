﻿namespace StackCafe.Cashier.Services
{
    public interface IOrderHistory
    {
        void AddOrder(string customerName, string[] orderItems);

        string GetFavoriteItem(string customer);

        string GetFavouriteItemExcludingCurrentOrderItems(string customer, string[] currentOrderItems);
    }
}