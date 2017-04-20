export class Project {

    Id: number;
    Name: string;
    Description: string;
    Slug: string;
    ImageLogoUrl: string;
    IsPrivate: boolean;
    ProjectType: number;
    CreatedOn: Date;
    UpdatedOn: Date;
    OwnerName: string;
    OwnerId: number;
 
 
    constructor(id: number,
        name: string,
        description: string,
        slug: string,
        imageLogoUrl: string,
        isPrivate: boolean,
        projectType: number,
        createdOn: Date,
        updatedOn: Date,
        ownerName: string,
        ownerId: number) {

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


}