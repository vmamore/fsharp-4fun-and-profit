open System.Net
open System
open System.IO

let fetchUrl callback url =
    let req = WebRequest.Create(Uri(url))
    use resp = req.GetResponse()
    use stream = resp.GetResponseStream()
    use reader = new IO.StreamReader(stream)
    callback reader url

let myCallback (reader:IO.StreamReader) url =
    let html = reader.ReadToEnd()
    let html1000 = html.Substring(0, 1000)
    printfn "Downloaded %s. First 1000 is %s" url html1000
    html


let fetchUrl2 = fetchUrl myCallback
//let google = fetchUrl2 "http://google.com"
//let bbc = fetchUrl2 "https://www.bbc.com/portuguese"

let sites = ["http://www.bing.com";
"http://www.google.com";
"http://www.yahoo.com"]

sites |> List.map fetchUrl2
