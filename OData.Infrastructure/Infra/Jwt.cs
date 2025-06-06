﻿namespace OData.Infrastructure.Infra;

/// <summary>
/// Jwt configuration used to generate a Jwt token
/// </summary>
public class Jwt
{
    /// <summary>
    /// Key used to sign the Jwt token
    /// </summary>
    public string Key { get; set; }

    /// <summary>
    /// Issuer: Under 'whose' name the token is signed
    /// </summary>
    public string Issuer { get; set; }

    /// <summary>
    /// Once issued, token is valid for x minutes
    /// </summary>
    public int ValidFor { get; set; }
}