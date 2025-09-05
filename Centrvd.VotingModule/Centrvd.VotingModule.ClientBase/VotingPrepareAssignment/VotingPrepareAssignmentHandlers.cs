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

    public virtual void SameMatrixForAllPointsValueInput(Sungero.Presentation.BooleanValueInputEventArgs e)
    {
      if (e.NewValue == true && _obj.VotingPoints.Any())
      {
        var pointWithMatrix = _obj.VotingPoints.FirstOrDefault(p => p.VoteMatrix != null);
        if (pointWithMatrix != null)
          foreach (var item in _obj.VotingPoints)
            item.VoteMatrix = pointWithMatrix.VoteMatrix;
      }
    }

  }
}