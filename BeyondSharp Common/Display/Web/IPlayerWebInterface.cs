using System;

namespace BeyondSharp.Common.Display.Web
{
    public interface IPlayerWebInterface<TPlayer>
    {
        Guid Id { get; }
        TPlayer Player { get; }
    }
}