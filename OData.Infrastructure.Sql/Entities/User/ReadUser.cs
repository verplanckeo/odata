﻿namespace OData.Infrastructure.Sql.Entities.User;

/// <summary>
/// Basic representation of a user record
/// </summary>
public class ReadUser
{
    public string AggregateRootId { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }
        
    public string UserName { get; set; }

    public int Version { get; set; }
}