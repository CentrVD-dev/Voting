using System;
using System.Collections.Generic;
using System.Linq;
using Sungero.Core;
using Sungero.CoreEntities;
using Centrvd.VotingModule.VotingPrepareAssignment;

namespace Centrvd.VotingModule
{
  partial class VotingPrepareAssignmentVotingPointsSharedHandlers
  {

    public virtual void VotingPointsVoteMatrixChanged(Centrvd.VotingModule.Shared.VotingPrepareAssignmentVotingPointsVoteMatrixChangedEventArgs e)
    {
      if (Equals(e.NewValue, e.OldValue))
        return;

      // Обновляем матрицы голосования для всех точек, если требуется
      if (_obj.VotingPrepareAssignment.SameMatrixForAllPoints == true)
      {
        foreach (var votingPoint in _obj.VotingPrepareAssignment.VotingPoints)
          votingPoint.VoteMatrix = e.NewValue;
      }

      // Обновляем виды голосов
      _obj.VoteKinds = e.NewValue != null
        ? string.Join(", ", e.NewValue.Variants.Select(v => v.VoteKind.Name))
        : null;
    }
  }

  partial class VotingPrepareAssignmentVotingPointsSharedCollectionHandlers
  {

    public virtual void VotingPointsDeleted(Sungero.Domain.Shared.CollectionPropertyDeletedEventArgs e)
    {
      foreach (var item in _obj.VotingPoints.Where(p => p.Number > _deleted.Number))
        item.Number--;
    }

    public virtual void VotingPointsAdded(Sungero.Domain.Shared.CollectionPropertyAddedEventArgs e)
    {
      _added.Number = (_obj.VotingPoints.Max(a => a.Number) ?? 0) + 1;
      
      if (_obj.SameMatrixForAllPoints == true && _obj.VotingPoints.Any())
      {
        var pointWithMatrix = _obj.VotingPoints.FirstOrDefault(p => p.VoteMatrix != null);
        if (pointWithMatrix != null)
          _added.VoteMatrix = pointWithMatrix.VoteMatrix;
      }
      
    }
  }
}