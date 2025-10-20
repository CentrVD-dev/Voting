using System;
using System.Collections.Generic;
using System.Linq;
using Sungero.Core;
using Sungero.CoreEntities;
using Centrvd.VotingModule.VoteKind;

namespace Centrvd.VotingModule
{
  partial class VoteKindClientHandlers
  {

    public override void Showing(Sungero.Presentation.FormShowingEventArgs e)
    {
      Functions.VoteKind.ShowEditWarning(_obj, e);

      Centrvd.VotingModule.Functions.VoteKind.SetEnableProperties(_obj);
    }

  }
}