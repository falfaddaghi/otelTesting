module OtelTesting.Logic
open System.Diagnostics
open OtelTesting.Root

let SimpleFunction x =
    use trace = testSource.StartActivity(sprintf "calling add %i" x)
    let res = x+3
    res
   

let ComplexFunction()  =
    use trace = testSource.StartActivity(sprintf "complex start" )
    System.Threading.Thread.Sleep 30
    trace.AddEvent(ActivityEvent("step 1 of complex"))|>ignore
    System.Threading.Thread.Sleep 30
    trace.AddEvent(ActivityEvent("step 2 of complex"))|>ignore
    System.Threading.Thread.Sleep 30
    trace.SetStatus(ActivityStatusCode.Ok)
