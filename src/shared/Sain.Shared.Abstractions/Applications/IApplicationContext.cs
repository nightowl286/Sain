namespace Sain.Shared.Applications;

/// <summary>
///   Represents the context of an application.
/// </summary>
public interface IApplicationContext : IHasApplicationInit
{
   #region Properties
   /// <summary>The collection of the available context providers.</summary>
   IReadOnlyCollection<IContextProvider> ContextProviders { get; }

   /// <summary>The collection of the available contexts.</summary>
   IReadOnlyCollection<IContext> Contexts { get; }

   /// <summary>The application's context group for audio.</summary>
   IAudioContextGroup Audio { get; }

   /// <summary>The application's context for the dispatcher.</summary>
   IDispatcherContext Dispatcher { get; }

   /// <summary>The application's context for logging.</summary>
   ILoggingContext Logging { get; }
   #endregion

   #region Methods
   /// <summary>Gets the context of the given type <typeparamref name="T"/>.</summary>
   /// <typeparam name="T">The type of the context to get.</typeparam>
   /// <returns>The obtained context.</returns>
   T GetContext<T>() where T : notnull, IContext;

   /// <summary>Tries to get the context of the given type <typeparamref name="T"/>.</summary>
   /// <typeparam name="T">The type of the context to try and get.</typeparam>
   /// <param name="context">
   ///   The obtained context, or <see langword="null"/> if a context
   ///   of the given <typeparamref name="T"/> could not be found.
   /// </param>
   /// <returns>
   ///   <see langword="true"/> if the <paramref name="context"/>
   ///   could be obtained, <see langword="false"/> otherwise.
   /// </returns>
   bool TryGetContext<T>([MaybeNullWhen(false)] out T context) where T : notnull, IContext;
   #endregion
}
