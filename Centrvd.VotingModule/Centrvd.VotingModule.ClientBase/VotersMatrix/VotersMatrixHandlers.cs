using System;
using System.Collections.Generic;
using System.Linq;
using Sungero.Core;
using Sungero.CoreEntities;
using Centrvd.VotingModule.VotersMatrix;

namespace Centrvd.VotingModule
{
  partial class VotersMatrixClientHandlers
  {

    public override void Showing(Sungero.Presentation.FormShowingEventArgs e)
    {
      Functions.VotersMatrix.ShowEditWarning(_obj, e);
      
      Centrvd.VotingModule.Functions.VotersMatrix.SetEnableProperties(_obj);
    }

  }
}