using System;
using System.Collections.Generic;
using System.Linq;
using Sungero.Core;
using Sungero.CoreEntities;
using Centrvd.VotingModule.VoteKind;

namespace Centrvd.VotingModule.Client
{
  partial class VoteKindFunctions
  {
    /// <summary>
    /// Показать предупреждение о редактировании карточки вида голоса.
    /// </summary>
    /// <param name="e">Аргументы события "Показ формы".</param>
    public void ShowEditWarning(Sungero.Presentation.FormShowingEventArgs e)
    {
      var usedInMatricesParam = Centrvd.VotingModule.Constants.VoteKind.UsedInMatrices;
      bool usedInMatrices = false;
      
      if (!e.Params.Contains(usedInMatricesParam))
        e.Params.Add(usedInMatricesParam, Centrvd.VotingModule.Functions.VoteKind.Remote.IsVoteKindUsedInMatrices(_obj));
      
      if (e.Params.TryGetValue(usedInMatricesParam, out usedInMatrices) && usedInMatrices && !(_obj.State.IsInserted || _obj.State.IsCopied) && _obj.AccessRights.CanUpdate())
        e.AddInformation(Centrvd.VotingModule.VoteKinds.Resources.VoteKindUsedInMatrices, _obj.Info.Actions.ShowUsingMatrices);
    }
  }
}