@description('Shortname of resource (e.g.: ResourceGroup -> rg, Keyvault -> kv)')
param resourceName string

@description('Name of the application (e.g.: odata)')
param applicationName string

@description('Environment name (e.g.: dev, prod)')
param environment string
    
output short string = locationShort
output resourceShortName string = '${resourceName}-${applicationName}-euw-${environment}'