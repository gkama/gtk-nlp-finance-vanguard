﻿using System;
using System.Collections.Generic;
using System.Text;

namespace nlp.finance.vanguard.data
{
    public static class Models
    {
        public static IModel<VanguardModel> vanguard_model =>
            new VanguardModel()
            {
                id = "984ce69d-de79-478b-9223-ff6349514e19",
                name = "Vanguard",
                children = {
                    new VanguardModel()
                    {
                        id = "5ec6957d-4de7-4199-9373-d4a7fb59d6e1",
                        name = "Index Funds",
                        details = "vbiix|vbinx|vbisx|vbltx|vbmfx|vdaix|vdvix|veiex|veurx|vexmx|vfinx|vfsvx|vftsx|vfwix|vgovx|vgtsx|vhdyx|viaix|vigrx|vihix|vimsx|visgx|visvx|vivax|vlacx|vmgix|vmvix|vpacx|vtebx|vtibx|vtipx|vtsax|vtsmx|vtws"
                    }
                }
            };
    }
}
