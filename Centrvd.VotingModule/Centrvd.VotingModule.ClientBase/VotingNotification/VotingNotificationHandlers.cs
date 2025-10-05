using System;
using System.Collections.Generic;
using System.Linq;
using Sungero.Core;
using Sungero.CoreEntities;
using Centrvd.VotingModule.VotingNotification;

namespace Centrvd.VotingModule
{
  partial class VotingNotificationClientHandlers
  {

    public override void Showing(Sungero.Presentation.FormShowingEventArgs e)
    {
      var isPerformer = Equals(Users.Current, _obj.Performer);
      var isResultsInNotice = Functions.VotingNotification.Remote.isResultinNotice(_obj);
      _obj.State.Properties.VotingResults.IsVisible = isPerformer && isResultsInNotice;
    }

  }
}