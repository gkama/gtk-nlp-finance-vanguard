# gtk-nlp-finance-vanguard
a Natural Language Processing (nlp) API specifically for financial `[Vanguard](http://vanguard.com)` words and phrases. it's used to text mine and get categorizations, with weight, back

## overview
- `ASP.NET Core 2.2 API` implementation
- `GraphQL` with `ui/playground` implementation
- `vanguard_model` is stored as a static object in the code, which allows the application to be fully code-first-and-only managed
- `/categorize` endpoint that categorizes the requested text content
- `Docker` implementation with very easy image use `docker pull gkama/nlp-finance-vanguard`

## examples
`/categorize` example with a sample request and response
``` json
{
	"content": "this is a test to find VBISX, VBISX, VEXMX and VEXMX Vanguard index funds"
}
```
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

additionally, we have the GraphQL (`/graphql` or `/ui/playgroud`) implementation where we can either grab the `vanguard_model` or use the `categorize` function. below are examples of that
```
{
  categorize(content: "this is a test to find VBISX, VBISX, VEXMX and VEXMX Vanguard index funds") {
    name
    total_weight
    matched {
      value
      weight
    }
  }
}
```
``` json
{
  "data": {
    "categorize": [
      {
        "name": "Index Funds",
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
  }
}
```

or the `vanguard_model` nested 2 levels
```
{
  vanguard_model {
    id
    name
    details
    children {
      id
      name
      details
    }
  }
}
```
``` json
{
  "data": {
    "vanguard_model": {
      "id": "984ce69d-de79-478b-9223-ff6349514e19",
      "name": "Vanguard",
      "details": null,
      "children": [
        {
          "id": "5ec6957d-4de7-4199-9373-d4a7fb59d6e1",
          "name": "Index Funds",
          "details": "vbiix|vbinx|vbisx|vbltx|vbmfx|vdaix|vdvix|veiex|veurx|vexmx|vfinx|vfsvx|vftsx|vfwix|vgovx|vgtsx|vhdyx|viaix|vigrx|vihix|vimsx|visgx|visvx|vivax|vlacx|vmgix|vmvix|vpacx|vtebx|vtibx|vtipx|vtsax|vtsmx|vtws"
        }
      ]
    }
  }
}
```
