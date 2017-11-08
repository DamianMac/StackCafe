using System;
using System.Collections.Generic;
using System.Linq;
using Serilog;

namespace StackCafe.Waiter.Services
{
    public class OrderDeliveryService : IOrderDeliveryService
    {
        private readonly ILogger _logger;
        private readonly List<Guid> _madeOrderIds = new List<Guid>();
        private readonly List<Guid> _paidOrderIds = new List<Guid>();

        private readonly Dictionary<Guid, List<string>> _incompleteOrderIds = new Dictionary<Guid, List<string>>();
        private readonly Dictionary<Guid, List<string>> _orderlessItems = new Dictionary<Guid, List<string>>();

        private object incompleteLock = new object();

        public OrderDeliveryService(ILogger logger)
        {
            _logger = logger;
        }

        public void AddUnmadeOrder(Guid orderId, List<string> items)
        {
            lock (incompleteLock)
            {
                _incompleteOrderIds.Add(orderId, items);
            }
        }

        public void MarkItemAsMade(Guid orderId, string itemCode)
        {
            var remainingItems = _incompleteOrderIds.ContainsKey(orderId) ? _incompleteOrderIds[orderId] : null;
            if (remainingItems == null)
            {
                // TODO: do this properly
                return;
            }
            if (!remainingItems.Any())
            {
                _incompleteOrderIds.Remove(orderId);
                if (!_madeOrderIds.Contains(orderId))
                {
                    _madeOrderIds.Add(orderId);
                    CheckWhetherWeShouldDeliver(orderId);
                }
                return;
            }

            if (!remainingItems.Contains(itemCode))
            {
                _logger.Warning("Duplicate item {ItemCode} for order {OrderId}. What a waste...", itemCode, orderId);
            }

            // TODO: support quantity
            remainingItems.Remove(itemCode);
            if (!remainingItems.Any())
            {
                _incompleteOrderIds.Remove(orderId);
                _madeOrderIds.Add(orderId);
                CheckWhetherWeShouldDeliver(orderId);
                return;
            }
            _incompleteOrderIds[orderId] = remainingItems;
        }

        public void MarkAsPaid(Guid orderId)
        {
            _paidOrderIds.Add(orderId);
            CheckWhetherWeShouldDeliver(orderId);
        }

        public void MarkAsMade(Guid orderId)
        {
            _madeOrderIds.Add(orderId);
            CheckWhetherWeShouldDeliver(orderId);
        }

        public bool HasBeenPaid(Guid orderId)
        {
            var hasBeenPaid = _paidOrderIds.Contains(orderId);
            return hasBeenPaid;
        }

        public bool HasBeenMade(Guid orderId)
        {
            return _madeOrderIds.Contains(orderId);
        }

        private void CheckWhetherWeShouldDeliver(Guid orderId)
        {
            if (!_madeOrderIds.Contains(orderId))
            {
                _logger.Information("{OrderId} isn't ready yet. We can't give it to the customer.", orderId);
                return;
            }

            if (!_paidOrderIds.Contains(orderId))
            {
                _logger.Information("{OrderId} hasn't been paid for yet. We can't give it to the customer.", orderId);
                return;
            }

            DeliverOrderToCustomer(orderId);
        }

        private void DeliverOrderToCustomer(Guid orderId)
        {
            _logger.Information("Delivering {OrderId} to the customer.", orderId);
        }
    }
}