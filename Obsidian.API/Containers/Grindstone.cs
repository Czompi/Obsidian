﻿using System;

namespace Obsidian.API.Containers
{
    public sealed class Grindstone : AbstractResultContainer
    {
        public Grindstone() : base(3, InventoryType.Grindstone)
        {
            this.Title = "Grindstone";
        }

        public override ItemStack? GetResult() => throw new NotImplementedException();
        public override void SetResult(ItemStack? result) => throw new NotImplementedException();
    }
}