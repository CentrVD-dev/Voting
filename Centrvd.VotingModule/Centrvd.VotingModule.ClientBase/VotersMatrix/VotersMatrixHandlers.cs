using System;
using System.Collections.Generic;
using System.Linq;
using Sungero.Core;
using Sungero.CoreEntities;
using Centrvd.VotingModule.VotersMatrix;

namespace Centrvd.VotingModule
{
  partial class VotersMatrixClientHandlers
  {

    public override void Showing(Sungero.Presentation.FormShowingEventArgs e)
    {
      e.Params.AddOrUpdate(Centrvd.VotingModule.Constants.VotersMatrix.UsedInAssignments, Centrvd.VotingModule.Functions.VotersMatrix.Remote.IsMatrixUsedInAssignments(_obj));
      
      bool hasUsingAssignments = false;
      e.Params.TryGetValue(Centrvd.VotingModule.Constants.VotesMatrix.UsedInAssignments, out hasUsingAssignments);

      _obj.State.Properties.Employees.IsEnabled = !hasUsingAssignments;
      _obj.State.Properties.Roles.IsEnabled = !hasUsingAssignments;
      
      if (hasUsingAssignments)
        e.AddInformation("Матрица используется в заданиях. Некоторые поля заблокированы от изменения.", _obj.Info.Actions.ShowUsingAssignments);
    }

  }
}