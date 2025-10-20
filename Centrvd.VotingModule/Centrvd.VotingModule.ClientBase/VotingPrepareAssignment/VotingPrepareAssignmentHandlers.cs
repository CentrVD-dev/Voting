using System;
using System.Collections.Generic;
using System.Linq;
using Sungero.Core;
using Sungero.CoreEntities;
using Centrvd.VotingModule.VotingPrepareAssignment;

namespace Centrvd.VotingModule
{
  partial class VotingPrepareAssignmentClientHandlers
  {

    public override void Showing(Sungero.Presentation.FormShowingEventArgs e)
    {
      Functions.VotingPrepareAssignment.SetRequiredProperties(_obj);
    }

  }
}