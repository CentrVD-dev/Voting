using System;
using System.Collections.Generic;
using System.Linq;
using Sungero.Core;
using Sungero.CoreEntities;
using Centrvd.VotingModule.VotingAssignment;

namespace Centrvd.VotingModule
{
  partial class VotingAssignmentClientHandlers
  {

    public override void Showing(Sungero.Presentation.FormShowingEventArgs e)
    {
      _obj.State.Properties.VotingPoints.Properties.Vote.IsRequired = true;
    }

  }
}