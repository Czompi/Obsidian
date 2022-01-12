using Obsidian.API;
using Obsidian.Net.Packets.Play.Clientbound;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obsidian.Entities;


internal class Villager : Entity, IVillager
{
    private void SetTradingPlayer(IPlayer? player)
    {

        bool inTrade = this.TradingPlayer != null && player == null;
    }
}

internal class VillagerTrader : Villager, IMerchant
{
    public IPlayer? TradingPlayer { get; set; }
    public bool ShowProgressBar { get; set; }

    public int Xp { get; set; }

    public List<Trade> Offers { get; set; }
    public ChatMessage DisplayName { get; private set; }

    private void StartTrading(Player player)
    {
        this.UpdateSpecialPrices(player);
        this.SetTradingPlayer(player);
        this.OpenTradingScreen(player, this.DisplayName, this.GetVillagerData().GetLevel());
    }


    public async void OpenTradingScreen(IPlayer player, ChatMessage chatMessage, int villagerLevel)
    {
        await ((Player)player).OpenMerchantWindowAsync(this.Offers, villagerLevel, this.Xp, isRegularVillager, canRestock);
    }

    public bool IsTrading() => TradingPlayer != null;
}
