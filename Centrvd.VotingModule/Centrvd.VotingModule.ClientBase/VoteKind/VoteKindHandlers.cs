using System;
using System.Collections.Generic;
using System.Linq;
using Sungero.Core;
using Sungero.CoreEntities;
using Centrvd.VotingModule.VoteKind;

namespace Centrvd.VotingModule
{
  partial class VoteKindClientHandlers
  {

    public override void Showing(Sungero.Presentation.FormShowingEventArgs e)
    {
      e.Params.AddOrUpdate(Centrvd.VotingModule.Constants.VoteKind.UsedInMatrices, Centrvd.VotingModule.Functions.VoteKind.Remote.IsVoteKindUsedInMatrices(_obj));
      
      bool hasUsingMatrices = false;
      e.Params.TryGetValue(Centrvd.VotingModule.Constants.VoteKind.UsedInMatrices, out hasUsingMatrices);

      _obj.State.Properties.Name.IsEnabled = !hasUsingMatrices;
      
      if (hasUsingMatrices)
        e.AddInformation("Вид голоса используется в матрицах голосов. Некоторые поля заблокированы от изменения.", _obj.Info.Actions.ShowUsingMatrices);
    }

  }
}