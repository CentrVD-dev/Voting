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
      //      var sameVotesMatrix = _obj.SameVoteMatrix.GetValueOrDefault();
      //      _obj.State.Properties.VotingPoints.Properties.VotesKinds.IsVisible = !sameVotesMatrix;
      //      _obj.State.Properties.VotesLabel.IsVisible = sameVotesMatrix;
      //      _obj.State.Properties.VotesMatrix.IsVisible = sameVotesMatrix;
//
      //      var sameVotersMatrix = _obj.SameVoterMatrix.GetValueOrDefault();
      //      _obj.State.Properties.VotingPoints.Properties.VotersNames.IsVisible = !sameVotersMatrix;
      //      _obj.State.Properties.VotersLabel.IsVisible = sameVotersMatrix;
      //      _obj.State.Properties.VotersMatrix.IsVisible = sameVotersMatrix;

      var sameVotesMatrix = _obj.VotesMatrix != null;
      _obj.State.Properties.VotingPoints.Properties.VotesKinds.IsVisible = !sameVotesMatrix;
      _obj.State.Properties.VotingPoints.Properties.VotesMatrix.IsVisible = !sameVotesMatrix;
      _obj.State.Properties.VotesLabel.IsVisible = sameVotesMatrix;

      var sameVotersMatrix = _obj.VotersMatrix != null;
      _obj.State.Properties.VotingPoints.Properties.VotersNames.IsVisible = !sameVotersMatrix;
      _obj.State.Properties.VotingPoints.Properties.VotersMatrix.IsVisible = !sameVotersMatrix;
      _obj.State.Properties.VotersLabel.IsVisible = sameVotersMatrix;
      
      _obj.State.Properties.VotingPoints.Properties.Text.IsRequired = true;
      _obj.State.Properties.VotingPoints.Properties.VotesMatrix.IsRequired = true;
      _obj.State.Properties.VotingPoints.Properties.VotersMatrix.IsRequired = true;
    }

    public virtual void SameVoterMatrixValueInput(Sungero.Presentation.BooleanValueInputEventArgs e)
    {
      // Заполнить матрицы голосующих.
//      if (e.NewValue == true && _obj.VotingPoints.Any())
//      {
//        var pointWithMatrix = _obj.VotingPoints.FirstOrDefault(p => p.VotersMatrix != null);
//        if (pointWithMatrix != null)
//        {
//          foreach (var item in _obj.VotingPoints)
//            item.VotersMatrix = pointWithMatrix.VotersMatrix;
//          
//          _obj.VotersLabel = "Голосующие: " + string.Join(", ", pointWithMatrix.VotersMatrix.Employees.Select(emp => emp.Employee?.Name ?? emp.Department?.Name ?? string.Empty));
//        }
//      }
//      
//      if (e.NewValue == false)
//        _obj.VotersLabel = null;
    }

    public virtual void SameVoteMatrixValueInput(Sungero.Presentation.BooleanValueInputEventArgs e)
    {
      // Заполнить матрицы голосов.
//      if (e.NewValue == true && _obj.VotingPoints.Any())
//      {
//        var pointWithMatrix = _obj.VotingPoints.FirstOrDefault(p => p.VotesMatrix != null);
//        if (pointWithMatrix != null)
//        {
//          foreach (var item in _obj.VotingPoints)
//            item.VotesMatrix = pointWithMatrix.VotesMatrix;
//          
//          _obj.VotesLabel = "Варианты голосов: " + string.Join(", ", pointWithMatrix.VotesMatrix.Variants.Select(v => v.VoteKind.Name));
//        }
//      }
//      
//      if (e.NewValue == false)
//        _obj.VotesLabel = null;
    }

  }
}