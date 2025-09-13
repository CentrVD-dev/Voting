using System;
using System.Collections.Generic;
using System.Linq;
using Sungero.Core;
using Sungero.CoreEntities;
using Centrvd.VotingModule.VoteKind;

namespace Centrvd.VotingModule.Shared
{
  partial class VoteKindFunctions
  {
    /// <summary>
    /// Установить доступность свойств.
    /// </summary>
    public virtual void SetEnableProperties()
    {
      object hasUsingMatrices;
      
      if (((Sungero.Domain.Shared.IExtendedEntity)_obj).Params.TryGetValue(Centrvd.VotingModule.Constants.VoteKind.UsedInMatrices, out hasUsingMatrices))
      {
        _obj.State.Properties.Name.IsEnabled = !(bool)hasUsingMatrices;
      }
    }
  }
}