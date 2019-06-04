using System;
using System.Collections.Generic;
using System.Text;

namespace nlp.finance.vanguard.data
{
    public static class Models
    {
        public static string vanguard_model_str =>
            @"
{
    ""id"": ""984ce69d-de79-478b-9223-ff6349514e19"",
    ""name"": ""Vanguard"",
    ""details"": ""vanguard|vanguard group"",
    ""children"": [
        {
            ""id"": ""5ec6957d-4de7-4199-9373-d4a7fb59d6e1"",
            ""name"": ""Index Funds"",
            ""details"": ""vbiix|vbinx|vbisx|vbltx|vbmfx|vdaix|vdvix|veiex|veurx|vexmx|vfinx|vfsvx|vftsx|vfwix|vgovx|vgtsx|vhdyx|viaix|vigrx|vihix|vimsx|visgx|visvx|vivax|vlacx|vmgix|vmvix|vpacx|vtebx|vtibx|vtipx|vtsmx|vtws"",
            ""children"": []
        }
    ]
}
";

        public static VanguardModel vanguard_model =>
            Newtonsoft.Json.JsonConvert.DeserializeObject<VanguardModel>(vanguard_model_str);
    }
}
