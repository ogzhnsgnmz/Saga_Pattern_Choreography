using MassTransit;
using Order.API.Models.Contexts;
using Shared.Events;

namespace Order.API.Consumers;

public class PaymentCompletedEventConsumers(OrderAPIDBContext _context) : IConsumer<PaymentCompletedEvent>
{
    public async Task Consume(ConsumeContext<PaymentCompletedEvent> context)
    {
        var order = await _context.Orders.FindAsync(context.Message.OrderId);
        if (order == null)
            throw new NullReferenceException();
        order.OrderStatus = Enums.OrderStatus.Complated;
        await _context.SaveChangesAsync();
    }
}