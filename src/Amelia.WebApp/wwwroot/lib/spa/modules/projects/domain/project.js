"use strict";
var Project = (function () {
    function Project(id, name, description, slug, imageLogoUrl, isPrivate, projectType, createdOn, updatedOn, ownerName, ownerId) {
        this.Id = id;
        this.Name = name;
        this.Slug = slug;
        this.ImageLogoUrl = imageLogoUrl;
        this.IsPrivate = isPrivate;
        this.ProjectType = projectType;
        this.CreatedOn = createdOn;
        this.UpdatedOn = updatedOn;
        this.OwnerName = ownerName;
        this.OwnerId = ownerId;
    }
    return Project;
}());
exports.Project = Project;
