using System;
using System.Collections.Generic;
using System.Linq;
using Sungero.Core;
using Sungero.CoreEntities;
using Centrvd.VotingModule.VotingAssignment;

namespace Centrvd.VotingModule
{
  partial class VotingAssignmentVotingPointsSharedCollectionHandlers
  {
    public virtual void VotingPointsAdded(Sungero.Domain.Shared.CollectionPropertyAddedEventArgs e)
    {
      _added.Number = (_obj.VotingPoints.Max(a => a.Number) ?? 0) + 1;
    }
  }

  partial class VotingAssignmentSharedHandlers
  {

  }
}