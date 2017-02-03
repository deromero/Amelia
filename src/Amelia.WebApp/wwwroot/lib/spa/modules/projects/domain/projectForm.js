"use strict";
var ProjectForm = (function () {
    function ProjectForm(id, name, description, isPrivate, projectType, ownerId) {
        this.Id = id;
        this.Name = name;
        this.Description = description;
        this.IsPrivate = isPrivate;
        this.ProjectType = projectType;
        this.OwnerId = ownerId;
    }
    return ProjectForm;
}());
exports.ProjectForm = ProjectForm;
