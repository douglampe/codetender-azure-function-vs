using Microsoft.Azure.WebJobs.Host;
using System.Collections.Generic;
using System.Diagnostics;

namespace AlphaZulu.FoxtrotUniform.Func.Test.Internal
{
  public class TestTraceWriter : TraceWriter
  {
    private readonly TraceLevel _level;

    public List<TraceEvent> Traces { get; private set; } = new List<TraceEvent>();

    public TestTraceWriter(TraceLevel level) : base(level)
    {
      _level = level;
    }

    public override void Trace(TraceEvent traceEvent)
    {
      Traces.Add(traceEvent);
    }
  }
}
