param location string
param applicationName string
param environment string
param appServicePrincipalId string

resource keyVault 'Microsoft.KeyVault/vaults@2023-02-01' = {
    name: 'kv-${applicationName}-euw-${environment}'
    location: location
    properties: {
        sku: {
            family: 'A'
            name: 'standard'
        }
        tenantId: subscription().tenantId
        accessPolicies: [] // either use RBAC or access policies - recommended approach is to use RBAC for new designs
        enableSoftDelete: true
        enableRbacAuthorization: true
        publicNetworkAccess: 'Enabled'
    }
}

output keyVaultId string = keyVault.id
output keyVaultName string = keyVault.name
output keyVaultUri string = keyVault.properties.vaultUri