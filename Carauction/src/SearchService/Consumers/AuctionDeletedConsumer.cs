using AutoMapper;
using Contracts;
using MassTransit;
using MongoDB.Entities;

namespace SearchService;

public class AuctionDeletedConsumer : IConsumer<AuctionDeleted>
{
    public async Task Consume(ConsumeContext<AuctionDeleted> context)
    {
        var res = await DB.DeleteAsync<Item>(context.Message.Id);

        if(!res.IsAcknowledged)
        {
            throw new Exception("Failed to delete item with id: " + context.Message.Id);
        }
    }
}