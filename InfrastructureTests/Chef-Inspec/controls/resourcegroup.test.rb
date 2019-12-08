control 'azurerm_resource_groups' do
  describe azurerm_resource_groups do
      its('names') { should include '-rg' }
  end
end
