namespace Sain.Shared.Contexts;

/// <summary>
///   Represents a provider for new application contexts.
/// </summary>
public interface IContextProvider : IApplicationComponent
{
   #region Methods
   /// <summary>Tries to get a new application context of the given type <typeparamref name="T"/>.</summary>
   /// <typeparam name="T">The type of the context to try and provide.</typeparam>
   /// <param name="context">The obtained context.</param>
   /// <returns>
   ///   <see langword="true"/> if the requested <paramref name="context"/>
   ///   could be provided, <see langword="false"/> otherwise.
   /// </returns>
   bool TryProvide<T>([MaybeNullWhen(false)] out T context) where T : notnull, IContext;
   #endregion
}
