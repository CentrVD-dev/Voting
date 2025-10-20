using System;
using System.Collections.Generic;
using System.Linq;
using Sungero.Core;
using Sungero.CoreEntities;
using Centrvd.VotingModule.VotersMatrix;

namespace Centrvd.VotingModule.Client
{
  partial class VotersMatrixActions
  {
    public override void DeleteEntity(Sungero.Domain.Client.ExecuteActionArgs e)
    {
      base.DeleteEntity(e);
    }

    public override bool CanDeleteEntity(Sungero.Domain.Client.CanExecuteActionArgs e)
    {
      bool hasUsingAssignments = false;
      e.Params.TryGetValue(Centrvd.VotingModule.Constants.VotersMatrix.UsedInAssignments, out hasUsingAssignments);
      
      return base.CanDeleteEntity(e) && !hasUsingAssignments;
    }

    public virtual void ShowUsingAssignments(Sungero.Domain.Client.ExecuteActionArgs e)
    {
      Centrvd.VotingModule.Functions.VotersMatrix.Remote.GetAssignmentsMatrixUsed(_obj).ShowModal();
    }

    public virtual bool CanShowUsingAssignments(Sungero.Domain.Client.CanExecuteActionArgs e)
    {
      bool hasUsingAssignments = false;
      e.Params.TryGetValue(Centrvd.VotingModule.Constants.VotersMatrix.UsedInAssignments, out hasUsingAssignments);
      
      return hasUsingAssignments;
    }

  }

}