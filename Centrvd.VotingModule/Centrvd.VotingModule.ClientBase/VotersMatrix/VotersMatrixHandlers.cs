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
      var hasUsingAssignments = Centrvd.VotingModule.Functions.VotersMatrix.Remote.IsMatrixUsedInAssignments(_obj);
      e.Params.AddOrUpdate(Centrvd.VotingModule.Constants.VotersMatrix.UsedInAssignments, hasUsingAssignments);
      
      Centrvd.VotingModule.Functions.VotersMatrix.SetEnableProperties(_obj);
      
      if (hasUsingAssignments && _obj.AccessRights.CanUpdate())
        e.AddInformation("Матрица используется в заданиях. Некоторые поля заблокированы от изменения.", _obj.Info.Actions.ShowUsingAssignments);
    }

  }
}