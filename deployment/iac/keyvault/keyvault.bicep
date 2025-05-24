param location string
param applicationName string
param environment string

module shortener '../modules/locationShortener.bicep' = {
    name: 'regionShortener'
    params: {
        location: location
        resourceName: 'kv'
        applicationName: applicationName
        environment: environment
    }    
}

var keyVaultName = shortener.outputs.resourceShortName

resource keyVault 'Microsoft.KeyVault/vaults@2023-02-01' = {
    name: keyVaultName
    location: location
    properties: {
        sku: {
            family: 'A',
            name: 'standard'
        }
        tenantId: subscription().tenantId
        accessPolicies: []
        enableSoftDelete: true
        enablePurgeProtection: false
        enableRbacAuthorization: true
        publicNetworkAccess: 'Enabled'
    }
}

output keyVaultId string = keyVault.id
output keyVaultName string = keyVault.name
output keyVaultUri string = keyVault.properties.vaultUri