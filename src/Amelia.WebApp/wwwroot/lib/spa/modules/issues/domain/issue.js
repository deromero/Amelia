"use strict";
var Issue = (function () {
    function Issue(id, subject, description, status, createdOn, projectId, sprintId, taskTypeId, requestTypeId, assignedToId, assignedToName, points) {
        this.Id = id;
        this.Subject = subject;
        this.Description = description;
        this.Status = status;
        this.CreatedOn = createdOn;
        this.ProjectId = projectId;
        this.SprintId = sprintId;
        this.TaskTypeId = taskTypeId;
        this.RequestTypeId = requestTypeId;
        this.AssignedToId = assignedToId;
        this.AssignedToName = assignedToName;
        this.Points = points;
    }
    return Issue;
}());
exports.Issue = Issue;
