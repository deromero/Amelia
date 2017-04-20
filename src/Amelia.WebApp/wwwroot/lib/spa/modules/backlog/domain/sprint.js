"use strict";
var Sprint = (function () {
    function Sprint(id, name, projectId, description, startDate, dueDate, createdOn, updatedOn) {
        this.Id = id;
        this.Name = name;
        this.Description = description;
        this.ProjectId = projectId;
        this.StartDate = startDate;
        this.DueDate = dueDate;
        this.CreatedOn = createdOn;
        this.UpdatedOn = updatedOn;
    }
    return Sprint;
}());
exports.Sprint = Sprint;
