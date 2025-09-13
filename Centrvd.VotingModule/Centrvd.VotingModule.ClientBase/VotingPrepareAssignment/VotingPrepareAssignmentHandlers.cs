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

    public override void Refresh(Sungero.Presentation.FormRefreshEventArgs e)
    {
      var sameVotesMatrix = _obj.UnitedVotesMatrix != null;
      _obj.State.Properties.VotingPoints.Properties.VotesKinds.IsVisible = !sameVotesMatrix;
      _obj.State.Properties.VotingPoints.Properties.VotesMatrix.IsVisible = !sameVotesMatrix;
      _obj.State.Properties.VotesLabel.IsVisible = sameVotesMatrix;

      var sameVotersMatrix = _obj.UnitedVotersMatrix != null;
      _obj.State.Properties.VotingPoints.Properties.VotersNames.IsVisible = !sameVotersMatrix;
      _obj.State.Properties.VotingPoints.Properties.VotersMatrix.IsVisible = !sameVotersMatrix;
      _obj.State.Properties.VotersLabel.IsVisible = sameVotersMatrix;
      
      _obj.State.Properties.VotingPoints.Properties.Text.IsRequired = true;
      _obj.State.Properties.VotingPoints.Properties.VotesMatrix.IsRequired = true;
      _obj.State.Properties.VotingPoints.Properties.VotersMatrix.IsRequired = true;
    }

  }
}