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

    public virtual void VotingNotificationBlockStartNotice(Centrvd.VotingModule.IVotingNotification notice)
    {
      var groupedPoints = _obj.VotingResults.GroupBy(v => v.PointId);
      foreach (var points in groupedPoints)
      {
        notice.VotingResults += points.First().Text + Environment.NewLine;
        
        var voteKinds = points.Select(v => v.Vote).Distinct().Cast<IVoteKind>().ToList();
        var votesCount = "Итого по пункту: ";
        foreach (var voteKind in voteKinds)
          votesCount += voteKind.Name + " - " + points.Count(v => Equals(v.Vote, voteKind)) + ". ";
        
        notice.VotingResults += votesCount + Environment.NewLine;
        
        foreach (var point in points)
        {
          var performerName = point.Substituted != null ? point.Voter.Person.ShortName + " за " + point.Substituted.Person.ShortName : point.Voter.Person.ShortName;
          var comment = !string.IsNullOrEmpty(point.Comment) ? ". Комментарий: " + point.Comment : string.Empty;
          
          notice.VotingResults += "- " + performerName + " - " + point.Vote.Name  + comment + Environment.NewLine;
        }
        
        notice.VotingResults += Environment.NewLine;
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