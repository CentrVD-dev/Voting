using System;
using System.Collections.Generic;
using System.Linq;
using Sungero.Core;
using Sungero.CoreEntities;
using Centrvd.VotingModule.VotesMatrix;

namespace Centrvd.VotingModule
{
  partial class VotesMatrixClientHandlers
  {
    public override void Showing(Sungero.Presentation.FormShowingEventArgs e)
    {
      var hasUsingAssignments =  Centrvd.VotingModule.Functions.VotesMatrix.Remote.IsMatrixUsedInAssignments(_obj);
      e.Params.AddOrUpdate(Centrvd.VotingModule.Constants.VotesMatrix.UsedInAssignments, hasUsingAssignments);

      Centrvd.VotingModule.Functions.VotesMatrix.SetEnableProperties(_obj);
      
      if (hasUsingAssignments && _obj.AccessRights.CanUpdate())
        e.AddInformation("Матрица используется в заданиях. Некоторые поля заблокированы от изменения.", _obj.Info.Actions.ShowUsingAssignments);
    }
  }

}