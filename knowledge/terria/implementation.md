# Implementation Notes

## Java implementation

- `RegistryService` scans a configured storage root and expects the Terraform registry under `registry.terraform.io`.
- The service reads provider/plugin metadata from `registry.terraform.io/plugins/...`.
- Modules are discovered from `registry.terraform.io/modules/...`.
- A symlink `registry.terraform.io/providers` points to `plugins` so Terraform protocol paths remain compatible.
- A Spring `StaticResourceConfig` serves download paths from the storage folder.
- Tests in `java-impl` use temporary registry storage and verify that provider indexes are built from the new layout.

## .NET implementation

- `RegistryService` reads the configured `Registry:StoragePath` and looks under `registry.terraform.io`.
- Provider/plugin scanning targets `registry.terraform.io/plugins/...` and module scanning targets `registry.terraform.io/modules/...`.
- The service keeps `/v1/providers/...` and `/v1/modules/...` endpoints unchanged.
- Download URLs continue to reference `/storage/providers/...`.
- Tests in `dotnet-test` now construct provider data under `registry.terraform.io/providers/...` to match the implemented storage layout.

## Notes

- The current implementation is Terraform-specific, but the layout is designed to allow additional registry roots in the future.
- The symlink strategy preserves protocol compatibility without changing the external API surface.
- Implementation details are intentionally separated from the general design so the same abstract architecture can be reused for future registry types.
</content>
<parameter name="filePath">c:\work\workspace\dsp\cloud\iac\terra_incognita\proposed_structure_update.md