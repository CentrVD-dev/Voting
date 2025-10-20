using System;
using System.Collections.Generic;
using System.Linq;
using Sungero.Core;
using Sungero.CoreEntities;
using Centrvd.VotingModule.VoteKind;

namespace Centrvd.VotingModule.Client
{
  partial class VoteKindActions
  {
    public override void DeleteEntity(Sungero.Domain.Client.ExecuteActionArgs e)
    {
      base.DeleteEntity(e);
    }

    public override bool CanDeleteEntity(Sungero.Domain.Client.CanExecuteActionArgs e)
    {
      bool hasUsedInMatrices = false;
      e.Params.TryGetValue(Centrvd.VotingModule.Constants.VoteKind.UsedInMatrices, out hasUsedInMatrices);
      
      return base.CanDeleteEntity(e) && !hasUsedInMatrices;
    }

    public virtual void ShowUsingMatrices(Sungero.Domain.Client.ExecuteActionArgs e)
    {
      Centrvd.VotingModule.Functions.VoteKind.Remote.GetMatricesVoteKindUsed(_obj).ShowModal();
    }

    public virtual bool CanShowUsingMatrices(Sungero.Domain.Client.CanExecuteActionArgs e)
    {
      bool hasUsedInMatrices = false;
      e.Params.TryGetValue(Centrvd.VotingModule.Constants.VoteKind.UsedInMatrices, out hasUsedInMatrices);
      
      return hasUsedInMatrices;
    }

  }

}