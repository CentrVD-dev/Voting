using System;
using System.Collections.Generic;
using System.Linq;
using Sungero.Core;
using Sungero.CoreEntities;

namespace Centrvd.VotingModule
{
  partial class VotingResultsReportServerHandlers
  {

    public override void BeforeExecute(Sungero.Reporting.Server.BeforeExecuteEventArgs e)
    {
      VotingResultsReport.TaskId = VotingResultsReport.Entity.Id;
      
      VotingResultsReport.Description = Centrvd.VotingModule.Reports.Resources.VotingResultsReport.DescriptionSubjectFormat(VotingResultsReport.Entity.Subject) + Environment.NewLine;
      
      // Если документов нет, то коллекция вложений null
      if (VotingResultsReport.Entity.VotingGroup.OfficialDocuments != null && VotingResultsReport.Entity.VotingGroup.OfficialDocuments.Any())
        VotingResultsReport.Description += Centrvd.VotingModule.Reports.Resources.VotingResultsReport.DescriptionOnDocument + VotingResultsReport.Entity.VotingGroup.OfficialDocuments.FirstOrDefault().Name;
    }
  }
}