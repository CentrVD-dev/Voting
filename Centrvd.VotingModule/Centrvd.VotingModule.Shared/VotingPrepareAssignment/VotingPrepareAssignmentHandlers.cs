using System;
using System.Collections.Generic;
using System.Linq;
using Sungero.Core;
using Sungero.CoreEntities;
using Centrvd.VotingModule.VotingPrepareAssignment;

namespace Centrvd.VotingModule
{
  partial class VotingPrepareAssignmentSharedHandlers
  {

    public virtual void VotersMatrixChanged(Centrvd.VotingModule.Shared.VotingPrepareAssignmentVotersMatrixChangedEventArgs e)
    {
      if (Equals(e.NewValue, e.OldValue))
        return;
      
      var votingTask = Centrvd.VotingModule.VotingTasks.As(_obj.Task);
      
      // Обновляем матрицы голосующих для всех пунктов
      foreach (var votingPoint in _obj.VotingPoints)
        votingPoint.VotersMatrix = e.NewValue;
      
      if (e.NewValue != null)
        _obj.VotersLabel = "Голосующие: " + string.Join(", ", Centrvd.VotingModule.Functions.VotersMatrix.CalculateEmployeesFromMatrix(e.NewValue, votingTask).Select(emp => emp.Person.ShortName));
      else
        _obj.VotersLabel = null;
    }

    public virtual void VotesMatrixChanged(Centrvd.VotingModule.Shared.VotingPrepareAssignmentVotesMatrixChangedEventArgs e)
    {
      if (Equals(e.NewValue, e.OldValue))
        return;
      
      // Обновляем матрицы голосов.
      foreach (var votingPoint in _obj.VotingPoints)
        votingPoint.VotesMatrix = e.NewValue;
      
      if (e.NewValue != null)
        _obj.VotesLabel = "Варианты голосов: " + string.Join(", ", e.NewValue.Variants.Select(v => v.VoteKind.Name));
      else
        _obj.VotesLabel = null;
    }
  }

  partial class VotingPrepareAssignmentVotingPointsSharedHandlers
  {

    public virtual void VotingPointsVotersMatrixChanged(Centrvd.VotingModule.Shared.VotingPrepareAssignmentVotingPointsVotersMatrixChangedEventArgs e)
    {
      if (Equals(e.NewValue, e.OldValue))
        return;
      
      // Обновляем матрицы голосующих для всех пунктов, если требуется.
      //      if (_obj.VotingPrepareAssignment.SameVoterMatrix == true)
      //      {
      //        foreach (var votingPoint in _obj.VotingPrepareAssignment.VotingPoints)
      //          votingPoint.VotersMatrix = e.NewValue;
      //      }
      
      // Обновляем вычисленных голосующих.
      var votingTask = Centrvd.VotingModule.VotingTasks.As(_obj.VotingPrepareAssignment.Task);
      _obj.VotersNames = e.NewValue != null
        ? string.Join(", ", Centrvd.VotingModule.Functions.VotersMatrix.CalculateEmployeesFromMatrix(e.NewValue, votingTask).Select(emp => emp.Person.ShortName))
        : null;
    }

    public virtual void VotingPointsVotesMatrixChanged(Centrvd.VotingModule.Shared.VotingPrepareAssignmentVotingPointsVotesMatrixChangedEventArgs e)
    {
      if (Equals(e.NewValue, e.OldValue))
        return;
      
      // Обновляем матрицы голосов для всех пунктов, если требуется.
      //      if (_obj.VotingPrepareAssignment.SameVoteMatrix == true)
      //      {
      //        foreach (var votingPoint in _obj.VotingPrepareAssignment.VotingPoints)
      //          votingPoint.VotesMatrix = e.NewValue;
      //      }

      // Обновляем виды голосов.
      _obj.VotesKinds = e.NewValue != null
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
      
      // Автозаполнение матриц голосов.
      //      if (_obj.SameVoteMatrix == true && _obj.VotingPoints.Any())
      //      {
      //        var pointWithMatrix = _obj.VotingPoints.FirstOrDefault(p => p.VotesMatrix != null);
      //        if (pointWithMatrix != null)
      //          _added.VotesMatrix = pointWithMatrix.VotesMatrix;
      //      }
      
      // Автозаполнение матриц голосующих.
      //      if (_obj.SameVoterMatrix == true && _obj.VotingPoints.Any())
      //      {
      //        var pointWithMatrix = _obj.VotingPoints.FirstOrDefault(p => p.VotersMatrix != null);
      //        if (pointWithMatrix != null)
      //          _added.VotersMatrix = pointWithMatrix.VotersMatrix;
      //      }
      
    }
  }
}