using System;
using System.Collections.Generic;
using System.Linq;
using Sungero.Core;
using Sungero.CoreEntities;
using Centrvd.VotingModule.VotesMatrix;

namespace Centrvd.VotingModule.Shared
{
  partial class VotesMatrixFunctions
  {
    /// <summary>
    /// Установить доступность свойств.
    /// </summary>
    public virtual void SetEnableProperties()
    {
      object hasUsingAssignments;
      
      if (((Sungero.Domain.Shared.IExtendedEntity)_obj).Params.TryGetValue(Centrvd.VotingModule.Constants.VotesMatrix.UsedInAssignments, out hasUsingAssignments))
      {
        _obj.State.Properties.Variants.IsEnabled = !(bool)hasUsingAssignments;
      }
    }

  }
}