resource "azurerm_resource_group" "rg" {
  name     = "${var.resource-group-name}"
  location = "${var.location}"
}

resource "azurerm_app_service_plan" "plan" {
  name                = "example-appserviceplan"
  location            = "${azurerm_resource_group.rg.location}"
  resource_group_name = "${azurerm_resource_group.rg.name}"

  sku {
    tier = "Standard"
    size = "S1"
  }
}

resource "azurerm_app_service" "app-service" {
  name                = "${var.app-service-name}"
  location            = "${azurerm_resource_group.rg.location}"
  resource_group_name = "${azurerm_resource_group.rg.name}"
  app_service_plan_id = "${azurerm_app_service_plan.plan.id}"

  site_config {
    dotnet_framework_version = "v4.0"
    scm_type                 = "LocalGit"
  }

  app_settings = {
    "SOME_KEY" = "some-value"
  }

  connection_string {
    name  = "Database"
    type  = "SQLServer"
    value = "Server=tcp:${azurerm_sql_server.sqldb.fully_qualified_domain_name} Database=${azurerm_sql_database.db.name};User ID=${azurerm_sql_server.sqldb.administrator_login};Password=${azurerm_sql_server.sqldb.administrator_login_password};Trusted_Connection=False;Encrypt=True;"
  }
}

resource "azurerm_sql_server" "sqldb" {
  name                         = "terraform-sqlserver"
  resource_group_name          = "${azurerm_resource_group.rg.name}"
  location                     = "${azurerm_resource_group.rg.location}"
  version                      = "12.0"
  administrator_login          = "houssem"
  administrator_login_password = "4-v3ry-53cr37-p455w0rd"
}

resource "azurerm_sql_database" "db" {
  name                = "terraform-sqldatabase"
  resource_group_name = "${azurerm_resource_group.rg.name}"
  location            = "${azurerm_resource_group.rg.location}"
  server_name         = "${azurerm_sql_server.sqldb.name}"

  tags = {
    environment = "production"
  }
}