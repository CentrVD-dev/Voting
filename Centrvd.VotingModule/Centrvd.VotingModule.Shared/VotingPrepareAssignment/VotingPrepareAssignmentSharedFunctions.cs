using System;
using System.Collections.Generic;
using System.Linq;
using Sungero.Core;
using Sungero.CoreEntities;
using Centrvd.VotingModule.VotingPrepareAssignment;

namespace Centrvd.VotingModule.Shared
{
  partial class VotingPrepareAssignmentFunctions
  {

    /// <summary>
    /// Установить обязательность свойств.
    /// </summary>
    public void SetRequiredProperties()
    {
      _obj.State.Properties.VotingPoints.Properties.Text.IsRequired = true;
      _obj.State.Properties.VotingPoints.Properties.VotesMatrix.IsRequired = true;
      _obj.State.Properties.VotingPoints.Properties.VotersMatrix.IsRequired = true;
    }
  }
}