export class ProjectForm {

    Id: number;
    Name: string;
    Description: string;
    IsPrivate: boolean;
    ProjectType: number;
    OwnerId: number;

    constructor(
        id: number,
        name: string,
        description: string,
        isPrivate: boolean,
        projectType: number,
        ownerId: number
    ) {
        this.Id = id;
        this.Name = name;
        this.Description = description;
        this.IsPrivate = isPrivate;
        this.ProjectType = projectType;
        this.OwnerId = ownerId
    }

}