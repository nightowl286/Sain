namespace Sain.Shared.Applications;

/// <summary>
///   Represents the context of an application.
/// </summary>
public class ApplicationContext : BaseHasApplicationInit, IApplicationContext
{
   #region Properties
   /// <inheritdoc/>
   public IReadOnlyCollection<IContextProvider> ContextProviders { get; }

   /// <inheritdoc/>
   public IReadOnlyCollection<IContext> Contexts { get; }

   /// <inheritdoc/>
   public IAudioContextGroup Audio { get; }

   /// <inheritdoc/>
   public IDispatcherContext Dispatcher { get; }
   #endregion

   #region Constructors
   /// <summary>Creates a new instance of the <see cref="ApplicationContext"/>.</summary>
   /// <param name="contextProviders">The context providers that are available to the application.</param>
   /// <param name="contexts">The contexts that are available to the application.</param>
   public ApplicationContext(IReadOnlyCollection<IContextProvider> contextProviders, IReadOnlyCollection<IContext> contexts)
   {
      ContextProviders = contextProviders;
      Contexts = contexts;

      IAudioPlaybackContext audioPlayback = GetContext<IAudioPlaybackContext>();
      IAudioCaptureContext audioCapture = GetContext<IAudioCaptureContext>();
      Audio = new AudioContextGroup(audioPlayback, audioCapture);

      Dispatcher = GetContext<IDispatcherContext>();
   }
   #endregion

   #region Methods
   /// <inheritdoc/>
   public T GetContext<T>() where T : notnull, IContext
   {
      if (TryGetContext<T>(out T? context))
         return context;

      throw new InvalidOperationException($"No context of the type ({typeof(T)}) is available.");
   }

   /// <inheritdoc/>
   public bool TryGetContext<T>([MaybeNullWhen(false)] out T context) where T : notnull, IContext
   {
      foreach (IContext current in Contexts)
      {
         if (current is T typed)
         {
            context = typed;
            return true;
         }
      }

      context = default;
      return false;
   }

   /// <inheritdoc/>
   protected override void Initialise()
   {
      foreach (IContextProvider provider in ContextProviders)
         provider.Initialise(Application);

      foreach (IContext context in Contexts)
         context.Initialise(Application);
   }

   /// <inheritdoc/>
   protected override void Cleanup()
   {
      foreach (IContext context in Contexts)
         context.Cleanup(Application);

      foreach (IContextProvider provider in ContextProviders)
         provider.Cleanup(Application);
   }
   #endregion
}
