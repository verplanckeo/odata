namespace OData.Application.User.LoadAllUsers;

public class LoadAllUsersMediatorCommandResponse
{
    public IEnumerable<ReadUserModel> Users { get; set; }

    public static LoadAllUsersMediatorCommandResponse CreateResponse(IEnumerable<ReadUserModel> users)
    {
        return new LoadAllUsersMediatorCommandResponse { Users = users };
    }
}