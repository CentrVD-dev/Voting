using System;
using System.Collections.Generic;
using System.Linq;
using Sungero.Core;
using Sungero.CoreEntities;
using Sungero.Workflow;
using Centrvd.VotingModule.VotingTask;

namespace Centrvd.VotingModule.Server.VotingTaskBlocks
{
  partial class VotingAssignmentBlockHandlers
  {

    public virtual void VotingAssignmentBlockStartAssignment(Centrvd.VotingModule.IVotingAssignment assignment)
    {
      var prepareAssignment = Centrvd.VotingModule.Functions.VotingTask.GetLastPrepareAssignment(_obj);
      var performer = Sungero.Company.Employees.As(assignment.Performer);
      
      if (prepareAssignment == null || performer == null)
        return;

      foreach (var point in prepareAssignment.VotingPoints)
      {
        var matrixEmployees = Centrvd.VotingModule.Functions.VotersMatix.CalculateEmployeesFromMatrix(point.VotersMatrix, _obj);
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
        voters.AddRange(Centrvd.VotingModule.Functions.VotersMatix.CalculateEmployeesFromMatrix(point.VotersMatrix, votingTask));
      
      foreach (var voter in voters.Distinct())
        _obj.Voters.AddNew().Voter = voter;
    }
    
  }
}