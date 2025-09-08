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
      e.Params.AddOrUpdate(Centrvd.VotingModule.Constants.VotesMatrix.UsedInAssignments, Centrvd.VotingModule.Functions.VotesMatrix.Remote.IsMatrixUsedInAssignments(_obj));
      
      bool hasUsingAssignments = false;
      e.Params.TryGetValue(Centrvd.VotingModule.Constants.VotesMatrix.UsedInAssignments, out hasUsingAssignments);

      _obj.State.Properties.Variants.IsEnabled = !hasUsingAssignments;
      _obj.State.Properties.DocumentKinds.IsEnabled = !hasUsingAssignments;
      
      if (hasUsingAssignments)
        e.AddInformation("Матрица используется в заданиях. Некоторые поля заблокированы от изменения.", _obj.Info.Actions.ShowUsingAssignments);
    }
  }

}