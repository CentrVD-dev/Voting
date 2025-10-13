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
      var hasUsingMatrices = Centrvd.VotingModule.Functions.VoteKind.Remote.IsVoteKindUsedInMatrices(_obj);
      e.Params.AddOrUpdate(Centrvd.VotingModule.Constants.VoteKind.UsedInMatrices, hasUsingMatrices);

      Centrvd.VotingModule.Functions.VoteKind.SetEnableProperties(_obj);
      
      if (hasUsingMatrices && _obj.AccessRights.CanUpdate())
        e.AddInformation("Вид голоса используется в матрицах голосов. Некоторые поля заблокированы от изменения.", _obj.Info.Actions.ShowUsingMatrices);
    }

  }
}