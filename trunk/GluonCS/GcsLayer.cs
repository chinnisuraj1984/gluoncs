using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GMap.NET;

namespace GluonCS
{
    public abstract class GcsLayer
    {
        private GMap.NET.WindowsForms.GMapOverlay gMapOverlay;
        private LayerPropertiesPanel layerPropertiesPanel;
        private IGcsLogger gcsLogger;

        public string Name { get { return "Abstract"; } }

        public GcsLayer(GMap.NET.WindowsForms.GMapOverlay gMapOverlay,
                        LayerPropertiesPanel layerPropertiesPanel,
                        IGcsLogger gcsLogger)
        {
            this.gcsLogger = gcsLogger;
            this.layerPropertiesPanel = layerPropertiesPanel;
            this.gMapOverlay = gMapOverlay;
        }
    }
}
