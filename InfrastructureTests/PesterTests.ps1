[CmdletBinding()]
param (
    $ResourceGroupName
)

# Install and import AzureRM modules
#Install-Module AzureRM
#Import-Module AzureRM

Describe "Resource Group tests" -tag "AzureInfrastructure" {
    Context "Resource Groups" { 
        It "Check Main Resource Group $ResourceGroupName Exists" { 
            Get-AzureRmResourceGroup -Name $ResourceGroupName -ErrorAction SilentlyContinue | Should Not be $null 
        } 
    } 
}

Describe "Azure SQL Tests" {
    $sqlServers = Get-AzureRmSqlServer -ResourceGroupName $ResourceGroupName 
    foreach ($sqlserver in $sqlServers) {
        $sqlDatabases = Get-AzureRmSqlDatabase -ServerName $sqlServer.ServerName -ResourceGroupName $ResourceGroupName

        foreach ($sqlDatabase in $sqlDatabases) {
            if ($sqlDatabase.databaseName -ne "Master") {
                $tdeStatus = Get-AzureRmSqlDatabaseTransparentDataEncryption -ServerName $sqlserver.ServerName -DatabaseName $sqlDatabase.databaseName -ResourceGroupName $ResourceGroupName
                $threatDetectionStatus = Get-AzureRmSqlDatabaseThreatDetectionPolicy -ServerName $sqlserver.ServerName -DatabaseName $sqlDatabase.databaseName -ResourceGroupName $ResourceGroupName
                It "$($sqlDatabase.DatabaseName) on server $($sqlServer.serverName)  Should have TDE Enabled" {
                    $tdeStatus.State| should be "Enabled"
                }

                It "$($sqlDatabase.DatabaseName) on server $($sqlServer.serverName)  Should have Threat Detection Enabled" {
                    $threatDetectionStatus.ThreatDetectionState| should be "Enabled"
                }
            }
        }
    }
}

Describe "Storage Account Tests" {
    $storageAccounts = Get-AzureRmStorageAccount -ResourceGroupName $ResourceGroupName

    foreach ($storageAccount in $storageAccounts) {
        It "$($storageAccount.StorageAccountName )  Should have encrypted blob storage" {
            $storageAccount.Encryption.Services.Blob.enabled | should be $true
        }
    }
}
