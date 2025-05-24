param location string
param applicationName string
param environment string

module shortener '../modules/locationShortener.bicep' = {
    name: 'regionShortener'
    params: {
        location: location
        resourceName: 'rg'
        applicationName: applicationName
        environment: environment
    }    
}

var resourceGroupName = shortener.outputs.resourceShortName

resource rg 'Microsoft.Resources/resourceGroups@2024-03-01' = {
  name: resourceGroupName
  location: location
}

output resourceGroupName string = rg.name
output location string = rg.location