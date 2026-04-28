
# -------------------------------------------------
# Hashicorp Terraform
# -------------------------------------------------

mkdir -p hashicorp/



# -------------------------------------------------
# Microsoft Azure
# -------------------------------------------------

mkdir -p azure/



mkdir -p azure/avm-utl-regions/
curl -o  azure/avm-utl-regions/terraform-azurerm-avm-utl-regions_0.1.0.zip https://github.com/Azure/terraform-azurerm-avm-utl-regions/archive/refs/tags/v0.1.0.zip

mkdir -p azure/avm-utl-interfaces/
curl -o  azure/avm-utl-interfaces/terraform-azurerm-avm-utl-interfaces_0.5.1.zip https://github.com/Azure/terraform-azure-avm-utl-interfaces/archive/refs/tags/v0.5.1.zip

mkdir -p azure/avm-res-network-virtualnetwork/
curl -o  azure/avm-res-network-virtualnetwork/azure/terraform-azurerm-avm-res-network-virtualnetwork_0.9.2.zip https://github.com/Azure/terraform-azurerm-avm-res-network-virtualnetwork/archive/refs/tags/0.9.2.zip

mkdir -p azure/avm-res-network-privatednszone/
curl -o  azure/avm-res-network-privatednszone/azure/terraform-azurerm-avm-res-network-privatednszone_0.5.0.zip https://github.com/Azure/terraform-azurerm-avm-res-network-privatednszone/archive/refs/tags/v0.5.0.zip

mkdir -p azure/avm-res-apimanagement-service/
curl -o  azure/avm-res-apimanagement-service/terraform-azurerm-avm-res-apimanagement-service_0.0.6.zip https://github.com/Azure/terraform-azurerm-avm-res-apimanagement-service/archive/refs/tags/v0.0.6.zip


