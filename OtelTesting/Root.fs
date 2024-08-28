module OtelTesting.Root
open OpenTelemetry
open OpenTelemetry.Trace
open System.Diagnostics

let testSource:ActivitySource = new ActivitySource ("FTS.Console")

