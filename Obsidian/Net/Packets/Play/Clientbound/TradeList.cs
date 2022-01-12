using Obsidian.Entities;
using Obsidian.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obsidian.Net.Packets.Play.Clientbound;

public partial class TradeListPacket : IClientboundPacket
{
    public TradeListPacket(int windowId, sbyte size, List<Trade> trades, EVillagerLevel villagerLevel, int experience, bool isRegularVillager, bool canRestock)
    {
        WindowId = windowId;
        Size = size;
        Trades = trades;
        VillagerLevel = villagerLevel;
        Experience = experience;
        IsRegularVillager = isRegularVillager;
        CanRestock = canRestock;
    }

    [Field(0), VarLength]
    public int WindowId { get; init; }

    [Field(1)]
    public sbyte Size { get; init; }

    [Field(2)]
    public List<Trade> Trades { get; init; }

    [Field(3), ActualType(typeof(int)), VarLength]
    public EVillagerLevel VillagerLevel { get; init; }

    [Field(4), VarLength]
    public int Experience { get; init; }
    
    [Field(5)]
    public bool IsRegularVillager { get; init; }
    
    [Field(6)]
    public bool CanRestock { get; init; }


    public int Id => 0x28;

}

public class Trade
{
    public Trade()
    {
    }

    public Trade(ESlot inputItem1, ESlot outputItem, bool hasSecondItem, ESlot inputItem2, bool tradeDisabled, int numberOfTradeUses, int maximumNumberOfTradeUses, int xp, float priceMultiplier, uint demand): base()
    {
        InputItem1 = inputItem1;
        OutputItem = outputItem;
        HasSecondItem = hasSecondItem;
        InputItem2 = inputItem2;
        TradeDisabled = tradeDisabled;
        NumberOfTradeUses = numberOfTradeUses;
        MaximumNumberOfTradeUses = maximumNumberOfTradeUses;
        Xp = xp;
        PriceMultiplier = priceMultiplier;
        Demand = demand;
    }

    //[Field(2), ActualType(typeof(int))]
    public ESlot InputItem1 { get; init; }

    //[Field(3), ActualType(typeof(int))]
    public ESlot OutputItem { get; init; }

    //[Field(4)]
    public bool HasSecondItem { get; init; }

    //[Field(5), ActualType(typeof(int)), Condition("HasSecondItem == true")]
    public ESlot InputItem2 { get; init; }

    //[Field(6)]
    public bool TradeDisabled { get; init; }

    //[Field(7)]
    public int NumberOfTradeUses { get; init; }

    //[Field(8)]
    public int MaximumNumberOfTradeUses { get; init; }

    //[Field(9)]
    public int Xp { get; init; }

    //[Field(10)]
    public float PriceMultiplier { get; init; }

    //[Field(11)]
    public uint Demand { get; init; }

}

public enum EVillagerLevel
{
    Novice = 1,
    Apprentice = 2,
    Journeyman = 3,
    Expert = 4,
    Master = 5
}
