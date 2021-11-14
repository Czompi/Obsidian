﻿using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace Obsidian.Plugins.PluginProviders;

public interface IPluginProvider
{
    public PluginContainer GetPlugin(string path, ILogger logger);

    public async Task<PluginContainer> GetPluginAsync(string path, ILogger logger)
    {
        return await Task.FromResult(GetPlugin(path, logger));
    }
}
