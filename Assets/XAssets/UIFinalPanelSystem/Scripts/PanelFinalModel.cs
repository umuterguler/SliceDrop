using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.XAssets.UIFinalPanelSystem.Scripts
{
    public class PanelFinalModel
    {
        public PanelFinalModel(bool finalStatus, int collectedBallCount)
        {
            FinalStatus = finalStatus;
            CollectedBallCount = collectedBallCount;
        }

        public bool FinalStatus { get; private set; }//Win or Lose
        public int CollectedBallCount { get; private set; }

    }
}
