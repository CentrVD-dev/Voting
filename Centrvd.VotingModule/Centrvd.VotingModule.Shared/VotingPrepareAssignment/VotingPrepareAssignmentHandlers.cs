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

    public virtual void UnitedVotersMatrixChanged(Centrvd.VotingModule.Shared.VotingPrepareAssignmentUnitedVotersMatrixChangedEventArgs e)
    {
      if (Equals(e.NewValue, e.OldValue))
        return;
      
      var votingTask = Centrvd.VotingModule.VotingTasks.As(_obj.Task);
      
      // Обновляем матрицы голосующих для всех пунктов.
      foreach (var votingPoint in _obj.VotingPoints)
        votingPoint.VotersMatrix = e.NewValue;
      
      if (e.NewValue != null)
      {
        _obj.VotersLabel = Centrvd.VotingModule.VotingPrepareAssignments.Resources.VotersLabel + string.Join(", ", Centrvd.VotingModule.Functions.VotersMatrix.CalculateEmployeesFromMatrix(e.NewValue, votingTask).Select(emp => emp.Person.ShortName));
        
        _obj.State.Properties.VotingPoints.Properties.VotersNames.IsVisible = false;
        _obj.State.Properties.VotingPoints.Properties.VotersMatrix.IsVisible = false;
        _obj.State.Properties.VotersLabel.IsVisible = true;
      }
      else
      {
        _obj.VotersLabel = null;
        
        _obj.State.Properties.VotingPoints.Properties.VotersNames.IsVisible = true;
        _obj.State.Properties.VotingPoints.Properties.VotersMatrix.IsVisible = true;
        _obj.State.Properties.VotersLabel.IsVisible = false;
      }
    }

    public virtual void UnitedVotesMatrixChanged(Centrvd.VotingModule.Shared.VotingPrepareAssignmentUnitedVotesMatrixChangedEventArgs e)
    {
      if (Equals(e.NewValue, e.OldValue))
        return;
      
      // Обновляем матрицы голосов.
      foreach (var votingPoint in _obj.VotingPoints)
        votingPoint.VotesMatrix = e.NewValue;
      
      if (e.NewValue != null)
      {
        _obj.VotesLabel = Centrvd.VotingModule.VotingPrepareAssignments.Resources.VotesKindsLabel + string.Join(", ", e.NewValue.Variants.Select(v => v.VoteKind.Name));
        
        _obj.State.Properties.VotingPoints.Properties.VotesKinds.IsVisible = false;
        _obj.State.Properties.VotingPoints.Properties.VotesMatrix.IsVisible = false;
        _obj.State.Properties.VotesLabel.IsVisible = true;
      }
      else
      {
        _obj.VotesLabel = null;
        
        _obj.State.Properties.VotingPoints.Properties.VotesKinds.IsVisible = true;
        _obj.State.Properties.VotingPoints.Properties.VotesMatrix.IsVisible = true;
        _obj.State.Properties.VotesLabel.IsVisible = false;
      }
    }
  }

  partial class VotingPrepareAssignmentVotingPointsSharedHandlers
  {

    public virtual void VotingPointsVotersMatrixChanged(Centrvd.VotingModule.Shared.VotingPrepareAssignmentVotingPointsVotersMatrixChangedEventArgs e)
    {
      if (Equals(e.NewValue, e.OldValue))
        return;

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
      
      if (_obj.UnitedVotesMatrix != null)
        _added.VotesMatrix = _obj.UnitedVotesMatrix;
      
      if (_obj.UnitedVotersMatrix != null)
        _added.VotersMatrix = _obj.UnitedVotersMatrix;
    }
  }
}