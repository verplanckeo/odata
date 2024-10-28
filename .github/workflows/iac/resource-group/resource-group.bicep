targetScope = 'subscription'

param namePrefix string
param environment string

resource rg 'Microsoft.Resources/resourceGroups@2024-07-01' = {
  name: 'rg-${namePrefix}-euw-${environment}'
  location: 'westeurope'
}
