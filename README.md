# gtk-nlp-finance-vanguard
a `Natural Language Processing (nlp)` API specifically for financial `(Vanguard)[http://vanguard.com]` words and phrases. it's used to mine text and get categorizations back

## overview
- `ASP.NET Core 2.2 API` implementation
- `GraphQL` with `ui/playground` implementation
- stores the `vanguard_model` as a static string in the code. this allows for the application to be fully code-first-and-only managed
- `/categorize` endpoint that categorizes the requested text content
- `Docker` implementation with very easy image use `docker pull gkama/nlp-finance-vanguard`

## examples
`/categorize` example with a sample request and response
- request
``` json
{
	"content": "this is a test to find VBISX, VBISX, VEXMX and VEXMX Vanguard index funds"
}
```
- response
``` json
[
    {
        "category": "Index Funds",
        "total_weight": 4,
        "matched": [
            {
                "value": "VBISX",
                "weight": 2
            },
            {
                "value": "VEXMX",
                "weight": 2
            }
        ]
    }
]
```
