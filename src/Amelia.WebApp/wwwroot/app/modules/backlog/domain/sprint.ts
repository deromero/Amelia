export class Sprint {
    Id: number;
    Name: string;
    ProjectId: number;
    Description: string;
    StartDate: Date;
    DueDate: Date;
    CreatedOn: Date;
    UpdatedOn: Date;

    constructor(id: number,
        name: string,
        projectId: number,
        description: string,
        startDate: Date,
        dueDate: Date,
        createdOn: Date,
        updatedOn: Date) {

        this.Id = id;
        this.Name = name;
        this.Description = description;
        this.ProjectId = projectId;
        this.StartDate = startDate;
        this.DueDate = dueDate;
        this.CreatedOn = createdOn;
        this.UpdatedOn = updatedOn;
    }
}