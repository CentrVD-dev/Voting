using System;
using System.Collections.Generic;
using System.Linq;
using Sungero.Core;
using Sungero.CoreEntities;
using Centrvd.VotingModule.VotesMatrix;

namespace Centrvd.VotingModule
{
  partial class VotesMatrixClientHandlers
  {
    public override void Showing(Sungero.Presentation.FormShowingEventArgs e)
    {
      Functions.VotesMatrix.ShowEditWarning(_obj, e);

      Centrvd.VotingModule.Functions.VotesMatrix.SetEnableProperties(_obj);
    }
  }

}