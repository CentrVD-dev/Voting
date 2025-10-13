using System;
using System.Collections.Generic;
using System.Linq;
using Sungero.Core;
using Sungero.CoreEntities;
using Sungero.Workflow;
using Centrvd.VotingModule.VotingTask;

namespace Centrvd.VotingModule.Server.VotingTaskBlocks
{
  partial class VotingNotificationBlockHandlers
  {

    public virtual void VotingNotificationBlockStart()
    {
      // Сформировать результаты отчетом и приложить к уведомлению
      if (_block.FormResultsInReport.GetValueOrDefault())
      {
        var report = Centrvd.VotingModule.Reports.GetVotingResultsReport();
        report.Entity = _obj;
        
        var simpleDocument = Sungero.Docflow.SimpleDocuments.Create();
        simpleDocument.Name = Centrvd.VotingModule.Reports.Resources.VotingResultsReport.TitleTitle;
        simpleDocument.Save();
        report.ExportTo(simpleDocument);
        
        if (_obj.ReportGroup.OfficialDocuments.Any())
          _obj.ReportGroup.OfficialDocuments.Clear();
        
        _obj.ReportGroup.OfficialDocuments.Add(simpleDocument);
      }
    }

    public virtual void VotingNotificationBlockStartNotice(Centrvd.VotingModule.IVotingNotification notice)
    {
      // Сформировать результаты в тексте уведомления.
      if (_block.FormResultInNotice.GetValueOrDefault())
      {
        var groupedPoints = _obj.VotingResults.GroupBy(v => v.PointId);
        foreach (var points in groupedPoints)
        {
          notice.VotingResults += points.First().Text + Environment.NewLine;
          
          // Сначала выводим всех участников.
          foreach (var point in points)
          {
            var performerName = point.Substituted != null ? Centrvd.VotingModule.VotingTasks.Resources.ForFormat(point.Voter.Person.ShortName, point.Substituted.Person.ShortName) : point.Voter.Person.ShortName;
            var comment = !string.IsNullOrEmpty(point.Comment) ? Centrvd.VotingModule.VotingTasks.Resources.CommentFormat(point.Comment) : string.Empty;
            
            notice.VotingResults += Centrvd.VotingModule.VotingTasks.Resources.VoterResultLineFormat(performerName, point.Vote.Name, comment) + Environment.NewLine;
          }
          
          // Затем выводим итоги.
          var voteKinds = points.Select(v => v.Vote).Distinct().Cast<IVoteKind>().ToList();
          var votesCount = Centrvd.VotingModule.Reports.Resources.VotingResultsReport.TitleResults.ToString();
          foreach (var voteKind in voteKinds)
            votesCount += Centrvd.VotingModule.VotingTasks.Resources.PointResultFormat(voteKind.Name, points.Count(v => Equals(v.Vote, voteKind)));
          
          notice.VotingResults += votesCount + Environment.NewLine + Environment.NewLine;
        }
      }
    }
  }


  partial class VotingAssignmentBlockHandlers
  {

    public virtual void VotingAssignmentBlockCompleteAssignment(Centrvd.VotingModule.IVotingAssignment assignment)
    {
      var performer = Sungero.Company.Employees.As(assignment.CompletedBy);
      var substituted = Sungero.Company.Employees.As(assignment.Performer);
      
      if (performer == null || substituted == null)
        return;
      
      foreach (var point in assignment.VotingPoints)
      {
        var result = _obj.VotingResults.AddNew();
        result.PointId = point.PointId;
        result.Text = point.Text;
        result.Vote = point.Vote;
        result.Substituted = !Equals(performer, substituted) ? substituted : null;
        result.Voter = performer;
        result.Comment = point.Comment;
      }
    }

    public virtual void VotingAssignmentBlockStartAssignment(Centrvd.VotingModule.IVotingAssignment assignment)
    {
      var prepareAssignment = Centrvd.VotingModule.Functions.VotingTask.GetLastPrepareAssignment(_obj);
      var performer = Sungero.Company.Employees.As(assignment.Performer);
      
      if (prepareAssignment == null || performer == null)
        return;

      foreach (var point in prepareAssignment.VotingPoints)
      {
        var matrixEmployees = Centrvd.VotingModule.Functions.VotersMatrix.CalculateEmployeesFromMatrix(point.VotersMatrix, _obj);
        if (matrixEmployees.Contains(performer))
        {
          var newPoint = assignment.VotingPoints.AddNew();
          newPoint.PointId = point.Id;
          newPoint.Text = point.Text;
          newPoint.VoteMatrix = point.VotesMatrix;
        }
      }

    }
  }

  partial class VotingPrepareAssignmentBlockHandlers
  {

    public virtual void VotingPrepareAssignmentBlockCompleteAssignment(Centrvd.VotingModule.IVotingPrepareAssignment assignment)
    {
      var votingTask = Centrvd.VotingModule.VotingTasks.As(assignment.Task);
      var voters = new List<Sungero.Company.IEmployee>();
      
      // Заполнить всех уникальных голосующих в задачу.
      foreach (var point in assignment.VotingPoints)
        voters.AddRange(Centrvd.VotingModule.Functions.VotersMatrix.CalculateEmployeesFromMatrix(point.VotersMatrix, votingTask));
      
      foreach (var voter in voters.Distinct())
        _obj.Voters.AddNew().Voter = voter;
    }
    
  }
}