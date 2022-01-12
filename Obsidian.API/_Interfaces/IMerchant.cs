using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obsidian.API;

public interface IMerchant
{
    bool ShowProgressBar { get; set; }
    IPlayer? TradingPlayer { get; set; }
    int Xp { get; set; }

    bool IsTrading();
    void OpenTradingScreen(IPlayer player, ChatMessage chatMessage, int villagerLevel);
}
public interface IVillager
{
}
