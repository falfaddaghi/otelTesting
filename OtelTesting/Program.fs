open System
open System.Diagnostics
open OpenTelemetry
open OpenTelemetry.Trace
open OtelTesting.Logic
open OtelTesting.Root

[<EntryPoint>]
let main args = 
    let traceProvider = Sdk.CreateTracerProviderBuilder()
                            .AddSource("FTS.Console")
                            .AddConsoleExporter()
                            .AddOtlpExporter().Build()
                        
    let activity = testSource.StartActivity("Activity 1")
    activity.SetTag("foo",1) |> ignore
    
    SimpleFunction 3 |> ignore
    SimpleFunction 8 |> ignore
    SimpleFunction 9 |> ignore
    SimpleFunction 22 |> ignore
    
    activity.SetStatus(ActivityStatusCode.Ok)|> ignore
    activity.Dispose()
    
    let subActivity = testSource.CreateActivity("Activity 2", ActivityKind.Internal).Start()
    subActivity.SetTag("bar",2) |> ignore
    SimpleFunction 4444|> ignore
    SimpleFunction 7 |> ignore
    ComplexFunction()|>ignore
    
    subActivity.SetStatus(ActivityStatusCode.Ok)|>ignore
    subActivity.Dispose()
    traceProvider.Dispose()
    
    0
