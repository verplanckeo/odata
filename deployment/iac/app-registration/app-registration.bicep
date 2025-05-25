param applicationName string
param environment string

var name = '${applicationName}-${environment}'

resource appReg 'Microsoft.Graph/applications@1.0' = {
  name: name
  properties: {
    displayName: name
  }
}

output clientId string = appReg.properties.appId
