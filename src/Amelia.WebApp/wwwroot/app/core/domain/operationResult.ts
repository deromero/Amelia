export class OperationResult {
    Succeeded: boolean;
    Message: string;
    Value

    constructor(succeeded: boolean, message: string) {
        this.Succeeded = succeeded;
        this.Message = message;
    }
    
}