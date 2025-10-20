using System;
using System.Collections.Generic;
using System.Linq;
using Sungero.Core;
using Sungero.CoreEntities;
using Centrvd.VotingModule.VotesMatrix;

namespace Centrvd.VotingModule.Client
{
  partial class VotesMatrixActions
  {
    public override void DeleteEntity(Sungero.Domain.Client.ExecuteActionArgs e)
    {
      base.DeleteEntity(e);
    }

    public override bool CanDeleteEntity(Sungero.Domain.Client.CanExecuteActionArgs e)
    {
      bool hasUsingAssignments = false;
      e.Params.TryGetValue(Centrvd.VotingModule.Constants.VotesMatrix.UsedInAssignments, out hasUsingAssignments);
      
      return base.CanDeleteEntity(e) && !hasUsingAssignments;
    }

    public virtual void ShowUsingAssignments(Sungero.Domain.Client.ExecuteActionArgs e)
    {
      Centrvd.VotingModule.Functions.VotesMatrix.Remote.GetAssignmentsMatrixUsed(_obj).ShowModal();
    }

    public virtual bool CanShowUsingAssignments(Sungero.Domain.Client.CanExecuteActionArgs e)
    {
      bool hasUsingAssignments = false;
      e.Params.TryGetValue(Centrvd.VotingModule.Constants.VotesMatrix.UsedInAssignments, out hasUsingAssignments);
      
      return hasUsingAssignments;
    }

  }

}