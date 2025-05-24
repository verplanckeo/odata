targetScope = 'subscription'

param location string
param applicationName string
param environment string

resource rg 'Microsoft.Resources/resourceGroups@2025-04-01' = {
  name: 'rg-${applicationName}-${location}-${environment}'
  location: location
}

output resourceGroupName string = rg.name
output location string = rg.location