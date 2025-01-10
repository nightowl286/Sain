namespace Sain.Shared.Logging;

/// <summary>
///   Represents a sink to use for the <see cref="ILoggingContext"/>.
/// </summary>
public interface ILogSink
{
   #region Methods
   /// <summary>Initialises the sink for the given <paramref name="application"/>.</summary>
   /// <param name="application">The application to initialise the sink for.</param>
   /// <param name="timestamp">The timestamp to use as the start time of the log.</param>
   void Initialise(IApplicationBase application, DateTimeOffset timestamp);

   /// <summary>Cleans up the sink.</summary>
   void Cleanup();

   /// <summary>Adds the given log <paramref name="entry"/> to the log sink.</summary>
   /// <param name="entry">The log entry to add to the log sink.</param>
   void AddEntry(ILogEntry entry);

   /// <summary>Adds the file at the given file <paramref name="path"/> to the log sink.</summary>
   /// <param name="path">The path of the file to add to the log sink.</param>
   void AddFile(string path);
   #endregion
}
