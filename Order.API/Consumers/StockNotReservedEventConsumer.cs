using MassTransit;
using Microsoft.EntityFrameworkCore;
using Order.API.Models.Contexts;
using Shared.Events;
using System.Collections.Concurrent;

namespace Order.API.Consumers
{
    public class StockNotReservedEventConsumer(OrderAPIDBContext _context) : IConsumer<StockNotReservedEvent>
    {
        public async Task Consume(ConsumeContext<StockNotReservedEvent> context)
        {
            var order = await _context.Orders.FindAsync(context.Message.OrderId);
            if (order == null)
                throw new NullReferenceException();
            order.OrderStatus = Enums.OrderStatus.Complated;
            await _context.SaveChangesAsync();
        }
    }
}
