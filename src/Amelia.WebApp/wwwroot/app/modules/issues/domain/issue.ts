export class Issue {

    Id: number;
    Subject: string;
    Description: string;
    Status: number;
    CreatedOn: Date;
    ProjectId: number;
    SprintId: number;
    TaskTypeId: number;
    RequestTypeId: number;
    AssignedToId: number;
    AssignedToName: string;
    Points: number;

    constructor(id: number,
        subject: string,
        description: string,
        status: number,
        createdOn: Date,
        projectId: number,
        sprintId: number,
        taskTypeId: number,
        requestTypeId: number,
        assignedToId: number,
        assignedToName: string,
        points: number ) {

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

}