using System;
using System.Collections.Generic;
using System.Linq;
using Sungero.Core;
using Sungero.CoreEntities;
using Centrvd.VotingModule.VotingNotification;

namespace Centrvd.VotingModule.Shared
{
  partial class VotingNotificationFunctions
  {
    /// <summary>
    /// Установить видимость свойств.
    /// </summary>
    public void SetVisibleProperties()
    {
      var isResultsInNotice = Centrvd.VotingModule.PublicFunctions.VotingNotification.IsResultinNotice(_obj);
      
      _obj.State.Properties.VotingResults.IsVisible = isResultsInNotice;
    }
  }
}