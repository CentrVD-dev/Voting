using System;
using System.Collections.Generic;
using System.Linq;
using Sungero.Core;
using Sungero.CoreEntities;
using Centrvd.VotingModule.VotersMatrix;

namespace Centrvd.VotingModule.Client
{
  partial class VotersMatrixFunctions
  {
    /// <summary>
    /// Показать предупреждение о редактировании карточки матрицы голосующих.
    /// </summary>
    /// <param name="e">Аргументы события "Показ формы".</param>
    public void ShowEditWarning(Sungero.Presentation.FormShowingEventArgs e)
    {
      var usedInAssignmentsParam = Centrvd.VotingModule.Constants.VotersMatrix.UsedInAssignments;
      bool hasUsingAssignments = false;
      
      if (!e.Params.Contains(usedInAssignmentsParam))
        e.Params.Add(usedInAssignmentsParam, Centrvd.VotingModule.Functions.VotersMatrix.Remote.IsMatrixUsedInAssignments(_obj));
      
      if (e.Params.TryGetValue(usedInAssignmentsParam, out hasUsingAssignments) && hasUsingAssignments && !(_obj.State.IsInserted || _obj.State.IsCopied) && _obj.AccessRights.CanUpdate())
        e.AddInformation(Centrvd.VotingModule.VotersMatrices.Resources.MatrixUsedInAssignments, _obj.Info.Actions.ShowUsingAssignments);
    }
  }
}