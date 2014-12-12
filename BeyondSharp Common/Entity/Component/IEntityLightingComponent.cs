namespace BeyondSharp.Common.Entity.Component
{
    using BeyondSharp.Common.Entity.Component.Attributes;

    [SynchronizedComponent(IDENTIFIER)]
    public class IEntityLightingComponent : IEntityComponent
    {
        private const string IDENTIFIER = "Lighting";
    }
}